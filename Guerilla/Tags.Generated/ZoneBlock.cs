// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class ZoneBlock : ZoneBlockBase
    {
        public ZoneBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 56, Alignment = 4)]
    public class ZoneBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.String32 name;
        internal Flags flags;
        internal Moonfish.Tags.ShortBlockIndex1 manualBsp;
        internal byte[] invalidName_;
        internal FiringPositionsBlock[] firingPositions;
        internal AreasBlock[] areas;
        public override int SerializedSize { get { return 56; } }
        public override int Alignment { get { return 4; } }
        public ZoneBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            name = binaryReader.ReadString32();
            flags = (Flags)binaryReader.ReadInt32();
            manualBsp = binaryReader.ReadShortBlockIndex1();
            invalidName_ = binaryReader.ReadBytes(2);
            blamPointers.Enqueue(ReadBlockArrayPointer<FiringPositionsBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<AreasBlock>(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            invalidName_[0].ReadPointers(binaryReader, blamPointers);
            invalidName_[1].ReadPointers(binaryReader, blamPointers);
            firingPositions = ReadBlockArrayData<FiringPositionsBlock>(binaryReader, blamPointers.Dequeue());
            areas = ReadBlockArrayData<AreasBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write(manualBsp);
                binaryWriter.Write(invalidName_, 0, 2);
                nextAddress = Guerilla.WriteBlockArray<FiringPositionsBlock>(binaryWriter, firingPositions, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<AreasBlock>(binaryWriter, areas, nextAddress);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        {
            ManualBspIndex = 1,
        };
    };
}
