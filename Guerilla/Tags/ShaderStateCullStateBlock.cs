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
    [LayoutAttribute(Size = 4)]
    public class ShaderStateCullStateBlockBase
    {
        internal Mode mode;
        internal FrontFace frontFace;
        internal  ShaderStateCullStateBlockBase(BinaryReader binaryReader)
        {
            this.mode = (Mode)binaryReader.ReadInt16();
            this.frontFace = (FrontFace)binaryReader.ReadInt16();
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
