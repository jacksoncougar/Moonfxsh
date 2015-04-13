using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("lsnd")]
    public  partial class SoundLoopingBlock : SoundLoopingBlockBase
    {
        public  SoundLoopingBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 44)]
    public class SoundLoopingBlockBase
    {
        internal Flags flags;
        internal float martysMusicTimeSeconds;
        internal float invalidName_;
        internal byte[] invalidName_0;
        [TagReference("null")]
        internal Moonfish.Tags.TagReference invalidName_1;
        /// <summary>
        /// tracks play in parallel and loop continuously for the duration of the looping sound.
        /// </summary>
        internal LoopingSoundTrackBlock[] tracks;
        /// <summary>
        /// detailSounds play at random throughout the duration of the looping sound.
        /// </summary>
        internal LoopingSoundDetailBlock[] detailSounds;
        internal  SoundLoopingBlockBase(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt32();
            this.martysMusicTimeSeconds = binaryReader.ReadSingle();
            this.invalidName_ = binaryReader.ReadSingle();
            this.invalidName_0 = binaryReader.ReadBytes(8);
            this.invalidName_1 = binaryReader.ReadTagReference();
            this.tracks = ReadLoopingSoundTrackBlockArray(binaryReader);
            this.detailSounds = ReadLoopingSoundDetailBlockArray(binaryReader);
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
        internal  virtual LoopingSoundTrackBlock[] ReadLoopingSoundTrackBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(LoopingSoundTrackBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new LoopingSoundTrackBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new LoopingSoundTrackBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual LoopingSoundDetailBlock[] ReadLoopingSoundDetailBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(LoopingSoundDetailBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new LoopingSoundDetailBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new LoopingSoundDetailBlock(binaryReader);
                }
            }
            return array;
        }
        [FlagsAttribute]
        internal enum Flags : int
        
        {
            DeafeningToAIsWhenUsedAsABackgroundStereoTrackCausesNearbyAIsToBeUnableToHear = 1,
            NotALoopThisIsACollectionOfPermutationsStrungTogetherThatShouldPlayOnceThenStop = 2,
            StopsMusicAllOtherMusicLoopsWillStopWhenThisOneStarts = 4,
            AlwaysSpatializeAlwaysPlayAs3DSoundEvenInFirstPerson = 8,
            SynchronizePlaybackSynchronizesPlaybackWithOtherLoopingSoundsAttachedToTheOwnerOfThisSound = 16,
            SynchronizeTracks = 32,
            FakeSpatializationWithDistance = 64,
            CombineAll3DPlayback = 128,
        };
    };
}
