// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ShaderPassPostprocessTextureStateBlock : ShaderPassPostprocessTextureStateBlockBase
    {
        public  ShaderPassPostprocessTextureStateBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class ShaderPassPostprocessTextureStateBlockBase  : IGuerilla
    {
        internal byte[] invalidName_;
        internal  ShaderPassPostprocessTextureStateBlockBase(BinaryReader binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(24);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_, 0, 24);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
