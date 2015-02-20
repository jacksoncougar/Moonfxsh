using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class BipedLockOnDataStructBlock : BipedLockOnDataStructBlockBase
    {
        public  BipedLockOnDataStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8)]
    public class BipedLockOnDataStructBlockBase
    {
        internal Flags flags;
        internal float lockOnDistance;
        internal  BipedLockOnDataStructBlockBase(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt32();
            this.lockOnDistance = binaryReader.ReadSingle();
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
        internal enum Flags : int
        {
            LockedByHumanTargeting = 1,
            LockedByPlasmaTargeting = 2,
            AlwaysLockedByPlasmaTargeting = 4,
        };
    };
}
