// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ShaderPostprocessVertexShaderConstantBlock : ShaderPostprocessVertexShaderConstantBlockBase
    {
        public  ShaderPostprocessVertexShaderConstantBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ShaderPostprocessVertexShaderConstantBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 18, Alignment = 4)]
    public class ShaderPostprocessVertexShaderConstantBlockBase : GuerillaBlock
    {
        internal byte registerIndex;
        internal byte registerBank;
        internal float data;
        internal float data0;
        internal float data1;
        internal float data2;
        
        public override int SerializedSize{get { return 18; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ShaderPostprocessVertexShaderConstantBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            registerIndex = binaryReader.ReadByte();
            registerBank = binaryReader.ReadByte();
            data = binaryReader.ReadSingle();
            data0 = binaryReader.ReadSingle();
            data1 = binaryReader.ReadSingle();
            data2 = binaryReader.ReadSingle();
        }
        public  ShaderPostprocessVertexShaderConstantBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            registerIndex = binaryReader.ReadByte();
            registerBank = binaryReader.ReadByte();
            data = binaryReader.ReadSingle();
            data0 = binaryReader.ReadSingle();
            data1 = binaryReader.ReadSingle();
            data2 = binaryReader.ReadSingle();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(registerIndex);
                binaryWriter.Write(registerBank);
                binaryWriter.Write(data);
                binaryWriter.Write(data0);
                binaryWriter.Write(data1);
                binaryWriter.Write(data2);
                return nextAddress;
            }
        }
    };
}
