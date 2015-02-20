using OpenTK;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using Fasterflect;
using Moonfish.Graphics;
using Moonfish.ResourceManagement;
using Moonfish.Tags;
using OpenTK.Graphics.ES30;
using Moonfish.Collision;
using System.Drawing;

namespace Moonfish.Guerilla.Tags
{
    public partial class RenderModelBlock
    {
    }

    partial class RenderModelSectionBlock
    {
        /// <summary>
        /// Loads geometry data into the tagblock from resource stream
        /// </summary>
        /// <param name="binaryReader"></param>
        /// <returns></returns>
        internal override RenderModelSectionDataBlock[] ReadRenderModelSectionDataBlockArray( BinaryReader binaryReader )
        {
            binaryReader.ReadBytes( 8 );
            using( binaryReader.BaseStream.Pin( ) )
            {
                var geometryBlockInfo = new GlobalGeometryBlockInfoStructBlock( binaryReader );
                ResourceStream source = Halo2.GetResourceBlock( geometryBlockInfo );
                BinaryReader reader = new BinaryReader( source );
                return new[] { new RenderModelSectionDataBlock( reader ) };
            }
        }
    }

    public partial class GlobalGeometryCompressionInfoBlock
    {
        public Matrix4 ToExtentsMatrix( )
        {
            Matrix4 extents_matrix = new Matrix4(
                new Vector4( positionBoundsX.Length / 2, 0.0f, 0.0f, 0.0f ),
                new Vector4( 0.0f, positionBoundsY.Length / 2, 0.0f, 0.0f ),
                new Vector4( 0.0f, 0.0f, positionBoundsZ.Length / 2, 0.0f ),
                new Vector4( positionBoundsX.Min + positionBoundsX.Length / 2, positionBoundsY.Min + positionBoundsY.Length / 2, positionBoundsZ.Min + positionBoundsZ.Length / 2, 1.0f )
                );
            return extents_matrix;
        }

        public Vector3 ToHalfExtents( )
        {
            return new Vector3( positionBoundsX.Length / 2, positionBoundsY.Length / 2, positionBoundsZ.Length / 2 );
        }
    };

    [TypeConverter( typeof( ExpandableObjectConverter ) )]
    partial class RenderModelMarkerBlock
    {
        public byte RegionIndex { get { return this.regionIndex; } set { this.regionIndex = value; } }
        public byte PermutationIndex { get { return this.permutationIndex; } set { this.permutationIndex = value; } }
        public byte NodeIndex { get { return this.nodeIndex; } set { this.nodeIndex = value; } }
        public Vector3 Translation { get { return this.translation; } set { this.translation = value; } }
        public Quaternion Rotation { get { return this.rotation; } set { this.rotation = value; } }
        public float Scale { get { return this.scale == 0 ? 1 : this.scale; } set { this.scale = value; } }
    };

    [TypeConverter( typeof( MarkerGroupConverter ) )]
    partial class RenderModelMarkerGroupBlock
    {
        public RenderModelMarkerBlock[] Markers { get { return this.markers; } }
    };

    partial class RenderModelNodeBlock
    {
        public Matrix4 WorldMatrix
        {
            get
            {
                var worldMatrix = Matrix4.Identity;
                var translation = Matrix4.CreateTranslation( this.defaultTranslation );
                var rotation = Matrix4.CreateFromQuaternion( this.defaultRotation.Normalized( ) );
                return worldMatrix = rotation * translation * Matrix4.Identity;
            }
        }
    };

    class MarkerGroupConverter : ExpandableObjectConverter
    {
        public override object ConvertTo( ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType )
        {
            if( destinationType == typeof( string ) && value is RenderModelMarkerGroupBlock )
            {
                var markerGroup = ( value as RenderModelMarkerGroupBlock );
                return markerGroup.name.ToString( );
            }
            return base.ConvertTo( context, culture, value, destinationType );
        }
    }

    partial class GlobalGeometrySectionStructBlock
    {
        internal override GlobalGeometrySectionVertexBufferBlock[] ReadGlobalGeometrySectionVertexBufferBlockArray( BinaryReader binaryReader )
        {
            var vertexBuffers = base.ReadGlobalGeometrySectionVertexBufferBlockArray( binaryReader );
            using( binaryReader.BaseStream.Pin( ) )
            {
                if( binaryReader.BaseStream is ResourceStream )
                {
                    var stream = binaryReader.BaseStream as ResourceStream;

                    var vertexBufferResources = stream.Resources.Where(
                        x => x.type == GlobalGeometryBlockResourceBlockBase.Type.VertexBuffer ).ToArray( );

                    for( int i = 0; i < vertexBuffers.Length; i++ )
                    {
                        vertexBuffers[i].vertexBuffer.Data = stream.GetResourceData( vertexBufferResources[i] );
                    }
                }
                return vertexBuffers;
            }
        }
    }
}
