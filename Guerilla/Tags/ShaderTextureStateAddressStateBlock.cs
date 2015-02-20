using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ShaderTextureStateAddressStateBlock : ShaderTextureStateAddressStateBlockBase
    {
        public  ShaderTextureStateAddressStateBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8)]
    public class ShaderTextureStateAddressStateBlockBase
    {
        internal UAddressMode uAddressMode;
        internal VAddressMode vAddressMode;
        internal WAddressMode wAddressMode;
        internal byte[] invalidName_;
        internal  ShaderTextureStateAddressStateBlockBase(BinaryReader binaryReader)
        {
            this.uAddressMode = (UAddressMode)binaryReader.ReadInt16();
            this.vAddressMode = (VAddressMode)binaryReader.ReadInt16();
            this.wAddressMode = (WAddressMode)binaryReader.ReadInt16();
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
        internal enum UAddressMode : short
        
        {
            Wrap = 0,
            Mirror = 1,
            Clamp = 2,
            Border = 3,
            ClampToEdge = 4,
        };
        internal enum VAddressMode : short
        
        {
            Wrap = 0,
            Mirror = 1,
            Clamp = 2,
            Border = 3,
            ClampToEdge = 4,
        };
        internal enum WAddressMode : short
        
        {
            Wrap = 0,
            Mirror = 1,
            Clamp = 2,
            Border = 3,
            ClampToEdge = 4,
        };
    };
}
