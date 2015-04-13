// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class LightGelAnimationBlock : LightGelAnimationBlockBase
    {
        public  LightGelAnimationBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class LightGelAnimationBlockBase  : IGuerilla
    {
        internal MappingFunctionBlock dx;
        internal MappingFunctionBlock dy;
        internal  LightGelAnimationBlockBase(BinaryReader binaryReader)
        {
            dx = new MappingFunctionBlock(binaryReader);
            dy = new MappingFunctionBlock(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                dx.Write(binaryWriter);
                dy.Write(binaryWriter);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
