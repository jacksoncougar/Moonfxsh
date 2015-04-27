// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class BipedLockOnDataStructBlock : BipedLockOnDataStructBlockBase
    {
        public  BipedLockOnDataStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  BipedLockOnDataStructBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class BipedLockOnDataStructBlockBase : GuerillaBlock
    {
        internal Flags flags;
        internal float lockOnDistance;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  BipedLockOnDataStructBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt32();
            lockOnDistance = binaryReader.ReadSingle();
        }
        public  BipedLockOnDataStructBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write(lockOnDistance);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        {
            LockedByHumanTargeting = 1,
            LockedByPlasmaTargeting = 2,
            AlwaysLockedByPlasmaTargeting = 4,
        };
    };
}
