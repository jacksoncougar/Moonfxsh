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
        public  UnitBoostStructBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  UnitBoostStructBlockBase(System.IO.BinaryReader binaryReader)
        {
            boostPeakPower = binaryReader.ReadSingle();
            boostRisePower = binaryReader.ReadSingle();
            boostPeakTime = binaryReader.ReadSingle();
            boostFallPower = binaryReader.ReadSingle();
            deadTime = binaryReader.ReadSingle();
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(boostPeakPower);
                binaryWriter.Write(boostRisePower);
                binaryWriter.Write(boostPeakTime);
                binaryWriter.Write(boostFallPower);
                binaryWriter.Write(deadTime);
            }
        }
    };
}
