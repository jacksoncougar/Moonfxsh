// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class SoundClassBlock : SoundClassBlockBase
    {
        public SoundClassBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 92, Alignment = 4)]
    public class SoundClassBlockBase : GuerillaBlock
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
        public override int SerializedSize { get { return 92; } }
        public override int Alignment { get { return 4; } }
        public SoundClassBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            maxSoundsPerTag116 = binaryReader.ReadInt16();
            maxSoundsPerObject116 = binaryReader.ReadInt16();
            preemptionTimeMs = binaryReader.ReadInt32();
            internalFlags = (InternalFlags)binaryReader.ReadInt16();
            flags = (Flags)binaryReader.ReadInt16();
            priority = binaryReader.ReadInt16();
            cacheMissMode = (CacheMissMode)binaryReader.ReadInt16();
            reverbGainDB = binaryReader.ReadSingle();
            overrideSpeakerGainDB = binaryReader.ReadSingle();
            distanceBounds = binaryReader.ReadRange();
            gainBoundsDB = binaryReader.ReadRange();
            cutsceneDuckingDB = binaryReader.ReadSingle();
            cutsceneDuckingFadeInTimeSeconds = binaryReader.ReadSingle();
            cutsceneDuckingSustainTimeSeconds = binaryReader.ReadSingle();
            cutsceneDuckingFadeOutTimeSeconds = binaryReader.ReadSingle();
            scriptedDialogDuckingDB = binaryReader.ReadSingle();
            scriptedDialogDuckingFadeInTimeSeconds = binaryReader.ReadSingle();
            scriptedDialogDuckingSustainTimeSeconds = binaryReader.ReadSingle();
            scriptedDialogDuckingFadeOutTimeSeconds = binaryReader.ReadSingle();
            dopplerFactor = binaryReader.ReadSingle();
            stereoPlaybackType = (StereoPlaybackType)binaryReader.ReadByte();
            invalidName_ = binaryReader.ReadBytes(3);
            transmissionMultiplier = binaryReader.ReadSingle();
            obstructionMaxBend = binaryReader.ReadSingle();
            occlusionMaxBend = binaryReader.ReadSingle();
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(maxSoundsPerTag116);
                binaryWriter.Write(maxSoundsPerObject116);
                binaryWriter.Write(preemptionTimeMs);
                binaryWriter.Write((Int16)internalFlags);
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(priority);
                binaryWriter.Write((Int16)cacheMissMode);
                binaryWriter.Write(reverbGainDB);
                binaryWriter.Write(overrideSpeakerGainDB);
                binaryWriter.Write(distanceBounds);
                binaryWriter.Write(gainBoundsDB);
                binaryWriter.Write(cutsceneDuckingDB);
                binaryWriter.Write(cutsceneDuckingFadeInTimeSeconds);
                binaryWriter.Write(cutsceneDuckingSustainTimeSeconds);
                binaryWriter.Write(cutsceneDuckingFadeOutTimeSeconds);
                binaryWriter.Write(scriptedDialogDuckingDB);
                binaryWriter.Write(scriptedDialogDuckingFadeInTimeSeconds);
                binaryWriter.Write(scriptedDialogDuckingSustainTimeSeconds);
                binaryWriter.Write(scriptedDialogDuckingFadeOutTimeSeconds);
                binaryWriter.Write(dopplerFactor);
                binaryWriter.Write((Byte)stereoPlaybackType);
                binaryWriter.Write(invalidName_, 0, 3);
                binaryWriter.Write(transmissionMultiplier);
                binaryWriter.Write(obstructionMaxBend);
                binaryWriter.Write(occlusionMaxBend);
                return nextAddress;
            }
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
