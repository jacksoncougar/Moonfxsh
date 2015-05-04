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
    public partial class PrtInfoBlock : PrtInfoBlockBase
    {
        public PrtInfoBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 88, Alignment = 4)]
    public class PrtInfoBlockBase : GuerillaBlock
    {
        internal short sHOrder;
        internal short numOfClusters;
        internal short pcaVectorsPerCluster;
        internal short numberOfRays;
        internal short numberOfBounces;
        internal short matIndexForSbsfcScattering;
        internal float lengthScale;
        internal short numberOfLodsInModel;
        internal byte[] invalidName_;
        internal PrtLodInfoBlock[] lodInfo;
        internal PrtClusterBasisBlock[] clusterBasis;
        internal PrtRawPcaDataBlock[] rawPcaData;
        internal PrtVertexBuffersBlock[] vertexBuffers;
        internal GlobalGeometryBlockInfoStructBlock geometryBlockInfo;

        public override int SerializedSize
        {
            get { return 88; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public PrtInfoBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            sHOrder = binaryReader.ReadInt16();
            numOfClusters = binaryReader.ReadInt16();
            pcaVectorsPerCluster = binaryReader.ReadInt16();
            numberOfRays = binaryReader.ReadInt16();
            numberOfBounces = binaryReader.ReadInt16();
            matIndexForSbsfcScattering = binaryReader.ReadInt16();
            lengthScale = binaryReader.ReadSingle();
            numberOfLodsInModel = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            blamPointers.Enqueue(ReadBlockArrayPointer<PrtLodInfoBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<PrtClusterBasisBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<PrtRawPcaDataBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<PrtVertexBuffersBlock>(binaryReader));
            geometryBlockInfo = new GlobalGeometryBlockInfoStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(geometryBlockInfo.ReadFields(binaryReader)));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            lodInfo = ReadBlockArrayData<PrtLodInfoBlock>(binaryReader, blamPointers.Dequeue());
            clusterBasis = ReadBlockArrayData<PrtClusterBasisBlock>(binaryReader, blamPointers.Dequeue());
            rawPcaData = ReadBlockArrayData<PrtRawPcaDataBlock>(binaryReader, blamPointers.Dequeue());
            vertexBuffers = ReadBlockArrayData<PrtVertexBuffersBlock>(binaryReader, blamPointers.Dequeue());
            geometryBlockInfo.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(sHOrder);
                binaryWriter.Write(numOfClusters);
                binaryWriter.Write(pcaVectorsPerCluster);
                binaryWriter.Write(numberOfRays);
                binaryWriter.Write(numberOfBounces);
                binaryWriter.Write(matIndexForSbsfcScattering);
                binaryWriter.Write(lengthScale);
                binaryWriter.Write(numberOfLodsInModel);
                binaryWriter.Write(invalidName_, 0, 2);
                nextAddress = Guerilla.WriteBlockArray<PrtLodInfoBlock>(binaryWriter, lodInfo, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<PrtClusterBasisBlock>(binaryWriter, clusterBasis, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<PrtRawPcaDataBlock>(binaryWriter, rawPcaData, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<PrtVertexBuffersBlock>(binaryWriter, vertexBuffers, nextAddress);
                geometryBlockInfo.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}