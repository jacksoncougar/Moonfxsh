using System.Text;
using System.IO;
using System;
using System.Collections.Generic;
using Moonfish.Model;
using System.Linq;
using Moonfish.Tags;
using System.Reflection;
using Fasterflect;
using Moonfish.Graphics;
using System.Security.Cryptography;

namespace Moonfish
{

    public enum MapType
    {
        Multiplayer = 1,
        MainMenu = 2,
        Shared = 3,
        SinglePlayerShared = 4,
    }

    public static class StreamExtensions
    {
        public static IDisposable Pin(this Stream stream)
        {
            return new StreamPositionHandle(stream);
        }

        public class StreamPositionHandle : IDisposable
        {
            long streamPosition;
            Stream stream;
            public StreamPositionHandle(Stream stream)
            {
                this.stream = stream;
                this.streamPosition = stream.Position;
            }
            void IDisposable.Dispose()
            {
                stream.Position = streamPosition;
            }
        }
    }
    /// <summary>
    /// A minimalist class to load essential data which can be used to parse a retail cache map.
    /// </summary>
    public class MapStream : FileStream, IMap, IEnumerable<Tag>
    {
        public readonly Version BuildVersion;
        /// <summary>
        /// name of this cache (is not used in anything, just compiled into the header)
        /// </summary>
        public readonly string MapName;
        /// <summary>
        /// path of the scenario (local directory path storing the resources of this map when decompiled)
        /// </summary>
        public readonly string Scenario;
        /// <summary>
        /// magic values are used to convert from pre-calculated memory pointers to file-addresses
        /// </summary>
        public readonly int PrimaryMagic;
        /// <summary>
        /// magic values are used to convert from pre-calculated memory pointers to file-addresses
        /// </summary>
        public readonly int SecondaryMagic;

        public readonly MapType Type;

        public readonly UnicodeValueNamePair[] Unicode;
        public readonly string[] Strings;
        public readonly Tag[] Tags;

        public readonly int IndexVirtualAddress;
        public readonly int TagCacheLength;

        public readonly VirtualMappedAddress[] MemoryBlocks;

        private Dictionary<TagIdent, dynamic> deserializedTags;
        private Dictionary<TagIdent, string> hashTags;

