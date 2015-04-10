// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class PixelShaderPermutationNewBlock : PixelShaderPermutationNewBlockBase
    {
        public  PixelShaderPermutationNewBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 6)]
    public class PixelShaderPermutationNewBlockBase
    {
        internal short enumIndex;
        internal short flags;
        internal TagBlockIndexStructBlock combiners;
        internal  PixelShaderPermutationNewBlockBase(System.IO.BinaryReader binaryReader)
        {
            enumIndex = binaryReader.ReadInt16();
            flags = binaryReader.ReadInt16();
            combiners = new TagBlockIndexStructBlock(binaryReader);
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
                binaryWriter.Write(enumIndex);
                binaryWriter.Write(flags);
                combiners.Write(binaryWriter);
            }
        }
    };
}
