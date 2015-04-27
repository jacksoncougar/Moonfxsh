// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public artial class SoundGestaltPitchRangesBlock : SoundGestaltPitchRangesBlockBase
    {
        public  oundGestaltPitchRangesBlock(B inaryReader binaryReader) :  base(b inaryReader) 
        {
         
    };

    LayoutAttribute(S ize = 12, Alignment = 4) ]
    public class SoundGestaltPitchRangesBlockBase  GuerillaBlock
    {
        internal Moonfish.Tags.ShortBlockIndex1 name;
        internal Moonfish.Tags.ShortBlockIndex1 parameters;
        internal short encodedPermutationData;
        internal short firstRuntimePermutationFlagIndex;
        internal Moonfish.Tags.ShortBlockIndex1 firstPermutation;
        internal short permutationCoun

          
       public override int SerializedS ize{get { return 12; }}
         
        internal  SoundGestaltPitchRangesBlockBase(Binary Reader binaryReader): base(binaryReader)
        {
             name = binaryReader.ReadShortBlockIndex1();
            param eters = binaryReader.ReadShortBlockIndex1();
            encodedPermutati onData = binaryReader.ReadInt16();
            firstRuntimePermutati onFlagIndex = binaryReader.ReadInt16();
            first Permutation =

        der.ReadShortBloc kIndex1();
            permutationCount = binaryReade r.ReadInt16();
        }
          public override int Write ( System.IO.BinaryWriter binaryWriter, Int32 nextAddres s)
         {
            using(binaryWrit er.BaseStr eam.Pin())
            {
                 binaryWriter.Write (name);
                binaryWriter.W rite(parameters);
                 binaryWriter.Write(encodedPermutatio nData);
                 binaryWriter.Write(firstRuntim ePermutationFlag Index);
                binaryWriter.Write(firstPermutation);
              binaryWriter.Write(permutationCount);
                return nextAddress;
            }
        }
    };
}
