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
    public partial class BipedLockOnDataStructBlock : BipedLockOnDataStructBlockBase
    {
        public BipedLockOnDataStructBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class BipedLockOnDataStructBlockBase : GuerillaBlock
    {
        internal Flags flags;
        internal float lockOnDistance;

        public override int SerializedSize
        {
            get { return 8; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public BipedLockOnDataStructBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            flags = (Flags) binaryReader.ReadInt32();
            lockOnDistance = binaryReader.ReadSingle();
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
                binaryWriter.Write((Int32) flags);
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