        public MapStream(string filename)
            : base(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 1024)
        {
            this.MemoryBlocks = new VirtualMappedAddress[2];
            //HEADER
            BinaryReader bin = new BinaryReader(this, Encoding.UTF8);

            this.Position = 0;
            if (bin.ReadTagClass() != (TagClass)"head")
                throw new InvalidDataException("Not a halo-map file");

            this.Position = 42;
            BuildVersion = (Version)bin.ReadInt32();

            this.Position = 16;
            int indexAddress = bin.ReadInt32();
            int indexLength = bin.ReadInt32();
            this.TagCacheLength = bin.ReadInt32();


            if (BuildVersion == Version.PC_RETAIL)
                this.Position += 12;

            // Read maptype
            using (this.Pin())
            {
                this.Position = 2048;
                this.Seek(320, SeekOrigin.Begin);
                this.Type = (MapType)bin.ReadInt32();
            }

            this.Seek(332, SeekOrigin.Current);

            int stringTableLength = bin.ReadInt32();
            this.Seek(4, SeekOrigin.Current);
            int stringTableAddress = bin.ReadInt32();

            this.Seek(36, SeekOrigin.Current);

            MapName = bin.ReadFixedString(32);

            this.Seek(4, SeekOrigin.Current);

            Scenario = bin.ReadFixedString(256);

            this.Seek(4, SeekOrigin.Current);
            int pathsCount = bin.ReadInt32();
            int pathsTableAddress = bin.ReadInt32();
            int pathsTableLength = bin.ReadInt32();


            this.Seek(pathsTableAddress, SeekOrigin.Begin);
            var Paths = Encoding.UTF8.GetString(bin.ReadBytes(pathsTableLength - 1)).Split(char.MinValue);

            Halo2.Paths.Assign(Paths);

            //STRINGS

            this.Seek(stringTableAddress, SeekOrigin.Begin);
            Strings = Encoding.UTF8.GetString(bin.ReadBytes(stringTableLength - 1)).Split(char.MinValue);

            Halo2.Strings.Assign(new List<string>(Strings));


            //  INDEX
            /*
             *  Vista doesn't use memory addresses for the following address-values. (they are instead 0-based from the index-address)
             *  
             *  0x00    Address to Classes array
             *  0x04    Classes array length
             *  0x08    Address to Tags array
             *  0x0C    Scenario        tag_id
             *  0x10    Match-Globals   tag_id
             *  0x14    ~
             *  0x18    Tags array length
             *  0xC0    'sgat'          four_cc
             * 
             *  */
            this.Seek(indexAddress, SeekOrigin.Begin);
            int tagClassTableVirtualAddress = bin.ReadInt32();
            this.IndexVirtualAddress = tagClassTableVirtualAddress - 32;

            this.Seek(4, SeekOrigin.Current);

            int tagDatumTableVirtualAddress = bin.ReadInt32();
            var ScenarioID = bin.ReadTagIdent();
            var GlobalsID = bin.ReadTagIdent();
            int tagDatumTableOffset = tagDatumTableVirtualAddress - tagClassTableVirtualAddress;

            this.Seek(4, SeekOrigin.Current);

            int tagDatumCount = bin.ReadInt32();

            this.Seek(4 + tagDatumTableOffset, SeekOrigin.Current);
            Tags = new Tag[tagDatumCount];
            for (int i = 0; i < tagDatumCount; i++)
            {
                Tags[i] = new Tag()
                {
                    Type = bin.ReadTagClass(),
                    Identifier = bin.ReadInt32(),
                    VirtualAddress = bin.ReadInt32(),
                    Length = bin.ReadInt32()
                };

                //Borky vista fix - broken paths are broken
                //if (Tags[i].VirtualAddress == 0) continue;
                // var tag = Tags[i];
                Tags[i].Path = Paths[Tags[i].Identifier.Index];
            }

            // Calculate File-pointer magic
            SecondaryMagic = Tags[0].VirtualAddress - (indexAddress + indexLength);

            this.MemoryBlocks[1] = new VirtualMappedAddress()
            {
                Address = Tags[0].VirtualAddress,
                Length = TagCacheLength,
                Magic = SecondaryMagic,
            };

            /* Intent: read the sbsp and lightmap address and lengths from the scenario tag 
             * and store them in the Tags array.
             */
            if (BuildVersion == Version.XBOX_RETAIL)
            {
                this.Seek(Tags[ScenarioID.Index].VirtualAddress - SecondaryMagic + 528, SeekOrigin.Begin);
                var count = bin.ReadInt32();
                var address = bin.ReadInt32();
                for (int i = 0; i < count; ++i)
                {
                    this.Seek(address - SecondaryMagic + i * 68, SeekOrigin.Begin);
                    var structureBlockOffset = bin.ReadInt32();
                    var structureBlockLength = bin.ReadInt32();
                    var structureBlockAddress = bin.ReadInt32();
                    if (i == 0)
                    {
                        this.PrimaryMagic = structureBlockAddress - structureBlockOffset;
                        this.MemoryBlocks[0].Address = structureBlockAddress;
                        this.MemoryBlocks[0].Magic = this.PrimaryMagic;
                        this.MemoryBlocks[0].Length = structureBlockLength;
                    }
                    Seek(8, SeekOrigin.Current);
                    var sbspIdentifier = bin.ReadTagIdent();
                    Seek(4, SeekOrigin.Current);
                    var ltmpIdentifier = bin.ReadTagIdent();

                    Seek(structureBlockOffset, SeekOrigin.Begin);

                    // is this the total block length or minus the 16?
                    var blockLength = bin.ReadInt32();
                    var sbspVirtualAddress = bin.ReadInt32();
                    var ltmpVirtualAddress = bin.ReadInt32();
                    var sbsp = bin.ReadTagClass();

                    var hasLightmapData = !TagIdent.IsNull(ltmpIdentifier);


                    var sbspLength = hasLightmapData ? ltmpVirtualAddress - sbspVirtualAddress : blockLength;
                    var ltmpLength = blockLength - sbspLength;


                    Tags[sbspIdentifier.Index].VirtualAddress = sbspVirtualAddress;
                    Tags[sbspIdentifier.Index].Length = sbspLength;

                    if (hasLightmapData)
                    {
                        Tags[ltmpIdentifier.Index].VirtualAddress = ltmpVirtualAddress;
                        Tags[ltmpIdentifier.Index].Length = ltmpLength;
                    }
                }

                ////UNICODE
                //this.Seek(Tags[GlobalsID.Index].VirtualAddress - SecondaryMagic + 400, SeekOrigin.Begin);
                //int unicodeCount = bin.ReadInt32();
                //int unicodeTableLength = bin.ReadInt32();
                //int unicodeIndexAddress = bin.ReadInt32();
                //int unicodeTableAddress = bin.ReadInt32();

                //Unicode = new UnicodeValueNamePair[unicodeCount];

                //StringID[] strRefs = new StringID[unicodeCount];
                //int[] strOffsets = new int[unicodeCount];

                //this.Seek(unicodeIndexAddress, SeekOrigin.Begin);
                //for (int i = 0; i < unicodeCount; i++)
                //{
                //    strRefs[i] = (StringID)bin.ReadInt32();
                //    strOffsets[i] = bin.ReadInt32();
                //}
                //for (int i = 0; i < unicodeCount; i++)
                //{
                //    this.Seek(unicodeTableAddress + strOffsets[i], SeekOrigin.Begin);
                //    StringBuilder unicodeString = new StringBuilder(byte.MaxValue);
                //    while (bin.PeekChar() != char.MinValue)
                //        unicodeString.Append(bin.ReadChar());
                //    Unicode[i] = new UnicodeValueNamePair { Name = strRefs[i], Value = unicodeString.ToString() };
                //}
            }

            this.deserializedTags = new Dictionary<TagIdent, dynamic>(this.Tags.Length);
            this.hashTags = new Dictionary<TagIdent, string>(this.Tags.Length);
            Halo2.ActiveMap(this);
        }



