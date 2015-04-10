using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class UnitBoostStructBlock : UnitBoostStructBlockBase
    {
        public  UnitBoostStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20)]
    public class UnitBoostStructBlockBase
    {
        internal float boostPeakPower;
        internal float boostRisePower;
        internal float boostPeakTime;
        internal float boostFallPower;
        internal float deadTime;
        internal  UnitBoostStructBlockBase(BinaryReader binaryReader)
        {
            this.boostPeakPower = binaryReader.ReadSingle();
            this.boostRisePower = binaryReader.ReadSingle();
            this.boostPeakTime = binaryReader.ReadSingle();
            this.boostFallPower = binaryReader.ReadSingle();
            this.deadTime = binaryReader.ReadSingle();
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
