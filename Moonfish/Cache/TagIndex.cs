using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Moonfish.Tags;

namespace Moonfish
{
    public class TagIndex : TagIndexBase, IReadOnlyList<TagDatum>
    {
        private const uint VirtualBaseAddress = 0x80061000;
        private readonly List<TagDatum> data;

        public TagIndex(Map cache, IReadOnlyList<string> paths) : base(cache)
        {
            var binaryReader = new BinaryReader(cache.BaseStream);
            ClassHeirarchies = new List<TagClassHeirarchy>(new TagClassHeirarchy[ClassArrayCount]);
            for (var i = 0; i < ClassArrayCount; i++)
            {
                ClassHeirarchies[i] = new TagClassHeirarchy(binaryReader.ReadTagClass(), binaryReader.ReadTagClass(),
                    binaryReader.ReadTagClass());
            }

            data = new List<TagDatum>(new TagDatum[DatumArrayCount]);
            for (var i = 0; i < DatumArrayCount && i < paths.Count; i++)
            {
                TagDatum datum;
                do
                {
                    datum = new TagDatum
                    {
                        Class = binaryReader.ReadTagClass(),
                        Identifier = binaryReader.ReadTagIdent(),
                        VirtualAddress = binaryReader.ReadInt32(),
                        Length = binaryReader.ReadInt32()
                    };
                } while (TagDatum.IsNull(datum));
                datum.Path = paths[i];
                this.data[i] = datum;
            }
        }

        public List<TagClassHeirarchy> ClassHeirarchies { get; }

        public TagDatum this[TagIdent ident]
        {
            get { return this[ident.Index%10000]; }
        }

        public TagDatum this[int index]
        {
            get { return data[index]; }
        }

        public int Count
        {
            get { return data.Count; }
        }

        public IEnumerator<TagDatum> GetEnumerator()
        {
            return data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return data.GetEnumerator();
        }

        internal void Remove(int i)
        {
            data.RemoveAt(i);
        }

        public IEnumerable<TagDatum> GetTags(string path)
        {
            return data.Where(u => u.Path.StartsWith(path));
        }

        public void Update(TagIdent ident, TagDatum item)
        {
            data[ident.Index] = item;
        }

        public int IndexOf(TagDatum item)
        {
            return data[item.Identifier.Index] == item
                ? item.Identifier.Index
                : data.IndexOf(item);
        }

        public IEnumerable<TagDatum> Where(TagClass tagClass)
        {
            return from item in data where item.Class == tagClass select item;
        }

        public void SerializeTo(Stream outputStream)
        {
            // Calculate size of arrays
            var sizeOfTagClassHeirarchyArray = ClassHeirarchies.Count*
                                               TagClassHeirarchy.SizeInBytes;
            const int sizeOfTagDatum = 16;
            var sizeOfTagDatumArray = data.Count*sizeOfTagDatum;

            // Create buffer and writer
            var buffer = new byte[GetSize() + HeaderSize];
            var stream = new VirtualStream(buffer,
                unchecked ((int) VirtualBaseAddress));
            var binaryWriter = new BinaryWriter(stream);

            // move past the header
            stream.Seek(HeaderSize, SeekOrigin.Begin);

            // write tag-class array
            ClassArrayAddress = (int) stream.Position;
            ClassArrayCount = ClassHeirarchies.Count;
            foreach (var tagClassHeirarchy in ClassHeirarchies)
            {
                WriteTagHeirarchy(binaryWriter, tagClassHeirarchy);
            }

            // write tag-data array
            DatumArrayAddress = (int) stream.Position;
            DatumArrayCount = data.Count;
            foreach (var tagDatum in data)
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
            var length = data.Sum(x => Encoding.UTF8.GetByteCount(x.Path) + 1);
            var stream = new MemoryStream(new byte[length]);
            var binaryWriter = new BinaryWriter(stream);
            data.ForEach(x =>
            {
                binaryWriter.Write(Encoding.UTF8.GetBytes(x.Path));
                binaryWriter.Write((byte) 0);
            });
            return stream.GetBuffer();
        }

        private static void WriteTagDatum(BinaryWriter binaryWriter,
            TagDatum tagDatum)
        {
            binaryWriter.Write(tagDatum.Class);
            binaryWriter.Write(tagDatum.Identifier);
            binaryWriter.Write(tagDatum.VirtualAddress);
            binaryWriter.Write(tagDatum.Length);
        }

        private static void WriteTagHeirarchy(BinaryWriter binaryWriter,
            TagClassHeirarchy tagClassHeirarchy)
        {
            binaryWriter.Write(tagClassHeirarchy.Class);
            binaryWriter.Write(tagClassHeirarchy.Parent);
            binaryWriter.Write(tagClassHeirarchy.Root);
        }

        public TagDatum Add(TagClass tagClass, string newPath, int length,
            int virtualAddress)
        {
            var last = data.Last();
            var newDatum = new TagDatum
            {
                Class = tagClass,
                Identifier = last.Identifier,
                Length = length,
                Path = newPath,
                VirtualAddress = virtualAddress
            };
            data.Insert(IndexOf(last), newDatum);
            last.Identifier++;
            Update(last.Identifier, last);
            return newDatum;
        }

        public int GetSize()
        {
            return
                Padding.Align(
                    ClassHeirarchies.Count*TagClassHeirarchy.SizeInBytes +
                    data.Count*TagDatum.SizeInBytes, 512);
        }
    }
}