using Moonfish.Graphics;
using OpenTK;
using System.IO;
using System.Linq;
using System.Text;
using Moonfish.Guerilla.Tags;
using Moonfish.ResourceManagement;

namespace Moonfish.Tags
{
    namespace BlamExtension
    {
        internal static class BinaryReaderExtensions
        {
            public static void Write( this BinaryWriter binaryWriter, BlamPointer blamPointer )
            {
                binaryWriter.Write( blamPointer.elementCount );
                binaryWriter.Write( blamPointer.elementCount > 0 ? blamPointer.startAddress : 0 );
            }

            public static BlamPointer ReadBlamPointer( this BinaryReader binaryReader, int elementSize )
            {
                var resourceStream = binaryReader.BaseStream as ResourceStream;
                if ( resourceStream == null )
                {
                    return new BlamPointer( binaryReader.ReadInt32( ), binaryReader.ReadInt32( ), elementSize );
                }

                var offset = resourceStream.Position;
                binaryReader.BaseStream.Seek( 8, SeekOrigin.Current );
                var resource =
                    resourceStream.Resources.SingleOrDefault(
                        x =>
                            x.primaryLocator == offset &&
                            x.type != GlobalGeometryBlockResourceBlockBase.Type.VertexBuffer );

                if ( resource == null )
                {
                    return new BlamPointer( 0, 0, elementSize );
                }
                if ( resource.type == GlobalGeometryBlockResourceBlockBase.Type.TagData )
                {
                    var count = resource.resourceDataSize;
                    var address = resource.resourceDataOffset + resourceStream.HeaderSize;
                    var size = 1;
                    return new BlamPointer( count, address, elementSize );
                }
                else
                {
                    var count = resource.resourceDataSize / resource.secondaryLocator;
                    var address = resource.resourceDataOffset + resourceStream.HeaderSize;
                    var size = resource.secondaryLocator;
                    return new BlamPointer( count, address, elementSize );
                }
            }
        }
    }

    internal static class BinaryWriterExtensions
    {
        public static void Write( this BinaryWriter binaryWriter, VertexBuffer value )
        {
            binaryWriter.Write( ( int ) value.Type );
            binaryWriter.Write( new byte[28] );
        }

        public static void Write( this BinaryWriter binaryWriter, String32 value )
        {
            var bytes = Encoding.UTF8.GetBytes( value.value );
            var padding = bytes.Length >= 32 ? 0 : 32 - bytes.Length;
            var length = 32 - padding;
            binaryWriter.Write( bytes, 0, length );
            binaryWriter.Write( new byte[padding] );
        }

        public static void Write( this BinaryWriter binaryWriter, String256 value )
        {
            var bytes = Encoding.UTF8.GetBytes( value.value );
            var padding = bytes.Length >= 256 ? 256 : 256 - bytes.Length;
            binaryWriter.Write( bytes );
            binaryWriter.Write( new byte[padding] );
        }

        public static void Write( this BinaryWriter binaryWriter, StringID value )
        {
            binaryWriter.Write( ( int ) value );
        }

        public static void Write( this BinaryWriter binaryWriter, RGBColor value )
        {
            binaryWriter.Write( value.Red );
            binaryWriter.Write( value.Green );
            binaryWriter.Write( value.Blue );
            binaryWriter.Write( 0 );
        }

        public static void Write( this BinaryWriter binaryWriter, TagReference value )
        {
            binaryWriter.Write( ( int ) value.Class );
            binaryWriter.Write( ( int ) value.Ident );
        }

        public static void Write( this BinaryWriter binaryWriter, BlockFlags8 value )
        {
            binaryWriter.Write( value.flags );
        }

        public static void Write( this BinaryWriter binaryWriter, BlockFlags16 value )
        {
            binaryWriter.Write( value.flags );
        }

        public static void Write( this BinaryWriter binaryWriter, BlockFlags32 value )
        {
            binaryWriter.Write( value.flags );
        }

        public static void Write( this BinaryWriter binaryWriter, ByteBlockIndex1 value )
        {
            binaryWriter.Write( ( byte ) value );
        }

        public static void Write( this BinaryWriter binaryWriter, ShortBlockIndex1 value )
        {
            binaryWriter.Write( ( short ) value );
        }

        public static void Write( this BinaryWriter binaryWriter, LongBlockIndex1 value )
        {
            binaryWriter.Write( ( int ) value );
        }

        public static void Write( this BinaryWriter binaryWriter, ByteBlockIndex2 value )
        {
            binaryWriter.Write( ( byte ) value );
        }

        public static void Write( this BinaryWriter binaryWriter, ShortBlockIndex2 value )
        {
            binaryWriter.Write( ( short ) value );
        }

        public static void Write( this BinaryWriter binaryWriter, LongBlockIndex2 value )
        {
            binaryWriter.Write( ( int ) value );
        }

