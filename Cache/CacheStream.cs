using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Fasterflect;
using Moonfish.Guerilla;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;

namespace Moonfish.Cache
{
    public partial class CacheStream : FileStream
    {
        private readonly Dictionary<TagIdent, GuerillaBlock> _deserializedTagCache;
        private readonly Dictionary<TagIdent, string> _tagHashDictionary;
        public readonly VirtualMappedAddress DefaultMemoryBlock;
        
        public readonly string[] Strings;
        public readonly Dictionary<TagIdent, int> StructureMemoryBlockBindings;
        public readonly List<VirtualMappedAddress> StructureMemoryBlocks;
        public readonly CacheHeader Header;

        public CacheStream(string filename)
            : base(filename, FileMode.Open, FileAccess.Read, FileShare.Read, 8*1024)  
        {
            //HEADER
            var binaryReader = new BinaryReader(this, Encoding.UTF8);

            Header = CacheHeader.DeserializeFrom(this);

            base.Seek(Header.PathsInfo.PathTableAddress, SeekOrigin.Begin);
            var paths = Encoding.UTF8.GetString(binaryReader.ReadBytes(Header.PathsInfo.PathTableLength - 1)).Split(Char.MinValue);

            Halo2.Paths.Assign(paths);

            //STRINGS

            base.Seek(Header.StringsInfo.StringTableAddress, SeekOrigin.Begin);
            Strings = Encoding.UTF8.GetString(binaryReader.ReadBytes(Header.StringsInfo.StringTableLength - 1)).Split(Char.MinValue);

            Halo2.Strings.Assign(new List<string>(Strings));

            //  INDEX
            base.Seek(Header.IndexInfo.IndexOffset, SeekOrigin.Begin);

            Index = new TagIndex(this, paths);

            // Calculate File-pointer magic
            var secondaryMagic = Index[Index.GlobalsIdent].VirtualAddress -
                                 (Header.IndexInfo.IndexOffset + Header.IndexInfo.IndexLength);

            DefaultMemoryBlock = new VirtualMappedAddress
            {
                Address = Index[0].VirtualAddress,
                Length = Header.IndexInfo.MetaAllocationLength,
                Magic = secondaryMagic
            };

            /* Intent: read the sbsp and lightmap address and lengths from the scenario tag 
             * and store them in the Tags array.
             */

            base.Seek(Index[Index.ScenarioIdent].VirtualAddress - secondaryMagic + 528, SeekOrigin.Begin);
            var count = binaryReader.ReadInt32();
            var address = binaryReader.ReadInt32();

            StructureMemoryBlockBindings = new Dictionary<TagIdent, int>(count*2);
            StructureMemoryBlocks = new List<VirtualMappedAddress>(count);
            for (var i = 0; i < count; ++i)
            {
                base.Seek(address - secondaryMagic + i * 68, SeekOrigin.Begin);
                var structureBlockOffset = binaryReader.ReadInt32();
                var structureBlockLength = binaryReader.ReadInt32();
                var structureBlockAddress = binaryReader.ReadInt32();
                base.Seek(8, SeekOrigin.Current);
                var sbspIdentifier = binaryReader.ReadTagIdent();
                base.Seek(4, SeekOrigin.Current);
                var ltmpIdentifier = binaryReader.ReadTagIdent();

                base.Seek(structureBlockOffset, SeekOrigin.Begin);


                var blockLength = binaryReader.ReadInt32();
                var sbspVirtualAddress = binaryReader.ReadInt32();
                var ltmpVirtualAddress = binaryReader.ReadInt32();
                var sbsp = binaryReader.ReadTagClass();

                var hasLightmapData = !TagIdent.IsNull(ltmpIdentifier);

                var sbspLength = hasLightmapData ? ltmpVirtualAddress - sbspVirtualAddress : blockLength;

                var ltmpLength = blockLength - sbspLength;

                var block = new VirtualMappedAddress
                {
                    Address = structureBlockAddress,
                    Length = structureBlockLength,
                    Magic = structureBlockAddress - structureBlockOffset
                };

                var sbspDatum = Index[sbspIdentifier];
                sbspDatum.VirtualAddress = sbspVirtualAddress;
                sbspDatum.Length = sbspLength;
                Index.Update(sbspIdentifier, sbspDatum);

                StructureMemoryBlocks.Add(block);
                var index = StructureMemoryBlocks.Count - 1;
                StructureMemoryBlockBindings[sbspIdentifier] = index;

                if (hasLightmapData)
                {
                    var ltmpDatum = Index[ltmpIdentifier];
                    ltmpDatum.VirtualAddress = ltmpVirtualAddress;
                    ltmpDatum.Length = ltmpLength;
                    Index.Update(ltmpIdentifier, ltmpDatum);
                    StructureMemoryBlockBindings[ltmpIdentifier] = index;
                }

                ActiveAllocation(StructureCache.VirtualStructureCache0);
            }


            _deserializedTagCache = new Dictionary<TagIdent, GuerillaBlock>(Index.Count);
            _tagHashDictionary = new Dictionary<TagIdent, string>(Index.Count);
            Halo2.ActiveMap(this);

            Initialize();
        }

