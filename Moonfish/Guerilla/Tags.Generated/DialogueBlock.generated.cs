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
    [TagClassAttribute("udlg")]
    [TagBlockOriginalNameAttribute("dialogue_block")]
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
        public override System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> ReadFields(Moonfish.Guerilla.BlamBinaryReader binaryReader)
        {
            System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(base.ReadFields(binaryReader));
            this.GlobalDialogueInfo = binaryReader.ReadTagReference();
            this.DialogueFlags = ((Flags)(binaryReader.ReadInt32()));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(16));
            this.MissionDialogueDesignator = binaryReader.ReadStringIdent();
            return pointerQueue;
        }
        public override void ReadInstances(Moonfish.Guerilla.BlamBinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.Vocalizations = base.ReadBlockArrayData<SoundReferencesBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            queueableBinaryWriter.QueueWrite(this.Vocalizations);
        }
        public override void Write(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBinaryWriter)
        {
            base.Write(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.GlobalDialogueInfo);
            queueableBinaryWriter.Write(((int)(this.DialogueFlags)));
            queueableBinaryWriter.WritePointer(this.Vocalizations);
            queueableBinaryWriter.Write(this.MissionDialogueDesignator);
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
