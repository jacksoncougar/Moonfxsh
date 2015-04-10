// ReSharper disable All
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
        public  RenderModelBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  RenderModelBlockBase(System.IO.BinaryReader binaryReader)
        {
            name = binaryReader.ReadStringID();
            flags = (Flags)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            invalidName_0 = binaryReader.ReadBytes(4);
            ReadGlobalTagImportInfoBlockArray(binaryReader);
            ReadGlobalGeometryCompressionInfoBlockArray(binaryReader);
            ReadRenderModelRegionBlockArray(binaryReader);
            ReadRenderModelSectionBlockArray(binaryReader);
            ReadRenderModelInvalidSectionPairsBlockArray(binaryReader);
            ReadRenderModelSectionGroupBlockArray(binaryReader);
            l1SectionGroupIndexSuperLow = binaryReader.ReadByte();
            l2SectionGroupIndexLow = binaryReader.ReadByte();
            l3SectionGroupIndexMedium = binaryReader.ReadByte();
            l4SectionGroupIndexHigh = binaryReader.ReadByte();
            l5SectionGroupIndexSuperHigh = binaryReader.ReadByte();
            l6SectionGroupIndexHollywood = binaryReader.ReadByte();
            invalidName_1 = binaryReader.ReadBytes(2);
            nodeListChecksum = binaryReader.ReadInt32();
            ReadRenderModelNodeBlockArray(binaryReader);
            ReadRenderModelNodeMapBlockOLDArray(binaryReader);
            ReadRenderModelMarkerGroupBlockArray(binaryReader);
            ReadGlobalGeometryMaterialBlockArray(binaryReader);
            ReadGlobalErrorReportCategoriesBlockArray(binaryReader);
            dontDrawOverCameraCosineAngle = binaryReader.ReadSingle();
            ReadPrtInfoBlockArray(binaryReader);
            ReadSectionRenderLeavesBlockArray(binaryReader);
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
        internal  virtual GlobalTagImportInfoBlock[] ReadGlobalTagImportInfoBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual GlobalGeometryCompressionInfoBlock[] ReadGlobalGeometryCompressionInfoBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual RenderModelRegionBlock[] ReadRenderModelRegionBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual RenderModelSectionBlock[] ReadRenderModelSectionBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual RenderModelInvalidSectionPairsBlock[] ReadRenderModelInvalidSectionPairsBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual RenderModelSectionGroupBlock[] ReadRenderModelSectionGroupBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual RenderModelNodeBlock[] ReadRenderModelNodeBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual RenderModelNodeMapBlockOLD[] ReadRenderModelNodeMapBlockOLDArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual RenderModelMarkerGroupBlock[] ReadRenderModelMarkerGroupBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual GlobalGeometryMaterialBlock[] ReadGlobalGeometryMaterialBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual GlobalErrorReportCategoriesBlock[] ReadGlobalErrorReportCategoriesBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual PrtInfoBlock[] ReadPrtInfoBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual SectionRenderLeavesBlock[] ReadSectionRenderLeavesBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGlobalTagImportInfoBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGlobalGeometryCompressionInfoBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteRenderModelRegionBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteRenderModelSectionBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteRenderModelInvalidSectionPairsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteRenderModelSectionGroupBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteRenderModelNodeBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteRenderModelNodeMapBlockOLDArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteRenderModelMarkerGroupBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGlobalGeometryMaterialBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGlobalErrorReportCategoriesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WritePrtInfoBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteSectionRenderLeavesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(invalidName_0, 0, 4);
                WriteGlobalTagImportInfoBlockArray(binaryWriter);
                WriteGlobalGeometryCompressionInfoBlockArray(binaryWriter);
                WriteRenderModelRegionBlockArray(binaryWriter);
                WriteRenderModelSectionBlockArray(binaryWriter);
                WriteRenderModelInvalidSectionPairsBlockArray(binaryWriter);
                WriteRenderModelSectionGroupBlockArray(binaryWriter);
                binaryWriter.Write(l1SectionGroupIndexSuperLow);
                binaryWriter.Write(l2SectionGroupIndexLow);
                binaryWriter.Write(l3SectionGroupIndexMedium);
                binaryWriter.Write(l4SectionGroupIndexHigh);
                binaryWriter.Write(l5SectionGroupIndexSuperHigh);
                binaryWriter.Write(l6SectionGroupIndexHollywood);
                binaryWriter.Write(invalidName_1, 0, 2);
                binaryWriter.Write(nodeListChecksum);
                WriteRenderModelNodeBlockArray(binaryWriter);
                WriteRenderModelNodeMapBlockOLDArray(binaryWriter);
                WriteRenderModelMarkerGroupBlockArray(binaryWriter);
                WriteGlobalGeometryMaterialBlockArray(binaryWriter);
                WriteGlobalErrorReportCategoriesBlockArray(binaryWriter);
                binaryWriter.Write(dontDrawOverCameraCosineAngle);
                WritePrtInfoBlockArray(binaryWriter);
                WriteSectionRenderLeavesBlockArray(binaryWriter);
            }
        }
        [FlagsAttribute]
        internal enum Flags : short
        
        {
            RenderModelForceThirdPersonBit = 1,
            ForceCarmackReverse = 2,
            ForceNodeMaps = 4,
            GeometryPostprocessed = 8,
        };
    };
}
