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
    [LayoutAttribute(Size = 8)]
    public class ShaderTextureStateMiscStateBlockBase
    {
        internal ComponentSignFlags componentSignFlags;
        internal byte[] invalidName_;
        internal Moonfish.Tags.ColourA1R1G1B1 borderColor;
        internal  ShaderTextureStateMiscStateBlockBase(BinaryReader binaryReader)
        {
            this.componentSignFlags = (ComponentSignFlags)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.borderColor = binaryReader.ReadColourA1R1G1B1();
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
        internal enum ComponentSignFlags : short
        
        {
            RSigned = 1,
            GSigned = 2,
            BSigned = 4,
            ASigned = 8,
        };
    };
}
