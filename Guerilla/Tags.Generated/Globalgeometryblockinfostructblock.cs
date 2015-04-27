// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class GlobalGeometryBlockInfoStructBlock : GlobalGeometryBlockInfoStructBlockBase
    {
        public  GlobalGeometryBlockInfoStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  GlobalGeometryBlockInfoStructBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 36, Alignment = 4)]
    public class GlobalGeometryBlockInfoStructBlockBase : GuerillaBlock
    {
        internal int blockOffset;
        internal int blockSize;
        internal int sectionDataSize;
        internal int resourceDataSize;
        internal GlobalGeometryBlockResourceBlock[] resources;
        internal byte[] invalidName_;
        internal short ownerTagSectionOffset;
        internal byte[] invalidName_0;
        internal byte[] invalidName_1;
        
        public override int SerializedSize{get { return 36; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  GlobalGeometryBlockInfoStructBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            blockOffset = binaryReader.ReadInt32();
            blockSize = binaryReader.ReadInt32();
            sectionDataSize = binaryReader.ReadInt32();
            resourceDataSize = binaryReader.ReadInt32();
            resources = Guerilla.ReadBlockArray<GlobalGeometryBlockResourceBlock>(binaryReader);
            invalidName_ = binaryReader.ReadBytes(4);
            ownerTagSectionOffset = binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(2);
            invalidName_1 = binaryReader.ReadBytes(4);
        }
        public  GlobalGeometryBlockInfoStructBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            blockOffset = binaryReader.ReadInt32();
            blockSize = binaryReader.ReadInt32();
            sectionDataSize = binaryReader.ReadInt32();
            resourceDataSize = binaryReader.ReadInt32();
            resources = Guerilla.ReadBlockArray<GlobalGeometryBlockResourceBlock>(binaryReader);
            invalidName_ = binaryReader.ReadBytes(4);
            ownerTagSectionOffset = binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(2);
            invalidName_1 = binaryReader.ReadBytes(4);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(blockOffset);
                binaryWriter.Write(blockSize);
                binaryWriter.Write(sectionDataSize);
                binaryWriter.Write(resourceDataSize);
                nextAddress = Guerilla.WriteBlockArray<GlobalGeometryBlockResourceBlock>(binaryWriter, resources, nextAddress);
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(ownerTagSectionOffset);
                binaryWriter.Write(invalidName_0, 0, 2);
                binaryWriter.Write(invalidName_1, 0, 4);
                return nextAddress;
            }
        }
    };
}
