// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ErrorReportQuadsBlock : ErrorReportQuadsBlockBase
    {
        public  ErrorReportQuadsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ErrorReportQuadsBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 144, Alignment = 4)]
    public class ErrorReportQuadsBlockBase : GuerillaBlock
    {
        internal Points[] points;
        internal OpenTK.Vector4 color;
        
        public override int SerializedSize{get { return 144; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ErrorReportQuadsBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            points = new []{ new Points(binaryReader), new Points(binaryReader), new Points(binaryReader), new Points(binaryReader),  };
            color = binaryReader.ReadVector4();
        }
        public  ErrorReportQuadsBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                points[0].Write(binaryWriter);
                points[1].Write(binaryWriter);
                points[2].Write(binaryWriter);
                points[3].Write(binaryWriter);
                binaryWriter.Write(color);
                return nextAddress;
            }
        }
        [LayoutAttribute(Size = 32, Alignment = 1)]
        public class Points : GuerillaBlock
        {
            internal OpenTK.Vector3 position;
            internal NodeIndices[] nodeIndices;
            internal NodeWeights[] nodeWeights;
            
            public override int SerializedSize{get { return 32; }}
            
            
            public override int Alignment{get { return 1; }}
            
            public  Points(BinaryReader binaryReader): base(binaryReader)
            {
                position = binaryReader.ReadVector3();
                nodeIndices = new []{ new NodeIndices(binaryReader), new NodeIndices(binaryReader), new NodeIndices(binaryReader), new NodeIndices(binaryReader),  };
                nodeWeights = new []{ new NodeWeights(binaryReader), new NodeWeights(binaryReader), new NodeWeights(binaryReader), new NodeWeights(binaryReader),  };
            }
            public  Points(): base()
            {
                
            }
            public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
            {
                using(binaryWriter.BaseStream.Pin())
                {
                    binaryWriter.Write(position);
                    nodeIndices[0].Write(binaryWriter);
                    nodeIndices[1].Write(binaryWriter);
                    nodeIndices[2].Write(binaryWriter);
                    nodeIndices[3].Write(binaryWriter);
                    nodeWeights[0].Write(binaryWriter);
                    nodeWeights[1].Write(binaryWriter);
                    nodeWeights[2].Write(binaryWriter);
                    nodeWeights[3].Write(binaryWriter);
                    return nextAddress;
                }
            }
            [LayoutAttribute(Size = 1, Alignment = 1)]
            public class NodeIndices : GuerillaBlock
            {
                internal byte nodeIndex;
                
                public override int SerializedSize{get { return 1; }}
                
                
                public override int Alignment{get { return 1; }}
                
                public  NodeIndices(BinaryReader binaryReader): base(binaryReader)
                {
                    nodeIndex = binaryReader.ReadByte();
                }
                public  NodeIndices(): base()
                {
                    
                }
                public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
                {
                    using(binaryWriter.BaseStream.Pin())
                    {
                        binaryWriter.Write(nodeIndex);
                        return nextAddress;
                    }
                }
            };
            [LayoutAttribute(Size = 4, Alignment = 1)]
            public class NodeWeights : GuerillaBlock
            {
                internal float nodeWeight;
                
                public override int SerializedSize{get { return 4; }}
                
                
                public override int Alignment{get { return 1; }}
                
                public  NodeWeights(BinaryReader binaryReader): base(binaryReader)
                {
                    nodeWeight = binaryReader.ReadSingle();
                }
                public  NodeWeights(): base()
                {
                    
                }
                public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
                {
                    using(binaryWriter.BaseStream.Pin())
                    {
                        binaryWriter.Write(nodeWeight);
                        return nextAddress;
                    }
                }
            };
        };
    };
}
