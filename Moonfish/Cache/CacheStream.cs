using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using Fasterflect;
using Moonfish.Guerilla;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;

namespace Moonfish.Cache
{
	
	public partial class CacheStream : CacheStreamWrapper<FileStream>, ICache
    {
        private readonly Dictionary<TagIdent, GuerillaBlock> _deserializedTagCache;
        private readonly Dictionary<TagIdent, string> _tagHashDictionary;

        public readonly string[] Strings;
        public readonly Dictionary<TagIdent, int> StructureMemoryBlockBindings;
        public readonly CacheHeader Header;

		public string Name => BaseStream.Name;

		private VirtualMemorySectionID activeAllocation = VirtualMemorySectionID.VirtualStructureCache0;

		public void UpdateBinding(TagIdent oldIdent, TagIdent newIdent)
		{
			var index = StructureMemoryBlockBindings[oldIdent];
			StructureMemoryBlockBindings.Remove(oldIdent);
			StructureMemoryBlockBindings.Add(newIdent, index);
		}

		public void UpdateCache(TagIdent ident, GuerillaBlock block)
		{
			_deserializedTagCache.Remove(ident);
			_deserializedTagCache.Add(ident, block);
		}

        public static CacheStream Open(string fileName)
        {
            var directory = Path.GetDirectoryName(fileName);

            if (directory != null)
                LoadResourceMaps(directory);

            return new CacheStream(fileName);
        }

        private static void LoadResourceMaps(string directory)
        {
        }

        public CacheStream(string filename)

			: base(new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read, 8*1024))  
        {
            //HEADER
            var binaryReader = new BinaryReader(this, Encoding.UTF8);

            Header = CacheHeader.DeserializeFrom(this);

            base.Seek(Header.PathsInfo.PathTableAddress, SeekOrigin.Begin);
            var paths = Encoding.UTF8.GetString(binaryReader.ReadBytes(Header.PathsInfo.PathTableLength - 1)).Split(Char.MinValue);

            //Halo2.Paths.Assign(paths);

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

			CreateVirtualSection(Index[Index.GlobalsIdent].VirtualAddress, 
			                     Header.IndexInfo.MetaAllocationLength, 
			                     new AddressModifier(secondaryMagic), true);
      

            /* Intent: read the sbsp and lightmap address and lengths from the scenario tag 
             * and store them in the Tags array.
             */

            base.Seek(Index[Index.ScenarioIdent].VirtualAddress - secondaryMagic + 528, SeekOrigin.Begin);
            var count = binaryReader.ReadInt32();
            var address = binaryReader.ReadInt32();

			StructureMemoryBlockBindings = new Dictionary<TagIdent, int>(count * 2);
            for (var i = 0; i < count; ++i)
            {
				var destination = address - secondaryMagic + i * 68;
				base.Seek(destination, SeekOrigin.Begin);
                var structureBlockOffset = binaryReader.ReadInt32();
                var structureBlockLength = binaryReader.ReadInt32();
                var structureBlockAddress = binaryReader.ReadInt32();
				//Position += 8;
				base.Seek(8, SeekOrigin.Current);
                var sbspIdentifier = binaryReader.ReadTagIdent();
				//Position += 4;
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

				var index = CreateVirtualSection(
					structureBlockAddress,
					structureBlockLength,
					structureBlockOffset,
					true);

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

                SwitchActiveAllocation(VirtualMemorySectionID.VirtualStructureCache0);
            }


            _deserializedTagCache = new Dictionary<TagIdent, GuerillaBlock>(Index.Count);
            _tagHashDictionary = new Dictionary<TagIdent, string>(Index.Count);

            Initialize();
        }

        private void Initialize()
        {
            // Unicode
        }

        public TagIndex Index { get; private set; }

        public int Count
        {
            get { return Index.Count; }
        }

        public TagDatum this[int index]
        {
            get { return Index[ index ]; }
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

            var attribute = ( TagClassAttribute ) item.GetType( ).Attribute( typeof ( TagClassAttribute ) ) ??
                            ( TagClassAttribute )
                                item.GetType( ).BaseType?.GetCustomAttributes(typeof ( TagClassAttribute ) ).FirstOrDefault();
            var tagDatum = Index.Add(attribute.TagClass, tagName, serializedTagData.Length, lastDatum.VirtualAddress);

            _deserializedTagCache.Add(tagDatum.Identifier, item );

            var paths = Index.Select( x => x.Path );
            

#if DEBUG
            //new Validator().Validate(tagDatum, stream);
#endif
            return tagDatum;

            //Allocate(tagDatum.Identifier, serializedTagData.Length);
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

        public void SwitchActiveAllocation(VirtualMemorySectionID allocation)
        {
			DisableVirtualSection((int)activeAllocation);
			EnableVirtualSection((int)allocation);
        }

        public string CalculateHash(TagIdent ident)
        {
            using (var sha1 = new SHA1CryptoServiceProvider())
            {
                var hash = Convert.ToBase64String(sha1.ComputeHash(Read(ident)));
                return hash;
            }
        }

        public GuerillaBlock Deserialize( TagIdent ident )
        {
            return Deserialize<GuerillaBlock>( ident );
        }

        public T Deserialize<T>( TagIdent ident ) where T : GuerillaBlock
        {
            GuerillaBlock deserializedTag;
            if ( _deserializedTagCache.TryGetValue( ident, out deserializedTag ) )
                return ( T ) deserializedTag;

            var type = Halo2.GetTypeOf( Index[ ident ].Class );
            if ( type == null ) return null;

            Seek( ident );
            _deserializedTagCache[ ident ] = Deserialize( type );
            _tagHashDictionary[ ident ] = CalculateHash( ident );

            return ( T ) _deserializedTagCache[ ident ];
        }

        public string GetStringValue( StringIdent ident )
        {
            return Strings[ ident.Index ];
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
                SwitchActiveAllocation(VirtualMemorySectionID.VirtualStructureCache0 + index);
            }
            var offset = Header.Version == HaloVersion.XBOX_RETAIL
                ? Index[tagident].VirtualAddress
                : Header.IndexInfo.IndexOffset + Index[tagident].VirtualAddress;
            return Seek(offset, SeekOrigin.Begin);
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

        public int CalculateChecksum()
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

        /// <summary>
        ///     Returns the meta that is linked to the Tag
        /// </summary>
        /// <param name="ident"></param>
        /// <returns></returns>
		public void Read(TagIdent ident, byte[] buffer)
        {
			TagDatum datum;

            using (this.Pin())
            {
                Seek(ident);
                datum = Index[ident];
                buffer = new byte[datum.Length];
                Read(buffer, 0, datum.Length);
            }

			return;
        }

        /// <summary>
        /// TODO optimize 
        /// </summary>
        /// <param name="guerillaBlock"></param>
        /// <returns></returns>
        public bool Contains<T>( T guerillaBlock ) where T :GuerillaBlock
        {
            foreach ( var block in _deserializedTagCache )
            {
                if ( block.Value == guerillaBlock )
                    return true;
                var children = block.Value.Children(  ).ToList(  );
                foreach ( var child in children )
                {
                    if ( child is GlobalGeometryPartBlockNew )
                    {
                        
                    }
                    if ( child == guerillaBlock )
                        return true;
                }
            }
            return false;
        }

        public IEnumerator<TagDatum> GetEnumerator()
        {
            return Index.GetEnumerator( );
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Index.GetEnumerator();
        }
    }
}