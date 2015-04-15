// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Pixl = (TagClass)"pixl";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("pixl")]
    public  partial class PixelShaderBlock : PixelShaderBlockBase
    {
        public  PixelShaderBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class PixelShaderBlockBase  : IGuerilla
    {
        internal byte[] invalidName_;
        internal byte[] compiledShader;
        internal  PixelShaderBlockBase(BinaryReader binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(4);
            compiledShader = Guerilla.ReadData(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_, 0, 4);
                nextAddress = Guerilla.WriteData(binaryWriter, compiledShader, nextAddress);
                return nextAddress;
            }
        }
    };
}
