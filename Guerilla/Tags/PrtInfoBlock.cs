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
    [LayoutAttribute(Size = 88)]
    public class PrtInfoBlockBase
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
            this.sHOrder = binaryReader.ReadInt16();
            this.numOfClusters = binaryReader.ReadInt16();
            this.pcaVectorsPerCluster = binaryReader.ReadInt16();
            this.numberOfRays = binaryReader.ReadInt16();
            this.numberOfBounces = binaryReader.ReadInt16();
            this.matIndexForSbsfcScattering = binaryReader.ReadInt16();
            this.lengthScale = binaryReader.ReadSingle();
            this.numberOfLodsInModel = binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.lodInfo = ReadPrtLodInfoBlockArray(binaryReader);
            this.clusterBasis = ReadPrtClusterBasisBlockArray(binaryReader);
            this.rawPcaData = ReadPrtRawPcaDataBlockArray(binaryReader);
            this.vertexBuffers = ReadPrtVertexBuffersBlockArray(binaryReader);
            this.geometryBlockInfo = new GlobalGeometryBlockInfoStructBlock(binaryReader);
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
        internal  virtual PrtLodInfoBlock[] ReadPrtLodInfoBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PrtLodInfoBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PrtLodInfoBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PrtLodInfoBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PrtClusterBasisBlock[] ReadPrtClusterBasisBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PrtClusterBasisBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PrtClusterBasisBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PrtClusterBasisBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PrtRawPcaDataBlock[] ReadPrtRawPcaDataBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PrtRawPcaDataBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PrtRawPcaDataBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PrtRawPcaDataBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PrtVertexBuffersBlock[] ReadPrtVertexBuffersBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PrtVertexBuffersBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PrtVertexBuffersBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PrtVertexBuffersBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
