// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ShaderStateMiscStateBlock : ShaderStateMiscStateBlockBase
    {
        public  ShaderStateMiscStateBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 7, Alignment = 4)]
    public class ShaderStateMiscStateBlockBase  : IGuerilla
    {
        internal Flags flags;
        internal byte[] invalidName_;
        internal Moonfish.Tags.RGBColor fogColor;
        internal  ShaderStateMiscStateBlockBase(BinaryReader binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            fogColor = binaryReader.ReadRGBColor();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(fogColor);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : short
        {
            YUVToRGB = 1,
            InvalidName16BitDither = 2,
            InvalidName32BitDXT1Noise = 4,
        };
    };
}
