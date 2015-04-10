// ReSharper disable All
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
        public  StructureBspDebugInfoBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  StructureBspDebugInfoBlockBase(System.IO.BinaryReader binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(64);
            ReadStructureBspClusterDebugInfoBlockArray(binaryReader);
            ReadStructureBspFogPlaneDebugInfoBlockArray(binaryReader);
            ReadStructureBspFogZoneDebugInfoBlockArray(binaryReader);
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
        internal  virtual StructureBspClusterDebugInfoBlock[] ReadStructureBspClusterDebugInfoBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual StructureBspFogPlaneDebugInfoBlock[] ReadStructureBspFogPlaneDebugInfoBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual StructureBspFogZoneDebugInfoBlock[] ReadStructureBspFogZoneDebugInfoBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteStructureBspClusterDebugInfoBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteStructureBspFogPlaneDebugInfoBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteStructureBspFogZoneDebugInfoBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_, 0, 64);
                WriteStructureBspClusterDebugInfoBlockArray(binaryWriter);
                WriteStructureBspFogPlaneDebugInfoBlockArray(binaryWriter);
                WriteStructureBspFogZoneDebugInfoBlockArray(binaryWriter);
            }
        }
    };
}
