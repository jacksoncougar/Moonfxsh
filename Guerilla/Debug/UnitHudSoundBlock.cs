// ReSharper disable All
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
        public  UnitHudSoundBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  UnitHudSoundBlockBase(System.IO.BinaryReader binaryReader)
        {
            sound = binaryReader.ReadTagReference();
            latchedTo = (LatchedTo)binaryReader.ReadInt32();
            scale = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadBytes(32);
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
                binaryWriter.Write(sound);
                binaryWriter.Write((Int32)latchedTo);
                binaryWriter.Write(scale);
                binaryWriter.Write(invalidName_, 0, 32);
            }
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
