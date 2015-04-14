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
    [LayoutAttribute(Size = 20)]
    public class SoundPromotionParametersStructBlockBase
    {
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference promotionSound;
        /// <summary>
        /// when there are this many instances of the sound, promote to the new sound.
        /// </summary>
        internal short promotionCount;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal  SoundPromotionParametersStructBlockBase(BinaryReader binaryReader)
        {
            this.promotionSound = binaryReader.ReadTagReference();
            this.promotionCount = binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.invalidName_0 = binaryReader.ReadBytes(8);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
        }
    };
}
