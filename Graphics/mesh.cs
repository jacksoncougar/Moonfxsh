using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;
using OpenTK.Graphics.OpenGL;

namespace Moonfish.Graphics
{
    /// <summary>
    /// Wrapper class for buffering Halo 2 mesh data for use through OpenGL
    /// </summary>
    public class Mesh : IDisposable, IEnumerable<TriangleBatch>
    {
        public TriangleBatch TriangleBatch { get; private set; }

        public RenderModelSectionBlock SectionBlock;

        private bool _disposed;

        public GlobalGeometryPartBlockNew[] Parts { get; private set; }

        public Mesh( GlobalGeometrySectionStructBlockBase section,
            GlobalGeometryCompressionInfoBlockBase compressionInfo ) :
                this( section.parts,
                    section.stripIndices.Select( x => x.index ).ToArray( ),
                    section.vertexBuffers.Select( x => x.vertexBuffer ).ToArray( ), compressionInfo )
        {
        }

        public Mesh( GlobalGeometryPartBlockNew[] parts, short[] indices, IList<VertexBuffer> vertexArrayBufferData,
            GlobalGeometryCompressionInfoBlockBase compressionInfo )
        {
            Parts = parts;
            TriangleBatch = new TriangleBatch( );
            BufferElementArrayData( indices );
            BufferVertexAttributeData( vertexArrayBufferData, compressionInfo );
        }

        private void BufferVertexAttributeData( IList<VertexBuffer> vertexBuffers,
            GlobalGeometryCompressionInfoBlockBase compressionInfo )
        {
            using ( TriangleBatch.Begin( ) )
            {
                var attribute = 0;
                for ( int i = 0; i < vertexBuffers.Count; ++i )
                {
                    if ( !Enum.IsDefined( typeof ( VertexAttributeType ), vertexBuffers[ i ].Type ) ) continue;

                    TriangleBatch.BindBuffer( BufferTarget.ArrayBuffer, TriangleBatch.GenerateBuffer( ) );

                    var attributeType = vertexBuffers[ i ].Type;
                    int attributeSize;
                    var data = Unpack( vertexBuffers[ i ].Data, vertexBuffers[ i ].Type, compressionInfo,
                        out attributeSize );
                    TriangleBatch.BufferVertexAttributeData( data );

                    switch ( attributeType )
                    {
                        case VertexAttributeType.CoordinateWithDoubleNode:
                        case VertexAttributeType.CoordinateCompressed:
                        case VertexAttributeType.CoordinateWithSingleNode:
                        case VertexAttributeType.CoordinateWithTripleNode:
                            TriangleBatch.VertexAttribArray( attribute++, 3, VertexAttribPointerType.Float, false,
                                attributeSize );
                            TriangleBatch.VertexAttribArray( attribute++, 4, VertexAttribPointerType.Byte, false,
                                attributeSize, sizeof ( float ) * 3 );
                            TriangleBatch.VertexAttribArray( attribute++, 4, VertexAttribPointerType.Float, false,
                                attributeSize, sizeof ( float ) * 3 + sizeof ( byte ) * 4 );
                            break;
                        case VertexAttributeType.TextureCoordinateCompressed:
                            TriangleBatch.VertexAttribArray( attribute++, 2, VertexAttribPointerType.Short, false,
                                attributeSize );
                            break;
                        case VertexAttributeType.TangentSpaceUnitVectorsCompressed:
                            TriangleBatch.VertexAttribArray( attribute++, 1, VertexAttribIntegerType.Int, attributeSize );
                            TriangleBatch.VertexAttribArray( attribute++, 1, VertexAttribIntegerType.Int, attributeSize,
                                4 );
                            TriangleBatch.VertexAttribArray( attribute++, 1, VertexAttribIntegerType.Int, attributeSize,
                                8 );
                            break;
                        case VertexAttributeType.CoordinateFloat:
                            TriangleBatch.VertexAttribArray( attribute++, 3, VertexAttribPointerType.Float, false,
                                attributeSize );
                            break;
                        case VertexAttributeType.TextureCoordinateFloat:
                            TriangleBatch.VertexAttribArray( attribute++, 2, VertexAttribPointerType.Float, false,
                                attributeSize );
                            break;
                    }
                }
            }
        }

