using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class RenderModelSectionGroupBlock : RenderModelSectionGroupBlockBase
    {
        public  RenderModelSectionGroupBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12)]
    public class RenderModelSectionGroupBlockBase
    {
        internal DetailLevels detailLevels;
        internal byte[] invalidName_;
        internal RenderModelCompoundNodeBlock[] compoundNodes;
        internal  RenderModelSectionGroupBlockBase(BinaryReader binaryReader)
        {
            this.detailLevels = (DetailLevels)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.compoundNodes = ReadRenderModelCompoundNodeBlockArray(binaryReader);
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
        internal  virtual RenderModelCompoundNodeBlock[] ReadRenderModelCompoundNodeBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(RenderModelCompoundNodeBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new RenderModelCompoundNodeBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new RenderModelCompoundNodeBlock(binaryReader);
                }
            }
            return array;
        }
        internal enum DetailLevels : short
        {
            L1SuperLow = 1,
            L2Low = 2,
            L3Medium = 4,
            L4High = 8,
            L5SuperHigh = 16,
            L6Hollywood = 32,
        };
    };
}
