// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class RenderModelNodeMapBlockOLD : RenderModelNodeMapBlockOLDBase
    {
        public  RenderModelNodeMapBlockOLD(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  RenderModelNodeMapBlockOLD(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 1, Alignment = 4)]
    public class RenderModelNodeMapBlockOLDBase : GuerillaBlock
    {
        internal byte nodeIndex;
        
        public override int SerializedSize{get { return 1; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  RenderModelNodeMapBlockOLDBase(BinaryReader binaryReader): base(binaryReader)
        {
            nodeIndex = binaryReader.ReadByte();
        }
        public  RenderModelNodeMapBlockOLDBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            nodeIndex = binaryReader.ReadByte();
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
}
