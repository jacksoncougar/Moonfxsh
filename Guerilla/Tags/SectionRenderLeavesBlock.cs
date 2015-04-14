// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SectionRenderLeavesBlock : SectionRenderLeavesBlockBase
    {
        public  SectionRenderLeavesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class SectionRenderLeavesBlockBase  : IGuerilla
    {
        internal NodeRenderLeavesBlock[] nodeRenderLeaves;
        internal  SectionRenderLeavesBlockBase(BinaryReader binaryReader)
        {
            nodeRenderLeaves = Guerilla.ReadBlockArray<NodeRenderLeavesBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                Guerilla.WriteBlockArray<NodeRenderLeavesBlock>(binaryWriter, nodeRenderLeaves, nextAddress);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
