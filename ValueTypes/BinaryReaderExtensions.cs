using Moonfish.Graphics;
using OpenTK;
using System.IO;
using System.Linq;
using System.Text;
using Moonfish.Guerilla.Tags;
using Moonfish.ResourceManagement;

namespace Moonfish.Tags
{
    internal static class BinaryReaderExtensions
    {
        public static void Write(this BinaryWriter binaryWriter, BlamPointer blamPointer)
        {
            binaryWriter.Write(blamPointer.ElementCount);
            binaryWriter.Write(blamPointer.ElementCount > 0 ? blamPointer.StartAddress : 0);
        }

        public static BlamPointer ReadBlamPointer(this BinaryReader binaryReader, int elementSize)
        {
            var resourceStream = binaryReader.BaseStream as ResourceStream;
            if (resourceStream == null)
            {
                return new BlamPointer(binaryReader.ReadInt32(), binaryReader.ReadInt32(), elementSize);
            }

            var offset = resourceStream.Position;
            binaryReader.BaseStream.Seek(8, SeekOrigin.Current);
            var resource =
                resourceStream.Resources.SingleOrDefault(
                    x =>
                        x.PrimaryLocator == offset &&
                        x.Type != GlobalGeometryBlockResourceBlock.TypeEnum.VertexBuffer);

            if (resource == null)
            {
                return new BlamPointer(0, 0, elementSize);
            }
            if (resource.Type == GlobalGeometryBlockResourceBlock.TypeEnum.TagData)
            {
                var count = resource.ResourceDataSize;
                var address = resource.ResourceDataOffset + resourceStream.HeaderSize;
                return new BlamPointer(count, address, elementSize);
            }
            else
            {
                var count = resource.ResourceDataSize / resource.SecondaryLocator;
                var address = resource.ResourceDataOffset + resourceStream.HeaderSize;
                return new BlamPointer(count, address, elementSize);
            }
        }

        public static VertexBuffer ReadVertexBuffer(this BinaryReader binaryReader)
        {
            var buffer = new VertexBuffer() {Type = binaryReader.ReadVertexAttributeType()};
            binaryReader.ReadBytes(30);
            return buffer;
        }

        public static String32 ReadString32(this BinaryReader binaryReader)
        {
            return new String32(new string(Encoding.UTF8.GetChars(binaryReader.ReadBytes(32))));
        }

        public static String256 ReadString256(this BinaryReader binaryReader)
        {
            return new String256(new string(Encoding.UTF8.GetChars(binaryReader.ReadBytes(256))));
        }

        public static StringIdent ReadStringIdent(this BinaryReader binaryReader)
        {
            return new StringIdent(binaryReader.ReadInt32());
        }

        public static ColourR1G1B1 ReadColourR1G1B1(this BinaryReader binaryReader)
        {
            var color = new ColourR1G1B1
            {
                R = binaryReader.ReadByte(),
                G = binaryReader.ReadByte(),
                B = binaryReader.ReadByte()
            };
            return color;
        }

        public static TagIdent ReadTagIdent(this BinaryReader binaryReader)
        {
            return new TagIdent(binaryReader.ReadInt16(), binaryReader.ReadInt16());
        }

        public static TagReference ReadTagReference(this BinaryReader binaryReader)
        {
            return new TagReference(binaryReader.ReadTagClass(), binaryReader.ReadTagIdent());
        }

        public static BlockFlags8 ReadBlockFlags8(this BinaryReader binaryReader)
        {
            return new BlockFlags8(binaryReader.ReadByte());
        }

        public static BlockFlags16 ReadBlockFlags16(this BinaryReader binaryReader)
        {
            return new BlockFlags16(binaryReader.ReadInt16());
        }

        public static ByteBlockIndex1 ReadByteBlockIndex1(this BinaryReader binaryReader)
        {
            return (ByteBlockIndex1) binaryReader.ReadByte();
        }

        public static ShortBlockIndex1 ReadShortBlockIndex1(this BinaryReader binaryReader)
        {
            return (ShortBlockIndex1) binaryReader.ReadInt16();
        }

        public static LongBlockIndex1 ReadLongBlockIndex1(this BinaryReader binaryReader)
        {
            return (LongBlockIndex1) binaryReader.ReadInt32();
        }

        public static ShortBlockIndex2 ReadShortBlockIndex2(this BinaryReader binaryReader)
        {
            return (ShortBlockIndex2) binaryReader.ReadInt16();
        }

        public static Quaternion ReadQuaternion(this BinaryReader binaryReader)
        {
            float i = binaryReader.ReadSingle(),
                j = binaryReader.ReadSingle(),
                k = binaryReader.ReadSingle(),
                l = binaryReader.ReadSingle();
            return new Quaternion(l, k, j, i);
        }

        public static ColourR8G8B8 ReadColorR8G8B8(this BinaryReader binaryReader)
        {
            return new ColourR8G8B8(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle());
        }

        public static ColourA1R1G1B1 ReadColourA1R1G1B1(this BinaryReader binaryReader)
        {
            return new ColourA1R1G1B1(
                binaryReader.ReadByte(),
                binaryReader.ReadByte(),
                binaryReader.ReadByte(),
                binaryReader.ReadByte());
        }

        public static Point ReadPoint(this BinaryReader binaryReader)
        {
            return new Point(binaryReader.ReadInt16(), binaryReader.ReadInt16());
        }
    }
}