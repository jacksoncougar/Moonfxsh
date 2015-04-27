// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public artial class SoundGestaltRuntimePermutationBitVectorBlock : SoundGestaltRuntimePermutationBitVectorBlockBase
    {
        public  oundGestaltRuntimePermutationBitVectorBlock(B inaryReader binaryReader) :  base(b inaryReader) 
        {
         
    };

    LayoutAttribute(S ize = 1, Alignment = 4) ]
    public class SoundGestaltRuntimePermutationBitVectorBlockBase  GuerillaBlock
    {
        internal byte invalidName

          
       public override int SerializedSize{get { return  1; }}
        
         internal  SoundGestaltRuntimePermutationBitVectorBlockBase(Bin aryReader bin

        : base(binaryRead er)
        {
            invalidName_ = binaryReade r.ReadByte();
        }
          public override int Write( S ystem.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        { 
            using(binaryWriter.BaseStream.Pin())
            {
              binaryWriter.Write(invalidName_);
                return nextAddress;
            }
        }
    };
}
