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
            var source = Halo2.GetResourceBlock(GeometryBlockInfo);
            using (var binaryReader = new BinaryReader(source))
            {
                SectionData = new[] {new RenderModelSectionDataBlock()};
                SectionData[0].Read(binaryReader);

                var vertexBufferResources = source.Resources.Where(
                    x => x.Type == GlobalGeometryBlockResourceBlock.TypeEnum.VertexBuffer).ToArray();
                foreach (var buffer in SectionData[0].Section.VertexBuffers)
                    if (buffer.VertexBuffer.Type == VertexAttributeType.None)
                    {
                    }
                for (var i = 0; i < SectionData[0].Section.VertexBuffers.Length; i++)
                {
                    SectionData[0].Section.VertexBuffers[i].VertexBuffer.Data =
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
        public Vector4 ExtractTexcoordScaling()
        {
            return new Vector4(
                TexcoordBoundsX.Min,
                TexcoordBoundsX.Max,
                TexcoordBoundsX.Min,
                TexcoordBoundsX.Max
                );
        }

        public Matrix4 ToObjectMatrix()
        {
            Matrix4 extents_matrix = new Matrix4(
                new Vector4(12, 0.0f, 0.0f, 0.0f),
                new Vector4(0.0f, 1, 0.0f, 0.0f),
                new Vector4(0.0f, 0.0f, 1, 0.0f),
                new Vector4(0, 0, 0, 1.0f)
                );
            return extents_matrix;
        }

        public Vector3 ToHalfExtents()
        {
            return new Vector3(PositionBoundsX.Length/2, PositionBoundsY.Length/2, PositionBoundsZ.Length/2);
        }
    };

    [TypeConverter(typeof (MarkerGroupConverter))]
    partial class RenderModelMarkerBlock
    {

        public Matrix4 WorldMatrix
        {
            get
            {
                var translationMatrix = Matrix4.CreateTranslation(Translation);
                var rotationMatrix = Matrix4.CreateFromQuaternion(Rotation);
                var scaleMatrix = Matrix4.CreateScale(Scale);
                return scaleMatrix*rotationMatrix*translationMatrix;
            }
        }
    };

    [TypeConverter(typeof (MarkerGroupConverter))]
    partial class RenderModelMarkerGroupBlock
    {
    };

    internal class MarkerGroupConverter : ExpandableObjectConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture,
            object value, Type destinationType)
        {
            if (destinationType == typeof (string) && value is RenderModelNodeBlock)
            {
                var markerGroup = ((RenderModelNodeBlock) value);
                return markerGroup.Name.ToString();
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}   