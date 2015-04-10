using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class UnitBoardingMeleeStructBlock : UnitBoardingMeleeStructBlockBase
    {
        public  UnitBoardingMeleeStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 40)]
    public class UnitBoardingMeleeStructBlockBase
    {
        [TagReference("jpt!")]
        internal Moonfish.Tags.TagReference boardingMeleeDamage;
        [TagReference("jpt!")]
        internal Moonfish.Tags.TagReference boardingMeleeResponse;
        [TagReference("jpt!")]
        internal Moonfish.Tags.TagReference landingMeleeDamage;
        [TagReference("jpt!")]
        internal Moonfish.Tags.TagReference flurryMeleeDamage;
        [TagReference("jpt!")]
        internal Moonfish.Tags.TagReference obstacleSmashDamage;
        internal  UnitBoardingMeleeStructBlockBase(BinaryReader binaryReader)
        {
            this.boardingMeleeDamage = binaryReader.ReadTagReference();
            this.boardingMeleeResponse = binaryReader.ReadTagReference();
            this.landingMeleeDamage = binaryReader.ReadTagReference();
            this.flurryMeleeDamage = binaryReader.ReadTagReference();
            this.obstacleSmashDamage = binaryReader.ReadTagReference();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
    };
}
