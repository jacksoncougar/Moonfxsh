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
    
    [TagClassAttribute("adlg")]
    public partial class AiDialogueGlobalsBlock : GuerillaBlock, IWriteQueueable
    {
        public VocalizationDefinitionsBlock0[] Vocalizations = new VocalizationDefinitionsBlock0[0];
        public VocalizationPatternsBlock[] Patterns = new VocalizationPatternsBlock[0];
        private byte[] fieldpad = new byte[12];
        public DialogueDataBlock[] DialogueData = new DialogueDataBlock[0];
        public InvoluntaryDataBlock[] InvoluntaryData = new InvoluntaryDataBlock[0];
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
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(96));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(64));
            this.fieldpad = binaryReader.ReadBytes(12);
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(4));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(4));
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.Vocalizations = base.ReadBlockArrayData<VocalizationDefinitionsBlock0>(binaryReader, pointerQueue.Dequeue());
            this.Patterns = base.ReadBlockArrayData<VocalizationPatternsBlock>(binaryReader, pointerQueue.Dequeue());
            this.DialogueData = base.ReadBlockArrayData<DialogueDataBlock>(binaryReader, pointerQueue.Dequeue());
            this.InvoluntaryData = base.ReadBlockArrayData<InvoluntaryDataBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            queueableBinaryWriter.QueueWrite(this.Vocalizations);
            queueableBinaryWriter.QueueWrite(this.Patterns);
            queueableBinaryWriter.QueueWrite(this.DialogueData);
            queueableBinaryWriter.QueueWrite(this.InvoluntaryData);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.Write_(queueableBinaryWriter);
            queueableBinaryWriter.WritePointer(this.Vocalizations);
            queueableBinaryWriter.WritePointer(this.Patterns);
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.WritePointer(this.DialogueData);
            queueableBinaryWriter.WritePointer(this.InvoluntaryData);
        }
    }
}
namespace Moonfish.Tags
{
    
    public partial struct TagClass
    {
        public static TagClass Adlg = ((TagClass)("adlg"));
    }
}
