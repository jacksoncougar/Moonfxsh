// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Mode = (TagClass)"mode";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("mode")]
    public partial class RenderModelBlock : RenderModelBlockBase
    {
        public  RenderModelBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  RenderModelBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 132, Alignment = 4)]
    public class RenderModelBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent name;
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
        
        public override int SerializedSize{get { return 132; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  RenderModelBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            name = binaryReader.ReadStringID();
            flags = (Flags)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            invalidName_0 = binaryReader.ReadBytes(4);
            importInfo = Guerilla.ReadBlockArray<GlobalTagImportInfoBlock>(binaryReader);
            compressionInfo = Guerilla.ReadBlockArray<GlobalGeometryCompressionInfoBlock>(binaryReader);
            regions = Guerilla.ReadBlockArray<RenderModelRegionBlock>(binaryReader);
            sections = Guerilla.ReadBlockArray<RenderModelSectionBlock>(binaryReader);
            invalidSectionPairBits = Guerilla.ReadBlockArray<RenderModelInvalidSectionPairsBlock>(binaryReader);
            sectionGroups = Guerilla.ReadBlockArray<RenderModelSectionGroupBlock>(binaryReader);
            l1SectionGroupIndexSuperLow = binaryReader.ReadByte();
            l2SectionGroupIndexLow = binaryReader.ReadByte();
            l3SectionGroupIndexMedium = binaryReader.ReadByte();
            l4SectionGroupIndexHigh = binaryReader.ReadByte();
            l5SectionGroupIndexSuperHigh = binaryReader.ReadByte();
            l6SectionGroupIndexHollywood = binaryReader.ReadByte();
            invalidName_1 = binaryReader.ReadBytes(2);
            nodeListChecksum = binaryReader.ReadInt32();
            nodes = Guerilla.ReadBlockArray<RenderModelNodeBlock>(binaryReader);
            nodeMapOLD = Guerilla.ReadBlockArray<RenderModelNodeMapBlockOLD>(binaryReader);
            markerGroups = Guerilla.ReadBlockArray<RenderModelMarkerGroupBlock>(binaryReader);
            materials = Guerilla.ReadBlockArray<GlobalGeometryMaterialBlock>(binaryReader);
            errors = Guerilla.ReadBlockArray<GlobalErrorReportCategoriesBlock>(binaryReader);
            dontDrawOverCameraCosineAngle = binaryReader.ReadSingle();
            pRTInfo = Guerilla.ReadBlockArray<PrtInfoBlock>(binaryReader);
            sectionRenderLeaves = Guerilla.ReadBlockArray<SectionRenderLeavesBlock>(binaryReader);
        }
        public  RenderModelBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            name = binaryReader.ReadStringID();
            flags = (Flags)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            invalidName_0 = binaryReader.ReadBytes(4);
            importInfo = Guerilla.ReadBlockArray<GlobalTagImportInfoBlock>(binaryReader);
            compressionInfo = Guerilla.ReadBlockArray<GlobalGeometryCompressionInfoBlock>(binaryReader);
            regions = Guerilla.ReadBlockArray<RenderModelRegionBlock>(binaryReader);
            sections = Guerilla.ReadBlockArray<RenderModelSectionBlock>(binaryReader);
            invalidSectionPairBits = Guerilla.ReadBlockArray<RenderModelInvalidSectionPairsBlock>(binaryReader);
            sectionGroups = Guerilla.ReadBlockArray<RenderModelSectionGroupBlock>(binaryReader);
            l1SectionGroupIndexSuperLow = binaryReader.ReadByte();
            l2SectionGroupIndexLow = binaryReader.ReadByte();
            l3SectionGroupIndexMedium = binaryReader.ReadByte();
            l4SectionGroupIndexHigh = binaryReader.ReadByte();
            l5SectionGroupIndexSuperHigh = binaryReader.ReadByte();
            l6SectionGroupIndexHollywood = binaryReader.ReadByte();
            invalidName_1 = binaryReader.ReadBytes(2);
            nodeListChecksum = binaryReader.ReadInt32();
            nodes = Guerilla.ReadBlockArray<RenderModelNodeBlock>(binaryReader);
            nodeMapOLD = Guerilla.ReadBlockArray<RenderModelNodeMapBlockOLD>(binaryReader);
            markerGroups = Guerilla.ReadBlockArray<RenderModelMarkerGroupBlock>(binaryReader);
            materials = Guerilla.ReadBlockArray<GlobalGeometryMaterialBlock>(binaryReader);
            errors = Guerilla.ReadBlockArray<GlobalErrorReportCategoriesBlock>(binaryReader);
            dontDrawOverCameraCosineAngle = binaryReader.ReadSingle();
            pRTInfo = Guerilla.ReadBlockArray<PrtInfoBlock>(binaryReader);
            sectionRenderLeaves = Guerilla.ReadBlockArray<SectionRenderLeavesBlock>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(invalidName_0, 0, 4);
                nextAddress = Guerilla.WriteBlockArray<GlobalTagImportInfoBlock>(binaryWriter, importInfo, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GlobalGeometryCompressionInfoBlock>(binaryWriter, compressionInfo, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<RenderModelRegionBlock>(binaryWriter, regions, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<RenderModelSectionBlock>(binaryWriter, sections, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<RenderModelInvalidSectionPairsBlock>(binaryWriter, invalidSectionPairBits, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<RenderModelSectionGroupBlock>(binaryWriter, sectionGroups, nextAddress);
                binaryWriter.Write(l1SectionGroupIndexSuperLow);
                binaryWriter.Write(l2SectionGroupIndexLow);
                binaryWriter.Write(l3SectionGroupIndexMedium);
                binaryWriter.Write(l4SectionGroupIndexHigh);
                binaryWriter.Write(l5SectionGroupIndexSuperHigh);
                binaryWriter.Write(l6SectionGroupIndexHollywood);
                binaryWriter.Write(invalidName_1, 0, 2);
                binaryWriter.Write(nodeListChecksum);
                nextAddress = Guerilla.WriteBlockArray<RenderModelNodeBlock>(binaryWriter, nodes, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<RenderModelNodeMapBlockOLD>(binaryWriter, nodeMapOLD, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<RenderModelMarkerGroupBlock>(binaryWriter, markerGroups, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GlobalGeometryMaterialBlock>(binaryWriter, materials, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GlobalErrorReportCategoriesBlock>(binaryWriter, errors, nextAddress);
                binaryWriter.Write(dontDrawOverCameraCosineAngle);
                nextAddress = Guerilla.WriteBlockArray<PrtInfoBlock>(binaryWriter, pRTInfo, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<SectionRenderLeavesBlock>(binaryWriter, sectionRenderLeaves, nextAddress);
                return nextAddress;
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
