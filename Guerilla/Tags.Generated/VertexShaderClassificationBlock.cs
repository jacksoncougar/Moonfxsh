// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class VertexShaderClassificationBlock : VertexShaderClassificationBlockBase
    {
        public  VertexShaderClassificationBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  VertexShaderClassificationBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 28, Alignment = 4)]
    public class VertexShaderClassificationBlockBase : GuerillaBlock
    {
        internal byte[] invalidName_;
        internal short[] compiledShader;
        internal byte[] code;
        internal byte[] invalidName_0;
        
        public override int SerializedSize{get { return 28; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  VertexShaderClassificationBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(4);
            compiledShader = Guerilla.ReadShortData(binaryReader);
            code = Guerilla.ReadData(binaryReader);
            invalidName_0 = binaryReader.ReadBytes(8);
        }
        public  VertexShaderClassificationBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(4);
            compiledShader = Guerilla.ReadShortData(binaryReader);
            code = Guerilla.ReadData(binaryReader);
            invalidName_0 = binaryReader.ReadBytes(8);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_, 0, 4);
                nextAddress = Guerilla.WriteData(binaryWriter, compiledShader, nextAddress);
                nextAddress = Guerilla.WriteData(binaryWriter, code, nextAddress);
                binaryWriter.Write(invalidName_0, 0, 8);
                return nextAddress;
            }
        }
    };
}
