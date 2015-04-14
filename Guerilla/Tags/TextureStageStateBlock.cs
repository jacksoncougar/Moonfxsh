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
        public  TextureStageStateBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 6, Alignment = 4)]
    public class TextureStageStateBlockBase  : IGuerilla
    {
        internal byte stateIndex;
        internal byte stageIndex;
        internal int stateValue;
        internal  TextureStageStateBlockBase(BinaryReader binaryReader)
        {
            stateIndex = binaryReader.ReadByte();
            stageIndex = binaryReader.ReadByte();
            stateValue = binaryReader.ReadInt32();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(stateIndex);
                binaryWriter.Write(stageIndex);
                binaryWriter.Write(stateValue);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
