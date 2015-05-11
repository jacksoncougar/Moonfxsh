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
    public partial class LeavesBlock : LeavesBlockBase
    {
        public LeavesBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class LeavesBlockBase : GuerillaBlock
    {
        internal Flags flags;
        internal byte bSP2DReferenceCount;
        internal short firstBSP2DReference;

        public override int SerializedSize
        {
            get { return 4; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public LeavesBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            flags = (Flags) binaryReader.ReadByte();
            bSP2DReferenceCount = binaryReader.ReadByte();
            firstBSP2DReference = binaryReader.ReadInt16();
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
                binaryWriter.Write((Byte) flags);
                binaryWriter.Write(bSP2DReferenceCount);
                binaryWriter.Write(firstBSP2DReference);
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum Flags : byte
        {
            ContainsDoubleSidedSurfaces = 1,
        };
    };
}