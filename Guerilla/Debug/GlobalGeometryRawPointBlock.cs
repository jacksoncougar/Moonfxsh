// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class GlobalGeometryRawPointBlock : GlobalGeometryRawPointBlockBase
    {
        public  GlobalGeometryRawPointBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 68)]
    public class GlobalGeometryRawPointBlockBase
    {
        internal OpenTK.Vector3 position;
        internal NodeIndicesOLD[] nodeIndicesOLD;
        internal NodeWeights[] nodeWeights;
        internal NodeIndicesNEW[] nodeIndicesNEW;
        internal int useNewNodeIndices;
        internal int adjustedCompoundNodeIndex;
        internal  GlobalGeometryRawPointBlockBase(System.IO.BinaryReader binaryReader)
        {
            position = binaryReader.ReadVector3();
            nodeIndicesOLD = new []{ new NodeIndicesOLD(binaryReader), new NodeIndicesOLD(binaryReader), new NodeIndicesOLD(binaryReader), new NodeIndicesOLD(binaryReader),  };
            nodeWeights = new []{ new NodeWeights(binaryReader), new NodeWeights(binaryReader), new NodeWeights(binaryReader), new NodeWeights(binaryReader),  };
            nodeIndicesNEW = new []{ new NodeIndicesNEW(binaryReader), new NodeIndicesNEW(binaryReader), new NodeIndicesNEW(binaryReader), new NodeIndicesNEW(binaryReader),  };
            useNewNodeIndices = binaryReader.ReadInt32();
            adjustedCompoundNodeIndex = binaryReader.ReadInt32();
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(position);
                nodeIndicesOLD[0].Write(binaryWriter);
                nodeIndicesOLD[1].Write(binaryWriter);
                nodeIndicesOLD[2].Write(binaryWriter);
                nodeIndicesOLD[3].Write(binaryWriter);
                nodeWeights[0].Write(binaryWriter);
                nodeWeights[1].Write(binaryWriter);
                nodeWeights[2].Write(binaryWriter);
                nodeWeights[3].Write(binaryWriter);
                nodeIndicesNEW[0].Write(binaryWriter);
                nodeIndicesNEW[1].Write(binaryWriter);
                nodeIndicesNEW[2].Write(binaryWriter);
                nodeIndicesNEW[3].Write(binaryWriter);
                binaryWriter.Write(useNewNodeIndices);
                binaryWriter.Write(adjustedCompoundNodeIndex);
            }
        }
        public class NodeIndicesOLD
        {
            internal int nodeIndexOLD;
            internal  NodeIndicesOLD(System.IO.BinaryReader binaryReader)
            {
                nodeIndexOLD = binaryReader.ReadInt32();
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
            internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
            {
                
            }
            public void Write(System.IO.BinaryWriter binaryWriter)
            {
                using(binaryWriter.BaseStream.Pin())
                {
                    binaryWriter.Write(nodeIndexOLD);
                }
            }
        };
        public class NodeWeights
        {
            internal float nodeWeight;
            internal  NodeWeights(System.IO.BinaryReader binaryReader)
            {
                nodeWeight = binaryReader.ReadSingle();
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
            internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
            {
                
            }
            public void Write(System.IO.BinaryWriter binaryWriter)
            {
                using(binaryWriter.BaseStream.Pin())
                {
                    binaryWriter.Write(nodeWeight);
                }
            }
        };
        public class NodeIndicesNEW
        {
            internal int nodeIndexNEW;
            internal  NodeIndicesNEW(System.IO.BinaryReader binaryReader)
            {
                nodeIndexNEW = binaryReader.ReadInt32();
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
            internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
            {
                
            }
            public void Write(System.IO.BinaryWriter binaryWriter)
            {
                using(binaryWriter.BaseStream.Pin())
                {
                    binaryWriter.Write(nodeIndexNEW);
                }
            }
        };
    };
}
