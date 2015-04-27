// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class EdgesBlock : EdgesBlockBase
    {
        public  EdgesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  EdgesBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class EdgesBlockBase : GuerillaBlock
    {
        internal short startVertex;
        internal short endVertex;
        internal short forwardEdge;
        internal short reverseEdge;
        internal short leftSurface;
        internal short rightSurface;
        
        public override int SerializedSize{get { return 12; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  EdgesBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            startVertex = binaryReader.ReadInt16();
            endVertex = binaryReader.ReadInt16();
            forwardEdge = binaryReader.ReadInt16();
            reverseEdge = binaryReader.ReadInt16();
            leftSurface = binaryReader.ReadInt16();
            rightSurface = binaryReader.ReadInt16();
        }
        public  EdgesBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            startVertex = binaryReader.ReadInt16();
            endVertex = binaryReader.ReadInt16();
            forwardEdge = binaryReader.ReadInt16();
            reverseEdge = binaryReader.ReadInt16();
            leftSurface = binaryReader.ReadInt16();
            rightSurface = binaryReader.ReadInt16();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(startVertex);
                binaryWriter.Write(endVertex);
                binaryWriter.Write(forwardEdge);
                binaryWriter.Write(reverseEdge);
                binaryWriter.Write(leftSurface);
                binaryWriter.Write(rightSurface);
                return nextAddress;
            }
        }
    };
}
