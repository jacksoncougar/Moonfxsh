using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Moonfish.Graphics;
using Moonfish.Guerilla;

namespace Moonfish.Tags
{
    [AttributeUsage( AttributeTargets.All, AllowMultiple = true )]
    internal class GuerillaTypeAttribute : Attribute
    {
        public GuerillaTypeAttribute( MoonfishFieldType fieldType )
        {
            FieldType = fieldType;
        }

        public MoonfishFieldType FieldType { get; private set; }
    }

    [GuerillaType( MoonfishFieldType.FieldVertexBuffer )]
    [StructLayout( LayoutKind.Sequential, Size = 32 )]
    public struct VertexBuffer
    {
        public VertexAttributeType Type; //?
        public byte[] Data;
    }

    [GuerillaType( MoonfishFieldType.FieldStringId )]
    [GuerillaType( MoonfishFieldType.FieldOldStringId )]
    [StructLayout( LayoutKind.Explicit, Size = 4 )]
    public struct StringID
    {
        [FieldOffset( 0 )] public readonly sbyte Length;
        [FieldOffset( 2 )] public readonly short Index;

        public StringID( int interleavedValue )
        {
            Length = ( sbyte ) ( interleavedValue >> 24 );
            Index = ( short ) ( interleavedValue & 0x0000FFFF );
        }

        public StringID( short index, sbyte length )
        {
            Index = index;
            Length = length;
        }

        public static explicit operator int( StringID stringId )
        {
            return ( stringId.Length << 24 ) | byte.MinValue | ( ushort ) stringId.Index;
        }

        public static explicit operator StringID( int i )
        {
            return new StringID( i );
        }

        public static bool operator ==( StringID first, StringID second )
        {
            return first.Index == second.Index && first.Length == second.Length;
        }

        public static bool operator !=( StringID first, StringID second )
        {
            return !( first == second );
        }

        public static StringID Zero
        {
            get { return new StringID( 0, 0 ); }
        }

        public override string ToString( )
        {
            var value = Halo2.Strings[ this ];
            return value;
        }
    }


    [StructLayout( LayoutKind.Sequential, Size = 4 )]
    [GuerillaType( MoonfishFieldType.FieldMoonfishIdent )]
    public struct TagIdent : IEquatable<TagIdent>
    {
        private const short SaltConstant = -7820;

        public readonly short Index;
        public readonly short Salt;

        public short SaltedIndex
        {
            get { return ( short ) ( Salt - SaltConstant ); }
        }

        public static bool IsNull( TagIdent value )
        {
            return value.Index == -1;
        }

        public TagIdent( short index )
            : this( index, ( short ) ( SaltConstant + index ) )
        {
        }

        public TagIdent( short index, short salt )
        {
            Index = index;
            Salt = salt;
        }

        public static explicit operator int( TagIdent item )
        {
            return ( item.Salt << 16 ) | ( ushort ) item.Index;
        }

        public static explicit operator TagIdent( int i )
        {
            return new TagIdent( ( short ) ( i & 0x0000FFFF ), ( short ) ( ( i & 0xFFFF0000 ) >> 16 ) );
        }

        public static TagIdent operator ++(TagIdent object1)
        {
            return new TagIdent((short)(object1.Index + 1), (short)(object1.Salt + 1));
        }

        public static TagIdent operator --(TagIdent object1)
        {
            return new TagIdent((short)(object1.Index - 1), (short)(object1.Salt - 1));
        }

        public static bool operator ==( TagIdent object1, TagIdent object2 )
        {
            return object1.Equals( object2 );
        }

        public override bool Equals( object obj )
        {
            var other = obj as TagIdent?;
            if ( other == null ) return false;
            return Equals( other.Value );
        }

        public override int GetHashCode( )
        {
            return SaltedIndex;
        }

        public static bool operator !=( TagIdent object1, TagIdent object2 )
        {
            return !( object1 == object2 );
        }

