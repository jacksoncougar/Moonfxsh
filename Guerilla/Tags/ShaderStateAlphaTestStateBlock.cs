using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ShaderStateAlphaTestStateBlock : ShaderStateAlphaTestStateBlockBase
    {
        public  ShaderStateAlphaTestStateBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8)]
    public class ShaderStateAlphaTestStateBlockBase
    {
        internal Flags flags;
        internal AlphaCompareFunction alphaCompareFunction;
        internal short alphaTestRef0255;
        internal byte[] invalidName_;
        internal  ShaderStateAlphaTestStateBlockBase(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt16();
            this.alphaCompareFunction = (AlphaCompareFunction)binaryReader.ReadInt16();
            this.alphaTestRef0255 = binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
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
            AlphaTestEnabled = 1,
            SampleAlphaToCoverage = 2,
            SampleAlphaToOne = 4,
        };
        internal enum AlphaCompareFunction : short
        
        {
            Never = 0,
            Less = 1,
            Equal = 2,
            LessOrEqual = 3,
            Greater = 4,
            NotEqual = 5,
            GreaterOrEqual = 6,
            Always = 7,
        };
    };
}
