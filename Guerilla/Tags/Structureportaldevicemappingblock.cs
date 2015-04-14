// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class StructurePortalDeviceMappingBlock : StructurePortalDeviceMappingBlockBase
    {
        public  StructurePortalDeviceMappingBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class StructurePortalDeviceMappingBlockBase  : IGuerilla
    {
        internal StructureDevicePortalAssociationBlock[] devicePortalAssociations;
        internal GamePortalToPortalMappingBlock[] gamePortalToPortalMap;
        internal  StructurePortalDeviceMappingBlockBase(BinaryReader binaryReader)
        {
            devicePortalAssociations = Guerilla.ReadBlockArray<StructureDevicePortalAssociationBlock>(binaryReader);
            gamePortalToPortalMap = Guerilla.ReadBlockArray<GamePortalToPortalMappingBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                Guerilla.WriteBlockArray<StructureDevicePortalAssociationBlock>(binaryWriter, devicePortalAssociations, nextAddress);
                Guerilla.WriteBlockArray<GamePortalToPortalMappingBlock>(binaryWriter, gamePortalToPortalMap, nextAddress);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
