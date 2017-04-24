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

        public virtual void Write(TagClass tclass)
        {
            Write((int) tclass);
        }

        public virtual void Write(Range range)
        {
            Write(range.Min);
            Write(range.Max);
        }

        public virtual void Write(VertexBuffer value)
        {
            Write((int) value.Type);
            Write(new byte[28]);
        }

        public virtual void Write(String32 value)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(value.value);
            WriteFixedArray(bytes, 32);
        }

        public virtual void Write(String256 value)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(value.value);
            WriteFixedArray(bytes, 256);
        }

        public virtual void Write(StringIdent value)
        {
            Write((int) value);
        }

        public virtual void Write(ColourR1G1B1 value)
        {
            Write(value.R);
            Write(value.G);
            Write(value.B);
        }

        public virtual void Write(TagIdent value)
        {
            Write((int) value);
        }

        public virtual void Write(TagReference value)
        {
            Write((int) value.Class);
            Write((int) value.Ident);
        }

        public virtual void Write(BlockFlags8 value)
        {
            Write(value.flags);
        }

        public virtual void Write(BlockFlags16 value)
        {
            Write((byte) value.Type);
            Write((byte) value.Source);
        }

        public virtual void Write(BlockFlags32 value)
        {
            Write(value.flags);
        }

        public virtual void Write(ByteBlockIndex1 value)
        {
            Write((byte) value);
        }

        public virtual void Write(ShortBlockIndex1 value)
        {
            Write(value);
        }

        public virtual void Write(LongBlockIndex1 value)
        {
            Write((int) value);
        }

        public virtual void Write(ByteBlockIndex2 value)
        {
            Write((byte) value);
        }

        public virtual void Write(ShortBlockIndex2 value)
        {
            Write((short) value);
        }

        public virtual void Write(LongBlockIndex2 value)
        {
            Write((int) value);
        }

        public virtual void Write(Quaternion value)
        {
            Write(value.W);
            Write(value.Z);
            Write(value.Y);
            Write(value.X);
        }

        public virtual void Write(Vector4 value)
        {
            Write(value.X);
            Write(value.Y);
            Write(value.Z);
            Write(value.W);
        }

        public virtual void Write(Vector3 value)
        {
            Write(value.X);
            Write(value.Y);
            Write(value.Z);
        }

        public virtual void Write(Vector2 value)
        {
            Write(value.X);
            Write(value.Y);
        }

        public virtual void Write(ColourA1R1G1B1 value)
        {
            Write(value.A);
            Write(value.R);
            Write(value.G);
            Write(value.B);
        }

        public virtual void Write(ColourR8G8B8 value)
        {
            Write(value.R);
            Write(value.G);
            Write(value.B);
        }

        public virtual void Write(Point value)
        {
            Write(value.X);
            Write(value.Y);
        }

        public virtual void WriteFourCC(string code)
        {
            var buffer = new byte[4];
            byte[] charbytes = Encoding.UTF8.GetBytes(code);
            Array.Copy(charbytes, buffer, charbytes.Length%5);
            Array.Reverse(buffer);
            Write(buffer);
        }

        public virtual void WritePadding(int alignment)
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

        public virtual BlockFlags16 ReadBlockFlags16()
        {
            return new BlockFlags16(ReadInt16());
        }

        public virtual BlockFlags8 ReadBlockFlags8()
        {
            return new BlockFlags8(ReadByte());
        }

        public virtual ByteBlockIndex1 ReadByteBlockIndex1()
        {
            return (ByteBlockIndex1) ReadByte();
        }

        public virtual ColourR8G8B8 ReadColourR8G8B8()
        {
            return new ColourR8G8B8(ReadSingle(), ReadSingle(), ReadSingle());
        }

        public virtual ColourA1R1G1B1 ReadColourA1R1G1B1()
        {
            return new ColourA1R1G1B1(ReadByte(), ReadByte(), ReadByte(), ReadByte());
        }

        public virtual ColourR1G1B1 ReadColourR1G1B1()
        {
            var color = new ColourR1G1B1 {R = ReadByte(), G = ReadByte(), B = ReadByte()};
            return color;
        }

        public virtual string ReadFixedString(int length, bool trimNullCharacters = true)
        {
            return trimNullCharacters
                ? Encoding.UTF8.GetString(ReadBytes(length)).Trim(char.MinValue)
                : Encoding.UTF8.GetString(ReadBytes(length));
        }

        public virtual LongBlockIndex1 ReadLongBlockIndex1()
        {
            return (LongBlockIndex1) ReadInt32();
        }

        public virtual Point ReadPoint()
        {
            return new Point(ReadInt16(), ReadInt16());
        }

        public virtual Quaternion ReadQuaternion()
        {
            float i = ReadSingle(), j = ReadSingle(), k = ReadSingle(), l = ReadSingle();
            return new Quaternion(l, k, j, i);
        }

        public virtual Range ReadRange()
        {
            return new Range(ReadSingle(), ReadSingle());
        }

        public virtual ShortBlockIndex1 ReadShortBlockIndex1()
        {
            return ReadInt16();
        }

        public virtual ShortBlockIndex2 ReadShortBlockIndex2()
        {
            return (ShortBlockIndex2) ReadInt16();
        }

        public virtual String256 ReadString256()
        {
            return new String256(new string(Encoding.UTF8.GetChars(ReadBytes(256))));
        }

        public virtual String32 ReadString32()
        {
            return new String32(new string(Encoding.UTF8.GetChars(ReadBytes(32))));
        }

        public virtual StringIdent ReadStringIdent()
        {
            return (StringIdent) ReadInt32();
        }

        public virtual TagClass ReadTagClass()
        {
            return (TagClass) ReadInt32();
        }

        public virtual TagIdent ReadTagIdent()
        {
            return new TagIdent(ReadInt16(), ReadInt16());
        }

        public virtual TagReference ReadTagReference()
        {
            return new TagReference(ReadTagClass(), ReadTagIdent());
        }

        public virtual Vector2 ReadVector2()
        {
            return new Vector2(ReadSingle(), ReadSingle());
        }

        public virtual Vector3 ReadVector3()
        {
            return new Vector3(ReadSingle(), ReadSingle(), ReadSingle());
        }

        public virtual Vector4 ReadVector4()
        {
            return new Vector4(ReadSingle(), ReadSingle(), ReadSingle(), ReadSingle());
        }

        public virtual VertexAttributeType ReadVertexAttributeType()
        {
            var msb = ReadByte();
            var lsb = ReadByte();
            var type = (VertexAttributeType) (msb << 8 | lsb);
            return type;
        }

        public virtual VertexBuffer ReadVertexBuffer()
        {
            var buffer = new VertexBuffer {Type = ReadVertexAttributeType()};
            ReadBytes(30);
            return buffer;
        }
    }
}