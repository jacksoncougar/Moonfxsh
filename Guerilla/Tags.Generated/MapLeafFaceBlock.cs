// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class MapLeafFaceBlock : MapLeafFaceBlockBase
    {
        public  MapLeafFaceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  MapLeafFaceBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class MapLeafFaceBlockBase : GuerillaBlock
    {
        internal int nodeIndex;
        internal MapLeafFaceVertexBlock[] vertices;
        
        public override int SerializedSize{get { return 12; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  MapLeafFaceBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            nodeIndex = binaryReader.ReadInt32();
            vertices = Guerilla.ReadBlockArray<MapLeafFaceVertexBlock>(binaryReader);
        }
        public  MapLeafFaceBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(nodeIndex);
                nextAddress = Guerilla.WriteBlockArray<MapLeafFaceVertexBlock>(binaryWriter, vertices, nextAddress);
                return nextAddress;
            }
        }
    };
}
