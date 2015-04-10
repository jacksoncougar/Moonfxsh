// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class EdgesBlock : EdgesBlockBase
    {
        public  EdgesBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12)]
    public class EdgesBlockBase
    {
        internal short startVertex;
        internal short endVertex;
        internal short forwardEdge;
        internal short reverseEdge;
        internal short leftSurface;
        internal short rightSurface;
        internal  EdgesBlockBase(System.IO.BinaryReader binaryReader)
        {
            startVertex = binaryReader.ReadInt16();
            endVertex = binaryReader.ReadInt16();
            forwardEdge = binaryReader.ReadInt16();
            reverseEdge = binaryReader.ReadInt16();
            leftSurface = binaryReader.ReadInt16();
            rightSurface = binaryReader.ReadInt16();
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
                binaryWriter.Write(startVertex);
                binaryWriter.Write(endVertex);
                binaryWriter.Write(forwardEdge);
                binaryWriter.Write(reverseEdge);
                binaryWriter.Write(leftSurface);
                binaryWriter.Write(rightSurface);
            }
        }
    };
}
