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
    public partial class GlobalStructurePhysicsStructBlock : GlobalStructurePhysicsStructBlockBase
    {
        public GlobalStructurePhysicsStructBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 52, Alignment = 4)]
    public class GlobalStructurePhysicsStructBlockBase : GuerillaBlock
    {
        internal byte[] moppCode;
        internal byte[] invalidName_;
        internal OpenTK.Vector3 moppBoundsMin;
        internal OpenTK.Vector3 moppBoundsMax;
        internal byte[] breakableSurfacesMoppCode;
        internal BreakableSurfaceKeyTableBlock[] breakableSurfaceKeyTable;

        public override int SerializedSize
        {
            get { return 52; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public GlobalStructurePhysicsStructBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer(binaryReader, 1));
            invalidName_ = binaryReader.ReadBytes(4);
            moppBoundsMin = binaryReader.ReadVector3();
            moppBoundsMax = binaryReader.ReadVector3();
            blamPointers.Enqueue(ReadBlockArrayPointer(binaryReader, 1));
            blamPointers.Enqueue(ReadBlockArrayPointer<BreakableSurfaceKeyTableBlock>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            moppCode = ReadDataByteArray(binaryReader, blamPointers.Dequeue());
            breakableSurfacesMoppCode = ReadDataByteArray(binaryReader, blamPointers.Dequeue());
            breakableSurfaceKeyTable = ReadBlockArrayData<BreakableSurfaceKeyTableBlock>(binaryReader,
                blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteData(binaryWriter, moppCode, nextAddress);
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(moppBoundsMin);
                binaryWriter.Write(moppBoundsMax);
                nextAddress = Guerilla.WriteData(binaryWriter, breakableSurfacesMoppCode, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<BreakableSurfaceKeyTableBlock>(binaryWriter,
                    breakableSurfaceKeyTable, nextAddress);
                return nextAddress;
            }
        }
    };
}