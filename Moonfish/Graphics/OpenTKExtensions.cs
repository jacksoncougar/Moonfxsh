using System;
using System.IO;
using System.Runtime.InteropServices;
using Moonfish.Guerilla;
using OpenTK;

namespace Moonfish
{
    public static class OpenTkExtensions
    {
        [StructLayout(LayoutKind.Explicit)]
        public unsafe struct FloatByteUnion
        {
            [FieldOffset( 0 )] public fixed byte bytes [sizeof ( float ) * 16];
            [FieldOffset( 0 )] public fixed float floats [16];
        }

        private static byte[] byteBuffer = new byte[sizeof(float) * 16];
        public static void Write(this BinaryWriter binaryWriter, ref Matrix4 value)
        {
            float[] elements =
            {
                value.M11,
                value.M12,
                value.M13,
                value.M14,

                value.M21,
                value.M22,
                value.M23,
                value.M24,

                value.M31,
                value.M32,
                value.M33,
                value.M34,

                value.M41,
                value.M42,
                value.M43,
                value.M44,
            };
            Buffer.BlockCopy( elements, 0, byteBuffer, 0, byteBuffer.Length );
            binaryWriter.Write(byteBuffer);
        }
        public static void Write(this BinaryWriter binaryWriter, Vector3 vector3)
        {
            binaryWriter.Write(vector3.X);
            binaryWriter.Write(vector3.Y);
            binaryWriter.Write(vector3.Z);
        }
        public static void Write(this BinaryWriter binaryWriter, Vector4 vector4)
        {
            binaryWriter.Write(vector4.X);
            binaryWriter.Write(vector4.Y);
            binaryWriter.Write(vector4.Z);
            binaryWriter.Write(vector4.W);
        }

        public static Vector3 ReadVector3(this BinaryReader binaryReader)
        {
            return new Vector3(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle());
        }

        public static Vector4 ReadVector4(this BinaryReader binaryReader)
        {
            return new Vector4(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(),
                binaryReader.ReadSingle());
        }

        public static void Write(this BinaryWriter binaryWriter, Vector2 value)
        {
            binaryWriter.Write(value.X);
            binaryWriter.Write(value.Y);
        }

        public static Vector2 ReadVector2(this BinaryReader binaryReader)
        {
            return new Vector2(binaryReader.ReadSingle(), binaryReader.ReadSingle());
        }

        //public static void Write(this BinaryWriter binary_writer, Vector3T value)
        //{
        //    binary_writer.Write((uint)value);
        //}
        //public static Vector3T ReadVector3T(this BinaryReader binary_reader)
        //{
        //    return new Vector3T(binary_reader.ReadUInt32());
        //}

        public static void Write(this BinaryWriter binaryWriter, Quaternion quaternion)
        {
            binaryWriter.Write(quaternion.X);
            binaryWriter.Write(quaternion.Y);
            binaryWriter.Write(quaternion.Z);
            binaryWriter.Write(quaternion.W);
        }

        public static Quaternion ReadQuaternion(this BinaryReader binaryReader)
        {
            return new Quaternion(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(),
                binaryReader.ReadSingle());
        }
    }
}