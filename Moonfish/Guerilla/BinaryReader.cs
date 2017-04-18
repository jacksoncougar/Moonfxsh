using System.IO;
using System.Text;
using JetBrains.Annotations;
using Moonfish.Graphics;
using Moonfish.Model;
using Moonfish.Tags;
using OpenTK;

namespace Moonfish.Guerilla
{
    /// <summary>Writes primitive data types and blam! data types to a stream.</summary>
    public class BlamBinaryWriter : System.IO.BinaryWriter
    {
        public BlamBinaryWriter([NotNull] Stream input) : base(input)
        {
        }

        public BlamBinaryWriter([NotNull] Stream input, [NotNull] Encoding encoding) : base(input, encoding)
        {
        }

        public BlamBinaryWriter(Stream input, Encoding encoding, bool leaveOpen) : base(input, encoding, leaveOpen)
        {
        }
    };

    /// <summary>Reads primitive data types and blam! data types from a stream.</summary>
    public class BlamBinaryReader : BinaryReader
    {
        public BlamBinaryReader([NotNull] Stream input) : base(input)
        {
        }

        public BlamBinaryReader([NotNull] Stream input, [NotNull] Encoding encoding) : base(input, encoding)
        {
        }

        public BlamBinaryReader(Stream input, Encoding encoding, bool leaveOpen) : base(input, encoding, leaveOpen)
        {
        }

        public BlockFlags16 ReadBlockFlags16()
        {
            return new BlockFlags16(ReadInt16());
        }

        public BlockFlags8 ReadBlockFlags8()
        {
            return new BlockFlags8(ReadByte());
        }

        public ByteBlockIndex1 ReadByteBlockIndex1()
        {
            return (ByteBlockIndex1) ReadByte();
        }

        public ColourR8G8B8 ReadColorR8G8B8()
        {
            return new ColourR8G8B8(ReadSingle(), ReadSingle(), ReadSingle());
        }

        public ColourA1R1G1B1 ReadColourA1R1G1B1()
        {
            return new ColourA1R1G1B1(ReadByte(), ReadByte(), ReadByte(), ReadByte());
        }

        public ColourR1G1B1 ReadColourR1G1B1()
        {
            var color = new ColourR1G1B1 {R = ReadByte(), G = ReadByte(), B = ReadByte()};
            return color;
        }

        public string ReadFixedString(int length, bool trimNullCharacters = true)
        {
            return trimNullCharacters
                ? Encoding.UTF8.GetString(ReadBytes(length)).Trim(char.MinValue)
                : Encoding.UTF8.GetString(ReadBytes(length));
        }

        public LongBlockIndex1 ReadLongBlockIndex1()
        {
            return (LongBlockIndex1) ReadInt32();
        }

        public Point ReadPoint()
        {
            return new Point(ReadInt16(), ReadInt16());
        }

        public Quaternion ReadQuaternion()
        {
            float i = ReadSingle(), j = ReadSingle(), k = ReadSingle(), l = ReadSingle();
            return new Quaternion(l, k, j, i);
        }

        public Range ReadRange()
        {
            return new Range(ReadSingle(), ReadSingle());
        }

        public ShortBlockIndex1 ReadShortBlockIndex1()
        {
            return ReadInt16();
        }

        public ShortBlockIndex2 ReadShortBlockIndex2()
        {
            return (ShortBlockIndex2) ReadInt16();
        }

        public String256 ReadString256()
        {
            return new String256(new string(Encoding.UTF8.GetChars(ReadBytes(256))));
        }

        public String32 ReadString32()
        {
            return new String32(new string(Encoding.UTF8.GetChars(ReadBytes(32))));
        }

        public StringIdent ReadStringIdent()
        {
            return (StringIdent) ReadInt32();
        }

        public TagClass ReadTagClass()
        {
            return (TagClass) ReadInt32();
        }

        public TagIdent ReadTagIdent()
        {
            return new TagIdent(ReadInt16(), ReadInt16());
        }

        public TagReference ReadTagReference()
        {
            return new TagReference(ReadTagClass(), ReadTagIdent());
        }

        public VertexAttributeType ReadVertexAttributeType()
        {
            var msb = ReadByte();
            var lsb = ReadByte();
            var type = (VertexAttributeType) (msb << 8 | lsb);
            return type;
        }

        public VertexBuffer ReadVertexBuffer()
        {
            var buffer = new VertexBuffer {Type = ReadVertexAttributeType()};
            ReadBytes(30);
            return buffer;
        }
    }
}