// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class GlobalGeometrySectionInfoStructBlock : GlobalGeometrySectionInfoStructBlockBase
    {
        public GlobalGeometrySectionInfoStructBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 40, Alignment = 4)]
    public class GlobalGeometrySectionInfoStructBlockBase : GuerillaBlock
    {
        internal short totalVertexCount;
        internal short totalTriangleCount;
        internal short totalPartCount;
        internal short shadowCastingTriangleCount;
        internal short shadowCastingPartCount;
        internal short opaquePointCount;
        internal short opaqueVertexCount;
        internal short opaquePartCount;
        internal byte opaqueMaxNodesVertex;
        internal byte transparentMaxNodesVertex;
        internal short shadowCastingRigidTriangleCount;
        internal GeometryClassification geometryClassification;
        internal GeometryCompressionFlags geometryCompressionFlags;
        internal GlobalGeometryCompressionInfoBlock[] eMPTYSTRING;
        internal byte hardwareNodeCount;
        internal byte nodeMapSize;
        internal short softwarePlaneCount;
        internal short totalSubpartCont;
        internal SectionLightingFlags sectionLightingFlags;
        public override int SerializedSize { get { return 40; } }
        public override int Alignment { get { return 4; } }
        public GlobalGeometrySectionInfoStructBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            totalVertexCount = binaryReader.ReadInt16();
            totalTriangleCount = binaryReader.ReadInt16();
            totalPartCount = binaryReader.ReadInt16();
            shadowCastingTriangleCount = binaryReader.ReadInt16();
            shadowCastingPartCount = binaryReader.ReadInt16();
            opaquePointCount = binaryReader.ReadInt16();
            opaqueVertexCount = binaryReader.ReadInt16();
            opaquePartCount = binaryReader.ReadInt16();
            opaqueMaxNodesVertex = binaryReader.ReadByte();
            transparentMaxNodesVertex = binaryReader.ReadByte();
            shadowCastingRigidTriangleCount = binaryReader.ReadInt16();
            geometryClassification = (GeometryClassification)binaryReader.ReadInt16();
            geometryCompressionFlags = (GeometryCompressionFlags)binaryReader.ReadInt16();
            blamPointers.Enqueue(ReadBlockArrayPointer<GlobalGeometryCompressionInfoBlock>(binaryReader));
            hardwareNodeCount = binaryReader.ReadByte();
            nodeMapSize = binaryReader.ReadByte();
            softwarePlaneCount = binaryReader.ReadInt16();
            totalSubpartCont = binaryReader.ReadInt16();
            sectionLightingFlags = (SectionLightingFlags)binaryReader.ReadInt16();
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            eMPTYSTRING = ReadBlockArrayData<GlobalGeometryCompressionInfoBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(totalVertexCount);
                binaryWriter.Write(totalTriangleCount);
                binaryWriter.Write(totalPartCount);
                binaryWriter.Write(shadowCastingTriangleCount);
                binaryWriter.Write(shadowCastingPartCount);
                binaryWriter.Write(opaquePointCount);
                binaryWriter.Write(opaqueVertexCount);
                binaryWriter.Write(opaquePartCount);
                binaryWriter.Write(opaqueMaxNodesVertex);
                binaryWriter.Write(transparentMaxNodesVertex);
                binaryWriter.Write(shadowCastingRigidTriangleCount);
                binaryWriter.Write((Int16)geometryClassification);
                binaryWriter.Write((Int16)geometryCompressionFlags);
                nextAddress = Guerilla.WriteBlockArray<GlobalGeometryCompressionInfoBlock>(binaryWriter, eMPTYSTRING, nextAddress);
                binaryWriter.Write(hardwareNodeCount);
                binaryWriter.Write(nodeMapSize);
                binaryWriter.Write(softwarePlaneCount);
                binaryWriter.Write(totalSubpartCont);
                binaryWriter.Write((Int16)sectionLightingFlags);
                return nextAddress;
            }
        }
        internal enum GeometryClassification : short
        {
            Worldspace = 0,
            Rigid = 1,
            RigidBoned = 2,
            Skinned = 3,
            UnsupportedReimport = 4,
        };
        [FlagsAttribute]
        internal enum GeometryCompressionFlags : short
        {
            CompressedPosition = 1,
            CompressedTexcoord = 2,
            CompressedSecondaryTexcoord = 4,
        };
        [FlagsAttribute]
        internal enum SectionLightingFlags : short
        {
            HasLmTexcoords = 1,
            HasLmIncRad = 2,
            HasLmColors = 4,
            HasLmPrt = 8,
        };
    };
}
