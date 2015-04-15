// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ColorBlock : ColorBlockBase
    {
        public  ColorBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 48, Alignment = 4)]
    public class ColorBlockBase  : IGuerilla
    {
        internal Moonfish.Tags.String32 name;
        internal OpenTK.Vector4 color;
        internal  ColorBlockBase(BinaryReader binaryReader)
        {
            name = binaryReader.ReadString32();
            color = binaryReader.ReadVector4();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
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
