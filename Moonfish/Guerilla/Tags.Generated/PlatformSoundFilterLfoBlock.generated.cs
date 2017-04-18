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
    
    public partial class PlatformSoundFilterLfoBlock : GuerillaBlock, IWriteQueueable
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
        public override System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> ReadFields(System.IO.BinaryReader binaryReader)
        {
            System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(base.ReadFields(binaryReader));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.Delay.ReadFields(binaryReader)));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.Frequency.ReadFields(binaryReader)));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.CutoffModulation.ReadFields(binaryReader)));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.GainModulation.ReadFields(binaryReader)));
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.Delay.ReadInstances(binaryReader, pointerQueue);
            this.Frequency.ReadInstances(binaryReader, pointerQueue);
            this.CutoffModulation.ReadInstances(binaryReader, pointerQueue);
            this.GainModulation.ReadInstances(binaryReader, pointerQueue);
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.QueueWrites(queueableBlamBinaryWriter);
            this.Delay.QueueWrites(queueableBlamBinaryWriter);
            this.Frequency.QueueWrites(queueableBlamBinaryWriter);
            this.CutoffModulation.QueueWrites(queueableBlamBinaryWriter);
            this.GainModulation.QueueWrites(queueableBlamBinaryWriter);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.Write_(queueableBlamBinaryWriter);
            this.Delay.Write_(queueableBlamBinaryWriter);
            this.Frequency.Write_(queueableBlamBinaryWriter);
            this.CutoffModulation.Write_(queueableBlamBinaryWriter);
            this.GainModulation.Write_(queueableBlamBinaryWriter);
        }
    }
}
