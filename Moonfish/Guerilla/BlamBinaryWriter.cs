using System;
using System.IO;
using System.Text;
using JetBrains.Annotations;
using Moonfish.Model;
using Moonfish.Tags;
using OpenTK;

namespace Moonfish.Guerilla
{
    /// <summary>
    /// Writes blam! types in binary to a stream.
    /// </summary>
    /// <seealso cref="System.IO.BinaryWriter" />
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

        public virtual void Write(BlamPointer blamPointer)
        {
            Write(blamPointer.ElementCount);
            Write(blamPointer.ElementCount > 0 ? blamPointer.StartAddress : 0);
        }

        public virtual void Write(Range range)
        {
            Write(range.Min);
            Write(range.Max);
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
            base.Write((int) value);
        }

        public virtual void Write(ColourR1G1B1 value)
        {
            base.Write(value.R);
            base.Write(value.G);
            base.Write(value.B);
        }

        public virtual void Write(TagIdent value)
        {
            base.Write((int) value);
        }

        public virtual void Write(TagReference value)
        {
            base.Write((int) value.Class);
            base.Write((int) value.Ident);
        }

        public virtual void Write(BlockFlags8 value)
        {
            base.Write(value.flags);
        }

        public virtual void Write(BlockFlags16 value)
        {
            base.Write((byte) value.Type);
            base.Write((byte) value.Source);
        }

        public virtual void Write(BlockFlags32 value)
        {
            base.Write(value.flags);
        }

        public virtual void Write(ByteBlockIndex1 value)
        {
            base.Write((byte) value);
        }

        public virtual void Write(ShortBlockIndex1 value)
        {
            base.Write(value);
        }

        public virtual void Write(LongBlockIndex1 value)
        {
            base.Write((int) value);
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
            base.Write(value.W);
            base.Write(value.Z);
            base.Write(value.Y);
            base.Write(value.X);
        }

        public virtual void Write(Vector4 value)
        {
            base.Write(value.X);
            base.Write(value.Y);
            base.Write(value.Z);
            base.Write(value.W);
        }
        
        public virtual void Write(Vector3 value)
        {
            base.Write(value.X);
            base.Write(value.Y);
            base.Write(value.Z);
        }

        public virtual void Write(Vector2 value)
        {
            base.Write(value.X);
            base.Write(value.Y);
        }

        public virtual void Write(ColourA1R1G1B1 value)
        {
            base.Write(value.A);
            base.Write(value.R);
            base.Write(value.G);
            base.Write(value.B);
        }

        public virtual void Write(ColourR8G8B8 value)
        {
            base.Write(value.R);
            base.Write(value.G);
            base.Write(value.B);
        }

        public virtual void Write(Point value)
        {
            base.Write(value.X);
            base.Write(value.Y);
        }

        public virtual void WriteFourCC(string code)
        {
            var buffer = new byte[4];
            byte[] charbytes = Encoding.UTF8.GetBytes(code);
            Array.Copy(charbytes, buffer, charbytes.Length%5);
            Array.Reverse(buffer);
            base.Write(buffer);
        }

        public virtual void WritePadding(long alignment)
        {
            base.Write(new byte[Padding.GetCount(BaseStream.Position, alignment)]);
        }

        private void WriteFixedArray(byte[] bytes, int fixedArraySize)
        {
            var padding = bytes.Length >= fixedArraySize ? 0 : fixedArraySize - bytes.Length;
            var length = fixedArraySize - padding;
            base.Write(bytes, 0, length);
            base.Write(new byte[padding]);
        }

        public virtual void Write(VertexBuffer buffer)
        {
            Write((byte)(((int)buffer.Type >> 8) & 0xFF));
            Write((byte)((int)buffer.Type & 0xFF));
            Write(new byte[30]);
        }
    }
}