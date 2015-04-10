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
        public  SoundGestaltPitchRangesBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  SoundGestaltPitchRangesBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadShortBlockIndex1();
            this.parameters = binaryReader.ReadShortBlockIndex1();
            this.encodedPermutationData = binaryReader.ReadInt16();
            this.firstRuntimePermutationFlagIndex = binaryReader.ReadInt16();
            this.firstPermutation = binaryReader.ReadShortBlockIndex1();
            this.permutationCount = binaryReader.ReadInt16();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
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
    };
}
