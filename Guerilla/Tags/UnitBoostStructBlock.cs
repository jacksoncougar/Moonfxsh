// ReSharper disable All
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
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class UnitBoostStructBlockBase  : IGuerilla
    {
        internal float boostPeakPower;
        internal float boostRisePower;
        internal float boostPeakTime;
        internal float boostFallPower;
        internal float deadTime;
        internal  UnitBoostStructBlockBase(BinaryReader binaryReader)
        {
            boostPeakPower = binaryReader.ReadSingle();
            boostRisePower = binaryReader.ReadSingle();
            boostPeakTime = binaryReader.ReadSingle();
            boostFallPower = binaryReader.ReadSingle();
            deadTime = binaryReader.ReadSingle();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(boostPeakPower);
                binaryWriter.Write(boostRisePower);
                binaryWriter.Write(boostPeakTime);
                binaryWriter.Write(boostFallPower);
                binaryWriter.Write(deadTime);
                return nextAddress;
            }
        }
    };
}
