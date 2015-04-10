using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SoundBlock : SoundBlockBase
    {
        public  SoundBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 144)]
    public class SoundBlockBase
    {
        internal Flags flags;
        internal Class _class;
        internal SampleRate sampleRate;
        internal InvalidName invalidName_;
        internal ImportType importType;
        internal SoundPlaybackParametersStructBlock playback;
        internal SoundScaleModifiersStructBlock scale;
        internal byte[] invalidName_0;
        internal Encoding encoding;
        internal Compression compression;
        internal SoundPromotionParametersStructBlock promotion;
        internal byte[] invalidName_1;
        /// <summary>
        /// pitch ranges allow multiple samples to represent the same sound at different pitches
        /// </summary>
        internal SoundPitchRangeBlock[] pitchRanges;
        internal SoundPlatformSoundPlaybackBlock[] platformParameters;
        internal SoundExtraInfoBlock[] soundExtraInfoBlock;
        internal  SoundBlockBase(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt32();
            this._class = (Class)binaryReader.ReadByte();
            this.sampleRate = (SampleRate)binaryReader.ReadByte();
            this.invalidName_ = (InvalidName)binaryReader.ReadByte();
            this.importType = (ImportType)binaryReader.ReadByte();
            this.playback = new SoundPlaybackParametersStructBlock(binaryReader);
            this.scale = new SoundScaleModifiersStructBlock(binaryReader);
            this.invalidName_0 = binaryReader.ReadBytes(2);
            this.encoding = (Encoding)binaryReader.ReadByte();
            this.compression = (Compression)binaryReader.ReadByte();
            this.promotion = new SoundPromotionParametersStructBlock(binaryReader);
            this.invalidName_1 = binaryReader.ReadBytes(12);
            this.pitchRanges = ReadSoundPitchRangeBlockArray(binaryReader);
            this.platformParameters = ReadSoundPlatformSoundPlaybackBlockArray(binaryReader);
            this.soundExtraInfoBlock = ReadSoundExtraInfoBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
        internal  virtual SoundPitchRangeBlock[] ReadSoundPitchRangeBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SoundPitchRangeBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SoundPitchRangeBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SoundPitchRangeBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual SoundPlatformSoundPlaybackBlock[] ReadSoundPlatformSoundPlaybackBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SoundPlatformSoundPlaybackBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SoundPlatformSoundPlaybackBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SoundPlatformSoundPlaybackBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual SoundExtraInfoBlock[] ReadSoundExtraInfoBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SoundExtraInfoBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SoundExtraInfoBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SoundExtraInfoBlock(binaryReader);
                }
            }
            return array;
        }
        [FlagsAttribute]
        internal enum Flags : int
        
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
        internal enum Class : byte
        
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
        internal enum InvalidName : byte
        
        {
            None = 0,
            OutputFrontSpeakers = 1,
            OutputRearSpeakers = 2,
            OutputCenterSpeakers = 3,
        };
        internal enum ImportType : byte
        
        {
            Unknown = 0,
            SingleShot = 1,
            SingleLayer = 2,
            MultiLayer = 3,
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