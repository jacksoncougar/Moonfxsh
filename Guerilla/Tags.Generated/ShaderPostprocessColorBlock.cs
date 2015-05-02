// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ShaderPostprocessColorBlock : ShaderPostprocessColorBlockBase
    {
        public  ShaderPostprocessColorBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ShaderPostprocessColorBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 13, Alignment = 4)]
    public class ShaderPostprocessColorBlockBase : GuerillaBlock
    {
        internal byte parameterIndex;
        internal Moonfish.Tags.ColourR8G8B8 Colour;
        
        public override int SerializedSize{get { return 13; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ShaderPostprocessColorBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            parameterIndex = binaryReader.ReadByte();
            Colour = binaryReader.ReadColorR8G8B8();
        }
        public  ShaderPostprocessColorBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            parameterIndex = binaryReader.ReadByte();
            Colour = binaryReader.ReadColorR8G8B8();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(parameterIndex);
                binaryWriter.Write(Colour);
                return nextAddress;
            }
        }
    };
}