        private void Initialize()
        {
            // Unicode
        }

        public TagIndex Index { get; private set; }

        public override long Position
        {
            get
            {
                var value = (int) base.Position;
                return TryConvertOffsetToPointer(ref value) ? value : base.Position;
            }
            set
            {
                base.Position = CheckOffset(value);
            }
        }

        private VirtualMappedAddress ActiveStructureMemoryAllocation { get; set; }

        public TagDatum GetOwner(int address)
        {
            foreach (var data in from data in Index
                let start = VirtualAddressToFileOffset(data.VirtualAddress)
                let length = data.Length
                where address >= start && address < start + length
                select data)
            {
                return data;
            }
            return new TagDatum();
        }

        public void Add<T>(T item, string tagName) where T : GuerillaBlock
        {
            var lastDatum = Index.Last();

            var stream = new VirtualStream(lastDatum.VirtualAddress);
            var binaryWriter = new BinaryWriter(stream);

            binaryWriter.Write(item);
            var serializedTagData = stream.ToArray();

            var attribute = (TagClassAttribute) typeof (T).Attribute(typeof (TagClassAttribute));
            var tagDatum = Index.Add(attribute.TagClass, tagName, serializedTagData.Length, lastDatum.VirtualAddress);

#if DEBUG
            var v = new Validator();
            v.Validate(tagDatum, stream);
#endif

            Allocate(tagDatum.Identifier, serializedTagData.Length);
        }

        private void Allocate(TagIdent ident, int size)
        {
            //create virtual stream to write into
            var tagCacheStream = new VirtualStream(Index[Index.GlobalsIdent].VirtualAddress);

            var binaryWriter = new BinaryWriter(tagCacheStream);

            for (var i = 0; i < Index.Count; ++i)
            {
                var datum = Index[i];

                // is this address affected by the shift?
                if (datum.Identifier == ident)
                {
                    var alignment = Guerilla.Guerilla.AlignmentOf(Halo2.GetTypeOf(Index[ident].Class));
                    datum.VirtualAddress = binaryWriter.BaseStream.Align(alignment);
                    binaryWriter.Write(new byte[size]);
                    datum.Length = size;
                    Index.Update(datum.Identifier, datum);
                }
                else
                {
                    var data = Deserialize(datum.Identifier);
                    var length = binaryWriter.BaseStream.Length;
                    binaryWriter.Write(data);
                    binaryWriter.Seek(0, SeekOrigin.End);
                    length = (int) binaryWriter.BaseStream.Length - length;
                    datum.Length = (int) length;
                    Index.Update(datum.Identifier, datum);
                }
            }
            binaryWriter.WritePadding(512);
        }

        public void ActiveAllocation(StructureCache activeAllocation)
        {
            var index = (int) activeAllocation;
            ActiveStructureMemoryAllocation = StructureMemoryBlocks[index];
        }

        public string CalculateHash(TagIdent ident)
        {
            using (var sha1 = new SHA1CryptoServiceProvider())
            {
                var hash = Convert.ToBase64String(sha1.ComputeHash(GetInternalTagMeta(ident)));
                return hash;
            }
        }

        public bool ContainsPointer(BlamPointer blamPointer)
        {
            return DefaultMemoryBlock.Contains(blamPointer) || ActiveStructureMemoryAllocation.Contains(blamPointer);
        }

        public GuerillaBlock Deserialize(TagIdent ident)
        {
            GuerillaBlock deserializedTag;
            if (_deserializedTagCache.TryGetValue(ident, out deserializedTag))
                return deserializedTag;

            var type = Halo2.GetTypeOf(Index[ident].Class);
            if (type == null) return null;

            Seek(ident);
            _deserializedTagCache[ident] = Deserialize(type);
            _tagHashDictionary[ident] = CalculateHash(ident);

            return _deserializedTagCache[ident];
        }

        private GuerillaBlock Deserialize(Type tagType)
        {
            var sourceReader = new BinaryReader(this);
            var instance = (GuerillaBlock) Activator.CreateInstance(tagType);
            instance.Read(sourceReader);
            return instance;
        }

