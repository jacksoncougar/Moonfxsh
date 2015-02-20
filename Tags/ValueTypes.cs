using Moonfish.Graphics;
using Moonfish.Guerilla;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace Moonfish.Tags
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    class GuerillaTypeAttribute : Attribute
    {
        field_type fieldType;
        public field_type FieldType { get { return fieldType; } }

        public GuerillaTypeAttribute(field_type fieldType)
        {
            this.fieldType = fieldType;
        }
    }

    [GuerillaType(field_type._field_vertex_buffer)]
    [StructLayout(LayoutKind.Sequential, Size = 32)]
    public struct VertexBuffer
    {
        public VertexAttributeType Type; //?
        public byte[] Data;
    }

    [GuerillaType(field_type._field_string_id)]
    [GuerillaType(field_type._field_old_string_id)]
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct StringID
    {
        [FieldOffset(0)]
        public readonly sbyte Length;
        [FieldOffset(2)]
        public readonly short Index;

        public StringID(int interleavedValue)
        {
            Length = (sbyte)(interleavedValue >> 24);
            Index = (short)(interleavedValue & 0x0000FFFF);
        }
        public StringID(short index, sbyte length)
        {
            Index = index;
            Length = length;
        }
        public static explicit operator int(StringID stringId)
        {
            return (stringId.Length << 24) | byte.MinValue | (ushort)stringId.Index;
        }
        public static explicit operator StringID(int i)
        {
            return new StringID(i);
        }
        public static bool operator ==(StringID first, StringID second)
        {
            return first.Index == second.Index && first.Length == second.Length;
        }
        public static bool operator !=(StringID first, StringID second)
        {
            return !(first == second);
        }
        public static StringID Zero { get { return new StringID(0, 0); } }

        public override string ToString()
        {
            var value = Halo2.Strings[this];
            return value;
        }
    }

    [GuerillaType(field_type._field_tag)]
    [StructLayout(LayoutKind.Sequential, Size = 4)]
    public struct TagClass : IEquatable<TagClass>, IEquatable<string>
    {
        private readonly byte a;
        private readonly byte b;
        private readonly byte c;
        private readonly byte d;

        public TagClass(params byte[] bytes)
        {
            a = default(byte);
            b = default(byte);
            c = default(byte);
            d = default(byte);
            switch (bytes.Length)
            {
                case 4:
                    d = bytes[3];
                    goto case 3;
                case 3:
                    c = bytes[2];
                    goto case 2;
                case 2:
                    b = bytes[1];
                    goto case 1;
                case 1:
                    a = bytes[0];
                    break;
                case 0:                 // Check if there are no bytes passed
                    break;
                default:                // The defualt case is now byte.Length > 4 so goto case 4 and truncate
                    goto case 4;
            }
        }

        public TagClass(int value)
            : this(BitConverter.GetBytes(value))
        {
        }

        public static explicit operator TagClass(string str)
        {
            return new TagClass(Encoding.UTF8.GetBytes(new string(str.ToCharArray().Reverse().ToArray())));
        }

        public static explicit operator string(TagClass tagclass)
        {
            return tagclass.ToString();
        }

        public static explicit operator TagClass(int integer)
        {
            return new TagClass(BitConverter.GetBytes(integer));
        }

        public static explicit operator int(TagClass type)
        {
            return BitConverter.ToInt32(new byte[] { type.a, type.b, type.c, type.d }, 0);
        }

        public static bool operator ==(TagClass object1, TagClass object2)
        {
            return (int)object1 == (int)object2;
        }

        public static bool operator !=(TagClass object1, TagClass object2)
        {
            return (int)object1 != (int)object2;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is TagClass)) return false;
            return this == (TagClass)obj;
        }

        public override int GetHashCode()
        {
            int i = (int)this; return i.GetHashCode();
        }

        public override string ToString()
        {
            if (a == 0xFF && b == 0xFF && c == 0xFF && d == 0xFF) return "null";
            return Encoding.UTF8.GetString(new byte[] { d, c, b, a });
        }

        bool IEquatable<TagClass>.Equals(TagClass other)
        {
            return this == other;
        }

        bool IEquatable<string>.Equals(string other)
        {
            return this == (TagClass)other;
        }

        public string ToSafeString()
        {
            var value = this.ToString();
            var illegalChars = new List<char>(new[] { '<', '>' });
            illegalChars.ForEach(x => { value = value.Replace(x, '_'); });
            illegalChars = Path.GetInvalidFileNameChars().ToList();
            illegalChars.ForEach(x => { value = value.Replace(x.ToString(), string.Empty); });
            return value.Trim();
        }

        public static TagClass Null = new TagClass(0xFF, 0xFF, 0xFF, 0xFF);
    }

    [StructLayout(LayoutKind.Sequential, Size = 4)]
    [GuerillaType(field_type._field_moonfish_ident)]    
    public struct TagIdent : IEquatable<TagIdent>
    {
        const short SaltConstant = -7820;

        public readonly short Index;
        public readonly short Salt;

        public short SaltedIndex { get { return (short)(Salt - SaltConstant); } }

        public static bool IsNull(TagIdent value)
        {
            return value.Index == -1;
        }

        public TagIdent(short index)
            : this(index, (short)(SaltConstant + index))
        {
        }
        public TagIdent(short index, short salt)
        {
            this.Index = index;
            this.Salt = salt;
        }

        public static implicit operator int(TagIdent item)
        {
            return (item.Salt << 16) | (ushort)item.Index;
        }

        public static implicit operator TagIdent(int i)
        {
            return new TagIdent((short)(i & 0x0000FFFF), (short)((i & 0xFFFF0000) >> 16));
        }

        public static bool operator ==(TagIdent object1, TagIdent object2)
        {
            return object1.Equals(object2);
        }

        public static bool operator !=(TagIdent object1, TagIdent object2)
        {
            return !(object1 == object2);
        }

        public override string ToString()
        {
            return String.Format(@"{0}:{1} - {2}", Index, Convert.ToString(Salt, 16).ToUpper(), Halo2.Paths[Index]);
        }

        public const int NullIdentifier = -1;

        public bool Equals(TagIdent other)
        {
            return Index.Equals(other.Index) && Salt.Equals(other.Salt);
        }
    }

    [GuerillaType(field_type._field_tag_reference)]
    [StructLayout(LayoutKind.Sequential, Size = 8)]
    public struct TagReference
    {
        public readonly TagClass Class;
        public readonly TagIdent Ident;

        public TagReference(TagClass tagClass, TagIdent tagID)
        {
            this.Class = tagClass;
            this.Ident = tagID;
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}", Class, Ident);
        }
    }

    class TagReferenceAttribute : TagFieldAttribute
    {
        TagClass referenceClass;

        public TagReferenceAttribute(string tagClassString)
        {
            referenceClass = new TagClass(Encoding.UTF8.GetBytes(tagClassString));
        }
    }


    [GuerillaType(field_type._field_real_rgb_color)]
    [StructLayout(LayoutKind.Sequential, Size = 12)]
    public struct ColorR8G8B8
    {
        public readonly float R;
        public readonly float G;
        public readonly float B;

        public ColorR8G8B8(float r, float g, float b)
        {
            this.R = r.Clamp(0, 1);
            this.G = g.Clamp(0, 1);
            this.B = b.Clamp(0, 1);
        }
    }

    [GuerillaType(field_type._field_rgb_color)]
    [StructLayout(LayoutKind.Sequential, Size = 3)]
    public struct RGBColor
    {
        public byte Red;
        public byte Green;
        public byte Blue;
    }

    [GuerillaType(field_type._field_argb_color)]
    [StructLayout(LayoutKind.Sequential, Size = 4)]
    public struct ColourA1R1G1B1
    {
        public byte Alpha;
        public byte Red;
        public byte Green;
        public byte Blue;

        public ColourA1R1G1B1(byte a, byte r, byte g, byte b)
        {
            Alpha = a; Red = r; Green = g; Blue = b;
        }
    }

    [GuerillaType(field_type._field_string)]
    [StructLayout(LayoutKind.Sequential, Size = 32)]
    public struct String32
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public char[] value;

        public String32(string stringValue)
        {
            value = new char[32];
            var length = stringValue.Length > 32 ? 32 : stringValue.Length;
            Array.Copy(stringValue.ToArray<char>(), value, length);
        }
    }

    [GuerillaType(field_type._field_long_string)]
    [StructLayout(LayoutKind.Sequential, Size = 256)]
    public struct String256
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public char[] value;
        public String256(string stringValue)
        {
            value = new char[256];
            var length = stringValue.Length > 256 ? 256 : stringValue.Length;
            Array.Copy(stringValue.ToArray<char>(), value, length);
        }
    }

    [GuerillaType(field_type._field_byte_block_flags)]
    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct BlockFlags8
    {
        public byte flags;

        public BlockFlags8(byte flags)
        {
            this.flags = flags;
        }
    }

    [GuerillaType(field_type._field_word_block_flags)]
    [StructLayout(LayoutKind.Sequential, Size = 2)]
    public struct BlockFlags16
    {
        public short flags;

        public BlockFlags16(short flags)
        {
            this.flags = flags;
        }
    }

    [GuerillaType(field_type._field_long_block_flags)]
    [StructLayout(LayoutKind.Sequential, Size = 4)]
    public struct BlockFlags32
    {
        public int flags;

        public BlockFlags32(int flags)
        {
            this.flags = flags;
        }
    }

    [GuerillaType(field_type._field_char_block_index1)]
    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct ByteBlockIndex1
    {
        byte index;

        public static explicit operator short(ByteBlockIndex1 shortBlockIndex)
        {
            return shortBlockIndex.index;
        }

        public static explicit operator ByteBlockIndex1(byte value)
        {
            return new ByteBlockIndex1 { index = value };
        }

        public override string ToString()
        {
            return index.ToString();
        }

    }

    [GuerillaType(field_type._field_short_block_index1)]
    [StructLayout(LayoutKind.Sequential, Size = 2)]
    public struct ShortBlockIndex1
    {
        short index;

        public static explicit operator short(ShortBlockIndex1 shortBlockIndex)
        {
            return shortBlockIndex.index;
        }

        public static explicit operator ShortBlockIndex1(short value)
        {
            return new ShortBlockIndex1 { index = value };
        }

        public override string ToString()
        {
            return index.ToString();
        }

    }

    [GuerillaType(field_type._field_long_block_index1)]
    [StructLayout(LayoutKind.Sequential, Size = 4)]
    public struct LongBlockIndex1
    {
        int index;

        public static explicit operator int(LongBlockIndex1 blockIndex)
        {
            return blockIndex.index;
        }

        public static explicit operator LongBlockIndex1(int value)
        {
            return new LongBlockIndex1 { index = value };
        }

        public override string ToString()
        {
            return index.ToString();
        }

    }

    [GuerillaType(field_type._field_char_block_index2)]
    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct ByteBlockIndex2
    {
        byte index;

        public static explicit operator short(ByteBlockIndex2 blockIndex)
        {
            return blockIndex.index;
        }

        public static explicit operator ByteBlockIndex2(byte value)
        {
            return new ByteBlockIndex2 { index = value };
        }

        public override string ToString()
        {
            return index.ToString();
        }

    }

    [GuerillaType(field_type._field_short_block_index2)]
    [StructLayout(LayoutKind.Sequential, Size = 2)]
    public struct ShortBlockIndex2
    {
        short index;

        public static explicit operator short(ShortBlockIndex2 blockIndex)
        {
            return blockIndex.index;
        }

        public static explicit operator ShortBlockIndex2(short value)
        {
            return new ShortBlockIndex2 { index = value };
        }

        public override string ToString()
        {
            return index.ToString();
        }

    }

    [GuerillaType(field_type._field_long_block_index2)]
    [StructLayout(LayoutKind.Sequential, Size = 4)]
    public struct LongBlockIndex2
    {
        int index;

        public static explicit operator int(LongBlockIndex2 blockIndex)
        {
            return blockIndex.index;
        }

        public static explicit operator LongBlockIndex2(int value)
        {
            return new LongBlockIndex2 { index = value };
        }

        public override string ToString()
        {
            return index.ToString();
        }

    }



    [GuerillaType(field_type._field_point_2d)]
    [StructLayout(LayoutKind.Sequential, Size = 4)]

    public struct Point : IWriteable
    {
        short X { get; set; }
        short Y { get; set; }

        public Point(short x, short y)
            : this()
        {
            X = x;
            Y = y;
        }

        public Point(BinaryReader binaryReader)
            : this(binaryReader.ReadInt16(), binaryReader.ReadInt16())
        {

        }

        void IWriteable.Write(BinaryWriter binaryWriter)
        {
            binaryWriter.Write(this.X);
            binaryWriter.Write(this.Y);
        }
    }


}