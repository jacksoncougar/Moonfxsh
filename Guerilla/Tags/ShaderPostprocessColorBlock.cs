// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ShaderPostprocessColorBlock : ShaderPostprocessColorBlockBase
    {
        public  ShaderPostprocessColorBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 13, Alignment = 4)]
    public class ShaderPostprocessColorBlockBase  : IGuerilla
    {
        internal byte parameterIndex;
        internal Moonfish.Tags.ColorR8G8B8 color;
        internal  ShaderPostprocessColorBlockBase(BinaryReader binaryReader)
        {
            parameterIndex = binaryReader.ReadByte();
            color = binaryReader.ReadColorR8G8B8();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(parameterIndex);
                binaryWriter.Write(color);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
