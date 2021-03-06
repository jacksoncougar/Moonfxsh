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
    
    public partial class ModelVariantBlock : GuerillaBlock, IWriteQueueable
    {
        public Moonfish.Tags.StringIdent Name;
        private byte[] fieldpad = new byte[16];
        public ModelVariantRegionBlock[] Regions = new ModelVariantRegionBlock[0];
        public ModelVariantObjectBlock[] Objects = new ModelVariantObjectBlock[0];
        private byte[] fieldpad0 = new byte[8];
        public Moonfish.Tags.StringIdent DialogueSoundEffect;
        [Moonfish.Tags.TagReferenceAttribute("udlg")]
        public Moonfish.Tags.TagReference Dialogue;
        public override int SerializedSize
        {
            get
            {
                return 56;
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
            this.Name = binaryReader.ReadStringID();
            this.fieldpad = binaryReader.ReadBytes(16);
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(20));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(16));
            this.fieldpad0 = binaryReader.ReadBytes(8);
            this.DialogueSoundEffect = binaryReader.ReadStringID();
            this.Dialogue = binaryReader.ReadTagReference();
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.Regions = base.ReadBlockArrayData<ModelVariantRegionBlock>(binaryReader, pointerQueue.Dequeue());
            this.Objects = base.ReadBlockArrayData<ModelVariantObjectBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            queueableBinaryWriter.QueueWrite(this.Regions);
            queueableBinaryWriter.QueueWrite(this.Objects);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.Write_(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.Name);
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.WritePointer(this.Regions);
            queueableBinaryWriter.WritePointer(this.Objects);
            queueableBinaryWriter.Write(this.fieldpad0);
            queueableBinaryWriter.Write(this.DialogueSoundEffect);
            queueableBinaryWriter.Write(this.Dialogue);
        }
    }
}
