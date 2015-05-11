// ReSharper disable All

using Moonfish.Model;

using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class UnitBoostStructBlock : UnitBoostStructBlockBase
    {
        public UnitBoostStructBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class UnitBoostStructBlockBase : GuerillaBlock
    {
        internal float boostPeakPower;
        internal float boostRisePower;
        internal float boostPeakTime;
        internal float boostFallPower;
        internal float deadTime;

        public override int SerializedSize
        {
            get { return 20; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public UnitBoostStructBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            boostPeakPower = binaryReader.ReadSingle();
            boostRisePower = binaryReader.ReadSingle();
            boostPeakTime = binaryReader.ReadSingle();
            boostFallPower = binaryReader.ReadSingle();
            deadTime = binaryReader.ReadSingle();
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
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