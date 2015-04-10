// ReSharper disable All
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
        public  RenderModelRegionBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  RenderModelRegionBlockBase(System.IO.BinaryReader binaryReader)
        {
            name = binaryReader.ReadStringID();
            nodeMapOffsetOLD = binaryReader.ReadInt16();
            nodeMapSizeOLD = binaryReader.ReadInt16();
            ReadRenderModelPermutationBlockArray(binaryReader);
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
        internal  virtual RenderModelPermutationBlock[] ReadRenderModelPermutationBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(RenderModelPermutationBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new RenderModelPermutationBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new RenderModelPermutationBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteRenderModelPermutationBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write(nodeMapOffsetOLD);
                binaryWriter.Write(nodeMapSizeOLD);
                WriteRenderModelPermutationBlockArray(binaryWriter);
            }
        }
    };
}
