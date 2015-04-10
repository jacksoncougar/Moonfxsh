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
        public  ShaderPostprocessImplementationBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 44)]
    public class ShaderPostprocessImplementationBlockBase
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
        internal  ShaderPostprocessImplementationBlockBase(System.IO.BinaryReader binaryReader)
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
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
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
            }
        }
    };
}