        public override string ToString( )
        {
            return String.Format( @"{0}:{1} - {2}", Index, Convert.ToString( Salt, 16 ).ToUpper( ), Halo2.Paths[ Index ] );
        }

        public static TagIdent NullIdentifier = ( TagIdent ) ( -1 );

        public bool Equals( TagIdent other )
        {
            return Index.Equals( other.Index ) && Salt.Equals( other.Salt );
        }
    }

    [GuerillaType( MoonfishFieldType.FieldTagReference )]
    [StructLayout( LayoutKind.Sequential, Size = 8 )]
    public struct TagReference
    {
        public readonly TagClass Class;
        public readonly TagIdent Ident;

        public TagReference( TagClass tagClass, TagIdent tagID )
        {
            Class = tagClass;
            Ident = tagID;
        }

        public override string ToString( )
        {
            return string.Format( "{0}, {1}", Class, Ident );
        }
    }

    internal class TagReferenceAttribute : TagFieldAttribute
    {
        private TagClass referenceClass;

        public TagReferenceAttribute( string tagClassString )
        {
            referenceClass = new TagClass( Encoding.UTF8.GetBytes( tagClassString ) );
        }
    }


    [GuerillaType( MoonfishFieldType.FieldRealRgbColor )]
    [StructLayout( LayoutKind.Sequential, Size = 12 )]
    public struct ColorR8G8B8
    {
        public readonly float R;
        public readonly float G;
        public readonly float B;

        public ColorR8G8B8( float r, float g, float b )
        {
            R = r.Clamp( 0, 1 );
            G = g.Clamp( 0, 1 );
            B = b.Clamp( 0, 1 );
        }
    }

    [GuerillaType( MoonfishFieldType.FieldRgbColor )]
    [StructLayout( LayoutKind.Sequential, Size = 3 )]
    public struct RGBColor
    {
        public byte Red;
        public byte Green;
        public byte Blue;
    }

    [GuerillaType( MoonfishFieldType.FieldArgbColor )]
    [StructLayout( LayoutKind.Sequential, Size = 4 )]
    public struct ColourA1R1G1B1
    {
        public byte Alpha;
        public byte Red;
        public byte Green;
        public byte Blue;

        public ColourA1R1G1B1( byte a, byte r, byte g, byte b )
        {
            Alpha = a;
            Red = r;
            Green = g;
            Blue = b;
        }
    }

    [GuerillaType( MoonfishFieldType.FieldString )]
    [StructLayout( LayoutKind.Sequential, Size = 32 )]
    public struct String32
    {
        [MarshalAs( UnmanagedType.ByValArray, SizeConst = 32 )] public char[] value;

        public String32( string stringValue )
        {
            value = new char[32];
            var length = stringValue.Length > 32 ? 32 : stringValue.Length;
            Array.Copy( stringValue.ToArray( ), value, length );
        }
    }

    [GuerillaType( MoonfishFieldType.FieldLongString )]
    [StructLayout( LayoutKind.Sequential, Size = 256 )]
    public struct String256
    {
        [MarshalAs( UnmanagedType.ByValArray, SizeConst = 256 )] public char[] value;

        public String256( string stringValue )
        {
            value = new char[256];
            var length = stringValue.Length > 256 ? 256 : stringValue.Length;
            Array.Copy( stringValue.ToArray( ), value, length );
        }
    }

    [GuerillaType( MoonfishFieldType.FieldByteBlockFlags )]
    [StructLayout( LayoutKind.Sequential, Size = 1 )]
    public struct BlockFlags8
    {
        public byte flags;

        public BlockFlags8( byte flags )
        {
            this.flags = flags;
        }
    }

    [GuerillaType( MoonfishFieldType.FieldWordBlockFlags )]
    [StructLayout( LayoutKind.Sequential, Size = 2 )]
    public struct BlockFlags16
    {
        public short flags;

        public BlockFlags16( short flags )
        {
            this.flags = flags;
        }
    }

    [GuerillaType( MoonfishFieldType.FieldLongBlockFlags )]
    [StructLayout( LayoutKind.Sequential, Size = 4 )]
    public struct BlockFlags32
    {
        public int flags;

