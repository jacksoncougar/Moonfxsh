// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public artial class SoundPermutationChunkBlock : SoundPermutationChunkBlockBase
    {
        public  oundPermutationChunkBlock(B inaryReader binaryReader) :  base(b inaryReader) 
        {
         
    };

    LayoutAttribute(S ize = 12, Alignment = 4) ]
    public class SoundPermutationChunkBlockBase  GuerillaBlock
    {
        internal int fileOffset;
        internal int invalidName_;
        internal int invalidName_

          
       public override int Serialize dSize{get { return 12; }} 
        
        internal  SoundPermutationChunkBlockBase(B inaryReader binaryReader): base(binaryReader)
         {
            fileOffset = binaryReader.ReadInt32(); 
            

        e_ = binaryReader .ReadInt32();
            invalidName_0 = binaryReade r.ReadInt32();
        }
          public override int Write ( System.IO.BinaryWriter binaryWriter, Int32 nextAddres s)
         {
            using(binaryWriter.Bas eStream.Pin( ))
            {
                bina ryWriter.Writ e(fileOffset);
                binaryWriter.Write(invalidName_);
              binaryWriter.Write(invalidName_0);
                return nextAddress;
            }
        }
    };
}
