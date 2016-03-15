using Moonfish.Model;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Text;

namespace Moonfish
{
    public static class Extensions
    {
        public static string ReadFixedString(this BinaryReader binreader, int length, bool trim_null_characters = true)
        {
            if (trim_null_characters)
                return Encoding.UTF8.GetString(binreader.ReadBytes(length)).Trim(char.MinValue);
            else return Encoding.UTF8.GetString(binreader.ReadBytes(length));
        }

        public static void WriteFourCC(this BinaryWriter writer, string code)
        {
            byte[] buffer = new byte[4];
            byte[] charbytes = Encoding.UTF8.GetBytes(code);
            Array.Copy(charbytes, buffer, charbytes.Length%5);
            Array.Reverse(buffer);
            writer.Write(buffer);
        }

        public static void WritePadding(this BinaryWriter writer, int alignment)
        {
            writer.Write(new byte[Padding.GetCount(writer.BaseStream.Position, alignment)]);
        }

        public static void Write(this BinaryWriter binary_writer, TagClass tclass)
        {
            binary_writer.Write((int) tclass);
        }

        public static TagClass ReadTagClass(this BinaryReader binary_reader)
        {
            return (TagClass) binary_reader.ReadInt32();
        }

        public static TagIdent ReadTagIdent(this BinaryReader binary_reader)
        {
            return (TagIdent) binary_reader.ReadInt32();
        }

        public static void Write(this BinaryWriter binary_writer, Range range)
        {
            binary_writer.Write(range.Min);
            binary_writer.Write(range.Max);
        }

        public static Range ReadRange(this BinaryReader binary_reader)
        {
            return new Range(binary_reader.ReadSingle(), binary_reader.ReadSingle());
        }

        public static void Write(this BinaryWriter binary_writer, StringIdent stringIdent)
        {
            binary_writer.Write((int) stringIdent);
        }

        public static StringIdent ReadStringID(this BinaryReader binary_reader)
        {
            return (StringIdent) binary_reader.ReadInt32();
        }

        public static double[] ToArray(this Vector3 vector3)
        {
            return new double[] {vector3.X, vector3.Y, vector3.Z};
        }
    }
}