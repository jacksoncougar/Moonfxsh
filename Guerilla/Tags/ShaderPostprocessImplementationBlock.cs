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
        internal  ShaderPostprocessImplementationBlockBase(BinaryReader binaryReader)
        {
            this.gPUConstantState = new ShaderGpuStateReferenceStructBlock(binaryReader);
            this.gPUVolatileState = new ShaderGpuStateReferenceStructBlock(binaryReader);
            this.bitmapParameters = new TagBlockIndexStructBlock(binaryReader);
            this.bitmapTransforms = new TagBlockIndexStructBlock(binaryReader);
            this.valueParameters = new TagBlockIndexStructBlock(binaryReader);
            this.colorParameters = new TagBlockIndexStructBlock(binaryReader);
            this.bitmapTransformOverlays = new TagBlockIndexStructBlock(binaryReader);
            this.valueOverlays = new TagBlockIndexStructBlock(binaryReader);
            this.colorOverlays = new TagBlockIndexStructBlock(binaryReader);
            this.vertexShaderConstants = new TagBlockIndexStructBlock(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
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
    };
}
