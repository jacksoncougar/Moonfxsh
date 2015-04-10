// ReSharper disable All
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
        public  GlobalGeometrySectionInfoStructBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  GlobalGeometrySectionInfoStructBlockBase(System.IO.BinaryReader binaryReader)
        {
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
            ReadGlobalGeometryCompressionInfoBlockArray(binaryReader);
            hardwareNodeCount = binaryReader.ReadByte();
            nodeMapSize = binaryReader.ReadByte();
            softwarePlaneCount = binaryReader.ReadInt16();
            totalSubpartCont = binaryReader.ReadInt16();
            sectionLightingFlags = (SectionLightingFlags)binaryReader.ReadInt16();
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGlobalGeometryCompressionInfoBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
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
                WriteGlobalGeometryCompressionInfoBlockArray(binaryWriter);
                binaryWriter.Write(hardwareNodeCount);
                binaryWriter.Write(nodeMapSize);
                binaryWriter.Write(softwarePlaneCount);
                binaryWriter.Write(totalSubpartCont);
                binaryWriter.Write((Int16)sectionLightingFlags);
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
