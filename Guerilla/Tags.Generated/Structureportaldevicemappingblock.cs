// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class StructurePortalDeviceMappingBlock : StructurePortalDeviceMappingBlockBase
    {
        public  StructurePortalDeviceMappingBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  StructurePortalDeviceMappingBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class StructurePortalDeviceMappingBlockBase : GuerillaBlock
    {
        internal StructureDevicePortalAssociationBlock[] devicePortalAssociations;
        internal GamePortalToPortalMappingBlock[] gamePortalToPortalMap;
        
        public override int SerializedSize{get { return 16; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  StructurePortalDeviceMappingBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            devicePortalAssociations = Guerilla.ReadBlockArray<StructureDevicePortalAssociationBlock>(binaryReader);
            gamePortalToPortalMap = Guerilla.ReadBlockArray<GamePortalToPortalMappingBlock>(binaryReader);
        }
        public  StructurePortalDeviceMappingBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            devicePortalAssociations = Guerilla.ReadBlockArray<StructureDevicePortalAssociationBlock>(binaryReader);
            gamePortalToPortalMap = Guerilla.ReadBlockArray<GamePortalToPortalMappingBlock>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<StructureDevicePortalAssociationBlock>(binaryWriter, devicePortalAssociations, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GamePortalToPortalMappingBlock>(binaryWriter, gamePortalToPortalMap, nextAddress);
                return nextAddress;
            }
        }
    };
}
