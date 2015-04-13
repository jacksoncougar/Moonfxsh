// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SoundGestaltPromotionsBlock : SoundGestaltPromotionsBlockBase
    {
        public  SoundGestaltPromotionsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class SoundGestaltPromotionsBlockBase  : IGuerilla
    {
        internal SoundPromotionParametersStructBlock soundPromotionParametersStruct;
        internal  SoundGestaltPromotionsBlockBase(BinaryReader binaryReader)
        {
            soundPromotionParametersStruct = new SoundPromotionParametersStructBlock(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                soundPromotionParametersStruct.Write(binaryWriter);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
