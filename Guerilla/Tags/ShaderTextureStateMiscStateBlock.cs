// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ShaderTextureStateMiscStateBlock : ShaderTextureStateMiscStateBlockBase
    {
        public  ShaderTextureStateMiscStateBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class ShaderTextureStateMiscStateBlockBase  : IGuerilla
    {
        internal ComponentSignFlags componentSignFlags;
        internal byte[] invalidName_;
        internal Moonfish.Tags.ColourA1R1G1B1 borderColor;
        internal  ShaderTextureStateMiscStateBlockBase(BinaryReader binaryReader)
        {
            componentSignFlags = (ComponentSignFlags)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            borderColor = binaryReader.ReadColourA1R1G1B1();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)componentSignFlags);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(borderColor);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum ComponentSignFlags : short
        {
            RSigned = 1,
            GSigned = 2,
            BSigned = 4,
            ASigned = 8,
        };
    };
}
