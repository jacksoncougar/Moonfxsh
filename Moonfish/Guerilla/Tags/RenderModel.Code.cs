using OpenTK;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class RenderModelBlock : IResourceContainer<RenderModelSectionDataBlock>
    {
        IEnumerator<IResourceBlock<RenderModelSectionDataBlock>> IEnumerable<IResourceBlock<RenderModelSectionDataBlock>>.GetEnumerator()
        {
            return Sections.Cast<IResourceBlock<RenderModelSectionDataBlock>>().GetEnumerator();
        }

        public IEnumerator GetEnumerator()
        {
            return Sections.GetEnumerator();
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
                 new Vector4(PositionBoundsX.Length / 2, 0.0f, 0.0f, 0.0f),
                 new Vector4(0.0f, PositionBoundsY.Length / 2, 0.0f, 0.0f),
                 new Vector4(0.0f, 0.0f, PositionBoundsZ.Length / 2, 0.0f),
                 new Vector4(PositionBoundsX.Min + PositionBoundsX.Length / 2, PositionBoundsY.Min + PositionBoundsY.Length / 2, PositionBoundsZ.Min + PositionBoundsZ.Length / 2, 1.0f)
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
                Matrix4 translationMatrix = Matrix4.CreateTranslation(Translation);
                Matrix4 rotationMatrix = Matrix4.CreateFromQuaternion(Rotation);
                Matrix4 scaleMatrix = Matrix4.CreateScale(Scale);
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
                RenderModelNodeBlock markerGroup = ((RenderModelNodeBlock) value);
                return markerGroup.Name.ToString();
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}   