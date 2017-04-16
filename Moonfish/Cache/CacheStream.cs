using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms.VisualStyles;
using Fasterflect;
using Moonfish.Guerilla;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;

namespace Moonfish.Cache
{

	/// <summary>
	/// Represents the data in a map
	/// </summary>
	public partial class Map : IDisposable
    {
        public CacheStreamWrapper<Stream> BaseStream { get; private set; }

        private readonly Dictionary<TagIdent, GuerillaBlock> tagCache;
        private readonly Dictionary<TagIdent, string> tagHashs;

        public readonly Dictionary<StringIdent, string> Strings;

	    public readonly Dictionary<StringIdent, ICollection<string>>
	        StringLocalizations;

        public readonly Dictionary<TagIdent, EVirtualStream> StructureMemoryBlockBindings;
        public readonly CacheHeader Header;

        private EVirtualStream activeAllocation = EVirtualStream.VirtualStream1;

        /// <summary>
        /// Initializes a Map object from a .map file
        /// </summary>
        /// <param name="filename">Filename of the .map file to initialize from.</param>
        public Map(string filename)
        {
            BaseStream = new CacheStreamWrapper<Stream>(new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read, 8 * 1024));

            //HEADER
            var binaryReader = new BinaryReader(BaseStream, Encoding.UTF8);

            Header = CacheHeader.DeserializeFrom(BaseStream);

            BaseStream.Seek(Header.PathsInfo.PathTableAddress, SeekOrigin.Begin);
            var paths = Encoding.UTF8.GetString(binaryReader.ReadBytes(Header.PathsInfo.PathTableLength - 1)).Split(Char.MinValue);

            //STRINGS

            BaseStream.Seek(Header.StringsInfo.StringIndexAddress, SeekOrigin.Begin);

			var stringKeys = new StringIdent[Header.StringsInfo.StringCount];
			int previousOffset = 0, currentOffset = 0;
			sbyte length;
            for(short sub = 0; sub < Header.StringsInfo.StringCount; ++sub)
            {
				currentOffset = binaryReader.ReadInt32();
				length = (sbyte)(currentOffset - previousOffset);
				stringKeys[sub] = new StringIdent(sub, length);
				previousOffset = currentOffset;
            }

            BaseStream.Seek(Header.StringsInfo.StringTableAddress, SeekOrigin.Begin);
            var stringValues = Encoding.UTF8.GetString(binaryReader.ReadBytes(Header.StringsInfo.StringTableLength - 1)).Split(Char.MinValue);

            Strings = stringKeys.Zip(stringValues, (k, v) => new { Key = k, Value = v }).ToDictionary(x => x.Key, x => x.Value);

            //  INDEX
            BaseStream.Seek(Header.IndexInfo.IndexOffset, SeekOrigin.Begin);

            Index = new TagIndex(this, paths);

            // Calculate File-pointer magic
            var secondaryMagic = Index[Index.GlobalsIdent].VirtualAddress -
                                 (Header.IndexInfo.IndexOffset + Header.IndexInfo.IndexLength);

            BaseStream.CreateVirtualSection(Index[Index.GlobalsIdent].VirtualAddress,
                                 Header.IndexInfo.MetaAllocationLength,
                                 new AddressModifier(secondaryMagic), true);

            /* Intent: read the sbsp and lightmap address and lengths from the scenario tag 
             * and store them in the Tags array.
             */

            BaseStream.Seek(Index[Index.ScenarioIdent].VirtualAddress - secondaryMagic + 528, SeekOrigin.Begin);
            var count = binaryReader.ReadInt32();
            var address = binaryReader.ReadInt32();

            StructureMemoryBlockBindings = new Dictionary<TagIdent, EVirtualStream>(count * 2);
            for (var i = 0; i < count; ++i)
            {
                var destination = address - secondaryMagic + i * 68;
                BaseStream.Seek(destination, SeekOrigin.Begin);
                var structureBlockOffset = binaryReader.ReadInt32();
                var structureBlockLength = binaryReader.ReadInt32();
                var structureBlockAddress = binaryReader.ReadInt32();
                //Position += 8;
                BaseStream.Seek(8, SeekOrigin.Current);
                var sbspIdentifier = binaryReader.ReadTagIdent();
                //Position += 4;
                BaseStream.Seek(4, SeekOrigin.Current);
                var ltmpIdentifier = binaryReader.ReadTagIdent();

                BaseStream.Seek(structureBlockOffset, SeekOrigin.Begin);

                var blockLength = binaryReader.ReadInt32();
                var sbspVirtualAddress = binaryReader.ReadInt32();
                var ltmpVirtualAddress = binaryReader.ReadInt32();
                var sbsp = binaryReader.ReadTagClass();

                var hasLightmapData = !TagIdent.IsNull(ltmpIdentifier);

                var sbspLength = hasLightmapData ? ltmpVirtualAddress - sbspVirtualAddress : blockLength;

                var ltmpLength = blockLength - sbspLength;

                var index = BaseStream.CreateVirtualSection(
                    structureBlockAddress,
                    structureBlockLength,
                    structureBlockOffset,
                    false);

                var sbspDatum = Index[sbspIdentifier];
                sbspDatum.VirtualAddress = sbspVirtualAddress;
                sbspDatum.Length = sbspLength;
                Index.Update(sbspIdentifier, sbspDatum);

                StructureMemoryBlockBindings[sbspIdentifier] = index;

                if (hasLightmapData)
                {
                    var ltmpDatum = Index[ltmpIdentifier];
                    ltmpDatum.VirtualAddress = ltmpVirtualAddress;
                    ltmpDatum.Length = ltmpLength;
                    Index.Update(ltmpIdentifier, ltmpDatum);
                    StructureMemoryBlockBindings[ltmpIdentifier] = index;
                }

                SwitchActiveAllocation(EVirtualStream.VirtualStream1);
            }


