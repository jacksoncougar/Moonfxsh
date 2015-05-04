// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class SoundGestaltPitchRangesBlock : SoundGestaltPitchRangesBlockBase
    {
        public  SoundGestaltPitchRangesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  SoundGestaltPitchRangesBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class SoundGestaltPitchRangesBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.ShortBlockIndex1 name;
        internal Moonfish.Tags.ShortBlockIndex1 parameters;
        internal short encodedPermutationData;
        internal short firstRuntimePermutationFlagIndex;
        internal Moonfish.Tags.ShortBlockIndex1 firstPermutation;
        internal short permutationCount;
        
        public override int SerializedSize{get { return 12; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  SoundGestaltPitchRangesBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            name = binaryReader.ReadShortBlockIndex1();
            parameters = binaryReader.ReadShortBlockIndex1();
            encodedPermutationData = binaryReader.ReadInt16();
            firstRuntimePermutationFlagIndex = binaryReader.ReadInt16();
            firstPermutation = binaryReader.ReadShortBlockIndex1();
            permutationCount = binaryReader.ReadInt16();
        }
        public  SoundGestaltPitchRangesBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            name = binaryReader.ReadShortBlockIndex1();
            parameters = binaryReader.ReadShortBlockIndex1();
            encodedPermutationData = binaryReader.ReadInt16();
            firstRuntimePermutationFlagIndex = binaryReader.ReadInt16();
            firstPermutation = binaryReader.ReadShortBlockIndex1();
            permutationCount = binaryReader.ReadInt16();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write(parameters);
                binaryWriter.Write(encodedPermutationData);
                binaryWriter.Write(firstRuntimePermutationFlagIndex);
                binaryWriter.Write(firstPermutation);
                binaryWriter.Write(permutationCount);
                return nextAddress;
            }
        }
    };
}
