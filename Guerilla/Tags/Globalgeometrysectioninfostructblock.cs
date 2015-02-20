using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class GlobalGeometrySectionInfoStructBlock : GlobalGeometrySectionInfoStructBlockBase
    {
        public  GlobalGeometrySectionInfoStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 40)]
    public class GlobalGeometrySectionInfoStructBlockBase
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
        internal  GlobalGeometrySectionInfoStructBlockBase(BinaryReader binaryReader)
        {
            this.totalVertexCount = binaryReader.ReadInt16();
            this.totalTriangleCount = binaryReader.ReadInt16();
            this.totalPartCount = binaryReader.ReadInt16();
            this.shadowCastingTriangleCount = binaryReader.ReadInt16();
            this.shadowCastingPartCount = binaryReader.ReadInt16();
            this.opaquePointCount = binaryReader.ReadInt16();
            this.opaqueVertexCount = binaryReader.ReadInt16();
            this.opaquePartCount = binaryReader.ReadInt16();
            this.opaqueMaxNodesVertex = binaryReader.ReadByte();
            this.transparentMaxNodesVertex = binaryReader.ReadByte();
            this.shadowCastingRigidTriangleCount = binaryReader.ReadInt16();
            this.geometryClassification = (GeometryClassification)binaryReader.ReadInt16();
            this.geometryCompressionFlags = (GeometryCompressionFlags)binaryReader.ReadInt16();
            this.eMPTYSTRING = ReadGlobalGeometryCompressionInfoBlockArray(binaryReader);
            this.hardwareNodeCount = binaryReader.ReadByte();
            this.nodeMapSize = binaryReader.ReadByte();
            this.softwarePlaneCount = binaryReader.ReadInt16();
            this.totalSubpartCont = binaryReader.ReadInt16();
            this.sectionLightingFlags = (SectionLightingFlags)binaryReader.ReadInt16();
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
        internal enum GeometryClassification : short
        {
            Worldspace = 0,
            Rigid = 1,
            RigidBoned = 2,
            Skinned = 3,
            UnsupportedReimport = 4,
        };
        internal enum GeometryCompressionFlags : short
        {
            CompressedPosition = 1,
            CompressedTexcoord = 2,
            CompressedSecondaryTexcoord = 4,
        };
        internal enum SectionLightingFlags : short
        {
            HasLmTexcoords = 1,
            HasLmIncRad = 2,
            HasLmColors = 4,
            HasLmPrt = 8,
        };
    };
}