        Tag current_tag = new Tag();
        public IMap this[string tag_class, string tag_name]
        {
            get
            {
                if (current_tag.Type == (TagClass)tag_class && current_tag.Path.Contains(tag_name))
                    return this;
                else current_tag = (from tag in Tags
                                    where tag.Type == (TagClass)tag_class
                                    where tag.Path.Contains(tag_name)
                                    select tag).First();
                return this;
            }
        }

        public IMap this[TagIdent tag_id]
        {
            get
            {
                if (current_tag.Identifier == tag_id) return this;
                else current_tag = Tags[tag_id.Index];
                return this;
            }

        }

        void IMap.Seek()
        {
            this.Seek(this.current_tag.VirtualAddress, SeekOrigin.Begin);
        }

        public void Remove(TagIdent ident)
        {
            deserializedTags.Remove(ident);
        }

        dynamic IMap.Deserialize()
        {
            var tagQuery = (from tag in deserializedTags
                            where tag.Key == current_tag.Identifier
                            select tag).FirstOrDefault();
            if (tagQuery.Value != null) return tagQuery.Value;

            this.Position = (this as IMap).Meta.VirtualAddress;

            var typeQuery = (from types in Assembly.GetExecutingAssembly().GetTypes()
                             where types.HasAttribute(typeof(TagClassAttribute))
                             where types.Attribute<TagClassAttribute>().TagClass == (this as IMap).Meta.Type
                             select types).FirstOrDefault();

            var ident = (this as IMap).Meta.Identifier;

            deserializedTags[ident] = Moonfish.Tags.Deserializer.Deserialize(this, typeQuery);
            this.hashTags[ident] = CalculateTaghash(ident);
            return deserializedTags[ident];
        }

