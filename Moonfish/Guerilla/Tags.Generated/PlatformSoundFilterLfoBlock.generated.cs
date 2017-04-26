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
    using Moonfish.Guerilla;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    
    [JetBrains.Annotations.UsedImplicitlyAttribute(ImplicitUseTargetFlags.WithMembers)]
    [TagBlockOriginalNameAttribute("platform_sound_filter_lfo_block")]
    public partial class PlatformSoundFilterLfoBlock : GuerillaBlock, IWriteDeferrable
    {
        public SoundPlaybackParameterDefinitionBlock Delay = new SoundPlaybackParameterDefinitionBlock();
        public SoundPlaybackParameterDefinitionBlock Frequency = new SoundPlaybackParameterDefinitionBlock();
        public SoundPlaybackParameterDefinitionBlock CutoffModulation = new SoundPlaybackParameterDefinitionBlock();
        public SoundPlaybackParameterDefinitionBlock GainModulation = new SoundPlaybackParameterDefinitionBlock();
        public override int SerializedSize
        {
            get
            {
                return 64;
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
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.Delay.ReadFields(binaryReader)));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.Frequency.ReadFields(binaryReader)));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.CutoffModulation.ReadFields(binaryReader)));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.GainModulation.ReadFields(binaryReader)));
            return pointerQueue;
        }
        public override void ReadInstances(Moonfish.Guerilla.BlamBinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.Delay.ReadInstances(binaryReader, pointerQueue);
            this.Frequency.ReadInstances(binaryReader, pointerQueue);
            this.CutoffModulation.ReadInstances(binaryReader, pointerQueue);
            this.GainModulation.ReadInstances(binaryReader, pointerQueue);
        }
        public override void DeferReferences(Moonfish.Guerilla.LinearBinaryWriter writer)
        {
            base.DeferReferences(writer);
            this.Delay.DeferReferences(writer);
            this.Frequency.DeferReferences(writer);
            this.CutoffModulation.DeferReferences(writer);
            this.GainModulation.DeferReferences(writer);
        }
        public override void Write(Moonfish.Guerilla.LinearBinaryWriter writer)
        {
            base.Write(writer);
            this.Delay.Write(writer);
            this.Frequency.Write(writer);
            this.CutoffModulation.Write(writer);
            this.GainModulation.Write(writer);
        }
    }
}
