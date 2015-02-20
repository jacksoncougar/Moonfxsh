using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class StructureBspFogPlaneDebugInfoBlock : StructureBspFogPlaneDebugInfoBlockBase
    {
        public  StructureBspFogPlaneDebugInfoBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 56)]
    public class StructureBspFogPlaneDebugInfoBlockBase
    {
        internal int fogZoneIndex;
        internal byte[] invalidName_;
        internal int connectedPlaneDesignator;
        internal StructureBspDebugInfoRenderLineBlock[] lines;
        internal StructureBspDebugInfoIndicesBlock[] intersectedClusterIndices;
        internal StructureBspDebugInfoIndicesBlock[] infExtentClusterIndices;
        internal  StructureBspFogPlaneDebugInfoBlockBase(BinaryReader binaryReader)
        {
            this.fogZoneIndex = binaryReader.ReadInt32();
            this.invalidName_ = binaryReader.ReadBytes(24);
            this.connectedPlaneDesignator = binaryReader.ReadInt32();
            this.lines = ReadStructureBspDebugInfoRenderLineBlockArray(binaryReader);
            this.intersectedClusterIndices = ReadStructureBspDebugInfoIndicesBlockArray(binaryReader);
            this.infExtentClusterIndices = ReadStructureBspDebugInfoIndicesBlockArray(binaryReader);
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
        internal  virtual StructureBspDebugInfoRenderLineBlock[] ReadStructureBspDebugInfoRenderLineBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspDebugInfoRenderLineBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspDebugInfoRenderLineBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspDebugInfoRenderLineBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual StructureBspDebugInfoIndicesBlock[] ReadStructureBspDebugInfoIndicesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspDebugInfoIndicesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspDebugInfoIndicesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspDebugInfoIndicesBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