        public string CalculateTaghash(TagIdent ident)
        {
            using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider())
            {
                var hash = Convert.ToBase64String(sha1.ComputeHash(this[ident].TagData));
                //Console.WriteLine(hash);
                return hash;
            }
        }

        public string GetTagHash(TagIdent ident)
        {
            return this.hashTags.ContainsKey(ident) ? this.hashTags[ident] : null;
        }

        Tag IMap.Meta
        {
            get { return current_tag; }
            set { }
        }

        public override long Position
        {
            get
            {
                int value = (int)base.Position;
                if (TryConvertOffsetToPointer(ref value)) return value;
                else return base.Position;
            }
            set
            {
                base.Position = CheckOffset(value);
            }
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return base.Seek(CheckOffset(offset), origin);
        }

        private long CheckOffset(long value)
        {
            if (value < 0 || value > this.Length)
            {
                return PointerToOffset((int)value);
            }
            else return value;
        }

        public bool TryConvertOffsetToPointer(ref int value)
        {
            foreach (var block in this.MemoryBlocks)
            {
                if (block.GetOffset(ref value, false, true))
                    return true;
            }
            return false;
        }

        public bool ContainsPointer(BlamPointer blamPointer)
        {
            foreach (var block in this.MemoryBlocks)
            {
                var previousAddressIsContained = true;
                foreach (var address in blamPointer)
                {
                    if (block.Contains(address, true) ^ previousAddressIsContained)
                    {
                        previousAddressIsContained = false;
                        break;
                    }
                    else previousAddressIsContained = true;
                }
                if (previousAddressIsContained) return true;
                else continue;
            }
            return false;
        }

        public int ConvertOffsetToPointer(int value)
        {
            foreach (var block in this.MemoryBlocks)
            {
                if (block.GetOffset(ref value, false, true)) return value;
            }
            return value;
        }

        private int PointerToOffset(int value)
        {
            foreach (var block in this.MemoryBlocks)
            {
                if (block.GetOffset(ref value, true, false)) return value;
            }
            throw new InvalidOperationException();
        }

        public bool Sign()
        {
            if (!CanWrite) return false;
            int checksum = CalculateChecksum();

            BinaryWriter writer = new BinaryWriter(this);
            writer.BaseStream.Position = 0x000002F0;
            writer.Write(checksum);
            return true;
        }

        unsafe public int CalculateChecksum()
        {
            const int block_size = 512;
            byte[] buffer = new byte[block_size];

            int word_count = ((int)this.Length - 2048) / sizeof(uint);
            int pass_count = word_count / (block_size / 4);
            int remainder = word_count % pass_count;

            this.Position = 2048;
            int checksum = 0;
            for (int pass = 0; pass < pass_count; pass++)
            {
                this.Read(buffer, 0, block_size);
                for (int index = 0; index < block_size / sizeof(uint); index += 4)
                {
                    checksum ^= BitConverter.ToInt32(buffer, (index + 0) * sizeof(uint));
                    checksum ^= BitConverter.ToInt32(buffer, (index + 1) * sizeof(uint));
                    checksum ^= BitConverter.ToInt32(buffer, (index + 2) * sizeof(uint));
                    checksum ^= BitConverter.ToInt32(buffer, (index + 3) * sizeof(uint));
                }
            }
            this.Read(buffer, 0, remainder);
            for (int index = 0; index < remainder / sizeof(uint); index += 4)
            {
                checksum ^= BitConverter.ToInt32(buffer, (index + 0) * sizeof(uint));
                checksum ^= BitConverter.ToInt32(buffer, (index + 1) * sizeof(uint));
                checksum ^= BitConverter.ToInt32(buffer, (index + 2) * sizeof(uint));
                checksum ^= BitConverter.ToInt32(buffer, (index + 3) * sizeof(uint));
            }
            return checksum;
        }

