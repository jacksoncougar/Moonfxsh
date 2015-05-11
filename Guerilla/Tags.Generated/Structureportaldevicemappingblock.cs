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
    public partial class StructurePortalDeviceMappingBlock : StructurePortalDeviceMappingBlockBase
    {
        public StructurePortalDeviceMappingBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class StructurePortalDeviceMappingBlockBase : GuerillaBlock
    {
        internal StructureDevicePortalAssociationBlock[] devicePortalAssociations;
        internal GamePortalToPortalMappingBlock[] gamePortalToPortalMap;

        public override int SerializedSize
        {
            get { return 16; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public StructurePortalDeviceMappingBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureDevicePortalAssociationBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<GamePortalToPortalMappingBlock>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            devicePortalAssociations = ReadBlockArrayData<StructureDevicePortalAssociationBlock>(binaryReader,
                blamPointers.Dequeue());
            gamePortalToPortalMap = ReadBlockArrayData<GamePortalToPortalMappingBlock>(binaryReader,
                blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<StructureDevicePortalAssociationBlock>(binaryWriter,
                    devicePortalAssociations, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GamePortalToPortalMappingBlock>(binaryWriter,
                    gamePortalToPortalMap, nextAddress);
                return nextAddress;
            }
        }
    };
}