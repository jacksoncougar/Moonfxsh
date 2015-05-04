using Moonfish.ResourceManagement;
using OpenTK;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Moonfish.Graphics;
using Moonfish.Tags;

namespace Moonfish.Guerilla.Tags
{
    public partial class RenderModelBlock
    {
    }

    partial class RenderModelSectionBlock : IResourceBlock
    {

        void IResourceBlock.LoadRawResources()
        {
            var source = Halo2.GetResourceBlock(geometryBlockInfo);
            using (var binaryReader = new BinaryReader(source))
            {
                sectionData = new[] {new RenderModelSectionDataBlock()};
                sectionData[0].Read(binaryReader);

                var vertexBufferResources = source.Resources.Where(
                    x => x.type == GlobalGeometryBlockResourceBlockBase.Type.VertexBuffer).ToArray();

                for (int i = 0; i < sectionData[0].section.vertexBuffers.Length; i++)
                {
                    sectionData[0].section.vertexBuffers[i].vertexBuffer.Data =
                        source.GetResourceData(vertexBufferResources[i]);
                }
            }
        }

        byte[] IResourceBlock.GetRawResourceBytes()
        {
            throw new NotImplementedException();
        }
    }

    public partial class GlobalGeometryCompressionInfoBlock
    {
        public Vector4 ExtractTexcoordScaling( )
        {
            return new Vector4(
                texcoordBoundsX.Min,
                texcoordBoundsX.Max,
                texcoordBoundsY.Min,
                texcoordBoundsY.Max
                );
        }

        public Matrix4 ToObjectMatrix( )
        {
            Matrix4 extents_matrix = new Matrix4(
                new Vector4( 12, 0.0f, 0.0f, 0.0f ),
                new Vector4( 0.0f, 1, 0.0f, 0.0f ),
                new Vector4( 0.0f, 0.0f, 1, 0.0f ),
                new Vector4( 0, 0, 0, 1.0f )
                );
            return extents_matrix;
        }

        public Vector3 ToHalfExtents( )
        {
            return new Vector3( positionBoundsX.Length / 2, positionBoundsY.Length / 2, positionBoundsZ.Length / 2 );
        }
    };

    [TypeConverter( typeof ( MarkerGroupConverter ) )]
    partial class RenderModelMarkerBlock
    {
        public byte RegionIndex
        {
            get { return regionIndex; }
            set { regionIndex = value; }
        }

        public byte PermutationIndex
        {
            get { return permutationIndex; }
            set { permutationIndex = value; }
        }

        public byte NodeIndex
        {
            get { return nodeIndex; }
            set { nodeIndex = value; }
        }

        public Vector3 Translation
        {
            get { return translation; }
            set { translation = value; }
        }

        public Quaternion Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }

        public float Scale
        {
            get { return scale.NearlyEqual( 0 ) ? 1 : scale; }
            set { scale = value; }
        }

        public Matrix4 WorldMatrix
        {
            get
            {
                var translationMatrix = Matrix4.CreateTranslation( translation );
                var rotationMatrix = Matrix4.CreateFromQuaternion( rotation );
                var scaleMatrix = Matrix4.CreateScale( scale );
                return scaleMatrix * rotationMatrix * translationMatrix;
            }
        }
    };

    [TypeConverter( typeof ( MarkerGroupConverter ) )]
    partial class RenderModelMarkerGroupBlock
    {
        public RenderModelMarkerBlock[] Markers
        {
            get { return markers; }
        }
    };

    internal class MarkerGroupConverter : ExpandableObjectConverter
    {
        public override object ConvertTo( ITypeDescriptorContext context, System.Globalization.CultureInfo culture,
            object value, Type destinationType )
        {
            if ( destinationType == typeof ( string ) && value is RenderModelNodeBlock )
            {
                var markerGroup = ( ( RenderModelNodeBlock ) value );
                return markerGroup.name.ToString( );
            }
            return base.ConvertTo( context, culture, value, destinationType );
        }
    }

    partial class GlobalGeometrySectionStructBlock
    {
        internal GlobalGeometrySectionVertexBufferBlock[] ReadGlobalGeometrySectionVertexBufferBlockArray(
            BinaryReader binaryReader )
        {
            var vertexBuffers = new GlobalGeometrySectionVertexBufferBlock[0];
            //base.ReadGlobalGeometrySectionVertexBufferBlockArray(binaryReader);
            using ( binaryReader.BaseStream.Pin( ) )
            {
                if ( binaryReader.BaseStream is ResourceStream )
                {
                    var stream = binaryReader.BaseStream as ResourceStream;

                    var vertexBufferResources = stream.Resources.Where(
                        x => x.type == GlobalGeometryBlockResourceBlockBase.Type.VertexBuffer ).ToArray( );

                    for ( int i = 0; i < vertexBuffers.Length; i++ )
                    {
                        vertexBuffers[ i ].vertexBuffer.Data = stream.GetResourceData( vertexBufferResources[ i ] );
                    }
                }
                return vertexBuffers;
            }
        }
    }
}