// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SoundPromotionParametersStructBlock : SoundPromotionParametersStructBlockBase
    {
        public  SoundPromotionParametersStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 28, Alignment = 4)]
    public class SoundPromotionParametersStructBlockBase  : IGuerilla
    {
        internal SoundPromotionRuleBlock[] promotionRules;
        internal SoundPromotionRuntimeTimerBlock[] soundPromotionRuntimeTimerBlock;
        internal byte[] invalidName_;
        internal  SoundPromotionParametersStructBlockBase(BinaryReader binaryReader)
        {
            promotionRules = Guerilla.ReadBlockArray<SoundPromotionRuleBlock>(binaryReader);
            soundPromotionRuntimeTimerBlock = Guerilla.ReadBlockArray<SoundPromotionRuntimeTimerBlock>(binaryReader);
            invalidName_ = binaryReader.ReadBytes(12);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<SoundPromotionRuleBlock>(binaryWriter, promotionRules, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<SoundPromotionRuntimeTimerBlock>(binaryWriter, soundPromotionRuntimeTimerBlock, nextAddress);
                binaryWriter.Write(invalidName_, 0, 12);
                return nextAddress;
            }
        }
    };
}
