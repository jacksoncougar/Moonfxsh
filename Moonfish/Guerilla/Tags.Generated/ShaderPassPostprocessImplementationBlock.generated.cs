//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Moonfish.Guerilla.Tags
{
    using JetBrains.Annotations;
    using Moonfish.Tags;
    using Moonfish.Model;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    
    [JetBrains.Annotations.UsedImplicitlyAttribute(ImplicitUseTargetFlags.WithMembers)]
    [TagBlockOriginalNameAttribute("shader_pass_postprocess_implementation_block")]
    public partial class ShaderPassPostprocessImplementationBlock : GuerillaBlock, IWriteDeferrable
    {
        public ShaderGpuStateStructBlock GPUState = new ShaderGpuStateStructBlock();
        public ShaderGpuStateReferenceStructBlock GPUConstantState = new ShaderGpuStateReferenceStructBlock();
        public ShaderGpuStateReferenceStructBlock GPUVolatileState = new ShaderGpuStateReferenceStructBlock();
        public ShaderGpuStateReferenceStructBlock GPUDefaultState = new ShaderGpuStateReferenceStructBlock();
        [Moonfish.Tags.TagReferenceAttribute("vrtx")]
        public Moonfish.Tags.TagReference VertexShader;
        private byte[] fieldskip = new byte[8];
        private byte[] fieldskip0 = new byte[8];
        private byte[] fieldskip1 = new byte[4];
        private byte[] fieldskip2 = new byte[4];
        public ExternReferenceBlock[] ValueExterns = new ExternReferenceBlock[0];
        public ExternReferenceBlock[] ColorExterns = new ExternReferenceBlock[0];
        public ExternReferenceBlock[] SwitchExterns = new ExternReferenceBlock[0];
        public short BitmapParameterCount;
        private byte[] fieldpad = new byte[2];
        private byte[] fieldskip3 = new byte[240];
        public PixelShaderFragmentBlock[] PixelShaderFragments = new PixelShaderFragmentBlock[0];
        public PixelShaderPermutationBlock[] PixelShaderPermutations = new PixelShaderPermutationBlock[0];
        public PixelShaderCombinerBlock[] PixelShaderCombiners = new PixelShaderCombinerBlock[0];
        public PixelShaderConstantBlock[] PixelShaderConstants = new PixelShaderConstantBlock[0];
        private byte[] fieldskip4 = new byte[4];
        private byte[] fieldskip5 = new byte[4];
        public override int SerializedSize
        {
            get
            {
                return 438;
            }
        }
        public override int Alignment
        {
            get
            {
                return 4;
            }
        }
        public override System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> ReadFields(Moonfish.Guerilla.BlamBinaryReader binaryReader)
        {
            System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(base.ReadFields(binaryReader));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.GPUState.ReadFields(binaryReader)));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.GPUConstantState.ReadFields(binaryReader)));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.GPUVolatileState.ReadFields(binaryReader)));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.GPUDefaultState.ReadFields(binaryReader)));
            this.VertexShader = binaryReader.ReadTagReference();
            this.fieldskip = binaryReader.ReadBytes(8);
            this.fieldskip0 = binaryReader.ReadBytes(8);
            this.fieldskip1 = binaryReader.ReadBytes(4);
            this.fieldskip2 = binaryReader.ReadBytes(4);
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(2));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(2));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(2));
            this.BitmapParameterCount = binaryReader.ReadInt16();
            this.fieldpad = binaryReader.ReadBytes(2);
            this.fieldskip3 = binaryReader.ReadBytes(240);
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(4));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(16));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(32));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(6));
            this.fieldskip4 = binaryReader.ReadBytes(4);
            this.fieldskip5 = binaryReader.ReadBytes(4);
            return pointerQueue;
        }
        public override void ReadInstances(Moonfish.Guerilla.BlamBinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.GPUState.ReadInstances(binaryReader, pointerQueue);
            this.GPUConstantState.ReadInstances(binaryReader, pointerQueue);
            this.GPUVolatileState.ReadInstances(binaryReader, pointerQueue);
            this.GPUDefaultState.ReadInstances(binaryReader, pointerQueue);
            this.ValueExterns = base.ReadBlockArrayData<ExternReferenceBlock>(binaryReader, pointerQueue.Dequeue());
            this.ColorExterns = base.ReadBlockArrayData<ExternReferenceBlock>(binaryReader, pointerQueue.Dequeue());
            this.SwitchExterns = base.ReadBlockArrayData<ExternReferenceBlock>(binaryReader, pointerQueue.Dequeue());
            this.PixelShaderFragments = base.ReadBlockArrayData<PixelShaderFragmentBlock>(binaryReader, pointerQueue.Dequeue());
            this.PixelShaderPermutations = base.ReadBlockArrayData<PixelShaderPermutationBlock>(binaryReader, pointerQueue.Dequeue());
            this.PixelShaderCombiners = base.ReadBlockArrayData<PixelShaderCombinerBlock>(binaryReader, pointerQueue.Dequeue());
            this.PixelShaderConstants = base.ReadBlockArrayData<PixelShaderConstantBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void DeferReferences(Moonfish.Guerilla.LinearBinaryWriter queueableBinaryWriter)
        {
            base.DeferReferences(queueableBinaryWriter);
            this.GPUState.DeferReferences(queueableBinaryWriter);
            this.GPUConstantState.DeferReferences(queueableBinaryWriter);
            this.GPUVolatileState.DeferReferences(queueableBinaryWriter);
            this.GPUDefaultState.DeferReferences(queueableBinaryWriter);
            queueableBinaryWriter.Defer(this.ValueExterns);
            queueableBinaryWriter.Defer(this.ColorExterns);
            queueableBinaryWriter.Defer(this.SwitchExterns);
            queueableBinaryWriter.Defer(this.PixelShaderFragments);
            queueableBinaryWriter.Defer(this.PixelShaderPermutations);
            queueableBinaryWriter.Defer(this.PixelShaderCombiners);
            queueableBinaryWriter.Defer(this.PixelShaderConstants);
        }
        public override void Write(Moonfish.Guerilla.LinearBinaryWriter queueableBinaryWriter)
        {
            base.Write(queueableBinaryWriter);
            this.GPUState.Write(queueableBinaryWriter);
            this.GPUConstantState.Write(queueableBinaryWriter);
            this.GPUVolatileState.Write(queueableBinaryWriter);
            this.GPUDefaultState.Write(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.VertexShader);
            queueableBinaryWriter.Write(this.fieldskip);
            queueableBinaryWriter.Write(this.fieldskip0);
            queueableBinaryWriter.Write(this.fieldskip1);
            queueableBinaryWriter.Write(this.fieldskip2);
            queueableBinaryWriter.WritePointer(this.ValueExterns);
            queueableBinaryWriter.WritePointer(this.ColorExterns);
            queueableBinaryWriter.WritePointer(this.SwitchExterns);
            queueableBinaryWriter.Write(this.BitmapParameterCount);
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.Write(this.fieldskip3);
            queueableBinaryWriter.WritePointer(this.PixelShaderFragments);
            queueableBinaryWriter.WritePointer(this.PixelShaderPermutations);
            queueableBinaryWriter.WritePointer(this.PixelShaderCombiners);
            queueableBinaryWriter.WritePointer(this.PixelShaderConstants);
            queueableBinaryWriter.Write(this.fieldskip4);
            queueableBinaryWriter.Write(this.fieldskip5);
        }
    }
}
