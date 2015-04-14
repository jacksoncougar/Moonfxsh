// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ShaderPassPostprocessConstantNewBlock : ShaderPassPostprocessConstantNewBlockBase
    {
        public  ShaderPassPostprocessConstantNewBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 7, Alignment = 4)]
    public class ShaderPassPostprocessConstantNewBlockBase  : IGuerilla
    {
        internal Moonfish.Tags.StringID parameterName;
        internal byte componentMask;
        internal byte scaleByTextureStage;
        internal byte functionIndex;
        internal  ShaderPassPostprocessConstantNewBlockBase(BinaryReader binaryReader)
        {
            parameterName = binaryReader.ReadStringID();
            componentMask = binaryReader.ReadByte();
            scaleByTextureStage = binaryReader.ReadByte();
            functionIndex = binaryReader.ReadByte();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(parameterName);
                binaryWriter.Write(componentMask);
                binaryWriter.Write(scaleByTextureStage);
                binaryWriter.Write(functionIndex);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
