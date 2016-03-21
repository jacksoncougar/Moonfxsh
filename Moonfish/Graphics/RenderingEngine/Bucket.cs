using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;
using OpenTK.Graphics.OpenGL;

namespace Moonfish.Graphics
{
    public class PartBufferLocations
    {
        public PartBufferLocations( int indexBaseOffset, int vertexBaseOffset )
        {
            IndexBaseOffset = indexBaseOffset;
            VertexBaseOffset = vertexBaseOffset;
        }

        public int IndexBaseOffset { get; set; }
        public TagIdent Shader { get; set; }
        public int VertexBaseOffset { get; set; }
    }

    public sealed class Bucket : IDisposable, IEnumerable<GlobalGeometryPartBlockNew>
    {
        private bool _disposed;

        private Dictionary<GlobalGeometryPartBlockNew, PartBufferLocations> _storageMeta =
            new Dictionary<GlobalGeometryPartBlockNew, PartBufferLocations>( );

        public Bucket( VertexAttributeType[] supportedVertexAttributeTypes )
        {
            SupportedVertexAttributes = supportedVertexAttributeTypes;
            VertexArrayObject = GL.GenVertexArray( );
            _instanceDataBuffer = GL.GenBuffer( );

            _attributeBuffers =
                new ReadOnlyDictionary<VertexAttributeType, int>(
                    SupportedVertexAttributes.ToDictionary( k => k,
                        v => GL.GenBuffer( ) ) );
            _elementBuffer = GL.GenBuffer( );
        }

        public int VertexArrayObject { get; }

        private int PartsCount { get; set; }

        public void Dispose( )
        {
            Dispose( true );
        }

        public bool Contains(GlobalGeometryPartBlockNew part)
        {
            return _storageMeta.ContainsKey( part );
        }

        public bool Contains( GlobalGeometrySectionStructBlock section )
        {
            foreach ( var part in section.Parts )
            {
                if ( !_storageMeta.ContainsKey( part ) ) return false;
            }
            return true;
        }

        public IEnumerator<GlobalGeometryPartBlockNew> GetEnumerator( )
        {
            return _storageMeta.Keys.GetEnumerator( );
        }

        IEnumerator IEnumerable.GetEnumerator( )
        {
            return GetEnumerator( );
        }

        public IDisposable Bind( )
        {
            return new Handle( VertexArrayObject );
        }

        public void BufferData( ICollection<GlobalGeometrySectionStructBlock> sectionData )
        {
            PartsCount = 0;

            _storageMeta = new Dictionary<GlobalGeometryPartBlockNew, PartBufferLocations>( );

            GL.BindVertexArray( VertexArrayObject );

            BufferElementData( sectionData );
            BufferAttributeData( sectionData );

            GL.BindVertexArray( 0 );
        }

        public PartBufferLocations GetBufferLocation( GlobalGeometryPartBlockNew part )
        {
            return _storageMeta[ part ];
        }

