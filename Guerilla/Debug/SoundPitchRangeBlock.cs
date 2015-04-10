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
        public  SoundPitchRangeBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  SoundPitchRangeBlockBase(System.IO.BinaryReader binaryReader)
        {
            name = binaryReader.ReadStringID();
            naturalPitchCents = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            bendBoundsCents = binaryReader.ReadInt32();
            invalidName_0 = binaryReader.ReadInt32();
            invalidName_1 = binaryReader.ReadBytes(4);
            ReadSoundPermutationsBlockArray(binaryReader);
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
        internal  virtual SoundPermutationsBlock[] ReadSoundPermutationsBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SoundPermutationsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SoundPermutationsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SoundPermutationsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteSoundPermutationsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write(naturalPitchCents);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(bendBoundsCents);
                binaryWriter.Write(invalidName_0);
                binaryWriter.Write(invalidName_1, 0, 4);
                WriteSoundPermutationsBlockArray(binaryWriter);
            }
        }
    };
}
