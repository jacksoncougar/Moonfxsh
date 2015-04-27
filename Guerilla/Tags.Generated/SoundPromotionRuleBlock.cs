// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public artial class SoundPromotionRuleBlock : SoundPromotionRuleBlockBase
    {
        public  oundPromotionRuleBlock(B inaryReader binaryReader) :  base(b inaryReader) 
        {
         
    };

    LayoutAttribute(S ize = 16, Alignment = 4) ]
    public class SoundPromotionRuleBlockBase  GuerillaBlock
    {
        internal Moonfish.Tags.ShortBlockIndex1 pitchRanges;
        internal short maximumPlayingCoun

          /// <summary>
        /// time from when first permutation plays to when another sound from an equal or lower promotion can play
        /// </summary>
        internal float suppressionTimeSecond

          internal byte[] invalidName

          
       public override int Serial izedSize{get { return 16;  }}
        
        internal  SoundPromotionRuleBlockBase(BinaryReader  binaryReader): base(binaryReader)
        {
            pit chRanges = binaryReader.ReadShortBlockIndex1();
            maxi mumPlayingCount = binaryReader.ReadInt16();
              suppression

        s = binaryReader. ReadSingle();
            invalidName_ = binaryReader .ReadBytes(8);
        }
          public override int Write ( System.IO.BinaryWriter binaryWriter, Int32 nextAddres s)
         {
            using(binaryWriter.Base Stream.Pin())
             {
                binaryWriter .Write(pitchRanges);
                 binaryWriter.Write(maxi mumPlayingCount); 
                binaryWriter.Write(suppressionTimeSeconds);
              binaryWriter.Write(invalidName_, 0, 8);
                return nextAddress;
            }
        }
    };
}
