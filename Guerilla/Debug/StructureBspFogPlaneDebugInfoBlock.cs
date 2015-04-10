// ReSharper disable All
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
        public  StructureBspFogPlaneDebugInfoBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  StructureBspFogPlaneDebugInfoBlockBase(System.IO.BinaryReader binaryReader)
        {
            fogZoneIndex = binaryReader.ReadInt32();
            invalidName_ = binaryReader.ReadBytes(24);
            connectedPlaneDesignator = binaryReader.ReadInt32();
            ReadStructureBspDebugInfoRenderLineBlockArray(binaryReader);
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
                binaryWriter.Write(fogZoneIndex);
                binaryWriter.Write(invalidName_, 0, 24);
                binaryWriter.Write(connectedPlaneDesignator);
                WriteStructureBspDebugInfoRenderLineBlockArray(binaryWriter);
                WriteStructureBspDebugInfoIndicesBlockArray(binaryWriter);
                WriteStructureBspDebugInfoIndicesBlockArray(binaryWriter);
            }
        }
    };
}