            tagCache = new Dictionary<TagIdent, GuerillaBlock>(Index.Count);
            tagHashs = new Dictionary<TagIdent, string>(Index.Count);

            // UNICODE

            using (BaseStream.Pin())
            {
                var globals =
                    Deserialize<GlobalsBlock>(Index.GlobalsIdent);

                StringLocalizations =
                    new Dictionary<StringIdent, ICollection<string>>();

                if (null != globals)
                {
                    LoadUnicode(binaryReader,
                        globals.UnicodeBlockInfo.EnglishStringIndexAddress,
                        globals.UnicodeBlockInfo.EnglishStringCount,
                        globals.UnicodeBlockInfo.EnglishStringTableAddress,
                        globals.UnicodeBlockInfo.EnglishStringTableLength);


                    LoadUnicode(binaryReader,
                        globals.UnicodeBlockInfo.FrenchStringIndexAddress,
                        globals.UnicodeBlockInfo.FrenchStringCount,
                        globals.UnicodeBlockInfo.FrenchStringTableAddress,
                        globals.UnicodeBlockInfo.FrenchStringTableLength);


                    LoadUnicode(binaryReader,
                        globals.UnicodeBlockInfo.ChineseStringIndexAddress,
                        globals.UnicodeBlockInfo.ChineseStringCount,
                        globals.UnicodeBlockInfo.ChineseStringTableAddress,
                        globals.UnicodeBlockInfo.ChineseStringTableLength);
                }
            }

            Initialize();
        }

	    private void LoadUnicode(BinaryReader binaryReader, 
            int stringIndexAddress, int stringCount, int stringTableAddress, int stringTableLength)
	    {
	        BaseStream.Seek(stringIndexAddress,
	            SeekOrigin.Begin);

	        int unicodeCount = stringCount;
	        List<Tuple<StringIdent, int>> info =
	            new List<Tuple<StringIdent, int>>(unicodeCount);

	        for (; unicodeCount > 0; --unicodeCount)
	        {
	            var key = binaryReader.ReadStringIdent();
	            var start = binaryReader.ReadInt32();
	            info.Add(new Tuple<StringIdent, int>(key, start));
	        }

	        BaseStream.Seek(stringTableAddress,
	            SeekOrigin.Begin);
	        byte[] buffer = new byte[stringTableLength];

	        BaseStream.Read(buffer, 0, buffer.Length);

	        int end = stringTableLength;
	        for (int index = info.Count - 1; index > 0; --index)
	        {
	            int start = info[index].Item2;
	            int len = end - start - 1; //trim the '\0'

	            var value = Encoding.UTF8.GetString(buffer, start, len);
	            if (!StringLocalizations.ContainsKey(info[index].Item1))
	            {
	                StringLocalizations.Add(info[index].Item1, new List<string>(8));
	            }
	            StringLocalizations[info[index].Item1].Add(value);

	            end = start;
	        }
	    }

	    private void Initialize()
        {
        }

        public TagIndex Index { get; private set; }

        public int Count
        {
            get { return Index.Count; }
        }

		public TagDatum this[int index]
        {
            get { return Index[index]; }
        }

        public TagDatum GetOwner(int address)
        {
            //TODO fix this bad code.
            //foreach (var data in from data in Index
            //    let start = VirtualAddressToFileOffset(data.VirtualAddress)
            //    let length = data.Length
            //    where address >= start && address < start + length
            //    select data)
            //{
            //    return data;
            //}
            return new TagDatum();
        }

        public TagDatum Add<T>(T item, string tagName) where T : GuerillaBlock
        {
            var lastDatum = Index.Last();

            var stream = new VirtualStream(lastDatum.VirtualAddress);
            var binaryWriter = new BinaryWriter(stream);

            binaryWriter.Write(item);
            var serializedTagData = stream.ToArray();

            var attribute = (TagClassAttribute)item.GetType().Attribute(typeof(TagClassAttribute)) ??
                            (TagClassAttribute)
                                item.GetType().BaseType?.GetCustomAttributes(typeof(TagClassAttribute)).FirstOrDefault();
            var tagDatum = Index.Add(attribute.TagClass, tagName, serializedTagData.Length, lastDatum.VirtualAddress);

            tagCache.Add(tagDatum.Identifier, item);

            var paths = Index.Select(x => x.Path);


#if DEBUG
            //new Validator().Validate(tagDatum, stream);
#endif
            return tagDatum;

            //Allocate(tagDatum.Identifier, serializedTagData.Length);
        }

