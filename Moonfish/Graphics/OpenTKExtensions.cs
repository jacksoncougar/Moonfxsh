using System.IO;
using OpenTK;

namespace Moonfish
{
    public static class OpenTKExtensions
    {
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