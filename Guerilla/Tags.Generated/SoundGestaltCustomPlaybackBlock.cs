// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public artial class SoundGestaltCustomPlaybackBlock : SoundGestaltCustomPlaybackBlockBase
    {
        public  oundGestaltCustomPlaybackBlock(B inaryReader binaryReader) :  base(b inaryReader) 
        {
         
    };

    LayoutAttribute(S ize = 52, Alignment = 4) ]
    public class SoundGestaltCustomPlaybackBlockBase  GuerillaBlock
    {
        internal SimplePlatformSoundPlaybackStructBlock playbackDefinitio

          
       public override int SerializedSize {get { return 52; }}
         
        internal  SoundGestaltCustomPlaybackBlockBase(BinaryReader binaryReader): b ase(binaryRe ader)
      

               playbackDe finition = new SimplePlatformSoundPlaybackStructBlock( binaryReader);
        }
          public override int Write ( System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
         {
             using(binaryWriter.BaseStream.Pin())
            {
              playbackDefinition.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
