using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Moonfish.Tags;
using OpenTK;

namespace Moonfish.Cache
{
    public class TagIndex : TagIndexBase, IReadOnlyList<TagDatum>
    {
        private readonly List<TagClassHeirarchy> _classes;
        private readonly List<TagDatum> _data;

        public List<TagClassHeirarchy> ClassHeirarchies
        {
            get { return _classes; }
        }

        public TagIndex(Map cache, IReadOnlyList<string> paths)
            : base(cache)
        {
            var binaryReader = new BinaryReader(cache.BaseStream);
            _classes = new List<TagClassHeirarchy>(new TagClassHeirarchy[classArrayCount]);
            for (var i = 0; i < classArrayCount; i++)
            {
                _classes[i] = new TagClassHeirarchy(binaryReader.ReadTagClass(), binaryReader.ReadTagClass(),
                    binaryReader.ReadTagClass());
            }

            _data = new List<TagDatum>(new TagDatum[datumArrayCount]);
            var cacheKey = default(CacheKey);// CacheKey.Create(cache);
            for (var i = 0; i < datumArrayCount && i < paths.Count; i++)
            {
                TagDatum data;
                do
                {
                    data = new TagDatum
                    {
                        Class = binaryReader.ReadTagClass( ),
                        Identifier = binaryReader.ReadTagIdent( ),
                        VirtualAddress = binaryReader.ReadInt32( ),
                        Length = binaryReader.ReadInt32( ),
                        CacheKey = cacheKey
                    };
                } while ( TagDatum.IsNull( data ) );
                data.Path = paths[i];
                _data[i] = data;
            }
        }

		internal void Remove(int i)
		{
			_data.RemoveAt(i);
		}

		public IEnumerable<TagDatum> GetTags( string path )
        {
            return _data.Where( u => u.Path.StartsWith( path ) );
        }

        public TagDatum this[TagIdent ident]
        {
            get { return this[ident.Index % 10000]; }
        }

        public TagDatum this[int index]
        {
            get { return _data[index]; }
        }

        public void Update(TagIdent ident, TagDatum item)
        {
			_data[ident.Index] = item;
        }

        public int IndexOf(TagDatum item)
        {
            return _data[item.Identifier.Index] == item ? item.Identifier.Index : _data.IndexOf(item);
        }

        public int Count
        {
            get { return _data.Count; }
        }

        public IEnumerator<TagDatum> GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        public IEnumerable<TagDatum> Where(TagClass tagClass)
        {
            return from item in _data
                   where item.Class == tagClass
                   select item;
        }

        public const uint VirtualBaseAddress = 0x80061000;

        public void SerializeTo(Stream outputStream)
        {
            // Calculate size of arrays
            var sizeOfTagClassHeirarchyArray = _classes.Count * TagClassHeirarchy.SizeInBytes;
            const int sizeOfTagDatum = 16;
            var sizeOfTagDatumArray = _data.Count * sizeOfTagDatum;

            // Create buffer and writer
            var buffer = new byte[GetSize() + HeaderSize];
            var stream =
                new VirtualStream(buffer, VirtualBaseAddress);
            var binaryWriter = new BinaryWriter(stream);

            // move past the header
            stream.Seek(HeaderSize, SeekOrigin.Begin);

            // write tag-class array
            classArrayAddress = (int) stream.Position;
            classArrayCount = _classes.Count;
            foreach (var tagClassHeirarchy in _classes)
            {
                WriteTagHeirarchy(binaryWriter, tagClassHeirarchy);
            }

            // write tag-data array
            datumArrayAddress = (int) stream.Position;
            datumArrayCount = _data.Count;
            foreach (var tagDatum in _data)
            {
                WriteTagDatum(binaryWriter, tagDatum);
            }

            // Serialise header and update address
            var headerBytes = SerializeHeader();

            stream.Seek(0, SeekOrigin.Begin);
            binaryWriter.Write(headerBytes);

            outputStream.Write(buffer, 0, buffer.Length);
        }

        public byte[] SerializePaths()
        {
            var length = _data.Sum(x => Encoding.UTF8.GetByteCount(x.Path) + 1);
            var stream = new MemoryStream(new byte[length]);
            var binaryWriter = new BinaryWriter(stream);
            _data.ForEach(x =>
            {
                binaryWriter.Write(Encoding.UTF8.GetBytes(x.Path));
                binaryWriter.Write((byte) 0);
            }
                );
            return stream.GetBuffer();
        }

        private static void WriteTagDatum(BinaryWriter binaryWriter, TagDatum tagDatum)
        {
            binaryWriter.Write(tagDatum.Class);
            binaryWriter.Write(tagDatum.Identifier);
            binaryWriter.Write(tagDatum.VirtualAddress);
            binaryWriter.Write(tagDatum.Length);
        }

        private static void WriteTagHeirarchy(BinaryWriter binaryWriter, TagClassHeirarchy tagClassHeirarchy)
        {
            binaryWriter.Write(tagClassHeirarchy.Class);
            binaryWriter.Write(tagClassHeirarchy.Parent);
            binaryWriter.Write(tagClassHeirarchy.Root);
        }

        public TagDatum Add(TagClass tagClass, string newPath, int length, int virtualAddress)
        {
            var last = _data.Last();
            var newDatum = new TagDatum
            {
                Class = tagClass,
                Identifier = last.Identifier,
                Length = length,
                Path = newPath,
                VirtualAddress = virtualAddress
            };
            _data.Insert(IndexOf(last), newDatum);
            last.Identifier++;
            Update(last.Identifier, last);
            return newDatum;
        }

        public int GetSize( )
        {
            return
                Padding.Align(
                    _classes.Count * TagClassHeirarchy.SizeInBytes
                    + _data.Count * TagDatum.SizeInBytes,
                    512 );
        }
    }
}