        private static byte[] Unpack( byte[] data, VertexAttributeType attributeType,
            GlobalGeometryCompressionInfoBlockBase compressionInfo, out int stride )
        {
            var packedElementSize = attributeType.GetSize( );
            stride = ( 3 * sizeof ( float ) ) + ( 4 * sizeof ( float ) ) + 4;
            var count = ( data.Length / packedElementSize );
            var bufferLength = count * stride;
            var buffer = new byte[bufferLength];
            using ( var binaryReader = new BinaryReader( new MemoryStream( data ) ) )
            using ( var binaryWriter = new BinaryWriter( new MemoryStream( buffer ) ) )
            {
                switch ( attributeType )
                {
                    case VertexAttributeType.CoordinateCompressed:
                    case VertexAttributeType.CoordinateWithTripleNode:
                    case VertexAttributeType.CoordinateWithDoubleNode:
                    case VertexAttributeType.CoordinateWithSingleNode:
                        while ( binaryReader.BaseStream.Position < data.Length )
                        {
                            var x = VertexFunctions.Unpack( binaryReader.ReadInt16( ),
                                compressionInfo.positionBoundsX.Min,
                                compressionInfo.positionBoundsX.Max );
                            var y = VertexFunctions.Unpack( binaryReader.ReadInt16( ),
                                compressionInfo.positionBoundsY.Min,
                                compressionInfo.positionBoundsY.Max );
                            var z = VertexFunctions.Unpack( binaryReader.ReadInt16( ),
                                compressionInfo.positionBoundsZ.Min,
                                compressionInfo.positionBoundsZ.Max );
                            binaryWriter.Write( x );
                            binaryWriter.Write( y );
                            binaryWriter.Write( z );
                            switch ( attributeType )
                            {
                                case VertexAttributeType.CoordinateCompressed:
                                    binaryWriter.Write( ( byte ) 0 ); // bone index 0
                                    binaryWriter.Write( ( byte ) 0 ); // bone index 1
                                    binaryWriter.Write( ( byte ) 0 ); // bone index 2
                                    binaryWriter.Write( ( byte ) 0 ); // pad
                                    binaryWriter.Write( 1.0f ); // bone weight 0
                                    binaryWriter.Write( ( float ) 0 ); // bone weight 1
                                    binaryWriter.Write( ( float ) 0 ); // bone weight 2
                                    binaryWriter.Write( ( float ) 0 ); // pad
                                    break;
                                case VertexAttributeType.CoordinateWithSingleNode:
                                    binaryWriter.Write( binaryReader.ReadByte( ) ); // bone index 0
                                    binaryWriter.Write( binaryReader.ReadByte( ) ); // bone index 1
                                    binaryWriter.Write( ( byte ) 0 ); // pad
                                    binaryWriter.Write( ( byte ) 0 ); // bone index 2
                                    binaryWriter.Write( 1.0f ); // bone weight 0
                                    binaryWriter.Write( ( float ) 0 ); // bone weight 1
                                    binaryWriter.Write( ( float ) 0 ); // bone weight 2
                                    binaryWriter.Write( ( float ) 0 ); // pad
                                    break;
                                case VertexAttributeType.CoordinateWithDoubleNode:
                                    binaryReader.ReadBytes( 2 );
                                    binaryWriter.Write( binaryReader.ReadByte( ) ); // bone index 0
                                    binaryWriter.Write( binaryReader.ReadByte( ) ); // bone index 1
                                    binaryWriter.Write( ( byte ) 0 ); // pad
                                    binaryWriter.Write( ( byte ) 0 ); // bone index 2
                                    binaryWriter.Write( binaryReader.ReadByte( ) / 255.0f ); // bone weight 0
                                    binaryWriter.Write( binaryReader.ReadByte( ) / 255.0f ); // bone weight 1
                                    binaryWriter.Write( ( float ) 0 ); // bone weight 2
                                    binaryWriter.Write( ( float ) 0 ); // pad
                                    break;
                                case VertexAttributeType.CoordinateWithTripleNode:
                                    binaryWriter.Write( binaryReader.ReadByte( ) ); // bone index 0
                                    binaryWriter.Write( binaryReader.ReadByte( ) ); // bone index 1
                                    binaryWriter.Write( binaryReader.ReadByte( ) ); // bone index 2
                                    binaryWriter.Write( ( byte ) 0 ); // pad
                                    binaryWriter.Write( binaryReader.ReadByte( ) / 255.0f ); // bone weight 0
                                    binaryWriter.Write( binaryReader.ReadByte( ) / 255.0f ); // bone weight 1
                                    binaryWriter.Write( binaryReader.ReadByte( ) / 255.0f ); // bone weight 2
                                    binaryWriter.Write( ( float ) 0 ); // pad
                                    break;
                            }
                        }
                        break;
                    default:
                        stride = attributeType.GetSize( );
                        return data;
                }
            }
            return buffer;
        }

        private void BufferElementArrayData( short[] indices )
        {
            using ( TriangleBatch.Begin( ) )
            {
                TriangleBatch.GenerateBuffer( );
                TriangleBatch.BindBuffer( BufferTarget.ElementArrayBuffer, TriangleBatch.BufferIdents.Last( ) );
                TriangleBatch.BufferElementArrayData( indices );
            }
        }

        public void Dispose( )
        {
            Dispose( true );
            GC.SuppressFinalize( this );
        }

        protected virtual void Dispose( bool disposing )
        {
            if ( _disposed || !disposing ) return;
            GL.BindVertexArray( 0 );
            TriangleBatch.Dispose( );
            _disposed = true;
        }

        IEnumerator<TriangleBatch> IEnumerable<TriangleBatch>.GetEnumerator( )
        {
            if ( TriangleBatch != null ) yield return TriangleBatch;
        }

        IEnumerator IEnumerable.GetEnumerator( )
        {
            return ( ( IEnumerable<TriangleBatch> ) this ).GetEnumerator( );
        }
    }


    public static class VertexAttributeTypeExtensions
    {
        public static byte GetSize( this VertexAttributeType attributeType )
        {
            var value = ( short ) attributeType;
            var size = ( byte ) ( value & 0x00FF );
            return size;
        }

        public static VertexAttributeType ReadVertexAttributeType( this BinaryReader binaryReader )
        {
            var msb = binaryReader.ReadByte( );
            var lsb = binaryReader.ReadByte( );
            var type = ( VertexAttributeType ) ( msb << 8 | lsb );
            return type;
        }
    }

    public enum VertexAttributeType : short
    {
        None = 0x0000,
        CoordinateFloat = 0x010C,
        CoordinateCompressed = 0x0206,
        CoordinateWithSingleNode = 0x0408,
        CoordinateWithDoubleNode = 0x060C,
        CoordinateWithTripleNode = 0x080C,

        TextureCoordinateFloatPc = 0x1708,
        TextureCoordinateFloat = 0x1808,
        TextureCoordinateCompressed = 0x1904,

        TangentSpaceUnitVectorsFloat = 0x1924,
        TangentSpaceUnitVectorsCompressed = 0x1B0C,

        LightmapUvCoordinateOne = 0x1F08,
        LightmapUvCoordinateTwo = 0x3008,

        DiffuseColour = 0x350C,
    }
}