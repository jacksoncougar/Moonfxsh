using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SoundClassBlock : SoundClassBlockBase
    {
        public  SoundClassBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 92)]
    public class SoundClassBlockBase
    {
        /// <summary>
        /// maximum number of sounds playing per individual sound tag
        /// </summary>
        internal short maxSoundsPerTag116;
        /// <summary>
        /// maximum number of sounds of this type playing on an object
        /// </summary>
        internal short maxSoundsPerObject116;
        /// <summary>
        /// replaces other instances after this many milliseconds
        /// </summary>
        internal int preemptionTimeMs;
        internal InternalFlags internalFlags;
        internal Flags flags;
        internal short priority;
        internal CacheMissMode cacheMissMode;
        /// <summary>
        /// how much reverb applies to this sound class
        /// </summary>
        internal float reverbGainDB;
        internal float overrideSpeakerGainDB;
        internal Moonfish.Model.Range distanceBounds;
        internal Moonfish.Model.Range gainBoundsDB;
        internal float cutsceneDuckingDB;
        internal float cutsceneDuckingFadeInTimeSeconds;
        /// <summary>
        /// how long this lasts after the cutscene ends
        /// </summary>
        internal float cutsceneDuckingSustainTimeSeconds;
        internal float cutsceneDuckingFadeOutTimeSeconds;
        internal float scriptedDialogDuckingDB;
        internal float scriptedDialogDuckingFadeInTimeSeconds;
        /// <summary>
        /// how long this lasts after the scripted dialog ends
        /// </summary>
        internal float scriptedDialogDuckingSustainTimeSeconds;
        internal float scriptedDialogDuckingFadeOutTimeSeconds;
        internal float dopplerFactor;
        internal StereoPlaybackType stereoPlaybackType;
        internal byte[] invalidName_;
        internal float transmissionMultiplier;
        internal float obstructionMaxBend;
        internal float occlusionMaxBend;
        internal  SoundClassBlockBase(BinaryReader binaryReader)
        {
            this.maxSoundsPerTag116 = binaryReader.ReadInt16();
            this.maxSoundsPerObject116 = binaryReader.ReadInt16();
            this.preemptionTimeMs = binaryReader.ReadInt32();
            this.internalFlags = (InternalFlags)binaryReader.ReadInt16();
            this.flags = (Flags)binaryReader.ReadInt16();
            this.priority = binaryReader.ReadInt16();
            this.cacheMissMode = (CacheMissMode)binaryReader.ReadInt16();
            this.reverbGainDB = binaryReader.ReadSingle();
            this.overrideSpeakerGainDB = binaryReader.ReadSingle();
            this.distanceBounds = binaryReader.ReadRange();
            this.gainBoundsDB = binaryReader.ReadRange();
            this.cutsceneDuckingDB = binaryReader.ReadSingle();
            this.cutsceneDuckingFadeInTimeSeconds = binaryReader.ReadSingle();
            this.cutsceneDuckingSustainTimeSeconds = binaryReader.ReadSingle();
            this.cutsceneDuckingFadeOutTimeSeconds = binaryReader.ReadSingle();
            this.scriptedDialogDuckingDB = binaryReader.ReadSingle();
            this.scriptedDialogDuckingFadeInTimeSeconds = binaryReader.ReadSingle();
            this.scriptedDialogDuckingSustainTimeSeconds = binaryReader.ReadSingle();
            this.scriptedDialogDuckingFadeOutTimeSeconds = binaryReader.ReadSingle();
            this.dopplerFactor = binaryReader.ReadSingle();
            this.stereoPlaybackType = (StereoPlaybackType)binaryReader.ReadByte();
            this.invalidName_ = binaryReader.ReadBytes(3);
            this.transmissionMultiplier = binaryReader.ReadSingle();
            this.obstructionMaxBend = binaryReader.ReadSingle();
            this.occlusionMaxBend = binaryReader.ReadSingle();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
        }
        [FlagsAttribute]
        internal enum InternalFlags : short
        
        {
            Valid = 1,
            IsSpeech = 2,
            Scripted = 4,
            StopsWithObject = 8,
            Unused = 16,
            ValidDopplerFactor = 32,
            ValidObstructionFactor = 64,
            Multilingual = 128,
        };
        [FlagsAttribute]
        internal enum Flags : short
        
        {
            PlaysDuringPause = 1,
            DryStereoMix = 2,
            NoObjectObstruction = 4,
            UseCenterSpeakerUnspatialized = 8,
            SendMonoToLfe = 16,
            Deterministic = 32,
            UseHugeTransmission = 64,
            AlwaysUseSpeakers = 128,
            DontStripFromMainMenu = 256,
            IgnoreStereoHeadroom = 512,
            LoopFadeOutIsLinear = 1024,
            StopWhenObjectDies = 2048,
            AllowCacheFileEditing = 4096,
        };
        internal enum CacheMissMode : short
        
        {
            Discard = 0,
            Postpone = 1,
        };
        internal enum StereoPlaybackType : byte
        
        {
            FirstPerson = 0,
            Ambient = 1,
        };
    };
}
