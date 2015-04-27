// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ShaderStateCullStateBlock : ShaderStateCullStateBlockBase
    {
        public  ShaderStateCullStateBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ShaderStateCullStateBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class ShaderStateCullStateBlockBase : GuerillaBlock
    {
        internal Mode mode;
        internal FrontFace frontFace;
        
        public override int SerializedSize{get { return 4; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ShaderStateCullStateBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            mode = (Mode)binaryReader.ReadInt16();
            frontFace = (FrontFace)binaryReader.ReadInt16();
        }
        public  ShaderStateCullStateBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            mode = (Mode)binaryReader.ReadInt16();
            frontFace = (FrontFace)binaryReader.ReadInt16();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)mode);
                binaryWriter.Write((Int16)frontFace);
                return nextAddress;
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