        IEnumerator<Tag> IEnumerable<Tag>.GetEnumerator()
        {
            foreach (var tag in this.Tags)
            {
                yield return tag;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        byte[] IMap.TagData
        {
            get
            {

                this.Position = this.current_tag.VirtualAddress;
                var buffer = new byte[this.current_tag.Length];
                this.Read(buffer, 0, buffer.Length);
                return buffer;
            }
        }
    }

    public enum Version
    {
        XBOX_RETAIL,
        PC_RETAIL,
    }

    /* * *
     * Unicode Handling
     * ----------------
     * Store and index pointing to a table which maps to a UTF8 string for each language.
     * For each Unicode there will be a memory usage of 4 + ( language_count * 4 ) used for indexers
     * 
     * [StringID] -> [index] : 0 -> [Language Switch Mappings] -> [English] -> UTF8 String
     * 
     * Using a dictionary to map the string_id value to an index in the language map
     * using a custom struct to hold to language mappings
     * using a list to hold the UTF8 strings
     * 
     * * */

    struct UnicodeItem
    {
        int[] _indices;
        int[] Indices { get { return _indices; } }
    }

    public struct UnicodeValueNamePair
    {
        //depre.//
        public StringID Name;
        public string Value;

        public override string ToString()
        {
            return string.Format("{0}:{1} : \"{2}\"", Name.Index, Name.Length, Value);
        }
    }

    public struct VirtualMappedAddress
    {
        public int Address;
        public int Length;
        public int Magic;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="address">Address Value</param>
        /// <param name="isVirtualAddress">If true Address Value is a virtual address else Address Value is file address</param>
        /// <returns>true if address points to this map</returns>
        bool ContainsFileOffset(long address)
        {
            return Contains(address, false);
        }
        bool ContainsVirtualOffset(long address)
        {
            return Contains(address, true);
        }
        public bool Contains(BlamPointer pointer)
        {
            var previousAddressIsContained = true;
            foreach (var address in pointer)
            {
                if (this.Contains(address, true) ^ previousAddressIsContained)
                {
                    previousAddressIsContained = false;
                    break;
                }
                else previousAddressIsContained = true;
            }
            if (previousAddressIsContained) return true;
            else return false;
        }
        public bool Contains(long address, bool isVirtualAddress = true)
        {
            var virtualOffset = isVirtualAddress ? 0 : Magic;
            int fileAddress = (int)address + virtualOffset;
            int beginAddress = Address;
            int endAddress = beginAddress + Length;
            return fileAddress >= beginAddress && fileAddress < endAddress;
        }
        public bool GetOffset(ref int address, bool addressIsVirtualAddress = true, bool returnVirtualAddress = false)
        {
            if (addressIsVirtualAddress)
            {
                if (!this.ContainsVirtualOffset(address)) return false;
                address = returnVirtualAddress ? address : address - Magic;
            }
            else
            {
                if (!this.ContainsFileOffset(address)) return false;
                address = returnVirtualAddress ? address + Magic : address;
            }
            return true;
        }
    }

    public interface IMap
    {
        /// <summary>
        /// Returns a TagBlock from the current class
        /// </summary>
        /// <returns></returns>
        dynamic Deserialize();
        /// <summary>
        /// Access meta information about the tag
        /// </summary>
        Tag Meta { get; set; }

        byte[] TagData { get; }

        void Seek();
    }

    public class Tag
    {
        public TagClass Type;
        public string Path { get; set; }
        public TagIdent Identifier;
        public int VirtualAddress;
        public int Length;

        internal bool Contains(int address)
        {
            return (address >= VirtualAddress && address < VirtualAddress + Length);
        }
    }
}
