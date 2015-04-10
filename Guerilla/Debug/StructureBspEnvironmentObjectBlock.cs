// ReSharper disable All
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
        public  StructureBspEnvironmentObjectBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  StructureBspEnvironmentObjectBlockBase(System.IO.BinaryReader binaryReader)
        {
            name = binaryReader.ReadString32();
            rotation = binaryReader.ReadQuaternion();
            translation = binaryReader.ReadVector3();
            paletteIndex = binaryReader.ReadShortBlockIndex1();
            invalidName_ = binaryReader.ReadBytes(2);
            uniqueID = binaryReader.ReadInt32();
            exportedObjectType = binaryReader.ReadTagClass();
            scenarioObjectName = binaryReader.ReadString32();
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
                binaryWriter.Write(name);
                binaryWriter.Write(rotation);
                binaryWriter.Write(translation);
                binaryWriter.Write(paletteIndex);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(uniqueID);
                binaryWriter.Write(exportedObjectType);
                binaryWriter.Write(scenarioObjectName);
            }
        }
    };
}
