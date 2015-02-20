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
    [LayoutAttribute(Size = 7)]
    public class ShaderStateMiscStateBlockBase
    {
        internal Flags flags;
        internal byte[] invalidName_;
        internal Moonfish.Tags.RGBColor fogColor;
        internal  ShaderStateMiscStateBlockBase(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.fogColor = binaryReader.ReadRGBColor();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
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
        [FlagsAttribute]
        internal enum Flags : short
        
        {
            YUVToRGB = 1,
            InvalidName16BitDither = 2,
            InvalidName32BitDXT1Noise = 4,
        };
    };
}
