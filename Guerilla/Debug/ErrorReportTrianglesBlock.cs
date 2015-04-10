// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ErrorReportTrianglesBlock : ErrorReportTrianglesBlockBase
    {
        public  ErrorReportTrianglesBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 71)]
    public class ErrorReportTrianglesBlockBase
    {
        internal Points[] points;
        internal NodeWeights[] nodeWeights;
        internal  ErrorReportTrianglesBlockBase(System.IO.BinaryReader binaryReader)
        {
            points = new []{ new Points(binaryReader), new Points(binaryReader), new Points(binaryReader),  };
            nodeWeights = new []{ new NodeWeights(binaryReader), new NodeWeights(binaryReader), new NodeWeights(binaryReader), new NodeWeights(binaryReader),  };
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
                points[0].Write(binaryWriter);
                points[1].Write(binaryWriter);
                points[2].Write(binaryWriter);
                nodeWeights[0].Write(binaryWriter);
                nodeWeights[1].Write(binaryWriter);
                nodeWeights[2].Write(binaryWriter);
                nodeWeights[3].Write(binaryWriter);
            }
        }
        public class Points
        {
            internal OpenTK.Vector3 position;
            internal NodeIndices[] nodeIndices;
            internal  Points(System.IO.BinaryReader binaryReader)
            {
                position = binaryReader.ReadVector3();
                nodeIndices = new []{ new NodeIndices(binaryReader), new NodeIndices(binaryReader), new NodeIndices(binaryReader), new NodeIndices(binaryReader),  };
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
                    nodeIndices[0].Write(binaryWriter);
                    nodeIndices[1].Write(binaryWriter);
                    nodeIndices[2].Write(binaryWriter);
                    nodeIndices[3].Write(binaryWriter);
                }
            }
            public class NodeIndices
            {
                internal byte nodeIndex;
                internal  NodeIndices(System.IO.BinaryReader binaryReader)
                {
                    nodeIndex = binaryReader.ReadByte();
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
                        binaryWriter.Write(nodeIndex);
                    }
                }
            };
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
    };
}
