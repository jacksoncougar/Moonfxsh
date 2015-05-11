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
    public partial class SpecialMovementBlock : SpecialMovementBlockBase
    {
        public SpecialMovementBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class SpecialMovementBlockBase : GuerillaBlock
    {
        internal SpecialMovement1 specialMovement1;

        public override int SerializedSize
        {
            get { return 4; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public SpecialMovementBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            specialMovement1 = (SpecialMovement1) binaryReader.ReadInt32();
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
                binaryWriter.Write((Int32) specialMovement1);
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum SpecialMovement1 : int
        {
            Jump = 1,
            Climb = 2,
            Vault = 4,
            Mount = 8,
            Hoist = 16,
            WallJump = 32,
            NA = 64,
        };
    };
}