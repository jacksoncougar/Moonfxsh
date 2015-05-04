// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class RenderModelRegionBlock : RenderModelRegionBlockBase
    {
        public  RenderModelRegionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  RenderModelRegionBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class RenderModelRegionBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent name;
        internal short nodeMapOffsetOLD;
        internal short nodeMapSizeOLD;
        internal RenderModelPermutationBlock[] permutations;
        
        public override int SerializedSize{get { return 16; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  RenderModelRegionBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            name = binaryReader.ReadStringID();
            nodeMapOffsetOLD = binaryReader.ReadInt16();
            nodeMapSizeOLD = binaryReader.ReadInt16();
            permutations = Guerilla.ReadBlockArray<RenderModelPermutationBlock>(binaryReader);
        }
        public  RenderModelRegionBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            name = binaryReader.ReadStringID();
            nodeMapOffsetOLD = binaryReader.ReadInt16();
            nodeMapSizeOLD = binaryReader.ReadInt16();
            permutations = Guerilla.ReadBlockArray<RenderModelPermutationBlock>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write(nodeMapOffsetOLD);
                binaryWriter.Write(nodeMapSizeOLD);
                nextAddress = Guerilla.WriteBlockArray<RenderModelPermutationBlock>(binaryWriter, permutations, nextAddress);
                return nextAddress;
            }
        }
    };
}