        private void BufferAttributeData( ICollection<GlobalGeometrySectionStructBlock> sectionData )
        {
            var firstPass = true;
            var index = 0;

            MoonGL.VertexAttribArray( 7, 7, 4, VertexAttribType.Float, false, 0, 1 );
            MoonGL.VertexAttribArray( 8, 7, 4, VertexAttribType.Float, false, 16, 1 );
            MoonGL.VertexAttribArray( 9, 7, 4, VertexAttribType.Float, false, 32, 1 );
            MoonGL.VertexAttribArray( 10, 7, 4, VertexAttribType.Float, false, 48, 1 );

            foreach ( var supportedFormat in SupportedVertexAttributes )
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
                    var vertexBuffer =
                        renderModelSectionDataBlock.VertexBuffers.Select( u => u.VertexBuffer )
                            .Single( e => e.Type == supportedFormat );

                    GL.BufferSubData( BufferTarget.ArrayBuffer, ( IntPtr ) offset,
                        ( IntPtr ) vertexBuffer.Data.Length,
                        vertexBuffer.Data );

                    if ( firstPass )
                    {
                        foreach ( var part in renderModelSectionDataBlock.Parts )
                        {
                            SetVertexOffset( part, vertexOffset );
                        }
                    }
                    vertexOffset += vertexBuffer.VertexElementCount;
                    offset += vertexBuffer.Data.Length;
                }
                firstPass = false;
                GL.BindVertexBuffer( index, _attributeBuffers[ supportedFormat ], ( IntPtr ) 0, attributeSize );
                ConfigureVertexAttributeArray( supportedFormat, index );
                index++;
            }
        }

        private void BufferElementData( ICollection<GlobalGeometrySectionStructBlock> sectionData )
        {
            var offset = 0;
            var indexBufferSize = sectionData.Sum( x => Padding.Align( x.StripIndices.Length * sizeof ( ushort ) ) );
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

                foreach ( var part in renderModelSectionDataBlock.Parts )
                {
                    SetIndexOffset( part, offset );
                }
                offset += dataSize;
            }
        }

        /// <summary>
        ///     Calls glVertexAttribPointer to setup attributes for shaders and enables the vertex attribute array
        /// </summary>
        /// <param name="type">Type of attribute data</param>
        /// <param name="bindingIndex"></param>
        private static void ConfigureVertexAttributeArray( VertexAttributeType type, int bindingIndex )
        {
            switch ( type )
            {
                case VertexAttributeType.UnpackedWorldCoordinateData:
                    MoonGL.VertexAttribArray( 0, bindingIndex, 3, VertexAttribType.Float );
                    MoonGL.VertexAttribArray( 1, bindingIndex, 4, VertexAttribType.Byte, false, 12 );
                    MoonGL.VertexAttribArray( 2, bindingIndex, 4, VertexAttribType.Float, false, 16 );
                    break;
                case VertexAttributeType.UnpackedTextureCoordinateData:
                    MoonGL.VertexAttribArray( 3, bindingIndex, 2, VertexAttribType.Float );
                    break;
                case VertexAttributeType.UnpackedLightingData:
                    MoonGL.VertexAttribArray( 4, bindingIndex, 3, VertexAttribType.Float );
                    MoonGL.VertexAttribArray( 5, bindingIndex, 3, VertexAttribType.Float, false, 12 );
                    MoonGL.VertexAttribArray( 6, bindingIndex, 3, VertexAttribType.Float, false, 24 );
                    break;
                case VertexAttributeType.CoordinateFloat:
                    MoonGL.VertexAttribArray( 0, bindingIndex, 3, VertexAttribType.Float );
                    break;
                case VertexAttributeType.TextureCoordinateFloat:
                    MoonGL.VertexAttribArray( 3, bindingIndex, 2, VertexAttribType.Float );
                    break;
                case VertexAttributeType.LightmapUVCoordinateOneXbox:
                    MoonGL.VertexAttribArray( 11, bindingIndex, 2, VertexAttribType.Short, true );
                    break;
                case VertexAttributeType.LightmapUVCoordinateTwoXbox:
                    MoonGL.VertexAttribArray( 12, bindingIndex, 2, VertexAttribType.Short, true );
                    break;
                default:
                    return;
            }
        }

        private void Dispose( bool disposing )
        {
            if ( _disposed || !disposing ) return;
            GL.DeleteVertexArray( VertexArrayObject );
            GL.DeleteBuffers( _attributeBuffers.Values.Count, _attributeBuffers.Values.ToArray( ) );
            GL.DeleteBuffer( _elementBuffer );
            GL.DeleteBuffer( _instanceDataBuffer );
            GL.BindVertexArray( 0 );
            _disposed = true;
        }

        private void SetIndexOffset( GlobalGeometryPartBlockNew part, int offset )
        {
            if ( !_storageMeta.ContainsKey( part ) )
            {
                _storageMeta.Add( part, new PartBufferLocations( offset, 0 ) );
                return;
            }
            _storageMeta[ part ].IndexBaseOffset = offset;
        }

        private void SetVertexOffset( GlobalGeometryPartBlockNew part, int offset )
        {
            if ( !_storageMeta.ContainsKey( part ) )
            {
                _storageMeta.Add( part, new PartBufferLocations( 0, offset ) );
                return;
            }
            _storageMeta[ part ].VertexBaseOffset = offset;
        }

        private class Handle : IDisposable
        {
            private bool _disposed;

            public Handle( int vertexArrayObject )
            {
                GL.BindVertexArray( vertexArrayObject );
            }

            public void Dispose( )
            {
                Dispose( true );
                GC.SuppressFinalize( this );
            }

            private void Dispose( bool disposing )
            {
                if ( !disposing || _disposed ) return;
                _disposed = true;
            }
        }

        #region OpenGL Buffer Handles

        private readonly ReadOnlyDictionary<VertexAttributeType, int> _attributeBuffers;
        private readonly int _elementBuffer;
        private readonly int _instanceDataBuffer;

        #endregion

        #region Properties

        public int BufferSize { get; private set; }
        public GlobalGeometryPartBlockNew.TypeEnum GeometryType { get; private set; }
        public VertexAttributeType[] SupportedVertexAttributes { get; }
        public int VertexAttributeId => SupportedVertexAttributes.GetVertexAttributesId( );

        #endregion

        public PartBufferLocations this [ GlobalGeometryPartBlockNew part ]
        {
            get { return GetBufferLocation( part ); }
        }
    }
}