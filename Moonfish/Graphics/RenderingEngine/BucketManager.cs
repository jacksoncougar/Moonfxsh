using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using JetBrains.Annotations;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;
using OpenTK;

namespace Moonfish.Graphics
{
    public class BucketManager
    {
        private readonly Dictionary<int, BucketBuilder> _bucketBuilders = new Dictionary<int, BucketBuilder>();

        private readonly List<Bucket> _buckets = new List<Bucket>( );

        public IDisposable Begin( )
        {
            return new Handle( this );
        }

        public void BufferPartData( GlobalGeometrySectionStructBlock section )
        {

            //  Check to see if data is buffered already

            if ( _buckets.Any( u => u.Contains( section ) ) )
                return;

            //  Get the attribute types that the section contains and use them to check if any existing bucket 
            //  builder can buffer all the attributes, if not, create a new builder to handle the data
            var attributeTypes = GetSectionVertexAttributeTypes( section );
            var vertexAttributesId = attributeTypes.GetVertexAttributesId(  );
            if ( !_bucketBuilders.ContainsKey(vertexAttributesId))
                _bucketBuilders.Add(vertexAttributesId, new BucketBuilder( new Bucket( attributeTypes ) ) );

            var builder = _bucketBuilders[ vertexAttributesId ];
            builder.Add( section );
        }

        public Bucket GetBucketResource( GlobalGeometryPartBlockNew part, out int indexBaseOffset,
            out int vertexBaseOffset )
        {
            var bucket = _buckets.Single( u => u.Contains( part ) );
            var locations = bucket.GetBufferLocation( part );
            indexBaseOffset = locations.IndexBaseOffset;
            vertexBaseOffset = locations.VertexBaseOffset;
            return bucket;
        }

        private class BucketBuilder
        {
            private readonly HashSet<GlobalGeometrySectionStructBlock> sections =
                new HashSet<GlobalGeometrySectionStructBlock>( );

            private Bucket _bucket;

            public BucketBuilder( Bucket bucket )
            {
                _bucket = bucket;
            }

            public void Add(GlobalGeometrySectionStructBlock sectionStructBlock)
            {
                sections.Add(sectionStructBlock);
            }

            /// <summary>
            /// Returns true if the GlobalGeometrySectionStructBlock vertex attributes matches the bucket attributes
            /// and GeoemetryType matches
            /// </summary>
            /// <param name="sectionStructBlock"></param>
            /// <returns></returns>
            public bool CanBuffer( GlobalGeometrySectionStructBlock sectionStructBlock )
            {
                return
                    _bucket.SupportedVertexAttributes.SequenceEqual( GetSectionVertexAttributeTypes( sectionStructBlock ) );
            }

            public Bucket Finalise( )
            {
                _bucket.BufferData( sections );
                return _bucket;
            }
        }

        private class Handle : IDisposable
        {
            private readonly BucketManager _bucketManager;

            public Handle( BucketManager bucketManager )
            {
                _bucketManager = bucketManager;
            }

            public void Dispose( )
            {
                foreach ( var keyValuePair in _bucketManager._bucketBuilders )
                {
                    _bucketManager._buckets.Add( keyValuePair.Value.Finalise( ) );
                }
                _bucketManager._bucketBuilders.Clear(  );
            }
        }

        #region Static Functions

        public static void UnpackLightingData( GlobalGeometrySectionStructBlock renderModelSectionStructBlock )
        {
            foreach ( var globalGeometrySectionVertexBufferBlock in renderModelSectionStructBlock.VertexBuffers )
            {
                if ( globalGeometrySectionVertexBufferBlock.VertexBuffer.Type ==
                     VertexAttributeType.TangentSpaceUnitVectorsCompressed )
                {
                    globalGeometrySectionVertexBufferBlock.VertexBuffer =
                        UnpackLightingData( ref globalGeometrySectionVertexBufferBlock.VertexBuffer );
                }
            }
        }

        public static void UnpackVertexData(RenderModelBlock renderModel )
        {
            foreach ( var renderModelSectionBlock in renderModel.Sections )
            {
                throw new NotImplementedException();
               // renderModelSectionBlock.LoadResource();
                if ( renderModel.CompressionInfo.Length > 0 && renderModelSectionBlock.SectionData.Length > 0)
                    UnpackAttributeData( renderModelSectionBlock.SectionData[ 0 ].Section,
                        renderModel.CompressionInfo[ 0 ] );
            }
        }

        private static VertexAttributeType[] GetSectionVertexAttributeTypes( GlobalGeometrySectionStructBlock section )
        {
            var sectionVertexBufferTypes =
                new VertexAttributeType[section.VertexBuffers.Length];

            for ( var i = 0; i < section.VertexBuffers.Length; ++i )
            {
                sectionVertexBufferTypes[ i ] = section.VertexBuffers[ i ].VertexBuffer.Type;
            }

            return sectionVertexBufferTypes;
        }

