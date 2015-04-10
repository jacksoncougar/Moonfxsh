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
        public  StructureDevicePortalAssociationBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12)]
    public class StructureDevicePortalAssociationBlockBase
    {
        internal ScenarioObjectIdStructBlock deviceId;
        internal short firstGamePortalIndex;
        internal short gamePortalCount;
        internal  StructureDevicePortalAssociationBlockBase(System.IO.BinaryReader binaryReader)
        {
            deviceId = new ScenarioObjectIdStructBlock(binaryReader);
            firstGamePortalIndex = binaryReader.ReadInt16();
            gamePortalCount = binaryReader.ReadInt16();
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                deviceId.Write(binaryWriter);
                binaryWriter.Write(firstGamePortalIndex);
                binaryWriter.Write(gamePortalCount);
            }
        }
    };
}
