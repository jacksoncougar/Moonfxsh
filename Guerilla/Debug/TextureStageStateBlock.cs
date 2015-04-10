// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class TextureStageStateBlock : TextureStageStateBlockBase
    {
        public  TextureStageStateBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 6)]
    public class TextureStageStateBlockBase
    {
        internal byte stateIndex;
        internal byte stageIndex;
        internal int stateValue;
        internal  TextureStageStateBlockBase(System.IO.BinaryReader binaryReader)
        {
            stateIndex = binaryReader.ReadByte();
            stageIndex = binaryReader.ReadByte();
            stateValue = binaryReader.ReadInt32();
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
                binaryWriter.Write(stateIndex);
                binaryWriter.Write(stageIndex);
                binaryWriter.Write(stateValue);
            }
        }
    };
}
