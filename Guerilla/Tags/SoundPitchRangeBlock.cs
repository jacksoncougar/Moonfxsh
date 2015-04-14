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
    [LayoutAttribute(Size = 28)]
    public class SoundPitchRangeBlockBase
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
            this.name = binaryReader.ReadStringID();
            this.naturalPitchCents = binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.bendBoundsCents = binaryReader.ReadInt32();
            this.invalidName_0 = binaryReader.ReadInt32();
            this.invalidName_1 = binaryReader.ReadBytes(4);
            this.permutations = ReadSoundPermutationsBlockArray(binaryReader);
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
        internal  virtual SoundPermutationsBlock[] ReadSoundPermutationsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SoundPermutationsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SoundPermutationsBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SoundPermutationsBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
