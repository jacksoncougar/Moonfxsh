// ReSharper disable All

using Moonfish.Model;

using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class LoopingSoundTrackBlock : LoopingSoundTrackBlockBase
    {
        public LoopingSoundTrackBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 88, Alignment = 4)]
    public class LoopingSoundTrackBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent name;
        internal Flags flags;
        internal float gainDB;
        internal float fadeInDurationSeconds;
        internal float fadeOutDurationSeconds;
        [TagReference("snd!")] internal Moonfish.Tags.TagReference _in;
        [TagReference("snd!")] internal Moonfish.Tags.TagReference loop;
        [TagReference("snd!")] internal Moonfish.Tags.TagReference _out;
        [TagReference("snd!")] internal Moonfish.Tags.TagReference altLoop;
        [TagReference("snd!")] internal Moonfish.Tags.TagReference altOut;
        internal OutputEffect outputEffect;
        internal byte[] invalidName_;
        [TagReference("snd!")] internal Moonfish.Tags.TagReference altTransIn;
        [TagReference("snd!")] internal Moonfish.Tags.TagReference altTransOut;
        internal float altCrossfadeDurationSeconds;
        internal float altFadeOutDurationSeconds;

        public override int SerializedSize
        {
            get { return 88; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public LoopingSoundTrackBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            name = binaryReader.ReadStringID();
            flags = (Flags) binaryReader.ReadInt32();
            gainDB = binaryReader.ReadSingle();
            fadeInDurationSeconds = binaryReader.ReadSingle();
            fadeOutDurationSeconds = binaryReader.ReadSingle();
            _in = binaryReader.ReadTagReference();
            loop = binaryReader.ReadTagReference();
            _out = binaryReader.ReadTagReference();
            altLoop = binaryReader.ReadTagReference();
            altOut = binaryReader.ReadTagReference();
            outputEffect = (OutputEffect) binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            altTransIn = binaryReader.ReadTagReference();
            altTransOut = binaryReader.ReadTagReference();
            altCrossfadeDurationSeconds = binaryReader.ReadSingle();
            altFadeOutDurationSeconds = binaryReader.ReadSingle();
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write((Int32) flags);
                binaryWriter.Write(gainDB);
                binaryWriter.Write(fadeInDurationSeconds);
                binaryWriter.Write(fadeOutDurationSeconds);
                binaryWriter.Write(_in);
                binaryWriter.Write(loop);
                binaryWriter.Write(_out);
                binaryWriter.Write(altLoop);
                binaryWriter.Write(altOut);
                binaryWriter.Write((Int16) outputEffect);
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