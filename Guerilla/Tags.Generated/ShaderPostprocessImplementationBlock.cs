// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class ShaderPostprocessImplementationBlock : ShaderPostprocessImplementationBlockBase
    {
        public ShaderPostprocessImplementationBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 44, Alignment = 4)]
    public class ShaderPostprocessImplementationBlockBase : GuerillaBlock
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
        public override int SerializedSize { get { return 44; } }
        public override int Alignment { get { return 4; } }
        public ShaderPostprocessImplementationBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            gPUConstantState = new ShaderGpuStateReferenceStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(gPUConstantState.ReadFields(binaryReader)));
            gPUVolatileState = new ShaderGpuStateReferenceStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(gPUVolatileState.ReadFields(binaryReader)));
            bitmapParameters = new TagBlockIndexStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(bitmapParameters.ReadFields(binaryReader)));
            bitmapTransforms = new TagBlockIndexStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(bitmapTransforms.ReadFields(binaryReader)));
            valueParameters = new TagBlockIndexStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(valueParameters.ReadFields(binaryReader)));
            colorParameters = new TagBlockIndexStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(colorParameters.ReadFields(binaryReader)));
            bitmapTransformOverlays = new TagBlockIndexStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(bitmapTransformOverlays.ReadFields(binaryReader)));
            valueOverlays = new TagBlockIndexStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(valueOverlays.ReadFields(binaryReader)));
            colorOverlays = new TagBlockIndexStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(colorOverlays.ReadFields(binaryReader)));
            vertexShaderConstants = new TagBlockIndexStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(vertexShaderConstants.ReadFields(binaryReader)));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            gPUConstantState.ReadPointers(binaryReader, blamPointers);
            gPUVolatileState.ReadPointers(binaryReader, blamPointers);
            bitmapParameters.ReadPointers(binaryReader, blamPointers);
            bitmapTransforms.ReadPointers(binaryReader, blamPointers);
            valueParameters.ReadPointers(binaryReader, blamPointers);
            colorParameters.ReadPointers(binaryReader, blamPointers);
            bitmapTransformOverlays.ReadPointers(binaryReader, blamPointers);
            valueOverlays.ReadPointers(binaryReader, blamPointers);
            colorOverlays.ReadPointers(binaryReader, blamPointers);
            vertexShaderConstants.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
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
