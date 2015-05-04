// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class SectionRenderLeavesBlock : SectionRenderLeavesBlockBase
    {
        public  SectionRenderLeavesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  SectionRenderLeavesBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class SectionRenderLeavesBlockBase : GuerillaBlock
    {
        internal NodeRenderLeavesBlock[] nodeRenderLeaves;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  SectionRenderLeavesBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            nodeRenderLeaves = Guerilla.ReadBlockArray<NodeRenderLeavesBlock>(binaryReader);
        }
        public  SectionRenderLeavesBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            nodeRenderLeaves = Guerilla.ReadBlockArray<NodeRenderLeavesBlock>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<NodeRenderLeavesBlock>(binaryWriter, nodeRenderLeaves, nextAddress);
                return nextAddress;
            }
        }
    };
}
