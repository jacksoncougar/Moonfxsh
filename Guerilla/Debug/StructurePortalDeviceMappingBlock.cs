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
        public  StructurePortalDeviceMappingBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class StructurePortalDeviceMappingBlockBase
    {
        internal StructureDevicePortalAssociationBlock[] devicePortalAssociations;
        internal GamePortalToPortalMappingBlock[] gamePortalToPortalMap;
        internal  StructurePortalDeviceMappingBlockBase(System.IO.BinaryReader binaryReader)
        {
            ReadStructureDevicePortalAssociationBlockArray(binaryReader);
            ReadGamePortalToPortalMappingBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
        internal  virtual StructureDevicePortalAssociationBlock[] ReadStructureDevicePortalAssociationBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureDevicePortalAssociationBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureDevicePortalAssociationBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureDevicePortalAssociationBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GamePortalToPortalMappingBlock[] ReadGamePortalToPortalMappingBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GamePortalToPortalMappingBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GamePortalToPortalMappingBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GamePortalToPortalMappingBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteStructureDevicePortalAssociationBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGamePortalToPortalMappingBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                WriteStructureDevicePortalAssociationBlockArray(binaryWriter);
                WriteGamePortalToPortalMappingBlockArray(binaryWriter);
            }
        }
    };
}
