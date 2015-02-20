using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("mode")]
    public  partial class RenderModelBlock : RenderModelBlockBase
    {
        public  RenderModelBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 132)]
    public class RenderModelBlockBase
    {
        internal Moonfish.Tags.StringID name;
        internal Flags flags;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal GlobalTagImportInfoBlock[] importInfo;
        internal GlobalGeometryCompressionInfoBlock[] compressionInfo;
        internal RenderModelRegionBlock[] regions;
        internal RenderModelSectionBlock[] sections;
        internal RenderModelInvalidSectionPairsBlock[] invalidSectionPairBits;
        internal RenderModelSectionGroupBlock[] sectionGroups;
        internal byte l1SectionGroupIndexSuperLow;
        internal byte l2SectionGroupIndexLow;
        internal byte l3SectionGroupIndexMedium;
        internal byte l4SectionGroupIndexHigh;
        internal byte l5SectionGroupIndexSuperHigh;
        internal byte l6SectionGroupIndexHollywood;
        internal byte[] invalidName_1;
        internal int nodeListChecksum;
        internal RenderModelNodeBlock[] nodes;
        internal RenderModelNodeMapBlockOLD[] nodeMapOLD;
        internal RenderModelMarkerGroupBlock[] markerGroups;
        internal GlobalGeometryMaterialBlock[] materials;
        internal GlobalErrorReportCategoriesBlock[] errors;
        /// <summary>
        /// dont draw fp model when camera > this angle cosine (-1,1) Sugg. -0.2. 0 disables.
        /// </summary>
        internal float dontDrawOverCameraCosineAngle;
        internal PrtInfoBlock[] pRTInfo;
        internal SectionRenderLeavesBlock[] sectionRenderLeaves;
        internal  RenderModelBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            this.flags = (Flags)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.invalidName_0 = binaryReader.ReadBytes(4);
            this.importInfo = ReadGlobalTagImportInfoBlockArray(binaryReader);
            this.compressionInfo = ReadGlobalGeometryCompressionInfoBlockArray(binaryReader);
            this.regions = ReadRenderModelRegionBlockArray(binaryReader);
            this.sections = ReadRenderModelSectionBlockArray(binaryReader);
            this.invalidSectionPairBits = ReadRenderModelInvalidSectionPairsBlockArray(binaryReader);
            this.sectionGroups = ReadRenderModelSectionGroupBlockArray(binaryReader);
            this.l1SectionGroupIndexSuperLow = binaryReader.ReadByte();
            this.l2SectionGroupIndexLow = binaryReader.ReadByte();
            this.l3SectionGroupIndexMedium = binaryReader.ReadByte();
            this.l4SectionGroupIndexHigh = binaryReader.ReadByte();
            this.l5SectionGroupIndexSuperHigh = binaryReader.ReadByte();
            this.l6SectionGroupIndexHollywood = binaryReader.ReadByte();
            this.invalidName_1 = binaryReader.ReadBytes(2);
            this.nodeListChecksum = binaryReader.ReadInt32();
            this.nodes = ReadRenderModelNodeBlockArray(binaryReader);
            this.nodeMapOLD = ReadRenderModelNodeMapBlockOLDArray(binaryReader);
            this.markerGroups = ReadRenderModelMarkerGroupBlockArray(binaryReader);
            this.materials = ReadGlobalGeometryMaterialBlockArray(binaryReader);
            this.errors = ReadGlobalErrorReportCategoriesBlockArray(binaryReader);
            this.dontDrawOverCameraCosineAngle = binaryReader.ReadSingle();
            this.pRTInfo = ReadPrtInfoBlockArray(binaryReader);
            this.sectionRenderLeaves = ReadSectionRenderLeavesBlockArray(binaryReader);
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
        internal  virtual GlobalTagImportInfoBlock[] ReadGlobalTagImportInfoBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalTagImportInfoBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalTagImportInfoBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalTagImportInfoBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GlobalGeometryCompressionInfoBlock[] ReadGlobalGeometryCompressionInfoBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalGeometryCompressionInfoBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalGeometryCompressionInfoBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalGeometryCompressionInfoBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual RenderModelRegionBlock[] ReadRenderModelRegionBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(RenderModelRegionBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new RenderModelRegionBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new RenderModelRegionBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual RenderModelSectionBlock[] ReadRenderModelSectionBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(RenderModelSectionBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new RenderModelSectionBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new RenderModelSectionBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual RenderModelInvalidSectionPairsBlock[] ReadRenderModelInvalidSectionPairsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(RenderModelInvalidSectionPairsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new RenderModelInvalidSectionPairsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new RenderModelInvalidSectionPairsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual RenderModelSectionGroupBlock[] ReadRenderModelSectionGroupBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(RenderModelSectionGroupBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new RenderModelSectionGroupBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new RenderModelSectionGroupBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual RenderModelNodeBlock[] ReadRenderModelNodeBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(RenderModelNodeBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new RenderModelNodeBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new RenderModelNodeBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual RenderModelNodeMapBlockOLD[] ReadRenderModelNodeMapBlockOLDArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(RenderModelNodeMapBlockOLD));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new RenderModelNodeMapBlockOLD[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new RenderModelNodeMapBlockOLD(binaryReader);
                }
            }
            return array;
        }
        internal  virtual RenderModelMarkerGroupBlock[] ReadRenderModelMarkerGroupBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(RenderModelMarkerGroupBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new RenderModelMarkerGroupBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new RenderModelMarkerGroupBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GlobalGeometryMaterialBlock[] ReadGlobalGeometryMaterialBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalGeometryMaterialBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalGeometryMaterialBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalGeometryMaterialBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GlobalErrorReportCategoriesBlock[] ReadGlobalErrorReportCategoriesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalErrorReportCategoriesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalErrorReportCategoriesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalErrorReportCategoriesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PrtInfoBlock[] ReadPrtInfoBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PrtInfoBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PrtInfoBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PrtInfoBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual SectionRenderLeavesBlock[] ReadSectionRenderLeavesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SectionRenderLeavesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SectionRenderLeavesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SectionRenderLeavesBlock(binaryReader);
                }
            }
            return array;
        }
        internal enum Flags : short
        {
            RenderModelForceThirdPersonBit = 1,
            ForceCarmackReverse = 2,
            ForceNodeMaps = 4,
            GeometryPostprocessed = 8,
        };
    };
}
