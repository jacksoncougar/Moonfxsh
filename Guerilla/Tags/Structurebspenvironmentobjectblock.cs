using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class StructureBspEnvironmentObjectBlock : StructureBspEnvironmentObjectBlockBase
    {
        public  StructureBspEnvironmentObjectBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 104)]
    public class StructureBspEnvironmentObjectBlockBase
    {
        internal Moonfish.Tags.String32 name;
        internal OpenTK.Quaternion rotation;
        internal OpenTK.Vector3 translation;
        internal Moonfish.Tags.ShortBlockIndex1 paletteIndex;
        internal byte[] invalidName_;
        internal int uniqueID;
        internal Moonfish.Tags.TagClass exportedObjectType;
        internal Moonfish.Tags.String32 scenarioObjectName;
        internal  StructureBspEnvironmentObjectBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadString32();
            this.rotation = binaryReader.ReadQuaternion();
            this.translation = binaryReader.ReadVector3();
            this.paletteIndex = binaryReader.ReadShortBlockIndex1();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.uniqueID = binaryReader.ReadInt32();
            this.exportedObjectType = binaryReader.ReadTagClass();
            this.scenarioObjectName = binaryReader.ReadString32();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
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
    };
}
