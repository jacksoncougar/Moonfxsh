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
    
    public partial class PlatformSoundPlaybackStructBlock : GuerillaBlock, IWriteQueueable
    {
        public PlatformSoundOverrideMixbinsBlock[] PlatformSoundOverrideMixbinsBlock = new PlatformSoundOverrideMixbinsBlock[0];
        public Flags PlatformSoundPlaybackStructFlags;
        private byte[] fieldpad = new byte[8];
        public PlatformSoundFilterBlock[] Filter = new PlatformSoundFilterBlock[0];
        public PlatformSoundPitchLfoBlock[] PitchLfo = new PlatformSoundPitchLfoBlock[0];
        public PlatformSoundFilterLfoBlock[] FilterLfo = new PlatformSoundFilterLfoBlock[0];
        public SoundEffectPlaybackBlock[] SoundEffect = new SoundEffectPlaybackBlock[0];
        public override int SerializedSize
        {
            get
            {
                return 52;
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
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(8));
            this.PlatformSoundPlaybackStructFlags = ((Flags)(binaryReader.ReadInt32()));
            this.fieldpad = binaryReader.ReadBytes(8);
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(72));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(48));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(64));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(40));
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.PlatformSoundOverrideMixbinsBlock = base.ReadBlockArrayData<PlatformSoundOverrideMixbinsBlock>(binaryReader, pointerQueue.Dequeue());
            this.Filter = base.ReadBlockArrayData<PlatformSoundFilterBlock>(binaryReader, pointerQueue.Dequeue());
            this.PitchLfo = base.ReadBlockArrayData<PlatformSoundPitchLfoBlock>(binaryReader, pointerQueue.Dequeue());
            this.FilterLfo = base.ReadBlockArrayData<PlatformSoundFilterLfoBlock>(binaryReader, pointerQueue.Dequeue());
            this.SoundEffect = base.ReadBlockArrayData<SoundEffectPlaybackBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            queueableBinaryWriter.QueueWrite(this.PlatformSoundOverrideMixbinsBlock);
            queueableBinaryWriter.QueueWrite(this.Filter);
            queueableBinaryWriter.QueueWrite(this.PitchLfo);
            queueableBinaryWriter.QueueWrite(this.FilterLfo);
            queueableBinaryWriter.QueueWrite(this.SoundEffect);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.Write_(queueableBinaryWriter);
            queueableBinaryWriter.WritePointer(this.PlatformSoundOverrideMixbinsBlock);
            queueableBinaryWriter.Write(((int)(this.PlatformSoundPlaybackStructFlags)));
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.WritePointer(this.Filter);
            queueableBinaryWriter.WritePointer(this.PitchLfo);
            queueableBinaryWriter.WritePointer(this.FilterLfo);
            queueableBinaryWriter.WritePointer(this.SoundEffect);
        }
        [System.FlagsAttribute()]
        public enum Flags : int
        {
            None = 0,
            Use3dRadioHack = 1,
        }
    }
}