        public static void Write( this BinaryWriter binaryWriter, Quaternion value )
        {
            binaryWriter.Write( value.W );
            binaryWriter.Write( value.X );
            binaryWriter.Write( value.Y );
            binaryWriter.Write( value.Z );
        }

        public static void Write( this BinaryWriter binaryWriter, Vector4 value )
        {
            binaryWriter.Write( value.X );
            binaryWriter.Write( value.Y );
            binaryWriter.Write( value.Z );
            binaryWriter.Write( value.W );
        }

        public static void Write( this BinaryWriter binaryWriter, Vector3 value )
        {
            binaryWriter.Write( value.X );
            binaryWriter.Write( value.Y );
            binaryWriter.Write( value.Z );
        }

        public static void Write( this BinaryWriter binaryWriter, Vector2 value )
        {
            binaryWriter.Write( value.X );
            binaryWriter.Write( value.Y );
        }

        public static void Write( this BinaryWriter binaryWriter, ColourA1R1G1B1 value )
        {
            binaryWriter.Write( value.Alpha );
            binaryWriter.Write( value.Red );
            binaryWriter.Write( value.Blue );
            binaryWriter.Write( value.Green );
        }

        public static void Write( this BinaryWriter binaryWriter, ColorR8G8B8 value )
        {
            binaryWriter.Write( value.R );
            binaryWriter.Write( value.G );
            binaryWriter.Write( value.B );
        }

        public static void Write( this BinaryWriter binaryWriter, Point value )
        {
            ( value as IWriteable ).Write( binaryWriter );
        }
    }

    internal static class BinaryReaderExtensions
    {
        public static VertexBuffer ReadVertexBuffer( this BinaryReader binaryReader )
        {
            return new VertexBuffer( ) {Type = binaryReader.ReadVertexAttributeType( )};
        }

        public static String32 ReadString32( this BinaryReader binaryReader )
        {
            return new String32( new string( Encoding.UTF8.GetChars( binaryReader.ReadBytes( 32 ) ) ) );
        }

        public static String256 ReadString256( this BinaryReader binaryReader )
        {
            return new String256( new string( Encoding.UTF8.GetChars( binaryReader.ReadBytes( 256 ) ) ) );
        }

        public static StringID ReadStringID( this BinaryReader binaryReader )
        {
            return new StringID( binaryReader.ReadInt32( ) );
        }

        public static RGBColor ReadRGBColor( this BinaryReader binaryReader )
        {
            var color = new RGBColor( )
            {
                Red = binaryReader.ReadByte( ),
                Green = binaryReader.ReadByte( ),
                Blue = binaryReader.ReadByte( )
            };
            binaryReader.ReadByte( );
            return color;
        }

        public static TagReference ReadTagReference( this BinaryReader binaryReader )
        {
            return new TagReference( binaryReader.ReadTagClass( ), binaryReader.ReadTagIdent( ) );
        }

        public static BlockFlags8 ReadBlockFlags8( this BinaryReader binaryReader )
        {
            return new BlockFlags8( binaryReader.ReadByte( ) );
        }

        public static BlockFlags16 ReadBlockFlags16( this BinaryReader binaryReader )
        {
            return new BlockFlags16( binaryReader.ReadInt16( ) );
        }

        public static ByteBlockIndex1 ReadByteBlockIndex1( this BinaryReader binaryReader )
        {
            return ( ByteBlockIndex1 ) binaryReader.ReadByte( );
        }

        public static ShortBlockIndex1 ReadShortBlockIndex1( this BinaryReader binaryReader )
        {
            return ( ShortBlockIndex1 ) binaryReader.ReadInt16( );
        }

        public static LongBlockIndex1 ReadLongBlockIndex1( this BinaryReader binaryReader )
        {
            return ( LongBlockIndex1 ) binaryReader.ReadInt32( );
        }

        public static ShortBlockIndex2 ReadShortBlockIndex2( this BinaryReader binaryReader )
        {
            return ( ShortBlockIndex2 ) binaryReader.ReadInt16( );
        }

        public static Quaternion ReadQuaternion( this BinaryReader binaryReader )
        {
            float i = binaryReader.ReadSingle( ),
                j = binaryReader.ReadSingle( ),
                k = binaryReader.ReadSingle( ),
                l = binaryReader.ReadSingle( );
            return new Quaternion( l, k, j, i );
        }

        public static ColorR8G8B8 ReadColorR8G8B8( this BinaryReader binaryReader )
        {
            return new ColorR8G8B8( binaryReader.ReadSingle( ), binaryReader.ReadSingle( ), binaryReader.ReadSingle( ) );
        }

        public static ColourA1R1G1B1 ReadColourA1R1G1B1( this BinaryReader binaryReader )
        {
            return new ColourA1R1G1B1(
                binaryReader.ReadByte( ),
                binaryReader.ReadByte( ),
                binaryReader.ReadByte( ),
                binaryReader.ReadByte( ) );
        }

        public static Point ReadPoint( this BinaryReader binaryReader )
        {
            return new Point( binaryReader );
        }
    }
}