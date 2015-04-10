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
        public  ShaderStateCullStateBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 4)]
    public class ShaderStateCullStateBlockBase
    {
        internal Mode mode;
        internal FrontFace frontFace;
        internal  ShaderStateCullStateBlockBase(System.IO.BinaryReader binaryReader)
        {
            mode = (Mode)binaryReader.ReadInt16();
            frontFace = (FrontFace)binaryReader.ReadInt16();
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
                binaryWriter.Write((Int16)mode);
                binaryWriter.Write((Int16)frontFace);
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
