// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class StructureDevicePortalAssociationBlock : StructureDevicePortalAssociationBlockBase
    {
        public  StructureDevicePortalAssociationBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class StructureDevicePortalAssociationBlockBase  : IGuerilla
    {
        internal ScenarioObjectIdStructBlock deviceId;
        internal short firstGamePortalIndex;
        internal short gamePortalCount;
        internal  StructureDevicePortalAssociationBlockBase(BinaryReader binaryReader)
        {
            deviceId = new ScenarioObjectIdStructBlock(binaryReader);
            firstGamePortalIndex = binaryReader.ReadInt16();
            gamePortalCount = binaryReader.ReadInt16();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                deviceId.Write(binaryWriter);
                binaryWriter.Write(firstGamePortalIndex);
                binaryWriter.Write(gamePortalCount);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
