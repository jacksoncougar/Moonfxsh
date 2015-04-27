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
    public partial class PixelShaderBlock : PixelShaderBlockBase
    {
        public  PixelShaderBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  PixelShaderBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class PixelShaderBlockBase : GuerillaBlock
    {
        internal byte[] invalidName_;
        internal byte[] compiledShader;
        
        public override int SerializedSize{get { return 12; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  PixelShaderBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(4);
            compiledShader = Guerilla.ReadData(binaryReader);
        }
        public  PixelShaderBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
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
