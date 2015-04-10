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
        public  PrtInfoBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  PrtInfoBlockBase(System.IO.BinaryReader binaryReader)
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
            ReadPrtLodInfoBlockArray(binaryReader);
            ReadPrtClusterBasisBlockArray(binaryReader);
            ReadPrtRawPcaDataBlockArray(binaryReader);
            ReadPrtVertexBuffersBlockArray(binaryReader);
            geometryBlockInfo = new GlobalGeometryBlockInfoStructBlock(binaryReader);
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
        internal  virtual PrtLodInfoBlock[] ReadPrtLodInfoBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual PrtClusterBasisBlock[] ReadPrtClusterBasisBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual PrtRawPcaDataBlock[] ReadPrtRawPcaDataBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual PrtVertexBuffersBlock[] ReadPrtVertexBuffersBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WritePrtLodInfoBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WritePrtClusterBasisBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WritePrtRawPcaDataBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WritePrtVertexBuffersBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
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
                WritePrtLodInfoBlockArray(binaryWriter);
                WritePrtClusterBasisBlockArray(binaryWriter);
                WritePrtRawPcaDataBlockArray(binaryWriter);
                WritePrtVertexBuffersBlockArray(binaryWriter);
                geometryBlockInfo.Write(binaryWriter);
            }
        }
    };
}
