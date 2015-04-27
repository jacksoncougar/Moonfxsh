// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public artial class SoundGestaltScaleBlock : SoundGestaltScaleBlockBase
    {
        public  oundGestaltScaleBlock(B inaryReader binaryReader) :  base(b inaryReader) 
        {
         
    };

    LayoutAttribute(S ize = 20, Alignment = 4) ]
    public class SoundGestaltScaleBlockBase  GuerillaBlock
    {
        internal SoundScaleModifiersStructBlock soundScaleModifiersStruc

          
       public override int Seria lizedSize{get { return 20 ; }}
        
        internal  SoundGestaltScaleBlockBase(BinaryReader binaryReader):  base(binaryR eader)
     

                soundScal eModifiersStruct = new SoundScaleModifiersStructBlock( binaryReader);
        }
          public override int Write ( System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        { 
             using(binaryWriter.BaseStream.Pin())
            {
                soundaleModifiersStruct.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
