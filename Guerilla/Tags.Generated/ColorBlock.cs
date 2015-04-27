// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ColorBlock : ColorBlockBase
    {
        public  ColorBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ColorBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 48, Alignment = 4)]
    public class ColorBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.String32 name;
        internal OpenTK.Vector4 color;
        
        public override int SerializedSize{get { return 48; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ColorBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            name = binaryReader.ReadString32();
            color = binaryReader.ReadVector4();
        }
        public  ColorBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write(color);
                return nextAddress;
            }
        }
    };
}
