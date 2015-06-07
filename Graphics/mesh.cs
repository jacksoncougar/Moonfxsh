using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Moonfish.Graphics
{
    /// <summary>
    ///     Wrapper class for buffering Halo 2 mesh data for use through OpenGL
    /// </summary>
    public class Mesh : IDisposable, IEnumerable<TriangleBatch>
    {
        private bool _disposed;
        public RenderModelSectionBlock SectionBlock;

        public Mesh( GlobalGeometrySectionStructBlock section,
            GlobalGeometryCompressionInfoBlock compressionInfo ) :
                this( section.Parts,
                    section.Subparts,
                    section.StripIndices.Select( x => x.Index ).ToArray( ),
                    section.VertexBuffers.Select( x => x.VertexBuffer ).ToArray( ), compressionInfo )
        {
        }

        public Mesh( GlobalGeometryPartBlockNew[] parts, GlobalSubpartsBlock[] subParts, short[] indices,
            IList<VertexBuffer> vertexArrayBufferData,
            GlobalGeometryCompressionInfoBlock compressionInfo )
        {
            Parts = parts;
            SubParts = subParts;
            TriangleBatch = new TriangleBatch( );
            BufferElementArrayData( indices );
            BufferVertexAttributeData( vertexArrayBufferData, compressionInfo );
        }

        public GlobalGeometryPartBlockNew[] Parts { get; private set; }
        public GlobalSubpartsBlock[] SubParts { get; private set; }
        public TriangleBatch TriangleBatch { get; private set; }

        public void Dispose( )
        {
            Dispose( true );
            GC.SuppressFinalize( this );
        }

        IEnumerator<TriangleBatch> IEnumerable<TriangleBatch>.GetEnumerator( )
        {
            if ( TriangleBatch != null ) yield return TriangleBatch;
        }

        IEnumerator IEnumerable.GetEnumerator( )
        {
            return ( ( IEnumerable<TriangleBatch> ) this ).GetEnumerator( );
        }

        protected virtual void Dispose( bool disposing )
        {
            if ( _disposed || !disposing ) return;
            GL.BindVertexArray( 0 );
            TriangleBatch.Dispose( );
            _disposed = true;
        }

        private void BufferElementArrayData( short[] indices )
        {
            using ( TriangleBatch.Begin( ) )
            {
                TriangleBatch.BindBuffer(BufferTarget.ElementArrayBuffer, TriangleBatch.GenerateBuffer());
                TriangleBatch.BufferElementArrayData( indices );
            }
        }

        private void BufferVertexAttributeData( IList<VertexBuffer> vertexBuffers,
            GlobalGeometryCompressionInfoBlock compressionInfo )
        {
            using ( TriangleBatch.Begin( ) )
            {
                var attribute = 0;
                for ( var i = 0; i < vertexBuffers.Count; ++i )
                {
                    if ( !Enum.IsDefined( typeof ( VertexAttributeType ), vertexBuffers[ i ].Type ) )
                        continue;


                    var attributeType = vertexBuffers[ i ].Type;
                    int attributeSize = vertexBuffers[ i ].Type.GetSize( );
                    var data = vertexBuffers[ i ].Data;
                    data = UnpackCoordinates( data, vertexBuffers[ i ].Type, compressionInfo, ref attributeSize );
                    data = UnpackNormals( data, vertexBuffers[ i ].Type, ref attributeSize );
#if DEBUG

#endif

                    TriangleBatch.BindBuffer(BufferTarget.ArrayBuffer, TriangleBatch.GenerateBuffer());
                    TriangleBatch.BufferVertexAttributeData( data );

                    switch ( attributeType )
                    {
                        case VertexAttributeType.CoordinateWithDoubleNode:
                        case VertexAttributeType.CoordinateCompressed:
                        case VertexAttributeType.CoordinateWithSingleNode:
                        case VertexAttributeType.CoordinateWithTripleNode:
                            TriangleBatch.VertexAttribArray( 0, 3, VertexAttribPointerType.Float, false,
                                attributeSize );
                            TriangleBatch.VertexAttribArray( 1, 4, VertexAttribPointerType.Byte, false,
                                attributeSize, sizeof ( float ) * 3 );
                            TriangleBatch.VertexAttribArray( 2, 4, VertexAttribPointerType.Float, false,
                                attributeSize, sizeof ( float ) * 3 + sizeof ( byte ) * 4 );
                            break;
                        case VertexAttributeType.TextureCoordinateCompressed:
                            TriangleBatch.VertexAttribArray( 3, 2, VertexAttribPointerType.Short, false,
                                attributeSize );
                            break;
                        case VertexAttributeType.TangentSpaceUnitVectorsCompressed:
                            TriangleBatch.VertexAttribArray( 4, 3, VertexAttribPointerType.Float, false,
                                attributeSize, Vector3.SizeInBytes * 0 );
                            TriangleBatch.VertexAttribArray( 5, 3, VertexAttribPointerType.Float, false,
                                attributeSize, Vector3.SizeInBytes * 1 );
                            TriangleBatch.VertexAttribArray( 6, 3, VertexAttribPointerType.Float, false,
                                attributeSize, Vector3.SizeInBytes * 2 );
                            break;
                        case VertexAttributeType.CoordinateFloat:
                            TriangleBatch.VertexAttribArray( 0, 3, VertexAttribPointerType.Float, false,
                                attributeSize );
                            break;
                        case VertexAttributeType.TextureCoordinateFloat:
                            TriangleBatch.VertexAttribArray( 3, 2, VertexAttribPointerType.Float, false,
                                attributeSize );
                            break;
                        case VertexAttributeType.LightmapUVCoordinateOneXbox:
                            TriangleBatch.VertexAttribArray( 7, 2, VertexAttribPointerType.Short, true,
                                attributeSize );
                            break;
                        case VertexAttributeType.LightmapUVCoordinateTwoXbox:
                            TriangleBatch.VertexAttribArray( 8, 2, VertexAttribPointerType.Short, true,
                                attributeSize );
                            break;
                        default:
                            throw new Exception( );
                    }
                }
            }
        }

        private static byte[] UnpackCoordinates( byte[] data, VertexAttributeType attributeType,
            GlobalGeometryCompressionInfoBlock compressionInfo, ref int stride )
        {
            switch ( attributeType )
            {
                case VertexAttributeType.CoordinateCompressed:
                case VertexAttributeType.CoordinateWithTripleNode:
                case VertexAttributeType.CoordinateWithDoubleNode:
                case VertexAttributeType.CoordinateWithSingleNode:
                    var packedElementSize = attributeType.GetSize( );
                    stride = ( 3 * sizeof ( float ) ) + ( 4 * sizeof ( float ) ) + 4;
                    var count = ( data.Length / packedElementSize );
                    var bufferLength = count * stride;
                    var buffer = new byte[bufferLength];
                    using ( var binaryReader = new BinaryReader( new MemoryStream( data ) ) )
                    using ( var binaryWriter = new BinaryWriter( new MemoryStream( buffer ) ) )
                    {
                        while ( binaryReader.BaseStream.Position < data.Length )
                        {
                            var x = VertexFunctions.Unpack( binaryReader.ReadInt16( ),
                                compressionInfo.PositionBoundsX.Min,
                                compressionInfo.PositionBoundsX.Max );
                            var y = VertexFunctions.Unpack( binaryReader.ReadInt16( ),
                                compressionInfo.PositionBoundsY.Min,
                                compressionInfo.PositionBoundsY.Max );
                            var z = VertexFunctions.Unpack( binaryReader.ReadInt16( ),
                                compressionInfo.PositionBoundsZ.Min,
                                compressionInfo.PositionBoundsZ.Max );
                            binaryWriter.Write( x );
                            binaryWriter.Write( y );
                            binaryWriter.Write( z );
                            switch ( attributeType )
                            {
                                case VertexAttributeType.CoordinateCompressed:
                                    WriteVertexNodeInformation( binaryWriter,
                                        0,
                                        0,
                                        0,
                                        1.0f,
                                        0,
                                        0 );
                                    break;
                                case VertexAttributeType.CoordinateWithSingleNode:
                                    WriteVertexNodeInformation( binaryWriter,
                                        binaryReader.ReadByte( ),
                                        binaryReader.ReadByte( ),
                                        0,
                                        1.0f,
                                        0,
                                        0 );
                                    break;
                                case VertexAttributeType.CoordinateWithDoubleNode:
                                    binaryReader.ReadBytes( 2 );
                                    WriteVertexNodeInformation( binaryWriter,
                                        binaryReader.ReadByte( ),
                                        binaryReader.ReadByte( ),
                                        0,
                                        binaryReader.ReadByte( ) / 255.0f,
                                        binaryReader.ReadByte( ) / 255.0f,
                                        0 );
                                    break;
                                case VertexAttributeType.CoordinateWithTripleNode:
                                    WriteVertexNodeInformation( binaryWriter,
                                        binaryReader.ReadByte( ),
                                        binaryReader.ReadByte( ),
                                        binaryReader.ReadByte( ),
                                        binaryReader.ReadByte( ) / 255.0f,
                                        binaryReader.ReadByte( ) / 255.0f,
                                        binaryReader.ReadByte( ) / 255.0f );
                                    break;
                            }
                        }
                    }
                    return buffer;
                default:
                    return data;
            }
        }

        private static byte[] UnpackNormals( byte[] data, VertexAttributeType attributeType, ref int stride )
        {
            switch ( attributeType )
            {
                case VertexAttributeType.TangentSpaceUnitVectorsCompressed:
                    var packedElementSize = attributeType.GetSize( );
                    stride = Vector3.SizeInBytes * 3;
                    var count = ( data.Length / packedElementSize );
                    var bufferLength = count * stride;
                    var buffer = new byte[bufferLength];
                    using ( var binaryReader = new BinaryReader( new MemoryStream( data ) ) )
                    using ( var binaryWriter = new BinaryWriter( new MemoryStream( buffer ) ) )
                    {
                        while ( binaryReader.BaseStream.Position < data.Length )
                        {
                            var normal = VertexFunctions.UnpackVectorInt( binaryReader.ReadInt32( ) );
                            var tangent = VertexFunctions.UnpackVectorInt( binaryReader.ReadInt32( ) );
                            var bitangent = VertexFunctions.UnpackVectorInt( binaryReader.ReadInt32( ) );
                            binaryWriter.Write( normal );
                            binaryWriter.Write( tangent );
                            binaryWriter.Write( bitangent );
                        }
                    }
                    return buffer;
                default:
                    return data;
            }
        }

        private static void WriteVertexNodeInformation( BinaryWriter binaryWriter, byte nodeIndex0, byte nodeIndex1,
            byte nodeIndex2, float nodeWeight0, float nodeWeight1, float nodeWeight2 )
        {
            binaryWriter.Write( nodeIndex0 ); // bone index 0
            binaryWriter.Write( nodeIndex1 ); // bone index 1
            binaryWriter.Write( nodeIndex2 ); // bone index 2
            binaryWriter.Write( ( byte ) 0 ); // pad
            binaryWriter.Write( nodeWeight0 ); // bone weight 0
            binaryWriter.Write( nodeWeight1 ); // bone weight 1
            binaryWriter.Write( nodeWeight2 ); // bone weight 2
            binaryWriter.Write( ( float ) 0 ); // pad
        }
    };
}