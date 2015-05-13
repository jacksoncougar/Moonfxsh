//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Moonfish.Guerilla.Tags
{
    using Moonfish.Tags;
    using Moonfish.Model;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    
    public partial class ShaderPostprocessImplementationBlock : GuerillaBlock, IWriteQueueable
    {
        public ShaderGpuStateReferenceStructBlock GPUConstantState = new ShaderGpuStateReferenceStructBlock();
        public ShaderGpuStateReferenceStructBlock GPUVolatileState = new ShaderGpuStateReferenceStructBlock();
        public TagBlockIndexStructBlock BitmapParameters = new TagBlockIndexStructBlock();
        public TagBlockIndexStructBlock BitmapTransforms = new TagBlockIndexStructBlock();
        public TagBlockIndexStructBlock ValueParameters = new TagBlockIndexStructBlock();
        public TagBlockIndexStructBlock ColorParameters = new TagBlockIndexStructBlock();
        public TagBlockIndexStructBlock BitmapTransformOverlays = new TagBlockIndexStructBlock();
        public TagBlockIndexStructBlock ValueOverlays = new TagBlockIndexStructBlock();
        public TagBlockIndexStructBlock ColorOverlays = new TagBlockIndexStructBlock();
        public TagBlockIndexStructBlock VertexShaderConstants = new TagBlockIndexStructBlock();
        public override int SerializedSize
        {
            get
            {
                return 44;
            }
        }
        public override int Alignment
        {
            get
            {
                return 4;
            }
        }
        public override System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> ReadFields(System.IO.BinaryReader binaryReader)
        {
            System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(base.ReadFields(binaryReader));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.GPUConstantState.ReadFields(binaryReader)));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.GPUVolatileState.ReadFields(binaryReader)));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.BitmapParameters.ReadFields(binaryReader)));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.BitmapTransforms.ReadFields(binaryReader)));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.ValueParameters.ReadFields(binaryReader)));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.ColorParameters.ReadFields(binaryReader)));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.BitmapTransformOverlays.ReadFields(binaryReader)));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.ValueOverlays.ReadFields(binaryReader)));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.ColorOverlays.ReadFields(binaryReader)));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.VertexShaderConstants.ReadFields(binaryReader)));
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.GPUConstantState.ReadInstances(binaryReader, pointerQueue);
            this.GPUVolatileState.ReadInstances(binaryReader, pointerQueue);
            this.BitmapParameters.ReadInstances(binaryReader, pointerQueue);
            this.BitmapTransforms.ReadInstances(binaryReader, pointerQueue);
            this.ValueParameters.ReadInstances(binaryReader, pointerQueue);
            this.ColorParameters.ReadInstances(binaryReader, pointerQueue);
            this.BitmapTransformOverlays.ReadInstances(binaryReader, pointerQueue);
            this.ValueOverlays.ReadInstances(binaryReader, pointerQueue);
            this.ColorOverlays.ReadInstances(binaryReader, pointerQueue);
            this.VertexShaderConstants.ReadInstances(binaryReader, pointerQueue);
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            this.GPUConstantState.QueueWrites(queueableBinaryWriter);
            this.GPUVolatileState.QueueWrites(queueableBinaryWriter);
            this.BitmapParameters.QueueWrites(queueableBinaryWriter);
            this.BitmapTransforms.QueueWrites(queueableBinaryWriter);
            this.ValueParameters.QueueWrites(queueableBinaryWriter);
            this.ColorParameters.QueueWrites(queueableBinaryWriter);
            this.BitmapTransformOverlays.QueueWrites(queueableBinaryWriter);
            this.ValueOverlays.QueueWrites(queueableBinaryWriter);
            this.ColorOverlays.QueueWrites(queueableBinaryWriter);
            this.VertexShaderConstants.QueueWrites(queueableBinaryWriter);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.Write_(queueableBinaryWriter);
            this.GPUConstantState.Write_(queueableBinaryWriter);
            this.GPUVolatileState.Write_(queueableBinaryWriter);
            this.BitmapParameters.Write_(queueableBinaryWriter);
            this.BitmapTransforms.Write_(queueableBinaryWriter);
            this.ValueParameters.Write_(queueableBinaryWriter);
            this.ColorParameters.Write_(queueableBinaryWriter);
            this.BitmapTransformOverlays.Write_(queueableBinaryWriter);
            this.ValueOverlays.Write_(queueableBinaryWriter);
            this.ColorOverlays.Write_(queueableBinaryWriter);
            this.VertexShaderConstants.Write_(queueableBinaryWriter);
        }
    }
}