        public long GetFilePosition()
        {
            return base.Position;
        }

        public string GetTagHash(TagIdent ident)
        {
            return _tagHashDictionary.ContainsKey(ident) ? _tagHashDictionary[ident] : null;
        }

        public void ClearCache(TagIdent ident)
        {
            _deserializedTagCache.Remove(ident);
        }

        public long Seek(TagIdent tagident)
        {
            if (Index[tagident].Class == TagClass.Sbsp || Index[tagident].Class == TagClass.Ltmp)
            {
                var index = StructureMemoryBlockBindings[tagident];
                ActiveAllocation(StructureCache.VirtualStructureCache0 + index);
            }
            var offset = Header.Version == HaloVersion.XBOX_RETAIL
                ? Index[tagident].VirtualAddress
                : Header.IndexInfo.IndexOffset + Index[tagident].VirtualAddress;
            return Seek(offset, SeekOrigin.Begin);
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            if (origin == SeekOrigin.Begin)
            {
                offset = CheckOffset(offset);
            }
            base.Seek(offset, origin);
            return Position;
        }

        public bool Sign()
        {
            if (!CanWrite) return false;
            var checksum = CalculateChecksum();

            var writer = new BinaryWriter(this);
            writer.BaseStream.Position = 0x000002F0;
            writer.Write(checksum);
            return true;
        }

        private int CalculateChecksum()
        {
            const int blockSize = 512;
            var buffer = new byte[blockSize];

            var wordCount = ((int) Length - 2048)/sizeof (uint);
            var passCount = wordCount/(blockSize/4);
            var remainder = wordCount%passCount;

            Position = 2048;
            var checksum = 0;
            for (var pass = 0; pass < passCount; pass++)
            {
                Read(buffer, 0, blockSize);
                for (var index = 0; index < blockSize/sizeof (uint); index += 4)
                {
                    checksum ^= BitConverter.ToInt32(buffer, (index + 0)*sizeof (uint));
                    checksum ^= BitConverter.ToInt32(buffer, (index + 1)*sizeof (uint));
                    checksum ^= BitConverter.ToInt32(buffer, (index + 2)*sizeof (uint));
                    checksum ^= BitConverter.ToInt32(buffer, (index + 3)*sizeof (uint));
                }
            }
            Read(buffer, 0, remainder);
            for (var index = 0; index < remainder/sizeof (uint); index += 4)
            {
                checksum ^= BitConverter.ToInt32(buffer, (index + 0)*sizeof (uint));
                checksum ^= BitConverter.ToInt32(buffer, (index + 1)*sizeof (uint));
                checksum ^= BitConverter.ToInt32(buffer, (index + 2)*sizeof (uint));
                checksum ^= BitConverter.ToInt32(buffer, (index + 3)*sizeof (uint));
            }
            return checksum;
        }

        private long CheckOffset(long value)
        {
            // if 'value' is a Pointer
            if (value < 0 || value > Length)
            {
                return VirtualAddressToFileOffset((int) value);
            }
            return value;
        }

        /// <summary>
        ///     Returns the meta that is linked to the Tag
        /// </summary>
        /// <param name="ident"></param>
        /// <returns></returns>
        private byte[] GetInternalTagMeta(TagIdent ident)
        {
            using (this.Pin())
            {
                Seek(ident);
                var tag = Index[ident];
                var buffer = new byte[tag.Length];
                Read(buffer, 0, tag.Length);
                return buffer;
            }
        }

        private bool TryConvertOffsetToPointer(ref int value)
        {
            if (DefaultMemoryBlock.ContainsFileOffset(value))
            {
                value = DefaultMemoryBlock.GetOffset(value, false, true);
                return true;
            }
            if (ActiveStructureMemoryAllocation.ContainsFileOffset(value))
            {
                value = ActiveStructureMemoryAllocation.GetOffset(value, false, true);
                return true;
            }
            return false;
        }

        public int VirtualAddressToFileOffset(int value)
        {
            if (DefaultMemoryBlock.ContainsVirtualOffset(value))
            {
                return DefaultMemoryBlock.GetOffset(value);
            }
            if (ActiveStructureMemoryAllocation.ContainsVirtualOffset(value))
            {
                return ActiveStructureMemoryAllocation.GetOffset(value);
            }
            foreach (var block in StructureMemoryBlocks.Where(block => block.ContainsVirtualOffset(value)))
                return block.GetOffset(value);
            throw new InvalidOperationException();
        }
    }
}