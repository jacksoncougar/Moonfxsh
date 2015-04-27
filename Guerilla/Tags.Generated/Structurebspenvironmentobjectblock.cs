// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class StructureBspEnvironmentObjectBlock : StructureBspEnvironmentObjectBlockBase
    {
        public  StructureBspEnvironmentObjectBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  StructureBspEnvironmentObjectBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 104, Alignment = 4)]
    public class StructureBspEnvironmentObjectBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.String32 name;
        internal OpenTK.Quaternion rotation;
        internal OpenTK.Vector3 translation;
        internal Moonfish.Tags.ShortBlockIndex1 paletteIndex;
        internal byte[] invalidName_;
        internal int uniqueID;
        internal Moonfish.Tags.TagClass exportedObjectType;
        internal Moonfish.Tags.String32 scenarioObjectName;
        
        public override int SerializedSize{get { return 104; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  StructureBspEnvironmentObjectBlockBase(BinaryReader binaryReader): base(binaryReader)
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
        public  StructureBspEnvironmentObjectBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
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
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
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
                return nextAddress;
            }
        }
    };
}
