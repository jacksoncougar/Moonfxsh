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
    [LayoutAttribute(Size = 88)]
    public class LoopingSoundTrackBlockBase
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
            this.name = binaryReader.ReadStringID();
            this.flags = (Flags)binaryReader.ReadInt32();
            this.gainDB = binaryReader.ReadSingle();
            this.fadeInDurationSeconds = binaryReader.ReadSingle();
            this.fadeOutDurationSeconds = binaryReader.ReadSingle();
            this._in = binaryReader.ReadTagReference();
            this.loop = binaryReader.ReadTagReference();
            this._out = binaryReader.ReadTagReference();
            this.altLoop = binaryReader.ReadTagReference();
            this.altOut = binaryReader.ReadTagReference();
            this.outputEffect = (OutputEffect)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.altTransIn = binaryReader.ReadTagReference();
            this.altTransOut = binaryReader.ReadTagReference();
            this.altCrossfadeDurationSeconds = binaryReader.ReadSingle();
            this.altFadeOutDurationSeconds = binaryReader.ReadSingle();
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
