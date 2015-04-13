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
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class VertexShaderClassificationBlockBase  : IGuerilla
    {
        internal byte[] invalidName_;
        internal byte[] compiledShader;
        internal byte[] code;
        internal  VertexShaderClassificationBlockBase(BinaryReader binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(4);
            compiledShader = Guerilla.ReadData(binaryReader);
            code = Guerilla.ReadData(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_, 0, 4);
                Guerilla.WriteData(binaryWriter);
                Guerilla.WriteData(binaryWriter);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
