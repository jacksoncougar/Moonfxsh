// ReSharper disable All
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
        public  StructureBspFogZoneDebugInfoBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  StructureBspFogZoneDebugInfoBlockBase(System.IO.BinaryReader binaryReader)
        {
            mediaIndexScenarioFogPlane = binaryReader.ReadInt32();
            baseFogPlaneIndex = binaryReader.ReadInt32();
            invalidName_ = binaryReader.ReadBytes(24);
            ReadStructureBspDebugInfoRenderLineBlockArray(binaryReader);
            ReadStructureBspDebugInfoIndicesBlockArray(binaryReader);
            ReadStructureBspDebugInfoIndicesBlockArray(binaryReader);
            ReadStructureBspDebugInfoIndicesBlockArray(binaryReader);
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
        internal  virtual StructureBspDebugInfoRenderLineBlock[] ReadStructureBspDebugInfoRenderLineBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual StructureBspDebugInfoIndicesBlock[] ReadStructureBspDebugInfoIndicesBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteStructureBspDebugInfoRenderLineBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteStructureBspDebugInfoIndicesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(mediaIndexScenarioFogPlane);
                binaryWriter.Write(baseFogPlaneIndex);
                binaryWriter.Write(invalidName_, 0, 24);
                WriteStructureBspDebugInfoRenderLineBlockArray(binaryWriter);
                WriteStructureBspDebugInfoIndicesBlockArray(binaryWriter);
                WriteStructureBspDebugInfoIndicesBlockArray(binaryWriter);
                WriteStructureBspDebugInfoIndicesBlockArray(binaryWriter);
            }
        }
    };
}
