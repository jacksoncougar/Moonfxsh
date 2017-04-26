using System.IO;
using System.Text;
using JetBrains.Annotations;
using Moonfish.Graphics;
using Moonfish.Model;
using Moonfish.Tags;
using OpenTK;

namespace Moonfish.Guerilla
{
    /// <summary>
    /// Reads blam! data types as binary values in a specific encoding.
    /// </summary>
    /// <seealso cref="System.IO.BinaryReader" />
    public class BlamBinaryReader : BinaryReader
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="BlamBinaryReader"/> class.
        /// </summary>
        /// <param name="input">The stream to read from.</param>
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
            return (ByteBlockIndex1)ReadByte();
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
            var color = new ColourR1G1B1 { R = ReadByte(), G = ReadByte(), B = ReadByte() };
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
            return (LongBlockIndex1)ReadInt32();
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
            return (ShortBlockIndex1)ReadInt16();
        }

        public virtual ShortBlockIndex2 ReadShortBlockIndex2()
        {
            return (ShortBlockIndex2)ReadInt16();
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
            return (StringIdent)ReadInt32();
        }

        public virtual TagClass ReadTagClass()
        {
            return (TagClass)ReadInt32();
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

        public VertexAttributeType ReadVertexAttributeType()
        {
            var msb = ReadByte();
            var lsb = ReadByte();
            var type = (VertexAttributeType)(msb << 8 | lsb);
            return type;
        }

        public virtual VertexBuffer ReadVertexBuffer()
        {
            var buffer = new VertexBuffer { Type = ReadVertexAttributeType() };
            ReadBytes(30);
            return buffer;
        }
    }
}