// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class TextureBlock : TextureBlockBase
    {
        public  TextureBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  TextureBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class TextureBlockBase : GuerillaBlock
    {
        internal byte stageIndex;
        internal byte parameterIndex;
        internal byte globalTextureIndex;
        internal byte flags;
        
        public override int SerializedSize{get { return 4; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  TextureBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            stageIndex = binaryReader.ReadByte();
            parameterIndex = binaryReader.ReadByte();
            globalTextureIndex = binaryReader.ReadByte();
            flags = binaryReader.ReadByte();
        }
        public  TextureBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            stageIndex = binaryReader.ReadByte();
            parameterIndex = binaryReader.ReadByte();
            globalTextureIndex = binaryReader.ReadByte();
            flags = binaryReader.ReadByte();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(stageIndex);
                binaryWriter.Write(parameterIndex);
                binaryWriter.Write(globalTextureIndex);
                binaryWriter.Write(flags);
                return nextAddress;
            }
        }
    };
}
