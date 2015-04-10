// ReSharper disable All
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
        public  SoundLoopingBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  SoundLoopingBlockBase(System.IO.BinaryReader binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt32();
            martysMusicTimeSeconds = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadSingle();
            invalidName_0 = binaryReader.ReadBytes(8);
            invalidName_1 = binaryReader.ReadTagReference();
            ReadLoopingSoundTrackBlockArray(binaryReader);
            ReadLoopingSoundDetailBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
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
        internal  virtual LoopingSoundTrackBlock[] ReadLoopingSoundTrackBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(LoopingSoundTrackBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new LoopingSoundTrackBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new LoopingSoundTrackBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual LoopingSoundDetailBlock[] ReadLoopingSoundDetailBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(LoopingSoundDetailBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new LoopingSoundDetailBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new LoopingSoundDetailBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteLoopingSoundTrackBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteLoopingSoundDetailBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write(martysMusicTimeSeconds);
                binaryWriter.Write(invalidName_);
                binaryWriter.Write(invalidName_0, 0, 8);
                binaryWriter.Write(invalidName_1);
                WriteLoopingSoundTrackBlockArray(binaryWriter);
                WriteLoopingSoundDetailBlockArray(binaryWriter);
            }
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
