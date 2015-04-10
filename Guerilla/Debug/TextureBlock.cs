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
        public  TextureBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 4)]
    public class TextureBlockBase
    {
        internal byte stageIndex;
        internal byte parameterIndex;
        internal byte globalTextureIndex;
        internal byte flags;
        internal  TextureBlockBase(System.IO.BinaryReader binaryReader)
        {
            stageIndex = binaryReader.ReadByte();
            parameterIndex = binaryReader.ReadByte();
            globalTextureIndex = binaryReader.ReadByte();
            flags = binaryReader.ReadByte();
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(stageIndex);
                binaryWriter.Write(parameterIndex);
                binaryWriter.Write(globalTextureIndex);
                binaryWriter.Write(flags);
            }
        }
    };
}
