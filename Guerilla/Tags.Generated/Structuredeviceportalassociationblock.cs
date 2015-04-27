// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class StructureDevicePortalAssociationBlock : StructureDevicePortalAssociationBlockBase
    {
        public  StructureDevicePortalAssociationBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  StructureDevicePortalAssociationBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class StructureDevicePortalAssociationBlockBase : GuerillaBlock
    {
        internal ScenarioObjectIdStructBlock deviceId;
        internal short firstGamePortalIndex;
        internal short gamePortalCount;
        
        public override int SerializedSize{get { return 12; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  StructureDevicePortalAssociationBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            deviceId = new ScenarioObjectIdStructBlock(binaryReader);
            firstGamePortalIndex = binaryReader.ReadInt16();
            gamePortalCount = binaryReader.ReadInt16();
        }
        public  StructureDevicePortalAssociationBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            deviceId = new ScenarioObjectIdStructBlock(binaryReader);
            firstGamePortalIndex = binaryReader.ReadInt16();
            gamePortalCount = binaryReader.ReadInt16();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                deviceId.Write(binaryWriter);
                binaryWriter.Write(firstGamePortalIndex);
                binaryWriter.Write(gamePortalCount);
                return nextAddress;
            }
        }
    };
}
