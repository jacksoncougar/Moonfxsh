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
    public partial class StructureDevicePortalAssociationBlock : StructureDevicePortalAssociationBlockBase
    {
        public StructureDevicePortalAssociationBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class StructureDevicePortalAssociationBlockBase : GuerillaBlock
    {
        internal ScenarioObjectIdStructBlock deviceId;
        internal short firstGamePortalIndex;
        internal short gamePortalCount;

        public override int SerializedSize
        {
            get { return 12; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public StructureDevicePortalAssociationBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            deviceId = new ScenarioObjectIdStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(deviceId.ReadFields(binaryReader)));
            firstGamePortalIndex = binaryReader.ReadInt16();
            gamePortalCount = binaryReader.ReadInt16();
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            deviceId.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                deviceId.Write(binaryWriter);
                binaryWriter.Write(firstGamePortalIndex);
                binaryWriter.Write(gamePortalCount);
                return nextAddress;
            }
        }
    };
}