// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ShaderPostprocessColorPropertyBlock : ShaderPostprocessColorPropertyBlockBase
    {
        public  ShaderPostprocessColorPropertyBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ShaderPostprocessColorPropertyBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class ShaderPostprocessColorPropertyBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.ColourR8G8B8 Colour;
        
        public override int SerializedSize{get { return 12; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ShaderPostprocessColorPropertyBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            Colour = binaryReader.ReadColorR8G8B8();
        }
        public  ShaderPostprocessColorPropertyBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            Colour = binaryReader.ReadColorR8G8B8();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(Colour);
                return nextAddress;
            }
        }
    };
}
