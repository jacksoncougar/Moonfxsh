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
    
    [TagClassAttribute("$#!+")]
    public partial class CacheFileSoundBlock : GuerillaBlock, IWriteQueueable
    {
        public Flags CacheFileSoundFlags;
        public SoundClassEnum SoundClass;
        public SampleRateEnum SampleRate;
        public EncodingEnum Encoding;
        public CompressionEnum Compression;
        public short PlaybackIndex;
        public short FirstPitchRangeIndex;
        public byte PitchRangeCount;
        public byte ScaleIndex;
        public byte PromotionIndex;
        public byte CustomPlaybackIndex;
        public short ExtraInfoIndex;
        public int MaximumPlayTime;
        public override int SerializedSize
        {
            get
            {
                return 20;
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
            this.CacheFileSoundFlags = ((Flags)(binaryReader.ReadInt16()));
            this.SoundClass = ((SoundClassEnum)(binaryReader.ReadByte()));
            this.SampleRate = ((SampleRateEnum)(binaryReader.ReadByte()));
            this.Encoding = ((EncodingEnum)(binaryReader.ReadByte()));
            this.Compression = ((CompressionEnum)(binaryReader.ReadByte()));
            this.PlaybackIndex = binaryReader.ReadInt16();
            this.FirstPitchRangeIndex = binaryReader.ReadInt16();
            this.PitchRangeCount = binaryReader.ReadByte();
            this.ScaleIndex = binaryReader.ReadByte();
            this.PromotionIndex = binaryReader.ReadByte();
            this.CustomPlaybackIndex = binaryReader.ReadByte();
            this.ExtraInfoIndex = binaryReader.ReadInt16();
            this.MaximumPlayTime = binaryReader.ReadInt32();
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
            queueableBinaryWriter.Write(((short)(this.CacheFileSoundFlags)));
            queueableBinaryWriter.Write(((byte)(this.SoundClass)));
            queueableBinaryWriter.Write(((byte)(this.SampleRate)));
            queueableBinaryWriter.Write(((byte)(this.Encoding)));
            queueableBinaryWriter.Write(((byte)(this.Compression)));
            queueableBinaryWriter.Write(this.PlaybackIndex);
            queueableBinaryWriter.Write(this.FirstPitchRangeIndex);
            queueableBinaryWriter.Write(this.PitchRangeCount);
            queueableBinaryWriter.Write(this.ScaleIndex);
            queueableBinaryWriter.Write(this.PromotionIndex);
            queueableBinaryWriter.Write(this.CustomPlaybackIndex);
            queueableBinaryWriter.Write(this.ExtraInfoIndex);
            queueableBinaryWriter.Write(this.MaximumPlayTime);
        }
        [System.FlagsAttribute()]
        public enum Flags : short
        {
            None = 0,
            FitToAdpcmBlocksize = 1,
            SplitLongSoundIntoPermutations = 2,
            AlwaysSpatializealwaysPlayAs3dSoundEvenInFirstPerson = 4,
            NeverObstructdisableOcclusionobstructionForThisSound = 8,
            InternalDontTouch = 16,
            UseHugeSoundTransmission = 32,
            LinkCountToOwnerUnit = 64,
            PitchRangeIsLanguage = 128,
            DontUseSoundClassSpeakerFlag = 256,
            DontUseLipsyncData = 512,
        }
        public enum SoundClassEnum : byte
        {
            ProjectileImpact = 0,
            ProjectileDetonation = 1,
            ProjectileFlyby = 2,
            WeaponFire = 4,
            WeaponReady = 5,
            WeaponReload = 6,
            WeaponEmpty = 7,
            WeaponCharge = 8,
            WeaponOverheat = 9,
            WeaponIdle = 10,
            WeaponMelee = 11,
            WeaponAnimation = 12,
            ObjectImpacts = 13,
            ParticleImpacts = 14,
            UnitFootsteps = 18,
            UnitDialog = 19,
            UnitAnimation = 20,
            VehicleCollision = 22,
            VehicleEngine = 23,
            VehicleAnimation = 24,
            DeviceDoor = 26,
            DeviceMachinery = 28,
            DeviceStationary = 29,
            Music = 32,
            AmbientNature = 33,
            AmbientMachinery = 34,
            HugeAss = 36,
            ObjectLooping = 37,
            CinematicMusic = 38,
            CortanaMission = 45,
            CortanaCinematic = 46,
            MissionDialog = 47,
            CinematicDialog = 48,
            ScriptedCinematicFoley = 49,
            GameEvent = 50,
            Ui = 51,
            Test = 52,
            MultilingualTest = 53,
        }
        public enum SampleRateEnum : byte
        {
            _22kHz = 0,
            _44kHz = 1,
            _32kHz = 2,
        }
        public enum EncodingEnum : byte
        {
            Mono = 0,
            Stereo = 1,
            Codec = 2,
        }
        public enum CompressionEnum : byte
        {
            NonebigEndian = 0,
            XboxAdpcm = 1,
            ImaAdpcm = 2,
            NonelittleEndian = 3,
            Wma = 4,
        }
    }
}
namespace Moonfish.Tags
{
    
    public partial struct TagClass
    {
        public static TagClass Shit = ((TagClass)("$#!+"));
    }
}