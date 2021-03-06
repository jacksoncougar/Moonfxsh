//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Moonfish.Guerilla.Tags
{
    using Moonfish.Tags;
    using Moonfish.Model;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    
    public partial class GlobalGeometrySectionInfoStructBlock : GuerillaBlock, IWriteQueueable
    {
        /// <summary>
        /// EMPTY STRING
        /// </summary>
        public short TotalVertexCount;
        public short TotalTriangleCount;
        public short TotalPartCount;
        public short ShadowCastingTriangleCount;
        public short ShadowCastingPartCount;
        public short OpaquePointCount;
        public short OpaqueVertexCount;
        public short OpaquePartCount;
        public byte OpaqueMaxNodesVertex;
        public byte TransparentMaxNodesVertex;
        public short ShadowCastingRigidTriangleCount;
        public GeometryClassificationEnum GeometryClassification;
        public GeometryCompressionFlags GlobalGeometrySectionInfoStructGeometryCompressionFlags;
        public GlobalGeometryCompressionInfoBlock[] EMPTYSTRING = new GlobalGeometryCompressionInfoBlock[0];
        public byte HardwareNodeCount;
        public byte NodeMapSize;
        public short SoftwarePlaneCount;
        public short TotalSubpartCont;
        public SectionLightingFlags GlobalGeometrySectionInfoStructSectionLightingFlags;
        public override int SerializedSize
        {
            get
            {
                return 40;
            }
        }
        public override int Alignment
        {
            get
            {
                return 4;
            }
        }
        public override System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> ReadFields(System.IO.BinaryReader binaryReader)
        {
            System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(base.ReadFields(binaryReader));
            this.TotalVertexCount = binaryReader.ReadInt16();
            this.TotalTriangleCount = binaryReader.ReadInt16();
            this.TotalPartCount = binaryReader.ReadInt16();
            this.ShadowCastingTriangleCount = binaryReader.ReadInt16();
            this.ShadowCastingPartCount = binaryReader.ReadInt16();
            this.OpaquePointCount = binaryReader.ReadInt16();
            this.OpaqueVertexCount = binaryReader.ReadInt16();
            this.OpaquePartCount = binaryReader.ReadInt16();
            this.OpaqueMaxNodesVertex = binaryReader.ReadByte();
            this.TransparentMaxNodesVertex = binaryReader.ReadByte();
            this.ShadowCastingRigidTriangleCount = binaryReader.ReadInt16();
            this.GeometryClassification = ((GeometryClassificationEnum)(binaryReader.ReadInt16()));
            this.GlobalGeometrySectionInfoStructGeometryCompressionFlags = ((GeometryCompressionFlags)(binaryReader.ReadInt16()));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(56));
            this.HardwareNodeCount = binaryReader.ReadByte();
            this.NodeMapSize = binaryReader.ReadByte();
            this.SoftwarePlaneCount = binaryReader.ReadInt16();
            this.TotalSubpartCont = binaryReader.ReadInt16();
            this.GlobalGeometrySectionInfoStructSectionLightingFlags = ((SectionLightingFlags)(binaryReader.ReadInt16()));
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.EMPTYSTRING = base.ReadBlockArrayData<GlobalGeometryCompressionInfoBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            queueableBinaryWriter.QueueWrite(this.EMPTYSTRING);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.Write_(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.TotalVertexCount);
            queueableBinaryWriter.Write(this.TotalTriangleCount);
            queueableBinaryWriter.Write(this.TotalPartCount);
            queueableBinaryWriter.Write(this.ShadowCastingTriangleCount);
            queueableBinaryWriter.Write(this.ShadowCastingPartCount);
            queueableBinaryWriter.Write(this.OpaquePointCount);
            queueableBinaryWriter.Write(this.OpaqueVertexCount);
            queueableBinaryWriter.Write(this.OpaquePartCount);
            queueableBinaryWriter.Write(this.OpaqueMaxNodesVertex);
            queueableBinaryWriter.Write(this.TransparentMaxNodesVertex);
            queueableBinaryWriter.Write(this.ShadowCastingRigidTriangleCount);
            queueableBinaryWriter.Write(((short)(this.GeometryClassification)));
            queueableBinaryWriter.Write(((short)(this.GlobalGeometrySectionInfoStructGeometryCompressionFlags)));
            queueableBinaryWriter.WritePointer(this.EMPTYSTRING);
            queueableBinaryWriter.Write(this.HardwareNodeCount);
            queueableBinaryWriter.Write(this.NodeMapSize);
            queueableBinaryWriter.Write(this.SoftwarePlaneCount);
            queueableBinaryWriter.Write(this.TotalSubpartCont);
            queueableBinaryWriter.Write(((short)(this.GlobalGeometrySectionInfoStructSectionLightingFlags)));
        }
        public enum GeometryClassificationEnum : short
        {
            Worldspace = 0,
            Rigid = 1,
            RigidBoned = 2,
            Skinned = 3,
            UnsupportedReimport = 4,
        }
        [System.FlagsAttribute()]
        public enum GeometryCompressionFlags : short
        {
            None = 0,
            CompressedPosition = 1,
            CompressedTexcoord = 2,
            CompressedSecondaryTexcoord = 4,
        }
        [System.FlagsAttribute()]
        public enum SectionLightingFlags : short
        {
            None = 0,
            HasLmTexcoords = 1,
            HasLmIncRad = 2,
            HasLmColors = 4,
            HasLmPrt = 8,
        }
    }
}
