using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class NewHudSoundBlock : NewHudSoundBlockBase
    {
        public  NewHudSoundBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 24)]
    public class NewHudSoundBlockBase
    {
        [TagReference("null")]
        internal Moonfish.Tags.TagReference chiefSound;
        internal LatchedTo latchedTo;
        internal float scale;
        [TagReference("null")]
        internal Moonfish.Tags.TagReference dervishSound;
        internal  NewHudSoundBlockBase(BinaryReader binaryReader)
        {
            this.chiefSound = binaryReader.ReadTagReference();
            this.latchedTo = (LatchedTo)binaryReader.ReadInt32();
            this.scale = binaryReader.ReadSingle();
            this.dervishSound = binaryReader.ReadTagReference();
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
            RocketLocking = 256,
            RocketLocked = 512,
        };
    };
}
