// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SoundPitchRangeBlock : SoundPitchRangeBlockBase
    {
        public  SoundPitchRangeBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 28, Alignment = 4)]
    public class SoundPitchRangeBlockBase  : IGuerilla
    {
        /// <summary>
        /// the name of the imported pitch range directory
        /// </summary>
        internal Moonfish.Tags.StringID name;
        /// <summary>
        /// the apparent pitch when these samples are played at their recorded pitch.
        /// </summary>
        internal short naturalPitchCents;
        internal byte[] invalidName_;
        /// <summary>
        /// the range of pitches that will be represented using this sample.
        /// </summary>
        internal int bendBoundsCents;
        internal int invalidName_0;
        internal byte[] invalidName_1;
        /// <summary>
        /// permutations represent equivalent variations of this sound.
        /// </summary>
        internal SoundPermutationsBlock[] permutations;
        internal  SoundPitchRangeBlockBase(BinaryReader binaryReader)
        {
            name = binaryReader.ReadStringID();
            naturalPitchCents = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            bendBoundsCents = binaryReader.ReadInt32();
            invalidName_0 = binaryReader.ReadInt32();
            invalidName_1 = binaryReader.ReadBytes(4);
            permutations = Guerilla.ReadBlockArray<SoundPermutationsBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write(naturalPitchCents);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(bendBoundsCents);
                binaryWriter.Write(invalidName_0);
                binaryWriter.Write(invalidName_1, 0, 4);
                Guerilla.WriteBlockArray<SoundPermutationsBlock>(binaryWriter, permutations, nextAddress);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
