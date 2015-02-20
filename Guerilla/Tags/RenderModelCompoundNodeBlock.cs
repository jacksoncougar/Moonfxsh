using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class RenderModelCompoundNodeBlock : RenderModelCompoundNodeBlockBase
    {
        public  RenderModelCompoundNodeBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class RenderModelCompoundNodeBlockBase
    {
        internal NodeIndices[] nodeIndices;
        internal NodeWeights[] nodeWeights;
        internal  RenderModelCompoundNodeBlockBase(BinaryReader binaryReader)
        {
            this.nodeIndices = new []{ new NodeIndices(binaryReader), new NodeIndices(binaryReader), new NodeIndices(binaryReader), new NodeIndices(binaryReader),  };
            this.nodeWeights = new []{ new NodeWeights(binaryReader), new NodeWeights(binaryReader), new NodeWeights(binaryReader),  };
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
        public class NodeIndices
        {
            internal byte nodeIndex;
            internal  NodeIndices(BinaryReader binaryReader)
            {
                this.nodeIndex = binaryReader.ReadByte();
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
    };
}
