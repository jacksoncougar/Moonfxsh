// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public artial class SoundPermutationDialogueInfoBlock : SoundPermutationDialogueInfoBlockBase
    {
        public  oundPermutationDialogueInfoBlock(B inaryReader binaryReader) :  base(b inaryReader) 
        {
         
    };

    LayoutAttribute(S ize = 16, Alignment = 4) ]
    public class SoundPermutationDialogueInfoBlockBase  GuerillaBlock
    {
        internal int mouthDataOffset;
        internal int mouthDataLength;
        internal int lipsyncDataOffset;
        internal int lipsyncDataLengt

          
       public override int SerializedSize{g et { return 16; }}
         
        internal  SoundPermutationDialogueInfoBlockBase(Binary Reader binaryReader): base(binaryReader)
        {
             mouthDataOffset = binaryReader.ReadInt32();
             mouthDataLength = binaryReader.ReadInt32();
             lipsyncDa

         binaryReader.Rea dInt32();
            lipsyncDataLength = binaryReade r.ReadInt32();
        }
          public override int Write ( System.IO.BinaryWriter binaryWriter, Int32 nextAddres s)
        {
             using(binaryWriter.BaseStre am.Pin())
             {
                binaryWriter .Write(mouthDataO ffset);
                binaryWriter.W rite(mouthDataLen gth);
                binaryWriter.Write(lipsyncDataOffset);
              binaryWriter.Write(lipsyncDataLength);
                return nextAddress;
            }
        }
    };
}
