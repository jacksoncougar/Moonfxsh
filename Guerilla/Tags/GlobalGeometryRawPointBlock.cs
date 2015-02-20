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
        public  GlobalGeometryRawPointBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  GlobalGeometryRawPointBlockBase(BinaryReader binaryReader)
        {
            this.position = binaryReader.ReadVector3();
            this.nodeIndicesOLD = new []{ new NodeIndicesOLD(binaryReader), new NodeIndicesOLD(binaryReader), new NodeIndicesOLD(binaryReader), new NodeIndicesOLD(binaryReader),  };
            this.nodeWeights = new []{ new NodeWeights(binaryReader), new NodeWeights(binaryReader), new NodeWeights(binaryReader), new NodeWeights(binaryReader),  };
            this.nodeIndicesNEW = new []{ new NodeIndicesNEW(binaryReader), new NodeIndicesNEW(binaryReader), new NodeIndicesNEW(binaryReader), new NodeIndicesNEW(binaryReader),  };
            this.useNewNodeIndices = binaryReader.ReadInt32();
            this.adjustedCompoundNodeIndex = binaryReader.ReadInt32();
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
        public class NodeIndicesOLD
        {
            internal int nodeIndexOLD;
            internal  NodeIndicesOLD(BinaryReader binaryReader)
            {
                this.nodeIndexOLD = binaryReader.ReadInt32();
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
        };
        public class NodeWeights
        {
            internal float nodeWeight;
            internal  NodeWeights(BinaryReader binaryReader)
            {
                this.nodeWeight = binaryReader.ReadSingle();
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
        };
        public class NodeIndicesNEW
        {
            internal int nodeIndexNEW;
            internal  NodeIndicesNEW(BinaryReader binaryReader)
            {
                this.nodeIndexNEW = binaryReader.ReadInt32();
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
        };
    };
}
