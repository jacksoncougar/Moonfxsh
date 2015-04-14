// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass ShitClass = (TagClass)"$#!+";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("$#!+")]
    public  partial class CacheFileSoundBlock : CacheFileSoundBlockBase
    {
        public  CacheFileSoundBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class CacheFileSoundBlockBase  : IGuerilla
    {
        internal Flags flags;
        internal SoundClass soundClass;
        internal SampleRate sampleRate;
        internal Encoding encoding;
        internal Compression compression;
        internal short playbackIndex;
        internal short firstPitchRangeIndex;
        internal byte pitchRangeCount;
        internal byte scaleIndex;
        internal byte promotionIndex;
        internal byte customPlaybackIndex;
        internal short extraInfoIndex;
        internal int maximumPlayTimeMs;
        internal  CacheFileSoundBlockBase(BinaryReader binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt16();
            soundClass = (SoundClass)binaryReader.ReadByte();
            sampleRate = (SampleRate)binaryReader.ReadByte();
            encoding = (Encoding)binaryReader.ReadByte();
            compression = (Compression)binaryReader.ReadByte();
            playbackIndex = binaryReader.ReadInt16();
            firstPitchRangeIndex = binaryReader.ReadInt16();
            pitchRangeCount = binaryReader.ReadByte();
            scaleIndex = binaryReader.ReadByte();
            promotionIndex = binaryReader.ReadByte();
            customPlaybackIndex = binaryReader.ReadByte();
            extraInfoIndex = binaryReader.ReadInt16();
            maximumPlayTimeMs = binaryReader.ReadInt32();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write((Byte)soundClass);
                binaryWriter.Write((Byte)sampleRate);
                binaryWriter.Write((Byte)encoding);
                binaryWriter.Write((Byte)compression);
                binaryWriter.Write(playbackIndex);
                binaryWriter.Write(firstPitchRangeIndex);
                binaryWriter.Write(pitchRangeCount);
                binaryWriter.Write(scaleIndex);
                binaryWriter.Write(promotionIndex);
                binaryWriter.Write(customPlaybackIndex);
                binaryWriter.Write(extraInfoIndex);
                binaryWriter.Write(maximumPlayTimeMs);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
        [FlagsAttribute]
        internal enum Flags : short
        {
            FitToAdpcmBlocksize = 1,
            SplitLongSoundIntoPermutations = 2,
            AlwaysSpatializeAlwaysPlayAs3DSoundEvenInFirstPerson = 4,
            NeverObstructDisableOcclusionObstructionForThisSound = 8,
            InternalDontTouch = 16,
            UseHugeSoundTransmission = 32,
            LinkCountToOwnerUnit = 64,
            PitchRangeIsLanguage = 128,
            DontUseSoundClassSpeakerFlag = 256,
            DontUseLipsyncData = 512,
        };
        internal enum SoundClass : byte
        {
            ProjectileImpact = 0,
            ProjectileDetonation = 1,
            ProjectileFlyby = 2,
            InvalidName = 3,
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
            InvalidName0 = 15,
            InvalidName1 = 16,
            InvalidName2 = 17,
            UnitFootsteps = 18,
            UnitDialog = 19,
            UnitAnimation = 20,
            InvalidName3 = 21,
            VehicleCollision = 22,
            VehicleEngine = 23,
            VehicleAnimation = 24,
            InvalidName4 = 25,
            DeviceDoor = 26,
            InvalidName5 = 27,
            DeviceMachinery = 28,
            DeviceStationary = 29,
            InvalidName6 = 30,
            InvalidName7 = 31,
            Music = 32,
            AmbientNature = 33,
            AmbientMachinery = 34,
            InvalidName8 = 35,
            HugeAss = 36,
            ObjectLooping = 37,
            CinematicMusic = 38,
            InvalidName9 = 39,
            InvalidName10 = 40,
            InvalidName11 = 41,
            InvalidName12 = 42,
            InvalidName13 = 43,
            InvalidName14 = 44,
            CortanaMission = 45,
            CortanaCinematic = 46,
            MissionDialog = 47,
            CinematicDialog = 48,
            ScriptedCinematicFoley = 49,
            GameEvent = 50,
            Ui = 51,
            Test = 52,
            MultilingualTest = 53,
        };
        internal enum SampleRate : byte
        {
            InvalidName22KHz = 0,
            InvalidName44KHz = 1,
            InvalidName32KHz = 2,
        };
        internal enum Encoding : byte
        {
            Mono = 0,
            Stereo = 1,
            Codec = 2,
        };
        internal enum Compression : byte
        {
            NoneBigEndian = 0,
            XboxAdpcm = 1,
            ImaAdpcm = 2,
            NoneLittleEndian = 3,
            Wma = 4,
        };
    };
}
