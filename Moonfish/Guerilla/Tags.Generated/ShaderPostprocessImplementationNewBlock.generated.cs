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
    
    public partial class ShaderPostprocessImplementationNewBlock : GuerillaBlock, IWriteQueueable
    {
        public TagBlockIndexStructBlock BitmapTransforms = new TagBlockIndexStructBlock();
        public TagBlockIndexStructBlock RenderStates = new TagBlockIndexStructBlock();
        public TagBlockIndexStructBlock TextureStates = new TagBlockIndexStructBlock();
        public TagBlockIndexStructBlock PixelConstants = new TagBlockIndexStructBlock();
        public TagBlockIndexStructBlock VertexConstants = new TagBlockIndexStructBlock();
        public override int SerializedSize
        {
            get
            {
                return 10;
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
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.BitmapTransforms.ReadFields(binaryReader)));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.RenderStates.ReadFields(binaryReader)));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.TextureStates.ReadFields(binaryReader)));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.PixelConstants.ReadFields(binaryReader)));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.VertexConstants.ReadFields(binaryReader)));
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.BitmapTransforms.ReadInstances(binaryReader, pointerQueue);
            this.RenderStates.ReadInstances(binaryReader, pointerQueue);
            this.TextureStates.ReadInstances(binaryReader, pointerQueue);
            this.PixelConstants.ReadInstances(binaryReader, pointerQueue);
            this.VertexConstants.ReadInstances(binaryReader, pointerQueue);
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            this.BitmapTransforms.QueueWrites(queueableBinaryWriter);
            this.RenderStates.QueueWrites(queueableBinaryWriter);
            this.TextureStates.QueueWrites(queueableBinaryWriter);
            this.PixelConstants.QueueWrites(queueableBinaryWriter);
            this.VertexConstants.QueueWrites(queueableBinaryWriter);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.Write_(queueableBinaryWriter);
            this.BitmapTransforms.Write_(queueableBinaryWriter);
            this.RenderStates.Write_(queueableBinaryWriter);
            this.TextureStates.Write_(queueableBinaryWriter);
            this.PixelConstants.Write_(queueableBinaryWriter);
            this.VertexConstants.Write_(queueableBinaryWriter);
        }
    }
}
