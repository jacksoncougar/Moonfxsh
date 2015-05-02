// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ShaderPassPostprocessConstantNewBlock : ShaderPassPostprocessConstantNewBlockBase
    {
        public  ShaderPassPostprocessConstantNewBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ShaderPassPostprocessConstantNewBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 7, Alignment = 4)]
    public class ShaderPassPostprocessConstantNewBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent parameterName;
        internal byte componentMask;
        internal byte scaleByTextureStage;
        internal byte functionIndex;
        
        public override int SerializedSize{get { return 7; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ShaderPassPostprocessConstantNewBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            parameterName = binaryReader.ReadStringID();
            componentMask = binaryReader.ReadByte();
            scaleByTextureStage = binaryReader.ReadByte();
            functionIndex = binaryReader.ReadByte();
        }
        public  ShaderPassPostprocessConstantNewBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            parameterName = binaryReader.ReadStringID();
            componentMask = binaryReader.ReadByte();
            scaleByTextureStage = binaryReader.ReadByte();
            functionIndex = binaryReader.ReadByte();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(parameterName);
                binaryWriter.Write(componentMask);
                binaryWriter.Write(scaleByTextureStage);
                binaryWriter.Write(functionIndex);
                return nextAddress;
            }
        }
    };
}
