using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class GlobalGeometryBlockInfoStructBlock : GlobalGeometryBlockInfoStructBlockBase
    {
        public  GlobalGeometryBlockInfoStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 36)]
    public class GlobalGeometryBlockInfoStructBlockBase
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
        internal  GlobalGeometryBlockInfoStructBlockBase(BinaryReader binaryReader)
        {
            this.blockOffset = binaryReader.ReadInt32();
            this.blockSize = binaryReader.ReadInt32();
            this.sectionDataSize = binaryReader.ReadInt32();
            this.resourceDataSize = binaryReader.ReadInt32();
            this.resources = ReadGlobalGeometryBlockResourceBlockArray(binaryReader);
            this.invalidName_ = binaryReader.ReadBytes(4);
            this.ownerTagSectionOffset = binaryReader.ReadInt16();
            this.invalidName_0 = binaryReader.ReadBytes(2);
            this.invalidName_1 = binaryReader.ReadBytes(4);
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
        internal  virtual GlobalGeometryBlockResourceBlock[] ReadGlobalGeometryBlockResourceBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalGeometryBlockResourceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalGeometryBlockResourceBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalGeometryBlockResourceBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
