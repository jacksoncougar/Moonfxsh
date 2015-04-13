// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class PrtInfoBlock : PrtInfoBlockBase
    {
        public  PrtInfoBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 88, Alignment = 4)]
    public class PrtInfoBlockBase  : IGuerilla
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
        internal  PrtInfoBlockBase(BinaryReader binaryReader)
        {
            sHOrder = binaryReader.ReadInt16();
            numOfClusters = binaryReader.ReadInt16();
            pcaVectorsPerCluster = binaryReader.ReadInt16();
            numberOfRays = binaryReader.ReadInt16();
            numberOfBounces = binaryReader.ReadInt16();
            matIndexForSbsfcScattering = binaryReader.ReadInt16();
            lengthScale = binaryReader.ReadSingle();
            numberOfLodsInModel = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            lodInfo = Guerilla.ReadBlockArray<PrtLodInfoBlock>(binaryReader);
            clusterBasis = Guerilla.ReadBlockArray<PrtClusterBasisBlock>(binaryReader);
            rawPcaData = Guerilla.ReadBlockArray<PrtRawPcaDataBlock>(binaryReader);
            vertexBuffers = Guerilla.ReadBlockArray<PrtVertexBuffersBlock>(binaryReader);
            geometryBlockInfo = new GlobalGeometryBlockInfoStructBlock(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
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
                Guerilla.WriteBlockArray<PrtLodInfoBlock>(binaryWriter, lodInfo, nextAddress);
                Guerilla.WriteBlockArray<PrtClusterBasisBlock>(binaryWriter, clusterBasis, nextAddress);
                Guerilla.WriteBlockArray<PrtRawPcaDataBlock>(binaryWriter, rawPcaData, nextAddress);
                Guerilla.WriteBlockArray<PrtVertexBuffersBlock>(binaryWriter, vertexBuffers, nextAddress);
                geometryBlockInfo.Write(binaryWriter);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
