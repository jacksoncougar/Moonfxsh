// ReSharper disable All
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
        public  RenderModelSectionGroupBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12)]
    public class RenderModelSectionGroupBlockBase
    {
        internal DetailLevels detailLevels;
        internal byte[] invalidName_;
        internal RenderModelCompoundNodeBlock[] compoundNodes;
        internal  RenderModelSectionGroupBlockBase(System.IO.BinaryReader binaryReader)
        {
            detailLevels = (DetailLevels)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            ReadRenderModelCompoundNodeBlockArray(binaryReader);
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
        internal  virtual RenderModelCompoundNodeBlock[] ReadRenderModelCompoundNodeBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteRenderModelCompoundNodeBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)detailLevels);
                binaryWriter.Write(invalidName_, 0, 2);
                WriteRenderModelCompoundNodeBlockArray(binaryWriter);
            }
        }
        [FlagsAttribute]
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
