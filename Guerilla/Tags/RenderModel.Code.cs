using Moonfish.ResourceManagement;
using OpenTK;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Moonfish.Tags;

namespace Moonfish.Guerilla.Tags
{
    public partial class RenderModelBlock
    {
    }

    partial class RenderModelSectionBlock : IResourceBlock
    {
        public ResourcePointer GetResourcePointer(int index = 0)
        {
            return GeometryBlockInfo.BlockOffset;
        }

        public int GetResourceLength(int index = 0)
        {
            return GeometryBlockInfo.BlockSize;
        }

        public void SetResourcePointer(ResourcePointer pointer, int index = 0)
        {
            GeometryBlockInfo.BlockOffset = pointer;
        }

        public void SetResourceLength(int length, int index = 0)
        {
            GeometryBlockInfo.BlockSize = length;
        }

        public void LoadSectionData()
        {
            SectionData = new[] {new RenderModelSectionDataBlock {Section = GeometryBlockInfo.LoadSectionData()}};
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