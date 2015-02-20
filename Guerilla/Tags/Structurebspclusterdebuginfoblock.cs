using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class StructureBspClusterDebugInfoBlock : StructureBspClusterDebugInfoBlockBase
    {
        public  StructureBspClusterDebugInfoBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 72)]
    public class StructureBspClusterDebugInfoBlockBase
    {
        internal Errors errors;
        internal Warnings warnings;
        internal byte[] invalidName_;
        internal StructureBspDebugInfoRenderLineBlock[] lines;
        internal StructureBspDebugInfoIndicesBlock[] fogPlaneIndices;
        internal StructureBspDebugInfoIndicesBlock[] visibleFogPlaneIndices;
        internal StructureBspDebugInfoIndicesBlock[] visFogOmissionClusterIndices;
        internal StructureBspDebugInfoIndicesBlock[] containingFogZoneIndices;
        internal  StructureBspClusterDebugInfoBlockBase(BinaryReader binaryReader)
        {
            this.errors = (Errors)binaryReader.ReadInt16();
            this.warnings = (Warnings)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(28);
            this.lines = ReadStructureBspDebugInfoRenderLineBlockArray(binaryReader);
            this.fogPlaneIndices = ReadStructureBspDebugInfoIndicesBlockArray(binaryReader);
            this.visibleFogPlaneIndices = ReadStructureBspDebugInfoIndicesBlockArray(binaryReader);
            this.visFogOmissionClusterIndices = ReadStructureBspDebugInfoIndicesBlockArray(binaryReader);
            this.containingFogZoneIndices = ReadStructureBspDebugInfoIndicesBlockArray(binaryReader);
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
        internal enum Errors : short
        {
            MultipleFogPlanes = 1,
            FogZoneCollision = 2,
            FogZoneImmersion = 4,
        };
        internal enum Warnings : short
        {
            MultipleVisibleFogPlanes = 1,
            VisibleFogClusterOmission = 2,
            FogPlaneMissedRenderBSP = 4,
        };
    };
}
