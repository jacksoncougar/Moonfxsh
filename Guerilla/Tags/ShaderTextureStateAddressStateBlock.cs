// ReSharper disable All
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
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class ShaderTextureStateAddressStateBlockBase  : IGuerilla
    {
        internal UAddressMode uAddressMode;
        internal VAddressMode vAddressMode;
        internal WAddressMode wAddressMode;
        internal byte[] invalidName_;
        internal  ShaderTextureStateAddressStateBlockBase(BinaryReader binaryReader)
        {
            uAddressMode = (UAddressMode)binaryReader.ReadInt16();
            vAddressMode = (VAddressMode)binaryReader.ReadInt16();
            wAddressMode = (WAddressMode)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)uAddressMode);
                binaryWriter.Write((Int16)vAddressMode);
                binaryWriter.Write((Int16)wAddressMode);
                binaryWriter.Write(invalidName_, 0, 2);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
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
