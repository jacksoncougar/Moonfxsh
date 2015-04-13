using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class RenderModelRegionBlock : RenderModelRegionBlockBase
    {
        public  RenderModelRegionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class RenderModelRegionBlockBase
    {
        internal Moonfish.Tags.StringID name;
        internal short nodeMapOffsetOLD;
        internal short nodeMapSizeOLD;
        internal RenderModelPermutationBlock[] permutations;
        internal  RenderModelRegionBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            this.nodeMapOffsetOLD = binaryReader.ReadInt16();
            this.nodeMapSizeOLD = binaryReader.ReadInt16();
            this.permutations = ReadRenderModelPermutationBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
        }
        internal  virtual RenderModelPermutationBlock[] ReadRenderModelPermutationBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(RenderModelPermutationBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new RenderModelPermutationBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new RenderModelPermutationBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
