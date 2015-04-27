// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public artial class SoundGestaltPlaybackBlock : SoundGestaltPlaybackBlockBase
    {
        public  oundGestaltPlaybackBlock(B inaryReader binaryReader) :  base(b inaryReader) 
        {
         
    };

    LayoutAttribute(S ize = 56, Alignment = 4) ]
    public class SoundGestaltPlaybackBlockBase  GuerillaBlock
    {
        internal SoundPlaybackParametersStructBlock soundPlaybackParametersStruc

          
       public override int Serializ edSize{get { return 56; } }
        
        internal  SoundGestaltPlaybackBlockBase(BinaryReader binaryReader): base(bin aryReader)
         {
  

        soundPlaybackPara metersStruct = new SoundPlaybackParametersStructBlock( binaryReader);
        }
          public override int Write ( System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
             us ing(binaryWriter.BaseStream.Pin())
            {
                soundPlayckParametersStruct.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
