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
        public static readonly TagClass Lsnd = (TagClass)"lsnd";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("lsnd")]
    public partial class SoundLoopingBlock : SoundLoopingBlockBase
    {
        public  SoundLoopingBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  SoundLoopingBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 44, Alignment = 4)]
    public class SoundLoopingBlockBase : GuerillaBlock
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
        
        public override int SerializedSize{get { return 44; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  SoundLoopingBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt32();
            martysMusicTimeSeconds = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadSingle();
            invalidName_0 = binaryReader.ReadBytes(8);
            invalidName_1 = binaryReader.ReadTagReference();
            tracks = Guerilla.ReadBlockArray<LoopingSoundTrackBlock>(binaryReader);
            detailSounds = Guerilla.ReadBlockArray<LoopingSoundDetailBlock>(binaryReader);
        }
        public  SoundLoopingBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write(martysMusicTimeSeconds);
                binaryWriter.Write(invalidName_);
                binaryWriter.Write(invalidName_0, 0, 8);
                binaryWriter.Write(invalidName_1);
                nextAddress = Guerilla.WriteBlockArray<LoopingSoundTrackBlock>(binaryWriter, tracks, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<LoopingSoundDetailBlock>(binaryWriter, detailSounds, nextAddress);
                return nextAddress;
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
