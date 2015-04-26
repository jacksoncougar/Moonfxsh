// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class VertexShaderClassificationBlock : VertexShaderClassificationBlockBase
    {
        public  VertexShaderClassificationBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 28, Alignment = 4)]
    public class VertexShaderClassificationBlockBase  : IGuerilla
    {
        internal byte[] invalidName_;
        internal short[] compiledShader;
        internal byte[] code;
        internal byte[] invalidName_0;
        internal  VertexShaderClassificationBlockBase(BinaryReader binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(4);
            compiledShader = Guerilla.ReadShortData(binaryReader);
            code = Guerilla.ReadData(binaryReader);
            invalidName_0 = binaryReader.ReadBytes(8);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
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
