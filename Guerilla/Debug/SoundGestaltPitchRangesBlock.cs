// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SoundGestaltPitchRangesBlock : SoundGestaltPitchRangesBlockBase
    {
        public  SoundGestaltPitchRangesBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12)]
    public class SoundGestaltPitchRangesBlockBase
    {
        internal Moonfish.Tags.ShortBlockIndex1 name;
        internal Moonfish.Tags.ShortBlockIndex1 parameters;
        internal short encodedPermutationData;
        internal short firstRuntimePermutationFlagIndex;
        internal Moonfish.Tags.ShortBlockIndex1 firstPermutation;
        internal short permutationCount;
        internal  SoundGestaltPitchRangesBlockBase(System.IO.BinaryReader binaryReader)
        {
            name = binaryReader.ReadShortBlockIndex1();
            parameters = binaryReader.ReadShortBlockIndex1();
            encodedPermutationData = binaryReader.ReadInt16();
            firstRuntimePermutationFlagIndex = binaryReader.ReadInt16();
            firstPermutation = binaryReader.ReadShortBlockIndex1();
            permutationCount = binaryReader.ReadInt16();
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write(parameters);
                binaryWriter.Write(encodedPermutationData);
                binaryWriter.Write(firstRuntimePermutationFlagIndex);
                binaryWriter.Write(firstPermutation);
                binaryWriter.Write(permutationCount);
            }
        }
    };
}
