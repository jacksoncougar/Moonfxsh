// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ShaderPostprocessValuePropertyBlock : ShaderPostprocessValuePropertyBlockBase
    {
        public  ShaderPostprocessValuePropertyBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ShaderPostprocessValuePropertyBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class ShaderPostprocessValuePropertyBlockBase : GuerillaBlock
    {
        internal float value;
        
        public override int SerializedSize{get { return 4; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ShaderPostprocessValuePropertyBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            value = binaryReader.ReadSingle();
        }
        public  ShaderPostprocessValuePropertyBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            value = binaryReader.ReadSingle();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(value);
                return nextAddress;
            }
        }
    };
}
