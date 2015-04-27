// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class PixelShaderFragmentBlock : PixelShaderFragmentBlockBase
    {
        public  PixelShaderFragmentBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class PixelShaderFragmentBlockBase : GuerillaBlock
    {
        internal byte switchParameterIndex;
        internal byte[] invalidName_;
        internal TagBlockIndexStructBlock permutationsIndex;
        
        public override int SerializedSize{get { return 4; }}
        
        internal  PixelShaderFragmentBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            switchParameterIndex = binaryReader.ReadByte();
            invalidName_ = binaryReader.ReadBytes(1);
            permutationsIndex = new TagBlockIndexStructBlock(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(switchParameterIndex);
                binaryWriter.Write(invalidName_, 0, 1);
                permutationsIndex.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
