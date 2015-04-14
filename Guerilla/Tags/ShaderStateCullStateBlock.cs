// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ShaderStateCullStateBlock : ShaderStateCullStateBlockBase
    {
        public  ShaderStateCullStateBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class ShaderStateCullStateBlockBase  : IGuerilla
    {
        internal Mode mode;
        internal FrontFace frontFace;
        internal  ShaderStateCullStateBlockBase(BinaryReader binaryReader)
        {
            mode = (Mode)binaryReader.ReadInt16();
            frontFace = (FrontFace)binaryReader.ReadInt16();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)mode);
                binaryWriter.Write((Int16)frontFace);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
        internal enum Mode : short
        {
            None = 0,
            CW = 1,
            CCW = 2,
        };
        internal enum FrontFace : short
        {
            CW = 0,
            CCW = 1,
        };
    };
}
