// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ShaderPostprocessImplementationBlock : ShaderPostprocessImplementationBlockBase
    {
        public  ShaderPostprocessImplementationBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 44, Alignment = 4)]
    public class ShaderPostprocessImplementationBlockBase  : IGuerilla
    {
        internal ShaderGpuStateReferenceStructBlock gPUConstantState;
        internal ShaderGpuStateReferenceStructBlock gPUVolatileState;
        internal TagBlockIndexStructBlock bitmapParameters;
        internal TagBlockIndexStructBlock bitmapTransforms;
        internal TagBlockIndexStructBlock valueParameters;
        internal TagBlockIndexStructBlock colorParameters;
        internal TagBlockIndexStructBlock bitmapTransformOverlays;
        internal TagBlockIndexStructBlock valueOverlays;
        internal TagBlockIndexStructBlock colorOverlays;
        internal TagBlockIndexStructBlock vertexShaderConstants;
        internal  ShaderPostprocessImplementationBlockBase(BinaryReader binaryReader)
        {
            gPUConstantState = new ShaderGpuStateReferenceStructBlock(binaryReader);
            gPUVolatileState = new ShaderGpuStateReferenceStructBlock(binaryReader);
            bitmapParameters = new TagBlockIndexStructBlock(binaryReader);
            bitmapTransforms = new TagBlockIndexStructBlock(binaryReader);
            valueParameters = new TagBlockIndexStructBlock(binaryReader);
            colorParameters = new TagBlockIndexStructBlock(binaryReader);
            bitmapTransformOverlays = new TagBlockIndexStructBlock(binaryReader);
            valueOverlays = new TagBlockIndexStructBlock(binaryReader);
            colorOverlays = new TagBlockIndexStructBlock(binaryReader);
            vertexShaderConstants = new TagBlockIndexStructBlock(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                gPUConstantState.Write(binaryWriter);
                gPUVolatileState.Write(binaryWriter);
                bitmapParameters.Write(binaryWriter);
                bitmapTransforms.Write(binaryWriter);
                valueParameters.Write(binaryWriter);
                colorParameters.Write(binaryWriter);
                bitmapTransformOverlays.Write(binaryWriter);
                valueOverlays.Write(binaryWriter);
                colorOverlays.Write(binaryWriter);
                vertexShaderConstants.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
