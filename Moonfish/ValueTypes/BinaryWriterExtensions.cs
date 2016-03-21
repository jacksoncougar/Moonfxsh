using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using OpenTK;

namespace Moonfish.Tags
{
    internal static class BinaryWriterExtensions
    {
        public static void Write(this BinaryWriter binaryWriter, VertexBuffer value)
        {
            binaryWriter.Write((int) value.Type);
            binaryWriter.Write(new byte[28]);
        }

        public static void Write(this BinaryWriter binaryWriter, String32 value)
        {
            var bytes = Encoding.UTF8.GetBytes(value.value);
            WriteFixedArray(binaryWriter, bytes, 32);
        }

        public static void Write(this BinaryWriter binaryWriter, String256 value)
        {
            var bytes = Encoding.UTF8.GetBytes(value.value);
            WriteFixedArray(binaryWriter, bytes, 256);
        }

        private static void WriteFixedArray(BinaryWriter binaryWriter, byte[] bytes, int fixedArraySize)
        {
            var padding = bytes.Length >= fixedArraySize ? 0 : fixedArraySize - bytes.Length;
            var length = fixedArraySize - padding;
            binaryWriter.Write(bytes, 0, length);
            binaryWriter.Write(new byte[padding]);
        }

        public static void Write(this BinaryWriter binaryWriter, StringIdent value)
        {
            binaryWriter.Write((int) value);
        }

        public static void Write(this BinaryWriter binaryWriter, ColourR1G1B1 value)
        {
            binaryWriter.Write(value.R);
            binaryWriter.Write(value.G);
            binaryWriter.Write(value.B);
        }

        public static void Write(this BinaryWriter binary, TagIdent value)
        {
            binary.Write((int) value);
        }

        public static void Write(this BinaryWriter binaryWriter, TagReference value)
        {
            binaryWriter.Write((int) value.Class);
            binaryWriter.Write((int) value.Ident);
        }

        public static void Write(this BinaryWriter binaryWriter, BlockFlags8 value)
        {
            binaryWriter.Write(value.flags);
        }

        public static void Write(this BinaryWriter binaryWriter, BlockFlags16 value)
        {
            binaryWriter.Write((byte)value.Type);
            binaryWriter.Write((byte)value.Source);
        }

        public static void Write(this BinaryWriter binaryWriter, BlockFlags32 value)
        {
            binaryWriter.Write(value.flags);
        }

        public static void Write(this BinaryWriter binaryWriter, ByteBlockIndex1 value)
        {
            binaryWriter.Write((byte) value);
        }

        public static void Write(this BinaryWriter binaryWriter, ShortBlockIndex1 value)
        {
            binaryWriter.Write(value);
        }

        public static void Write(this BinaryWriter binaryWriter, LongBlockIndex1 value)
        {
            binaryWriter.Write((int) value);
        }

        public static void Write(this BinaryWriter binaryWriter, ByteBlockIndex2 value)
        {
            binaryWriter.Write((byte) value);
        }

        public static void Write(this BinaryWriter binaryWriter, ShortBlockIndex2 value)
        {
            binaryWriter.Write((short) value);
        }

        public static void Write(this BinaryWriter binaryWriter, LongBlockIndex2 value)
        {
            binaryWriter.Write((int) value);
        }

        public static void Write(this BinaryWriter binaryWriter, Quaternion value)
        {
            binaryWriter.Write(value.W);
            binaryWriter.Write(value.Z);
            binaryWriter.Write(value.Y);
            binaryWriter.Write(value.X);
        }

        public static void Write(this BinaryWriter binaryWriter, Vector4 value)
        {
            binaryWriter.Write(value.X);
            binaryWriter.Write(value.Y);
            binaryWriter.Write(value.Z);
            binaryWriter.Write(value.W);
        }

        public static void Write(this BinaryWriter binaryWriter, Vector3 value)
        {
            binaryWriter.Write(value.X);
            binaryWriter.Write(value.Y);
            binaryWriter.Write(value.Z);
        }

        public static void Write(this BinaryWriter binaryWriter, Vector2 value)
        {
            binaryWriter.Write(value.X);
            binaryWriter.Write(value.Y);
        }

        public static void Write(this BinaryWriter binaryWriter, ColourA1R1G1B1 value)
        {
            binaryWriter.Write(value.A);
            binaryWriter.Write(value.R);
            binaryWriter.Write(value.G);
            binaryWriter.Write(value.B);
        }

        public static void Write(this BinaryWriter binaryWriter, ColourR8G8B8 value)
        {
            binaryWriter.Write(value.R);
            binaryWriter.Write(value.G);
            binaryWriter.Write(value.B);
        }

        public static void Write(this BinaryWriter binaryWriter, Point value)
        {
            binaryWriter.Write(value.X);
            binaryWriter.Write(value.Y);
        }
    }
}