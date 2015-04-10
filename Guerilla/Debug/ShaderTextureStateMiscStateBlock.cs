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
        public  ShaderTextureStateMiscStateBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8)]
    public class ShaderTextureStateMiscStateBlockBase
    {
        internal ComponentSignFlags componentSignFlags;
        internal byte[] invalidName_;
        internal Moonfish.Tags.ColourA1R1G1B1 borderColor;
        internal  ShaderTextureStateMiscStateBlockBase(System.IO.BinaryReader binaryReader)
        {
            componentSignFlags = (ComponentSignFlags)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            borderColor = binaryReader.ReadColourA1R1G1B1();
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)componentSignFlags);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(borderColor);
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
