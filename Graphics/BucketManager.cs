using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using JetBrains.Annotations;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Moonfish.Graphics
{
    public class DrawCommand
    {
        public int[] baseVertex;
        public Bucket bucket;

        public int[] count;

        public DrawElementsType elementType;

        public int instanceBaseOffset;
        public int instanceCount;
        public int multiDrawCount;
        public int[] offset;
        public PrimitiveType primitiveType;
        public Dictionary<string, dynamic> Attributes { get; } = new Dictionary<string, dynamic>( );
        public bool IsInstancedDraw => instanceCount > 0;

        public bool IsMultiDraw => multiDrawCount > 0;

        public void AssignAttribute( string attributeName, dynamic value )
        {
            Attributes[ attributeName ] = value;
        }

        public void SetupAttributes( Program program )
        {
            foreach ( var attribute in Attributes )
            {
                var attributeLocation = program.GetAttributeLocation( attribute.Key );
                Program.SetAttribute( attributeLocation, attribute.Value );
            }
        }
    }

    public class NewBucketManager
    {
        private class BucketBuilder
        {
            private Bucket _bucket;

            private HashSet<GlobalGeometrySectionStructBlock> sections =
                new HashSet<GlobalGeometrySectionStructBlock>( );

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

            public BucketBuilder( Bucket bucket )
            {
                _bucket = bucket;
            }

            public void Add(GlobalGeometrySectionStructBlock sectionStructBlock)
            {
                sections.Add(sectionStructBlock);
            }

            public Bucket Finalise( )
            {
                _bucket.BufferData( sections );
                return _bucket;
            }
        }

        private readonly List<Bucket> _buckets = new List<Bucket>( );
        private Dictionary<int, BucketBuilder> bucketBuilders = new Dictionary<int, BucketBuilder>();

        public Bucket GetBucketResource( GlobalGeometryPartBlockNew part, out int indexBaseOffset,
            out int vertexBaseOffset )
        {
            var bucket = _buckets.Single( u => u.Contains( part ) );
            var locations = bucket.GetBufferLocation( part );
            indexBaseOffset = locations.IndexBaseOffset;
            vertexBaseOffset = locations.VertexBaseOffset;
            return bucket;
        }

        public IDisposable Begin( )
        {
            return new Handle( this );
        }

        private class Handle : IDisposable
        {
            private readonly NewBucketManager _newBucketManager;

            public Handle( NewBucketManager newBucketManager )
            {
                _newBucketManager = newBucketManager;
            }

            public void Dispose( )
            {
                foreach ( var keyValuePair in _newBucketManager.bucketBuilders )
                {
                    _newBucketManager._buckets.Add( keyValuePair.Value.Finalise( ) );
                }
                _newBucketManager.bucketBuilders.Clear(  );
            }
        }

        public void BufferPartData( GlobalGeometrySectionStructBlock section )
        {
            //  Check to see if data is buffered already
            if ( _buckets.Any( u => section.Parts.All( u.Contains )))
                return;

            //  Get the attribute types that the section contains and use them to check if any existing bucket 
            //  builder can buffer all the attributes, if not, create a new builder to handle the data
            var attributeTypes = GetSectionVertexAttributeTypes( section );
            var vertexAttributesId = attributeTypes.GetVertexAttributesId(  );
            if ( !bucketBuilders.ContainsKey(vertexAttributesId))
                bucketBuilders.Add(vertexAttributesId, new BucketBuilder( new Bucket( attributeTypes ) ) );

            var builder = bucketBuilders[ vertexAttributesId ];
            builder.Add( section );
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
                renderModelSectionBlock.LoadSectionDataIfEmpty(  );
                UnpackAttributeData( renderModelSectionBlock.SectionData[ 0 ].Section, renderModel.CompressionInfo[ 0 ] );
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
    };

    public class BucketManager
    {
        private readonly List<Bucket> _buckets = new List<Bucket>( );

        private readonly List<Matrix4> InstanceData = new List<Matrix4>( );

        private readonly Dictionary<GlobalGeometrySectionStructBlock, InstanceDataStorageInfo> InstanceStorageMeta =
            new Dictionary<GlobalGeometrySectionStructBlock, InstanceDataStorageInfo>( );

        public List<GlobalGeometrySectionStructBlock> SectionBlockQueue = new List<GlobalGeometrySectionStructBlock>( );

        private bool ProcessingBucket { get; set; }

        public IDisposable BeginBucket( )
        {
            return new BucketHandle( this );
        }

        public static void Draw( [NotNull] ICollection<DrawCommand> drawCommands, Program program )
        {
            var lastVertexArray = 0;
            var uniformLocation = program.GetUniformLocation( "ShaderArguments" );
            program.SetUniform( uniformLocation, Vector4.UnitX );
            foreach (
                var drawCommand in drawCommands.OrderBy( e => e.bucket.VertexArrayObject ).Where( e => e.IsMultiDraw ) )
            {
                using ( lastVertexArray != drawCommand.bucket.VertexArrayObject ? drawCommand.bucket.Bind( ) : null )
                {
                    if ( drawCommand.IsMultiDraw )
                    {
                        GL.MultiDrawElementsBaseVertex( drawCommand.primitiveType, drawCommand.count,
                            drawCommand.elementType, drawCommand.offset, drawCommand.multiDrawCount,
                            drawCommand.baseVertex );
                    }
                    lastVertexArray = drawCommand.bucket.VertexArrayObject;
                }
            }
            program.SetUniform( uniformLocation, Vector4.Zero );
            foreach (
                var drawCommand in
                    drawCommands.OrderBy( e => e.bucket.VertexArrayObject ).Where( e => e.IsInstancedDraw ) )
            {
                using ( lastVertexArray != drawCommand.bucket.VertexArrayObject ? drawCommand.bucket.Bind( ) : null )
                {
                    if ( drawCommand.IsInstancedDraw )
                    {
                        GL.DrawElementsInstancedBaseVertexBaseInstance( drawCommand.primitiveType,
                            drawCommand.count[ 0 ],
                            drawCommand.elementType, ( IntPtr ) drawCommand.offset[ 0 ], drawCommand.instanceCount,
                            drawCommand.baseVertex[ 0 ], drawCommand.instanceBaseOffset );
                    }
                    lastVertexArray = drawCommand.bucket.VertexArrayObject;
                }
            }
        }

        public IEnumerable<DrawCommand> GetDrawCommands( GlobalGeometrySectionStructBlock section )
        {
            //var commands = new List<DrawCommand>( );

            ////  Loop through every bucket and select buckets which contain the section
            //foreach ( var bucket in _buckets )
            //{
            //    if ( !bucket.Contains( section ) ) continue;

            //    var meshFragmentInfo = bucket.storageMeta[ section ];

            //    foreach ( var globalGeometryPartBlockNew in section.Parts )
            //    {
            //        var primitiveType =
            //            globalGeometryPartBlockNew.GlobalGeometryPartNewFlags.HasFlag(
            //                GlobalGeometryPartBlockNew.Flags.OverrideTriangleList )
            //                ? PrimitiveType.Triangles
            //                : PrimitiveType.TriangleStrip;

            //        var drawCommand = new DrawCommand
            //        {
            //            instanceCount = meshFragmentInfo.InstanceCount,
            //            instanceBaseOffset = meshFragmentInfo.InstanceBufferBaseOffset,
            //            baseVertex = new[] {meshFragmentInfo.VertexBufferBaseOffset},
            //            count = new[] {( int ) globalGeometryPartBlockNew.StripLength},
            //            elementType = DrawElementsType.UnsignedShort,
            //            offset =
            //                new[]
            //                {
            //                    meshFragmentInfo.IndexBufferBaseOffset + globalGeometryPartBlockNew.StripStartIndex * 2
            //                },
            //            primitiveType = primitiveType,
            //            bucket = bucket
            //        };
            //        commands.Add( drawCommand );
            //    }
            //}
            return new DrawCommand[0];
        }

        public DrawCommand[] GetMultiDrawCommands( )
        {
            //var commands = new List<DrawCommand>( );

            //foreach ( var bucket in _buckets )
            //{
            //    if ( bucket.InstanceCount != 0 ) continue;

            //    var multiDrawCount = bucket.PartsCount;

            //    var count = new int[multiDrawCount];
            //    var baseOffset = new int[multiDrawCount];
            //    var baseVertex = new int[multiDrawCount];

            //    var index = 0;
            //    foreach ( var key in bucket )
            //    {
            //        foreach ( var globalGeometryPartBlockNew in key.Parts )
            //        {
            //            if ( !globalGeometryPartBlockNew.GlobalGeometryPartNewFlags.HasFlag(
            //                GlobalGeometryPartBlockNew.Flags.Decalable ) )
            //            {
            //                index++;
            //                continue;
            //            }

            //            if ( globalGeometryPartBlockNew.Type ==
            //                 GlobalGeometryPartBlockNew.TypeEnum.Transparent )
            //            {
            //                index++;
            //                continue;
            //            }
            //            count[ index ] = globalGeometryPartBlockNew.StripLength;
            //            baseVertex[ index ] = 0;
            //            baseOffset[ index ] = 0;
            //            //bucket.indexBufferBaseOffets[ key ] +
            //            // globalGeometryPartBlockNew.StripStartIndex * 2;
            //            index++;
            //        }
            //    }
            //    var drawCommand = new DrawCommand
            //    {
            //        baseVertex = baseVertex,
            //        count = count,
            //        elementType = DrawElementsType.UnsignedShort,
            //        primitiveType = PrimitiveType.Triangles,
            //        multiDrawCount = multiDrawCount,
            //        offset = baseOffset,
            //        bucket = bucket
            //    };
            //    drawCommand.AssignAttribute( "instanceWorldMatrix", Matrix4.Identity );
            //    commands.Add( drawCommand );
            //}
            return new DrawCommand[0];
        }


        public void LoadSectionInstanceData( IEnumerable<GlobalGeometrySectionStructBlock> sectionStructBlocks,
            IReadOnlyList<Matrix4> instanceWorldMatrixs, int instanceId )
        {
            //foreach ( var bucket in _buckets.Where( e => e.Intersect( sectionStructBlocks ).Any( ) ) )
            //    unsafe
            //    {
            //        var baseInstance = bucket.storageMeta[ sectionStructBlocks.First( ) ].InstanceBufferBaseOffset;
            //        bucket.BufferInstanceSubData( instanceWorldMatrixs,
            //            ( baseInstance + instanceId ) * sizeof ( Matrix4 ) );
                //}
        }

        public void QueueInstanceData( IEnumerable<GlobalGeometrySectionStructBlock> sectionStructBlocks,
            ICollection<Matrix4> instanceData, out int instanceBaseId )
        {
            instanceBaseId = 0;
            var instanceOffset = InstanceData.Count;
            var insert = false;
            foreach ( var globalGeometrySectionStructBlock in sectionStructBlocks )
            {
                if ( !InstanceStorageMeta.ContainsKey( globalGeometrySectionStructBlock ) )
                {
                    instanceBaseId = instanceOffset;
                    InstanceStorageMeta.Add( globalGeometrySectionStructBlock,
                        new InstanceDataStorageInfo( instanceOffset, instanceData.Count ) );
                }
                else
                {
                    insert = true;
                    var instanceDataStorageInfo = InstanceStorageMeta[ globalGeometrySectionStructBlock ];
                    instanceOffset = instanceDataStorageInfo.InstanceOffset + instanceDataStorageInfo.InstanceCount;
                    instanceDataStorageInfo.InstanceCount += instanceData.Count;
                    instanceBaseId = instanceDataStorageInfo.InstanceOffset;
                }
            }
            if ( insert )
            {
                InstanceData.InsertRange( instanceOffset, instanceData );
            }
            else
            {
                InstanceData.AddRange( instanceData );
            }
        }

        public void QueueInstanceData( IEnumerable<GlobalGeometrySectionStructBlock> sectionStructBlocks,
            ICollection<Matrix4> intanceWorldMatrices )
        {
            int discard;
            QueueInstanceData( sectionStructBlocks, intanceWorldMatrices, out discard );
        }

        public void QueueSectionData( IEnumerable<GlobalGeometrySectionStructBlock> sectionStructBlocks )
        {
            if ( !ProcessingBucket ) throw new InvalidOperationException( );
            SectionBlockQueue.AddRange( sectionStructBlocks );
        }

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

        public static void UnpackVertexData( RenderModelBlock renderModel )
        {
            foreach ( var renderModelSectionBlock in renderModel.Sections )
            {
                UnpackAttributeData( renderModelSectionBlock.SectionData[ 0 ].Section, renderModel.CompressionInfo[ 0 ] );
            }
        }

        internal void Draw( IEnumerable<RenderPatch> drawStubs )
        {
            foreach ( var stub in drawStubs )
            {
                //stub.part
            }
        }

        private static int GetSectionTypeIdent( GlobalGeometrySectionStructBlock section )
        {
            var sectionVertexBufferTypes = GetSectionTypes( section );
            return sectionVertexBufferTypes.Sum( e => ( int ) e );
        }

        private static VertexAttributeType[] GetSectionTypes( GlobalGeometrySectionStructBlock section )
        {
            var sectionVertexBufferTypes =
                new VertexAttributeType[section.VertexBuffers.Length];

            for ( var i = 0; i < section.VertexBuffers.Length; ++i )
            {
                sectionVertexBufferTypes[ i ] = section.VertexBuffers[ i ].VertexBuffer.Type;
            }

            return sectionVertexBufferTypes;
        }

        private static Dictionary<int, List<GlobalGeometrySectionStructBlock>> GroupSections(
            IEnumerable<GlobalGeometrySectionStructBlock> sections )
        {
            return
                sections.GroupBy( GetSectionTypeIdent )
                    .Select( g => g ).ToDictionary( e => e.Key, v => new List<GlobalGeometrySectionStructBlock>( v ) );
        }

        private void ProcessBuckets( )
        {
            //var sectionGroups = GroupSections( SectionBlockQueue );
            //var buckets = new List<Bucket>( sectionGroups.Count );
            //foreach ( var group in sectionGroups )
            //{
            //    if ( group.Value.Count <= 0 ) continue;

            //    var types = GetSectionTypes( group.Value.First( ) );
            //    var bucket = new Bucket( types );

            //    bucket.BufferData( group.Value );

            //    if ( InstanceData.Count > 0 )
            //    {
            //        bucket.BufferInstanceData( InstanceData );
            //        foreach ( var globalGeometrySectionStructBlock in bucket )
            //        {
            //            if ( InstanceStorageMeta.ContainsKey( globalGeometrySectionStructBlock ) )
            //                bucket.storageMeta[ globalGeometrySectionStructBlock ].InstanceBufferBaseOffset =
            //                    InstanceStorageMeta[ globalGeometrySectionStructBlock ].InstanceOffset;
            //            if ( InstanceStorageMeta.ContainsKey( globalGeometrySectionStructBlock ) )
            //                bucket.storageMeta[ globalGeometrySectionStructBlock ].InstanceCount =
            //                    InstanceStorageMeta[ globalGeometrySectionStructBlock ].InstanceCount;
            //        }
            //    }


            //    buckets.Add( bucket );
            //}
            //_buckets.AddRange( buckets );
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

        private class BucketHandle : IDisposable
        {
            private readonly BucketManager _manager;

            public BucketHandle( BucketManager manager )
            {
                _manager = manager;
                _manager.ProcessingBucket = true;
                _manager.SectionBlockQueue.Clear( );
                _manager.InstanceData.Clear( );
                _manager.InstanceStorageMeta.Clear( );
            }

            public void Dispose( )
            {
                _manager.ProcessBuckets( );
                _manager.ProcessingBucket = false;
            }
        }

        private class InstanceDataStorageInfo
        {
            public int InstanceCount;
            public readonly int InstanceOffset;

            public InstanceDataStorageInfo( int offset, int count )
            {
                InstanceOffset = offset;
                InstanceCount = count;
            }
        }
    };
}