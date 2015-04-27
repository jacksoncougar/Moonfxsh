// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class SectorVertexBlock : SectorVertexBlockBase
    {
        public  SectorVertexBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  SectorVertexBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class SectorVertexBlockBase : GuerillaBlock
    {
        internal OpenTK.Vector3 point;
        
        public override int SerializedSize{get { return 12; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  SectorVertexBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            point = binaryReader.ReadVector3();
        }
        public  SectorVertexBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            point = binaryReader.ReadVector3();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(point);
                return nextAddress;
            }
        }
    };
}
