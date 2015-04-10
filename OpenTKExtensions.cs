using System.IO;
using OpenTK;

namespace Moonfish
{
    public static class OpenTKExtensions
    {
        public static void Write(this BinaryWriter binary_writer, Vector3 vector3)
        {
            binary_writer.Write(vector3.X);
            binary_writer.Write(vector3.Y);
            binary_writer.Write(vector3.Z);
        }

        public static Vector3 ReadVector3(this BinaryReader binary_reader)
        {
            return new Vector3(binary_reader.ReadSingle(), binary_reader.ReadSingle(), binary_reader.ReadSingle());
        }

        public static Vector4 ReadVector4(this BinaryReader binaryReader)
        {
            return new Vector4(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle());
        }

        public static void Write(this BinaryWriter binary_writer, Vector2 value)
        {
            binary_writer.Write(value.X);
            binary_writer.Write(value.Y);
        }

        public static Vector2 ReadVector2(this BinaryReader binary_reader)
        {
            return new Vector2(binary_reader.ReadSingle(), binary_reader.ReadSingle());
        }

        //public static void Write(this BinaryWriter binary_writer, Vector3T value)
        //{
        //    binary_writer.Write((uint)value);
        //}
        //public static Vector3T ReadVector3T(this BinaryReader binary_reader)
        //{
        //    return new Vector3T(binary_reader.ReadUInt32());
        //}

        public static void Write(this BinaryWriter binary_writer, Quaternion quaternion)
        {
            binary_writer.Write(quaternion.X);
            binary_writer.Write(quaternion.Y);
            binary_writer.Write(quaternion.Z);
            binary_writer.Write(quaternion.W);
        }

        public static Quaternion ReadQuaternion(this BinaryReader binary_reader)
        {
            return new Quaternion(binary_reader.ReadSingle(), binary_reader.ReadSingle(), binary_reader.ReadSingle(), binary_reader.ReadSingle());
        }
    }
}