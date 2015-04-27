// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class MapLeafFaceVertexBlock : MapLeafFaceVertexBlockBase
    {
        public  MapLeafFaceVertexBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  MapLeafFaceVertexBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class MapLeafFaceVertexBlockBase : GuerillaBlock
    {
        internal OpenTK.Vector3 vertex;
        
        public override int SerializedSize{get { return 12; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  MapLeafFaceVertexBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            vertex = binaryReader.ReadVector3();
        }
        public  MapLeafFaceVertexBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(vertex);
                return nextAddress;
            }
        }
    };
}
