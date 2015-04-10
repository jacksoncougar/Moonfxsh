using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class PoweredMassPointBlock : PoweredMassPointBlockBase
    {
        public  PoweredMassPointBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 128)]
    public class PoweredMassPointBlockBase
    {
        internal Moonfish.Tags.String32 name;
        internal Flags flags;
        internal float antigravStrength;
        internal float antigravOffset;
        internal float antigravHeight;
        internal float antigravDampFraction;
        internal float antigravNormalK1;
        internal float antigravNormalK0;
        internal Moonfish.Tags.StringID damageSourceRegionName;
        internal byte[] invalidName_;
        internal  PoweredMassPointBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadString32();
            this.flags = (Flags)binaryReader.ReadInt32();
            this.antigravStrength = binaryReader.ReadSingle();
            this.antigravOffset = binaryReader.ReadSingle();
            this.antigravHeight = binaryReader.ReadSingle();
            this.antigravDampFraction = binaryReader.ReadSingle();
            this.antigravNormalK1 = binaryReader.ReadSingle();
            this.antigravNormalK0 = binaryReader.ReadSingle();
            this.damageSourceRegionName = binaryReader.ReadStringID();
            this.invalidName_ = binaryReader.ReadBytes(64);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
        }
        [FlagsAttribute]
        internal enum Flags : int
        
        {
            GroundFriction = 1,
            WaterFriction = 2,
            AirFriction = 4,
            WaterLift = 8,
            AirLift = 16,
            Thrust = 32,
            Antigrav = 64,
            GetsDamageFromRegion = 128,
        };
    };
}
