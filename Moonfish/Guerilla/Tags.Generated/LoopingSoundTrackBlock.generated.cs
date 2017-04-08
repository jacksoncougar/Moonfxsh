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
    
    public partial class LoopingSoundTrackBlock : GuerillaBlock, IWriteQueueable
    {
        public Moonfish.Tags.StringIdent Name;
        public Flags LoopingSoundTrackFlags;
        public float Gain;
        public float FadeInDuration;
        public float FadeOutDuration;
        [Moonfish.Tags.TagReferenceAttribute("snd!")]
        public Moonfish.Tags.TagReference In;
        [Moonfish.Tags.TagReferenceAttribute("snd!")]
        public Moonfish.Tags.TagReference Loop;
        [Moonfish.Tags.TagReferenceAttribute("snd!")]
        public Moonfish.Tags.TagReference Out;
        [Moonfish.Tags.TagReferenceAttribute("snd!")]
        public Moonfish.Tags.TagReference AltLoop;
        [Moonfish.Tags.TagReferenceAttribute("snd!")]
        public Moonfish.Tags.TagReference AltOut;
        public OutputEffectEnum OutputEffect;
        private byte[] fieldpad = new byte[2];
        [Moonfish.Tags.TagReferenceAttribute("snd!")]
        public Moonfish.Tags.TagReference AltTransIn;
        [Moonfish.Tags.TagReferenceAttribute("snd!")]
        public Moonfish.Tags.TagReference AltTransOut;
        public float AltCrossfadeDuration;
        public float AltFadeOutDuration;
        public override int SerializedSize
        {
            get
            {
                return 88;
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
            this.Name = binaryReader.ReadStringIdent();
            this.LoopingSoundTrackFlags = ((Flags)(binaryReader.ReadInt32()));
            this.Gain = binaryReader.ReadSingle();
            this.FadeInDuration = binaryReader.ReadSingle();
            this.FadeOutDuration = binaryReader.ReadSingle();
            this.In = binaryReader.ReadTagReference();
            this.Loop = binaryReader.ReadTagReference();
            this.Out = binaryReader.ReadTagReference();
            this.AltLoop = binaryReader.ReadTagReference();
            this.AltOut = binaryReader.ReadTagReference();
            this.OutputEffect = ((OutputEffectEnum)(binaryReader.ReadInt16()));
            this.fieldpad = binaryReader.ReadBytes(2);
            this.AltTransIn = binaryReader.ReadTagReference();
            this.AltTransOut = binaryReader.ReadTagReference();
            this.AltCrossfadeDuration = binaryReader.ReadSingle();
            this.AltFadeOutDuration = binaryReader.ReadSingle();
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
            queueableBinaryWriter.Write(this.Name);
            queueableBinaryWriter.Write(((int)(this.LoopingSoundTrackFlags)));
            queueableBinaryWriter.Write(this.Gain);
            queueableBinaryWriter.Write(this.FadeInDuration);
            queueableBinaryWriter.Write(this.FadeOutDuration);
            queueableBinaryWriter.Write(this.In);
            queueableBinaryWriter.Write(this.Loop);
            queueableBinaryWriter.Write(this.Out);
            queueableBinaryWriter.Write(this.AltLoop);
            queueableBinaryWriter.Write(this.AltOut);
            queueableBinaryWriter.Write(((short)(this.OutputEffect)));
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.Write(this.AltTransIn);
            queueableBinaryWriter.Write(this.AltTransOut);
            queueableBinaryWriter.Write(this.AltCrossfadeDuration);
            queueableBinaryWriter.Write(this.AltFadeOutDuration);
        }
        [System.FlagsAttribute()]
        public enum Flags : int
        {
            None = 0,
            FadeInAtStarttheLoopSoundShouldFadeInWhileTheStartSoundIsPlaying = 1,
            FadeOutAtStoptheLoopSoundShouldFadeOutWhileTheStopSoundIsPlaying = 2,
            CrossfadeAltLoopwhenTheSoundChangesToTheAlternateVersion = 4,
            MasterSurroundSoundTrack = 8,
            FadeOutAtAltStop = 16,
        }
        public enum OutputEffectEnum : short
        {
            None = 0,
            OutputFrontSpeakers = 1,
            OutputRearSpeakers = 2,
            OutputCenterSpeakers = 3,
        }
    }
}
