// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class VertexShaderConstantBlock : VertexShaderConstantBlockBase
    {
        public  VertexShaderConstantBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class VertexShaderConstantBlockBase  : IGuerilla
    {
        internal byte registerIndex;
        internal byte parameterIndex;
        internal byte destinationMask;
        internal byte scaleByTextureStage;
        internal  VertexShaderConstantBlockBase(BinaryReader binaryReader)
        {
            registerIndex = binaryReader.ReadByte();
            parameterIndex = binaryReader.ReadByte();
            destinationMask = binaryReader.ReadByte();
            scaleByTextureStage = binaryReader.ReadByte();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(registerIndex);
                binaryWriter.Write(parameterIndex);
                binaryWriter.Write(destinationMask);
                binaryWriter.Write(scaleByTextureStage);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
