// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class TextureStageStateParameterBlock : TextureStageStateParameterBlockBase
    {
        public  TextureStageStateParameterBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 4)]
    public class TextureStageStateParameterBlockBase
    {
        internal byte parameterIndex;
        internal byte parameterType;
        internal byte stateIndex;
        internal byte stageIndex;
        internal  TextureStageStateParameterBlockBase(System.IO.BinaryReader binaryReader)
        {
            parameterIndex = binaryReader.ReadByte();
            parameterType = binaryReader.ReadByte();
            stateIndex = binaryReader.ReadByte();
            stageIndex = binaryReader.ReadByte();
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
                binaryWriter.Write(parameterIndex);
                binaryWriter.Write(parameterType);
                binaryWriter.Write(stateIndex);
                binaryWriter.Write(stageIndex);
            }
        }
    };
}
