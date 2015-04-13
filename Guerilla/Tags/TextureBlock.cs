// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class TextureBlock : TextureBlockBase
    {
        public  TextureBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class TextureBlockBase  : IGuerilla
    {
        internal byte stageIndex;
        internal byte parameterIndex;
        internal byte globalTextureIndex;
        internal byte flags;
        internal  TextureBlockBase(BinaryReader binaryReader)
        {
            stageIndex = binaryReader.ReadByte();
            parameterIndex = binaryReader.ReadByte();
            globalTextureIndex = binaryReader.ReadByte();
            flags = binaryReader.ReadByte();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(stageIndex);
                binaryWriter.Write(parameterIndex);
                binaryWriter.Write(globalTextureIndex);
                binaryWriter.Write(flags);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
