using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class StructureBspFogZoneDebugInfoBlock : StructureBspFogZoneDebugInfoBlockBase
    {
        public  StructureBspFogZoneDebugInfoBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 64)]
    public class StructureBspFogZoneDebugInfoBlockBase
    {
        internal int mediaIndexScenarioFogPlane;
        internal int baseFogPlaneIndex;
        internal byte[] invalidName_;
        internal StructureBspDebugInfoRenderLineBlock[] lines;
        internal StructureBspDebugInfoIndicesBlock[] immersedClusterIndices;
        internal StructureBspDebugInfoIndicesBlock[] boundingFogPlaneIndices;
        internal StructureBspDebugInfoIndicesBlock[] collisionFogPlaneIndices;
        internal  StructureBspFogZoneDebugInfoBlockBase(BinaryReader binaryReader)
        {
            this.mediaIndexScenarioFogPlane = binaryReader.ReadInt32();
            this.baseFogPlaneIndex = binaryReader.ReadInt32();
            this.invalidName_ = binaryReader.ReadBytes(24);
            this.lines = ReadStructureBspDebugInfoRenderLineBlockArray(binaryReader);
            this.immersedClusterIndices = ReadStructureBspDebugInfoIndicesBlockArray(binaryReader);
            this.boundingFogPlaneIndices = ReadStructureBspDebugInfoIndicesBlockArray(binaryReader);
            this.collisionFogPlaneIndices = ReadStructureBspDebugInfoIndicesBlockArray(binaryReader);
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
