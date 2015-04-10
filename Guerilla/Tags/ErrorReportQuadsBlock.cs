using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ErrorReportQuadsBlock : ErrorReportQuadsBlockBase
    {
        public  ErrorReportQuadsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 84)]
    public class ErrorReportQuadsBlockBase
    {
        internal Points[] points;
        internal NodeWeights[] nodeWeights;
        internal  ErrorReportQuadsBlockBase(BinaryReader binaryReader)
        {
            this.points = new []{ new Points(binaryReader), new Points(binaryReader), new Points(binaryReader), new Points(binaryReader),  };
            this.nodeWeights = new []{ new NodeWeights(binaryReader), new NodeWeights(binaryReader), new NodeWeights(binaryReader), new NodeWeights(binaryReader),  };
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
        public class Points
        {
            internal OpenTK.Vector3 position;
            internal NodeIndices[] nodeIndices;
            internal  Points(BinaryReader binaryReader)
            {
                this.position = binaryReader.ReadVector3();
                this.nodeIndices = new []{ new NodeIndices(binaryReader), new NodeIndices(binaryReader), new NodeIndices(binaryReader), new NodeIndices(binaryReader),  };
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
