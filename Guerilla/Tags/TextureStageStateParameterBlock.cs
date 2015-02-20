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
        public  TextureStageStateParameterBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  TextureStageStateParameterBlockBase(BinaryReader binaryReader)
        {
            this.parameterIndex = binaryReader.ReadByte();
            this.parameterType = binaryReader.ReadByte();
            this.stateIndex = binaryReader.ReadByte();
            this.stageIndex = binaryReader.ReadByte();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
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
    };
}
