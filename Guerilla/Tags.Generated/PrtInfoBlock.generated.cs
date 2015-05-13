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
    
    public partial class PrtInfoBlock : GuerillaBlock, IWriteQueueable
    {
        public short SHOrder;
        public short NumOfClusters;
        public short PcaVectorsPerCluster;
        public short NumberOfRays;
        public short NumberOfBounces;
        public short MatIndexForSbsfcScattering;
        public float LengthScale;
        public short NumberOfLodsInModel;
        private byte[] fieldpad = new byte[2];
        public PrtLodInfoBlock[] LodInfo = new PrtLodInfoBlock[0];
        public PrtClusterBasisBlock[] ClusterBasis = new PrtClusterBasisBlock[0];
        public PrtRawPcaDataBlock[] RawPcaData = new PrtRawPcaDataBlock[0];
        public PrtVertexBuffersBlock[] VertexBuffers = new PrtVertexBuffersBlock[0];
        public GlobalGeometryBlockInfoStructBlock GeometryBlockInfo = new GlobalGeometryBlockInfoStructBlock();
        public override int SerializedSize
        {
            get
            {
                return 88;
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
            this.SHOrder = binaryReader.ReadInt16();
            this.NumOfClusters = binaryReader.ReadInt16();
            this.PcaVectorsPerCluster = binaryReader.ReadInt16();
            this.NumberOfRays = binaryReader.ReadInt16();
            this.NumberOfBounces = binaryReader.ReadInt16();
            this.MatIndexForSbsfcScattering = binaryReader.ReadInt16();
            this.LengthScale = binaryReader.ReadSingle();
            this.NumberOfLodsInModel = binaryReader.ReadInt16();
            this.fieldpad = binaryReader.ReadBytes(2);
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(12));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(4));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(4));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(32));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.GeometryBlockInfo.ReadFields(binaryReader)));
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.LodInfo = base.ReadBlockArrayData<PrtLodInfoBlock>(binaryReader, pointerQueue.Dequeue());
            this.ClusterBasis = base.ReadBlockArrayData<PrtClusterBasisBlock>(binaryReader, pointerQueue.Dequeue());
            this.RawPcaData = base.ReadBlockArrayData<PrtRawPcaDataBlock>(binaryReader, pointerQueue.Dequeue());
            this.VertexBuffers = base.ReadBlockArrayData<PrtVertexBuffersBlock>(binaryReader, pointerQueue.Dequeue());
            this.GeometryBlockInfo.ReadInstances(binaryReader, pointerQueue);
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            queueableBinaryWriter.QueueWrite(this.LodInfo);
            queueableBinaryWriter.QueueWrite(this.ClusterBasis);
            queueableBinaryWriter.QueueWrite(this.RawPcaData);
            queueableBinaryWriter.QueueWrite(this.VertexBuffers);
            this.GeometryBlockInfo.QueueWrites(queueableBinaryWriter);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.Write_(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.SHOrder);
            queueableBinaryWriter.Write(this.NumOfClusters);
            queueableBinaryWriter.Write(this.PcaVectorsPerCluster);
            queueableBinaryWriter.Write(this.NumberOfRays);
            queueableBinaryWriter.Write(this.NumberOfBounces);
            queueableBinaryWriter.Write(this.MatIndexForSbsfcScattering);
            queueableBinaryWriter.Write(this.LengthScale);
            queueableBinaryWriter.Write(this.NumberOfLodsInModel);
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.WritePointer(this.LodInfo);
            queueableBinaryWriter.WritePointer(this.ClusterBasis);
            queueableBinaryWriter.WritePointer(this.RawPcaData);
            queueableBinaryWriter.WritePointer(this.VertexBuffers);
            this.GeometryBlockInfo.Write_(queueableBinaryWriter);
        }
    }
}
