using System;
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
    public class BlamBinaryWriter : BinaryWriter
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

        public double[] ToArray(Vector3 vector3)
        {
            return new double[] {vector3.X, vector3.Y, vector3.Z};
        }

        public void Write(TagClass tclass)
        {
            Write((int) tclass);
        }

        public void Write(Range range)
        {
            Write(range.Min);
            Write(range.Max);
        }

        public void Write(VertexBuffer value)
        {
            Write((int) value.Type);
            Write(new byte[28]);
        }

        public void Write(String32 value)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(value.value);
            WriteFixedArray(bytes, 32);
        }

        public void Write(String256 value)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(value.value);
            WriteFixedArray(bytes, 256);
        }

        public void Write(StringIdent value)
        {
            Write((int) value);
        }

        public void Write(ColourR1G1B1 value)
        {
            Write(value.R);
            Write(value.G);
            Write(value.B);
        }

        public void Write(TagIdent value)
        {
            Write((int) value);
        }

        public void Write(TagReference value)
        {
            Write((int) value.Class);
            Write((int) value.Ident);
        }

        public void Write(BlockFlags8 value)
        {
            Write(value.flags);
        }

        public void Write(BlockFlags16 value)
        {
            Write((byte) value.Type);
            Write((byte) value.Source);
        }

        public void Write(BlockFlags32 value)
        {
            Write(value.flags);
        }

        public void Write(ByteBlockIndex1 value)
        {
            Write((byte) value);
        }

        public void Write(ShortBlockIndex1 value)
        {
            Write(value);
        }

        public void Write(LongBlockIndex1 value)
        {
            Write((int) value);
        }

        public void Write(ByteBlockIndex2 value)
        {
            Write((byte) value);
        }

        public void Write(ShortBlockIndex2 value)
        {
            Write((short) value);
        }

        public void Write(LongBlockIndex2 value)
        {
            Write((int) value);
        }

        public void Write(Quaternion value)
        {
            Write(value.W);
            Write(value.Z);
            Write(value.Y);
            Write(value.X);
        }

        public void Write(Vector4 value)
        {
            Write(value.X);
            Write(value.Y);
            Write(value.Z);
            Write(value.W);
        }

        public void Write(Vector3 value)
        {
            Write(value.X);
            Write(value.Y);
            Write(value.Z);
        }

        public void Write(Vector2 value)
        {
            Write(value.X);
            Write(value.Y);
        }

        public void Write(ColourA1R1G1B1 value)
        {
            Write(value.A);
            Write(value.R);
            Write(value.G);
            Write(value.B);
        }

        public void Write(ColourR8G8B8 value)
        {
            Write(value.R);
            Write(value.G);
            Write(value.B);
        }

        public void Write(Point value)
        {
            Write(value.X);
            Write(value.Y);
        }

        public void WriteFourCC(string code)
        {
            var buffer = new byte[4];
            byte[] charbytes = Encoding.UTF8.GetBytes(code);
            Array.Copy(charbytes, buffer, charbytes.Length%5);
            Array.Reverse(buffer);
            Write(buffer);
        }

        public void WritePadding(int alignment)
        {
            Write(new byte[Padding.GetCount(BaseStream.Position, alignment)]);
        }

        private void WriteFixedArray(byte[] bytes, int fixedArraySize)
        {
            var padding = bytes.Length >= fixedArraySize ? 0 : fixedArraySize - bytes.Length;
            var length = fixedArraySize - padding;
            Write(bytes, 0, length);
            Write(new byte[padding]);
        }
    }

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

        public Vector2 ReadVector2()
        {
            return new Vector2(ReadSingle(), ReadSingle());
        }

        public Vector3 ReadVector3()
        {
            return new Vector3(ReadSingle(), ReadSingle(), ReadSingle());
        }

        public Vector4 ReadVector4()
        {
            return new Vector4(ReadSingle(), ReadSingle(), ReadSingle(), ReadSingle());
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