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
    
    public partial class SoundGlobalsBlock : GuerillaBlock, IWriteQueueable
    {
        [Moonfish.Tags.TagReferenceAttribute("sncl")]
        public Moonfish.Tags.TagReference SoundClasses;
        [Moonfish.Tags.TagReferenceAttribute("sfx+")]
        public Moonfish.Tags.TagReference SoundEffects;
        [Moonfish.Tags.TagReferenceAttribute("snmx")]
        public Moonfish.Tags.TagReference SoundMix;
        [Moonfish.Tags.TagReferenceAttribute("spk!")]
        public Moonfish.Tags.TagReference SoundCombatDialogueConstants;
        public int FieldLongInteger;
        public override int SerializedSize
        {
            get
            {
                return 36;
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
            this.SoundClasses = binaryReader.ReadTagReference();
            this.SoundEffects = binaryReader.ReadTagReference();
            this.SoundMix = binaryReader.ReadTagReference();
            this.SoundCombatDialogueConstants = binaryReader.ReadTagReference();
            this.FieldLongInteger = binaryReader.ReadInt32();
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.Write_(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.SoundClasses);
            queueableBinaryWriter.Write(this.SoundEffects);
            queueableBinaryWriter.Write(this.SoundMix);
            queueableBinaryWriter.Write(this.SoundCombatDialogueConstants);
            queueableBinaryWriter.Write(this.FieldLongInteger);
        }
    }
}