        private static void UnpackAttributeData( GlobalGeometrySectionStructBlock geometrySectionStructBlock,
            GlobalGeometryCompressionInfoBlock compressionInfo )
        {
            foreach ( var globalGeometrySectionVertexBufferBlock in geometrySectionStructBlock.VertexBuffers )
            {
                switch ( globalGeometrySectionVertexBufferBlock.VertexBuffer.Type )
                {
                    case VertexAttributeType.TextureCoordinateCompressed:
                        globalGeometrySectionVertexBufferBlock.VertexBuffer =
                            UnpackTextureCoordinateData( ref globalGeometrySectionVertexBufferBlock.VertexBuffer,
                                compressionInfo );
                        break;
                    case VertexAttributeType.CoordinateFloat:
                    case VertexAttributeType.CoordinateCompressed:
                    case VertexAttributeType.CoordinateWithSingleNode:
                    case VertexAttributeType.CoordinateWithDoubleNode:
                    case VertexAttributeType.CoordinateWithTripleNode:
                        globalGeometrySectionVertexBufferBlock.VertexBuffer =
                            UnpackWorldCoordinateData( ref globalGeometrySectionVertexBufferBlock.VertexBuffer,
                                compressionInfo );
                        break;
                    case VertexAttributeType.TangentSpaceUnitVectorsCompressed:
                        globalGeometrySectionVertexBufferBlock.VertexBuffer =
                            UnpackLightingData( ref globalGeometrySectionVertexBufferBlock.VertexBuffer );
                        break;
                }
            }
        }

        private static VertexBuffer UnpackLightingData( ref VertexBuffer vertexBuffer )
        {
            var packedElementSize = vertexBuffer.Type.GetSize( );
            var stride = Vector3.SizeInBytes * 3;
            var count = vertexBuffer.Data.Length / packedElementSize;
            var bufferLength = count * stride;
            var buffer = new byte[bufferLength];
            using ( var binaryReader = new BinaryReader( new MemoryStream( vertexBuffer.Data ) ) )
            using ( var binaryWriter = new BinaryWriter( new MemoryStream( buffer ) ) )
            {
                while ( binaryReader.BaseStream.Position < vertexBuffer.Data.Length )
                {
                    var normal = VertexFunctions.UnpackVectorInt( binaryReader.ReadInt32( ) );
                    var tangent = VertexFunctions.UnpackVectorInt( binaryReader.ReadInt32( ) );
                    var bitangent = VertexFunctions.UnpackVectorInt( binaryReader.ReadInt32( ) );
                    binaryWriter.Write( normal );
                    binaryWriter.Write( tangent );
                    binaryWriter.Write( bitangent );
                }
            }
            return new VertexBuffer
            {
                Data = buffer,
                Type = VertexAttributeType.UnpackedLightingData
            };
        }

        private static VertexBuffer UnpackTextureCoordinateData( ref VertexBuffer vertexBuffer,
            GlobalGeometryCompressionInfoBlock compressionInfo )
        {
            var packedElementSize = vertexBuffer.Type.GetSize( );
            const int stride = 2 * sizeof ( float );
            var count = vertexBuffer.Data.Length / packedElementSize;
            var bufferLength = count * stride;
            var buffer = new byte[bufferLength];
            using ( var binaryReader = new BinaryReader( new MemoryStream( vertexBuffer.Data ) ) )
            using ( var binaryWriter = new BinaryWriter( new MemoryStream( buffer ) ) )
            {
                while ( binaryReader.BaseStream.Position < vertexBuffer.Data.Length )
                {
                    var s = VertexFunctions.Unpack( binaryReader.ReadInt16( ),
                        compressionInfo.TexcoordBoundsX.Min,
                        compressionInfo.TexcoordBoundsX.Max );
                    var t = VertexFunctions.Unpack( binaryReader.ReadInt16( ),
                        compressionInfo.TexcoordBoundsY.Min,
                        compressionInfo.TexcoordBoundsY.Max );
                    binaryWriter.Write( s );
                    binaryWriter.Write( t );
                }
            }
            return new VertexBuffer
            {
                Data = buffer,
                Type = VertexAttributeType.UnpackedTextureCoordinateData
            };
        }

        private static VertexBuffer UnpackWorldCoordinateData( ref VertexBuffer vertexBuffer,
            GlobalGeometryCompressionInfoBlock compressionInfo )
        {
            var packedElementSize = vertexBuffer.Type.GetSize( );
            const int stride = 3 * sizeof ( float ) + 4 * sizeof ( float ) + 4;
            var count = vertexBuffer.Data.Length / packedElementSize;
            var bufferLength = count * stride;
            var buffer = new byte[bufferLength];
            using ( var binaryReader = new BinaryReader( new MemoryStream( vertexBuffer.Data ) ) )
            using ( var binaryWriter = new BinaryWriter( new MemoryStream( buffer ) ) )
            {
                while ( binaryReader.BaseStream.Position < vertexBuffer.Data.Length )
                    switch ( vertexBuffer.Type )
                    {
                        case VertexAttributeType.CoordinateFloat:
                        {
                            var x = binaryReader.ReadSingle( );
                            var y = binaryReader.ReadSingle( );
                            var z = binaryReader.ReadSingle( );
                            binaryWriter.Write( x );
                            binaryWriter.Write( y );
                            binaryWriter.Write( z );
                            WriteVertexNodeInformation( binaryWriter,
                                0,
                                0,
                                0,
                                1.0f,
                                0,
                                0 );
                        }
                            break;
                        default:
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
                            switch ( vertexBuffer.Type )
                            {
                                case VertexAttributeType.CoordinateFloat:
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
                            break;
                    }
                return new VertexBuffer
                {
                    Data = buffer,
                    Type = VertexAttributeType.UnpackedWorldCoordinateData
                };
            }
        }

        private static
            void WriteVertexNodeInformation( BinaryWriter binaryWriter, byte nodeIndex0, byte nodeIndex1,
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

        #endregion

        public Bucket GetBucketResource( GlobalGeometryPartBlockNew part )
        {
            return _buckets.Single( u => u.Contains( part ) );
        }
    };
}
