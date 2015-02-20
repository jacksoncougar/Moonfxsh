using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class RenderModelPermutationBlock : RenderModelPermutationBlockBase
    {
        public  RenderModelPermutationBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class RenderModelPermutationBlockBase
    {
        internal Moonfish.Tags.StringID name;
        internal short l1SectionIndexSuperLow;
        internal short l2SectionIndexLow;
        internal short l3SectionIndexMedium;
        internal short l4SectionIndexHigh;
        internal short l5SectionIndexSuperHigh;
        internal short l6SectionIndexHollywood;
        internal  RenderModelPermutationBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            this.l1SectionIndexSuperLow = binaryReader.ReadInt16();
            this.l2SectionIndexLow = binaryReader.ReadInt16();
            this.l3SectionIndexMedium = binaryReader.ReadInt16();
            this.l4SectionIndexHigh = binaryReader.ReadInt16();
            this.l5SectionIndexSuperHigh = binaryReader.ReadInt16();
            this.l6SectionIndexHollywood = binaryReader.ReadInt16();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
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
    };
}
