using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class UnitHudSoundBlock : UnitHudSoundBlockBase
    {
        public  UnitHudSoundBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 48)]
    public class UnitHudSoundBlockBase
    {
        [TagReference("null")]
        internal Moonfish.Tags.TagReference sound;
        internal LatchedTo latchedTo;
        internal float scale;
        internal byte[] invalidName_;
        internal  UnitHudSoundBlockBase(BinaryReader binaryReader)
        {
            this.sound = binaryReader.ReadTagReference();
            this.latchedTo = (LatchedTo)binaryReader.ReadInt32();
            this.scale = binaryReader.ReadSingle();
            this.invalidName_ = binaryReader.ReadBytes(32);
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
        [FlagsAttribute]
        internal enum LatchedTo : int
        
        {
            ShieldRecharging = 1,
            ShieldDamaged = 2,
            ShieldLow = 4,
            ShieldEmpty = 8,
            HealthLow = 16,
            HealthEmpty = 32,
            HealthMinorDamage = 64,
            HealthMajorDamage = 128,
        };
    };
}
