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
    [LayoutAttribute(Size = 16)]
    public class StructurePortalDeviceMappingBlockBase
    {
        internal StructureDevicePortalAssociationBlock[] devicePortalAssociations;
        internal GamePortalToPortalMappingBlock[] gamePortalToPortalMap;
        internal  StructurePortalDeviceMappingBlockBase(BinaryReader binaryReader)
        {
            this.devicePortalAssociations = ReadStructureDevicePortalAssociationBlockArray(binaryReader);
            this.gamePortalToPortalMap = ReadGamePortalToPortalMappingBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
        }
        internal  virtual StructureDevicePortalAssociationBlock[] ReadStructureDevicePortalAssociationBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureDevicePortalAssociationBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureDevicePortalAssociationBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureDevicePortalAssociationBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GamePortalToPortalMappingBlock[] ReadGamePortalToPortalMappingBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GamePortalToPortalMappingBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GamePortalToPortalMappingBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GamePortalToPortalMappingBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