        public void SwitchActiveAllocation(EVirtualStream allocation)
        {
            BaseStream.DisableVirtualSection(activeAllocation);
            BaseStream.EnableVirtualSection(allocation);
        }

        public string CalculateHash(TagIdent ident)
        {
            var sha1 = new SHA1CryptoServiceProvider();
            var buffer = sha1.ComputeHash(ReadTagMeta(ident));
            var hash = Convert.ToBase64String(buffer);

            return hash;
        }
        private GuerillaBlock Deserialize(Type tagType)
        {
            var sourceReader = new BinaryReader(BaseStream);
            var instance = (GuerillaBlock)Activator.CreateInstance(tagType);

            instance.Read(sourceReader);

            return instance;
        }

        public GuerillaBlock Deserialize(TagIdent ident)
        {
            return Deserialize<GuerillaBlock>(ident);
        }

        public T Deserialize<T>(TagIdent ident) where T : GuerillaBlock
        {
            GuerillaBlock deserializedTag;

            if (tagCache.TryGetValue(ident, out deserializedTag))
                return (T)deserializedTag;

            var type = Index[ident].Class.GetClassType();

            if (type == null) return null;

            Seek(ident);
            tagCache[ident] = Deserialize(type);
            tagHashs[ident] = CalculateHash(ident);

            return (T)tagCache[ident];
        }

        public long GetFilePosition()
        {
            return BaseStream.Position;
        }

        public long Seek(TagIdent tagident)
        {
            if (Index[tagident].Class == TagClass.Sbsp || Index[tagident].Class == TagClass.Ltmp)
            {
                var index = StructureMemoryBlockBindings[tagident];
                SwitchActiveAllocation(index);
            }
            var offset = Header.Version == HaloVersion.XBOX_RETAIL
                ? Index[tagident].VirtualAddress
                : Header.IndexInfo.IndexOffset + Index[tagident].VirtualAddress;
            return BaseStream.Seek(offset, SeekOrigin.Begin);
        }

        public bool Sign()
        {
            if (!BaseStream.CanWrite) return false;
            var checksum = CalculateChecksum();

            var writer = new BinaryWriter(BaseStream);
            writer.BaseStream.Position = 0x000002F0;
            writer.Write(checksum);
            return true;
        }

        public int CalculateChecksum()
        {
            const int blockSize = 512;
            var buffer = new byte[blockSize];

            var wordCount = ((int)BaseStream.Length - 2048) / sizeof(uint);
            var passCount = wordCount / (blockSize / 4);
            var remainder = wordCount % passCount;

            BaseStream.Position = 2048;
            var checksum = 0;
            for (var pass = 0; pass < passCount; pass++)
            {
                BaseStream.Read(buffer, 0, blockSize);
                for (var index = 0; index < blockSize / sizeof(uint); index += 4)
                {
                    checksum ^= BitConverter.ToInt32(buffer, (index + 0) * sizeof(uint));
                    checksum ^= BitConverter.ToInt32(buffer, (index + 1) * sizeof(uint));
                    checksum ^= BitConverter.ToInt32(buffer, (index + 2) * sizeof(uint));
                    checksum ^= BitConverter.ToInt32(buffer, (index + 3) * sizeof(uint));
                }
            }
            BaseStream.Read(buffer, 0, remainder);
            for (var index = 0; index < remainder / sizeof(uint); index += 4)
            {
                checksum ^= BitConverter.ToInt32(buffer, (index + 0) * sizeof(uint));
                checksum ^= BitConverter.ToInt32(buffer, (index + 1) * sizeof(uint));
                checksum ^= BitConverter.ToInt32(buffer, (index + 2) * sizeof(uint));
                checksum ^= BitConverter.ToInt32(buffer, (index + 3) * sizeof(uint));
            }
            return checksum;
        }

        /// <summary>
        ///     Returns the meta that is linked to the Tag
        /// </summary>
        /// <param name="ident"></param>
        /// <returns></returns>
		public byte[] ReadTagMeta(TagIdent ident)
        {
            TagDatum datum;
            byte[] buffer;

            using (BaseStream.Pin())
            {
                Seek(ident);
                datum = Index[ident];
                buffer = new byte[datum.Length];
                BaseStream.Read(buffer, 0, datum.Length);
            }

            return buffer;
        }

        /// <summary>
        /// TODO optimize 
        /// </summary>
        /// <param name="guerillaBlock"></param>
        /// <returns></returns>
        public bool Contains<T>(T guerillaBlock) where T : GuerillaBlock
        {
            foreach (var block in tagCache)
            {
                if (block.Value == guerillaBlock)
                    return true;
                var children = block.Value.Children().ToList();
                foreach (var child in children)
                {
                    if (child is GlobalGeometryPartBlockNew)
                    {

                    }
                    if (child == guerillaBlock)
                        return true;
                }
            }
            return false;
        }

        public IEnumerator<TagDatum> GetEnumerator()
        {
            return Index.GetEnumerator();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    BaseStream.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~CacheStream() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
		#endregion
	}
}