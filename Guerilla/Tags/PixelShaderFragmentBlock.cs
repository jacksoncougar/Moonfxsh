// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class PixelShaderFragmentBlock : PixelShaderFragmentBlockBase
    {
        public  PixelShaderFragmentBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 3, Alignment = 4)]
    public class PixelShaderFragmentBlockBase  : IGuerilla
    {
        internal byte switchParameterIndex;
        internal TagBlockIndexStructBlock permutationsIndex;
        internal  PixelShaderFragmentBlockBase(BinaryReader binaryReader)
        {
            switchParameterIndex = binaryReader.ReadByte();
            permutationsIndex = new TagBlockIndexStructBlock(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(switchParameterIndex);
                permutationsIndex.Write(binaryWriter);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
