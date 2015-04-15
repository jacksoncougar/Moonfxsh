// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class LoopingSoundTrackBlock : LoopingSoundTrackBlockBase
    {
        public  LoopingSoundTrackBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 88, Alignment = 4)]
    public class LoopingSoundTrackBlockBase  : IGuerilla
    {
        internal Moonfish.Tags.StringID name;
        internal Flags flags;
        internal float gainDB;
        internal float fadeInDurationSeconds;
        internal float fadeOutDurationSeconds;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference _in;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference loop;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference _out;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference altLoop;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference altOut;
        internal OutputEffect outputEffect;
        internal byte[] invalidName_;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference altTransIn;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference altTransOut;
        internal float altCrossfadeDurationSeconds;
        internal float altFadeOutDurationSeconds;
        internal  LoopingSoundTrackBlockBase(BinaryReader binaryReader)
        {
            name = binaryReader.ReadStringID();
            flags = (Flags)binaryReader.ReadInt32();
            gainDB = binaryReader.ReadSingle();
            fadeInDurationSeconds = binaryReader.ReadSingle();
            fadeOutDurationSeconds = binaryReader.ReadSingle();
            _in = binaryReader.ReadTagReference();
            loop = binaryReader.ReadTagReference();
            _out = binaryReader.ReadTagReference();
            altLoop = binaryReader.ReadTagReference();
            altOut = binaryReader.ReadTagReference();
            outputEffect = (OutputEffect)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            altTransIn = binaryReader.ReadTagReference();
            altTransOut = binaryReader.ReadTagReference();
            altCrossfadeDurationSeconds = binaryReader.ReadSingle();
            altFadeOutDurationSeconds = binaryReader.ReadSingle();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write(gainDB);
                binaryWriter.Write(fadeInDurationSeconds);
                binaryWriter.Write(fadeOutDurationSeconds);
                binaryWriter.Write(_in);
                binaryWriter.Write(loop);
                binaryWriter.Write(_out);
                binaryWriter.Write(altLoop);
                binaryWriter.Write(altOut);
                binaryWriter.Write((Int16)outputEffect);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(altTransIn);
                binaryWriter.Write(altTransOut);
                binaryWriter.Write(altCrossfadeDurationSeconds);
                binaryWriter.Write(altFadeOutDurationSeconds);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        {
            FadeInAtStartTheLoopSoundShouldFadeInWhileTheStartSoundIsPlaying = 1,
            FadeOutAtStopTheLoopSoundShouldFadeOutWhileTheStopSoundIsPlaying = 2,
            CrossfadeAltLoopWhenTheSoundChangesToTheAlternateVersion = 4,
            MasterSurroundSoundTrack = 8,
            FadeOutAtAltStop = 16,
        };
        internal enum OutputEffect : short
        {
            None = 0,
            OutputFrontSpeakers = 1,
            OutputRearSpeakers = 2,
            OutputCenterSpeakers = 3,
        };
    };
}
