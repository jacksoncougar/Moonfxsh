// ReSharper disable All
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
        public  RenderModelPermutationBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  RenderModelPermutationBlockBase(System.IO.BinaryReader binaryReader)
        {
            name = binaryReader.ReadStringID();
            l1SectionIndexSuperLow = binaryReader.ReadInt16();
            l2SectionIndexLow = binaryReader.ReadInt16();
            l3SectionIndexMedium = binaryReader.ReadInt16();
            l4SectionIndexHigh = binaryReader.ReadInt16();
            l5SectionIndexSuperHigh = binaryReader.ReadInt16();
            l6SectionIndexHollywood = binaryReader.ReadInt16();
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
                binaryWriter.Write(name);
                binaryWriter.Write(l1SectionIndexSuperLow);
                binaryWriter.Write(l2SectionIndexLow);
                binaryWriter.Write(l3SectionIndexMedium);
                binaryWriter.Write(l4SectionIndexHigh);
                binaryWriter.Write(l5SectionIndexSuperHigh);
                binaryWriter.Write(l6SectionIndexHollywood);
            }
        }
    };
}
