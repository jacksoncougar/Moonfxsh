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
    [TagClassAttribute("<fx>")]
    [TagBlockOriginalNameAttribute("sound_effect_template_block")]
    public partial class SoundEffectTemplateBlock : GuerillaBlock, IWriteDeferrable
    {
        public SoundEffectTemplatesBlock[] TemplateCollection = new SoundEffectTemplatesBlock[0];
        public Moonfish.Tags.StringIdent InputEffectName;
        public SoundEffectTemplateAdditionalSoundInputBlock[] AdditionalSoundInputs = new SoundEffectTemplateAdditionalSoundInputBlock[0];
        public PlatformSoundEffectTemplateCollectionBlock[] PlatformSoundEffectTemplateCollectionBlock = new PlatformSoundEffectTemplateCollectionBlock[0];
        public override int SerializedSize
        {
            get
            {
                return 28;
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
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(28));
            this.InputEffectName = binaryReader.ReadStringIdent();
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(16));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(12));
            return pointerQueue;
        }
        public override void ReadInstances(Moonfish.Guerilla.BlamBinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.TemplateCollection = base.ReadBlockArrayData<SoundEffectTemplatesBlock>(binaryReader, pointerQueue.Dequeue());
            this.AdditionalSoundInputs = base.ReadBlockArrayData<SoundEffectTemplateAdditionalSoundInputBlock>(binaryReader, pointerQueue.Dequeue());
            this.PlatformSoundEffectTemplateCollectionBlock = base.ReadBlockArrayData<PlatformSoundEffectTemplateCollectionBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void DeferReferences(Moonfish.Guerilla.LinearBinaryWriter queueableBinaryWriter)
        {
            base.DeferReferences(queueableBinaryWriter);
            queueableBinaryWriter.Defer(this.TemplateCollection);
            queueableBinaryWriter.Defer(this.AdditionalSoundInputs);
            queueableBinaryWriter.Defer(this.PlatformSoundEffectTemplateCollectionBlock);
        }
        public override void Write(Moonfish.Guerilla.LinearBinaryWriter queueableBinaryWriter)
        {
            base.Write(queueableBinaryWriter);
            queueableBinaryWriter.WritePointer(this.TemplateCollection);
            queueableBinaryWriter.Write(this.InputEffectName);
            queueableBinaryWriter.WritePointer(this.AdditionalSoundInputs);
            queueableBinaryWriter.WritePointer(this.PlatformSoundEffectTemplateCollectionBlock);
        }
    }
}
namespace Moonfish.Tags
{
    
    public partial struct TagClass
    {
        public static TagClass Fx = ((TagClass)("<fx>"));
    }
}
