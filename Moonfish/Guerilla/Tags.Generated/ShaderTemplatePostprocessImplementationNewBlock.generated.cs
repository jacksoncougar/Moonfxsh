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
    
    public partial class ShaderTemplatePostprocessImplementationNewBlock : GuerillaBlock, IWriteQueueable
    {
        public TagBlockIndexStructBlock Bitmaps = new TagBlockIndexStructBlock();
        public TagBlockIndexStructBlock PixelConstants = new TagBlockIndexStructBlock();
        public TagBlockIndexStructBlock VertexConstants = new TagBlockIndexStructBlock();
        public override int SerializedSize
        {
            get
            {
                return 6;
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
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.Bitmaps.ReadFields(binaryReader)));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.PixelConstants.ReadFields(binaryReader)));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.VertexConstants.ReadFields(binaryReader)));
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.Bitmaps.ReadInstances(binaryReader, pointerQueue);
            this.PixelConstants.ReadInstances(binaryReader, pointerQueue);
            this.VertexConstants.ReadInstances(binaryReader, pointerQueue);
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.QueueWrites(queueableBlamBinaryWriter);
            this.Bitmaps.QueueWrites(queueableBlamBinaryWriter);
            this.PixelConstants.QueueWrites(queueableBlamBinaryWriter);
            this.VertexConstants.QueueWrites(queueableBlamBinaryWriter);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.Write_(queueableBlamBinaryWriter);
            this.Bitmaps.Write_(queueableBlamBinaryWriter);
            this.PixelConstants.Write_(queueableBlamBinaryWriter);
            this.VertexConstants.Write_(queueableBlamBinaryWriter);
        }
    }
}
