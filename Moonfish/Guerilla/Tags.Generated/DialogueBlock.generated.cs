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
    
    [TagClassAttribute("udlg")]
    public partial class DialogueBlock : GuerillaBlock, IWriteQueueable
    {
        [Moonfish.Tags.TagReferenceAttribute("adlg")]
        public Moonfish.Tags.TagReference GlobalDialogueInfo;
        public Flags DialogueFlags;
        public SoundReferencesBlock[] Vocalizations = new SoundReferencesBlock[0];
        public Moonfish.Tags.StringIdent MissionDialogueDesignator;
        public override int SerializedSize
        {
            get
            {
                return 24;
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
            this.GlobalDialogueInfo = binaryReader.ReadTagReference();
            this.DialogueFlags = ((Flags)(binaryReader.ReadInt32()));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(16));
            this.MissionDialogueDesignator = binaryReader.ReadStringIdent();
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.Vocalizations = base.ReadBlockArrayData<SoundReferencesBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.QueueWrites(queueableBlamBinaryWriter);
            queueableBlamBinaryWriter.QueueWrite(this.Vocalizations);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.Write_(queueableBlamBinaryWriter);
            queueableBlamBinaryWriter.Write(this.GlobalDialogueInfo);
            queueableBlamBinaryWriter.Write(((int)(this.DialogueFlags)));
            queueableBlamBinaryWriter.WritePointer(this.Vocalizations);
            queueableBlamBinaryWriter.Write(this.MissionDialogueDesignator);
        }
        [System.FlagsAttribute()]
        public enum Flags : int
        {
            None = 0,
            Female = 1,
        }
    }
}
namespace Moonfish.Tags
{
    
    public partial struct TagClass
    {
        public static TagClass Udlg = ((TagClass)("udlg"));
    }
}
