using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class StructureBspDebugInfoBlock : StructureBspDebugInfoBlockBase
    {
        public  StructureBspDebugInfoBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 88)]
    public class StructureBspDebugInfoBlockBase
    {
        internal byte[] invalidName_;
        internal StructureBspClusterDebugInfoBlock[] clusters;
        internal StructureBspFogPlaneDebugInfoBlock[] fogPlanes;
        internal StructureBspFogZoneDebugInfoBlock[] fogZones;
        internal  StructureBspDebugInfoBlockBase(BinaryReader binaryReader)
        {
            this.invalidName_ = binaryReader.ReadBytes(64);
            this.clusters = ReadStructureBspClusterDebugInfoBlockArray(binaryReader);
            this.fogPlanes = ReadStructureBspFogPlaneDebugInfoBlockArray(binaryReader);
            this.fogZones = ReadStructureBspFogZoneDebugInfoBlockArray(binaryReader);
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
        internal  virtual StructureBspClusterDebugInfoBlock[] ReadStructureBspClusterDebugInfoBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspClusterDebugInfoBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspClusterDebugInfoBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspClusterDebugInfoBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual StructureBspFogPlaneDebugInfoBlock[] ReadStructureBspFogPlaneDebugInfoBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspFogPlaneDebugInfoBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspFogPlaneDebugInfoBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspFogPlaneDebugInfoBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual StructureBspFogZoneDebugInfoBlock[] ReadStructureBspFogZoneDebugInfoBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspFogZoneDebugInfoBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspFogZoneDebugInfoBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspFogZoneDebugInfoBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
