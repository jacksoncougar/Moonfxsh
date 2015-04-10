// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ModelTargetLockOnDataStructBlock : ModelTargetLockOnDataStructBlockBase
    {
        public  ModelTargetLockOnDataStructBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8)]
    public class ModelTargetLockOnDataStructBlockBase
    {
        internal Flags flags;
        internal float lockOnDistance;
        internal  ModelTargetLockOnDataStructBlockBase(System.IO.BinaryReader binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt32();
            lockOnDistance = binaryReader.ReadSingle();
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
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write(lockOnDistance);
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        
        {
            LockedByHumanTracking = 1,
            LockedByPlasmaTracking = 2,
            Headshot = 4,
            Vulnerable = 8,
            AlwasLockedByPlasmaTracking = 16,
        };
    };
}
