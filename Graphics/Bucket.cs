using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Moonfish.Guerilla.Tags;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Moonfish.Graphics
{
    public class MeshFragmentInfo
    {
        public int IndexBufferBaseOffset;
        public int VertexBufferBaseOffset;
        public int InstanceBufferBaseOffset;
        public int InstanceCount;
    }
    
    public class Bucket : IDisposable, IEnumerable<GlobalGeometrySectionStructBlock>
    {
        private readonly ReadOnlyDictionary<VertexAttributeType, int> _attributeBuffers;
        private readonly int _elementBuffer;
        private readonly int _instanceDataBuffer;

        private readonly int _vertexArrayObject;
        private bool _disposed;

        private BucketAttributes attributes;

        public Dictionary<GlobalGeometrySectionStructBlock, MeshFragmentInfo> storageMeta =
            new Dictionary<GlobalGeometrySectionStructBlock, MeshFragmentInfo>( );
        
        public Bucket( VertexAttributeType[] supportedVertexAttributeTypes )
        {
            attributes.SupportedVertexAttributes = supportedVertexAttributeTypes;
            _vertexArrayObject = GL.GenVertexArray( );
            _instanceDataBuffer = GL.GenBuffer( );

            _attributeBuffers =
                new ReadOnlyDictionary<VertexAttributeType, int>(
                    attributes.SupportedVertexAttributes.ToDictionary( k => k,
                        v => GL.GenBuffer( ) ) );
            _elementBuffer = GL.GenBuffer( );
        }

        public int InstanceCount { get; private set; }

        public int PartsCount { get; private set; }

        public int VertexArrayObject
        {
            get { return _vertexArrayObject; }
        }

        public void Dispose( )
        {
            Dispose( true );
            GC.SuppressFinalize( this );
        }

        public IEnumerator<GlobalGeometrySectionStructBlock> GetEnumerator( )
        {
            return storageMeta.Keys.GetEnumerator( );
        }

        IEnumerator IEnumerable.GetEnumerator( )
        {
            return GetEnumerator( );
        }

        public IDisposable Bind( bool keepBound = true )
        {
            return new Handle( VertexArrayObject, keepBound);
        }

        public void BufferData( List<GlobalGeometrySectionStructBlock> sectionData )
        {
            PartsCount = 0;

            storageMeta =
                new Dictionary<GlobalGeometrySectionStructBlock, MeshFragmentInfo>(
                    sectionData.ToDictionary(k => k, v => new MeshFragmentInfo()));

            GL.BindVertexArray( VertexArrayObject );

            BufferElementData( sectionData );

            BufferAttributeData( sectionData );

            GL.BindVertexArray( 0 );
        }
        
        public void BufferInstanceSubData(IReadOnlyList<Matrix4> objectInstanceWorldMatrixs, int offset)
        {
            var count = objectInstanceWorldMatrixs.Count;
            var stride = Vector4.SizeInBytes * 4;
            var instanceDataSize = count * stride;

            var buffer = new byte[instanceDataSize];
            using (var binaryWriter = new BinaryWriter(new MemoryStream(buffer)))
            {
                for (var i = 0; i < count; i++)
                {
                    // Write Row-Major
                    binaryWriter.Write(objectInstanceWorldMatrixs[i].Row0);
                    binaryWriter.Write(objectInstanceWorldMatrixs[i].Row1);
                    binaryWriter.Write(objectInstanceWorldMatrixs[i].Row2);
                    binaryWriter.Write(objectInstanceWorldMatrixs[i].Row3);
                }
            }

            GL.BindVertexArray(VertexArrayObject);

            GL.BindBuffer(BufferTarget.ArrayBuffer, _instanceDataBuffer);
            GL.BufferSubData(BufferTarget.ArrayBuffer, (IntPtr) offset, (IntPtr)instanceDataSize, buffer);

            GL.BindVertexArray(0);
        }

        public void BufferInstanceData( IReadOnlyList<Matrix4> objectInstanceWorldMatrixs )
        {
            var count = InstanceCount = objectInstanceWorldMatrixs.Count;
            var stride = Vector4.SizeInBytes * 4;
            var instanceDataSize = count * stride;

            var buffer = new byte[instanceDataSize];
            using ( var binaryWriter = new BinaryWriter( new MemoryStream( buffer ) ) )
            {
                for ( var i = 0; i < count; i++ )
                {
                    // Write Row-Major
                    binaryWriter.Write( objectInstanceWorldMatrixs[ i ].Row0 );
                    binaryWriter.Write( objectInstanceWorldMatrixs[ i ].Row1 );
                    binaryWriter.Write( objectInstanceWorldMatrixs[ i ].Row2 );
                    binaryWriter.Write( objectInstanceWorldMatrixs[ i ].Row3 );
                }
            }

            GL.BindVertexArray( VertexArrayObject );

            GL.BindBuffer( BufferTarget.ArrayBuffer, _instanceDataBuffer );
            GL.BufferData( BufferTarget.ArrayBuffer, ( IntPtr ) instanceDataSize, buffer, BufferUsageHint.StaticDraw );

            VertexAttribArray( 7, 4, VertexAttribPointerType.Float, false, stride, 0, 1 );
            VertexAttribArray( 8, 4, VertexAttribPointerType.Float, false, stride, Vector4.SizeInBytes * 1, 1 );
            VertexAttribArray( 9, 4, VertexAttribPointerType.Float, false, stride, Vector4.SizeInBytes * 2, 1 );
            VertexAttribArray( 10, 4, VertexAttribPointerType.Float, false, stride, Vector4.SizeInBytes * 3, 1 );

            GL.BindVertexArray( 0 );
        }

        protected virtual void Dispose( bool disposing )
        {
            if ( _disposed || !disposing ) return;
            GL.DeleteVertexArray( VertexArrayObject );
            GL.DeleteBuffers( _attributeBuffers.Values.Count, _attributeBuffers.Values.ToArray( ) );
            GL.DeleteBuffer( _elementBuffer );
            GL.DeleteBuffer( _instanceDataBuffer );
            GL.BindVertexArray( 0 );
            _disposed = true;
        }

        private void BufferAttributeData( ICollection<GlobalGeometrySectionStructBlock> sectionData )
        {
            var firstPass = true;
            var vertexBaseVertex = sectionData.ToDictionary( k => k, v => 0 );

            foreach ( var supportedFormat in attributes.SupportedVertexAttributes )
            {
                var bufferSize =
                    sectionData.SelectMany( e => e.VertexBuffers )
                        .Where( e => e.VertexBuffer.Type == supportedFormat )
                        .Sum( e => e.VertexBuffer.Data.Length );

                int attributeSize = supportedFormat.GetSize( );

                GL.BindBuffer( BufferTarget.ArrayBuffer, _attributeBuffers[ supportedFormat ] );
                GL.BufferData( BufferTarget.ArrayBuffer, ( IntPtr ) bufferSize, ( IntPtr ) null,
                    BufferUsageHint.StaticDraw );

                var offset = 0;
                var vertexOffset = 0;
                foreach ( var renderModelSectionDataBlock in sectionData )
                {
                    PartsCount += renderModelSectionDataBlock.Parts.Length;

                    var globalGeometrySectionVertexBufferBlock =
                        renderModelSectionDataBlock.VertexBuffers.First( e => e.VertexBuffer.Type == supportedFormat );

                    GL.BufferSubData( BufferTarget.ArrayBuffer, ( IntPtr ) offset,
                        ( IntPtr ) globalGeometrySectionVertexBufferBlock.VertexBuffer.Data.Length,
                        globalGeometrySectionVertexBufferBlock.VertexBuffer.Data );

                    if ( firstPass )
                    {
                        storageMeta[ renderModelSectionDataBlock ].VertexBufferBaseOffset = vertexOffset;
                        vertexBaseVertex[ renderModelSectionDataBlock ] = vertexOffset;
                        vertexOffset += globalGeometrySectionVertexBufferBlock.VertexBuffer.Data.Length / attributeSize;
                    }

                    offset += globalGeometrySectionVertexBufferBlock.VertexBuffer.Data.Length;
                }
                firstPass = false;

                ConfigureVertexAttributeArray( supportedFormat, attributeSize );
            }
            
        }

        private void BufferElementData( ICollection<GlobalGeometrySectionStructBlock> sectionData )
        {
            var offset = 0;
            var indexBufferSize = sectionData.Sum( x => Padding.Align( x.StripIndices.Length * 2 ) );
            var indexBaseVertex = sectionData.ToDictionary( k => k, v => 0 );

            GL.BindBuffer( BufferTarget.ElementArrayBuffer, _elementBuffer );
            GL.BufferData( BufferTarget.ElementArrayBuffer, ( IntPtr ) indexBufferSize, ( IntPtr ) null,
                BufferUsageHint.StaticDraw );

            GL.BindBuffer( BufferTarget.ElementArrayBuffer, _elementBuffer );
            foreach ( var renderModelSectionDataBlock in sectionData )
            {
                var indices = renderModelSectionDataBlock.StripIndices.Select( e => e.Index ).ToArray( );
                var dataSize = Padding.Align( indices.Length * sizeof ( ushort ) );

                GL.BufferSubData( BufferTarget.ElementArrayBuffer, ( IntPtr ) offset, ( IntPtr ) dataSize, indices );

                indexBaseVertex[ renderModelSectionDataBlock ] = offset;
                
                storageMeta[renderModelSectionDataBlock].IndexBufferBaseOffset = offset;
                offset += dataSize;

            }
            new ReadOnlyDictionary<GlobalGeometrySectionStructBlock, int>( indexBaseVertex );
        }

        /// <summary>
        ///     Calls glVertexAttribPointer to setup attributes for shaders and enables the vertex attribute array
        /// </summary>
        /// <param name="type">Type of attribute data</param>
        /// <param name="stride">Distance between consequetive attribute elements</param>
        private static void ConfigureVertexAttributeArray( VertexAttributeType type, int stride )
        {
            switch ( type )
            {
                case VertexAttributeType.UnpackedWorldCoordinateData:
                    VertexAttribArray( 0, 3, VertexAttribPointerType.Float, false, stride );
                    VertexAttribArray( 1, 4, VertexAttribPointerType.Byte, false, stride, 12 );
                    VertexAttribArray( 2, 4, VertexAttribPointerType.Float, false, stride, 16 );
                    break;
                case VertexAttributeType.UnpackedTextureCoordinateData:
                    VertexAttribArray( 3, 2, VertexAttribPointerType.Float, false, stride );
                    break;
                case VertexAttributeType.UnpackedLightingData:
                    VertexAttribArray( 4, 3, VertexAttribPointerType.Float, false, stride );
                    VertexAttribArray( 5, 3, VertexAttribPointerType.Float, false, stride, 12 );
                    VertexAttribArray( 6, 3, VertexAttribPointerType.Float, false, stride, 24 );
                    break;
                case VertexAttributeType.CoordinateFloat:
                    VertexAttribArray( 0, 3, VertexAttribPointerType.Float, false, stride );
                    break;
                case VertexAttributeType.TextureCoordinateFloat:
                    VertexAttribArray( 3, 2, VertexAttribPointerType.Float, false, stride );
                    break;
                case VertexAttributeType.LightmapUVCoordinateOneXbox:
                    VertexAttribArray( 11, 2, VertexAttribPointerType.Short, true, stride );
                    break;
                case VertexAttributeType.LightmapUVCoordinateTwoXbox:
                    VertexAttribArray( 12, 2, VertexAttribPointerType.Short, true, stride );
                    break;
                default:
                    return;
            }
        }

        private static void VertexAttribArray( int index, int count, VertexAttribPointerType type,
            bool normalised = false, int stride = 0, int offset = 0, int divisor = 0 )
        {
            GL.VertexAttribPointer( index, count, type, normalised, stride, offset );
            GL.EnableVertexAttribArray( index );
            GL.VertexAttribDivisor( index, divisor );
        }

        private class Handle : IDisposable
        {
            private readonly bool _keepBound;

            public Handle( int vertexArrayObject, bool keepBound = true )
            {
                _keepBound = keepBound;
                GL.BindVertexArray( vertexArrayObject );
            }

            public void Dispose( )
            {
                if ( !_keepBound ) GL.BindVertexArray( 0 );
            }
        }
    }
}