        public BlockFlags32( int flags )
        {
            this.flags = flags;
        }
    }

    [GuerillaType( MoonfishFieldType.FieldCharBlockIndex1 )]
    [StructLayout( LayoutKind.Sequential, Size = 1 )]
    public struct ByteBlockIndex1
    {
        private byte index;

        public static explicit operator short( ByteBlockIndex1 shortBlockIndex )
        {
            return shortBlockIndex.index;
        }

        public static explicit operator ByteBlockIndex1( byte value )
        {
            return new ByteBlockIndex1 {index = value};
        }

        public override string ToString( )
        {
            return index.ToString( );
        }
    }

    [GuerillaType( MoonfishFieldType.FieldShortBlockIndex1 )]
    [StructLayout( LayoutKind.Sequential, Size = 2 )]
    public struct ShortBlockIndex1
    {
        private short index;

        public static implicit operator short( ShortBlockIndex1 shortBlockIndex )
        {
            return shortBlockIndex.index;
        }

        public static implicit operator ShortBlockIndex1( short value )
        {
            return new ShortBlockIndex1 {index = value};
        }

        public override string ToString( )
        {
            return index.ToString( );
        }
    }

    [GuerillaType( MoonfishFieldType.FieldLongBlockIndex1 )]
    [StructLayout( LayoutKind.Sequential, Size = 4 )]
    public struct LongBlockIndex1
    {
        private int index;

        public static explicit operator int( LongBlockIndex1 blockIndex )
        {
            return blockIndex.index;
        }

        public static explicit operator LongBlockIndex1( int value )
        {
            return new LongBlockIndex1 {index = value};
        }

        public override string ToString( )
        {
            return index.ToString( );
        }
    }

    [GuerillaType( MoonfishFieldType.FieldCharBlockIndex2 )]
    [StructLayout( LayoutKind.Sequential, Size = 1 )]
    public struct ByteBlockIndex2
    {
        private byte index;

        public static explicit operator short( ByteBlockIndex2 blockIndex )
        {
            return blockIndex.index;
        }

        public static explicit operator ByteBlockIndex2( byte value )
        {
            return new ByteBlockIndex2 {index = value};
        }

        public override string ToString( )
        {
            return index.ToString( );
        }
    }

    [GuerillaType( MoonfishFieldType.FieldShortBlockIndex2 )]
    [StructLayout( LayoutKind.Sequential, Size = 2 )]
    public struct ShortBlockIndex2
    {
        private short index;

        public static explicit operator short( ShortBlockIndex2 blockIndex )
        {
            return blockIndex.index;
        }

        public static explicit operator ShortBlockIndex2( short value )
        {
            return new ShortBlockIndex2 {index = value};
        }

        public override string ToString( )
        {
            return index.ToString( );
        }
    }

    [GuerillaType( MoonfishFieldType.FieldLongBlockIndex2 )]
    [StructLayout( LayoutKind.Sequential, Size = 4 )]
    public struct LongBlockIndex2
    {
        private int index;

        public static explicit operator int( LongBlockIndex2 blockIndex )
        {
            return blockIndex.index;
        }

        public static explicit operator LongBlockIndex2( int value )
        {
            return new LongBlockIndex2 {index = value};
        }

        public override string ToString( )
        {
            return index.ToString( );
        }
    }


    [GuerillaType( MoonfishFieldType.FieldPoint_2D )]
    [StructLayout( LayoutKind.Sequential, Size = 4 )]
    public struct Point : IWriteable
    {
        private short X { get; set; }
        private short Y { get; set; }

        public Point( short x, short y )
            : this( )
        {
            X = x;
            Y = y;
        }

        public Point( BinaryReader binaryReader )
            : this( binaryReader.ReadInt16( ), binaryReader.ReadInt16( ) )
        {
        }

        void IWriteable.Write( BinaryWriter binaryWriter )
        {
            binaryWriter.Write( X );
            binaryWriter.Write( Y );
        }
    }
}