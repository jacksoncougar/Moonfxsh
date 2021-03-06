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
    
    public partial class SoundPlaybackParametersStructBlock : GuerillaBlock, IWriteQueueable
    {
        public float MinimumDistance;
        public float MaximumDistance;
        public float SkipFraction;
        public float MaximumBendPerSecond;
        /// <summary>
        /// these settings control random variation of volume and pitch.
        /// the second parameter gets clipped to the first.
        /// </summary>
        public float GainBase;
        public float GainVariance;
        public int RandomPitchBounds;
        /// <summary>
        /// these settings allow sounds to be directional, fading as they turn away from the listener
        /// </summary>
        public float InnerConeAngle;
        public float OuterConeAngle;
        public float OuterConeGain;
        public Flags SoundPlaybackParametersStructFlags;
        public float Azimuth;
        public float PositionalGain;
        public float FirstPersonGain;
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
            this.MinimumDistance = binaryReader.ReadSingle();
            this.MaximumDistance = binaryReader.ReadSingle();
            this.SkipFraction = binaryReader.ReadSingle();
            this.MaximumBendPerSecond = binaryReader.ReadSingle();
            this.GainBase = binaryReader.ReadSingle();
            this.GainVariance = binaryReader.ReadSingle();
            this.RandomPitchBounds = binaryReader.ReadInt32();
            this.InnerConeAngle = binaryReader.ReadSingle();
            this.OuterConeAngle = binaryReader.ReadSingle();
            this.OuterConeGain = binaryReader.ReadSingle();
            this.SoundPlaybackParametersStructFlags = ((Flags)(binaryReader.ReadInt32()));
            this.Azimuth = binaryReader.ReadSingle();
            this.PositionalGain = binaryReader.ReadSingle();
            this.FirstPersonGain = binaryReader.ReadSingle();
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
            queueableBinaryWriter.Write(this.MinimumDistance);
            queueableBinaryWriter.Write(this.MaximumDistance);
            queueableBinaryWriter.Write(this.SkipFraction);
            queueableBinaryWriter.Write(this.MaximumBendPerSecond);
            queueableBinaryWriter.Write(this.GainBase);
            queueableBinaryWriter.Write(this.GainVariance);
            queueableBinaryWriter.Write(this.RandomPitchBounds);
            queueableBinaryWriter.Write(this.InnerConeAngle);
            queueableBinaryWriter.Write(this.OuterConeAngle);
            queueableBinaryWriter.Write(this.OuterConeGain);
            queueableBinaryWriter.Write(((int)(this.SoundPlaybackParametersStructFlags)));
            queueableBinaryWriter.Write(this.Azimuth);
            queueableBinaryWriter.Write(this.PositionalGain);
            queueableBinaryWriter.Write(this.FirstPersonGain);
        }
        /// <summary>
        /// NOTE: this will only apply when the sound is started via script
        ///azimuth:
        ///    0 => front
        ///    90 => left
        ///    180 => back
        ///    270 => right
        /// </summary>
        [System.FlagsAttribute()]
        public enum Flags : int
        {
            None = 0,
            OverrideAzimuth = 1,
            Override3dGain = 2,
            OverrideSpeakerGain = 4,
        }
    }
}
