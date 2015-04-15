// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ParticlesRenderDataBlock : ParticlesRenderDataBlockBase
    {
        public  ParticlesRenderDataBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 19, Alignment = 4)]
    public class ParticlesRenderDataBlockBase  : IGuerilla
    {
        internal float positionX;
        internal float positionY;
        internal float positionZ;
        internal float size;
        internal Moonfish.Tags.RGBColor color;
        internal  ParticlesRenderDataBlockBase(BinaryReader binaryReader)
        {
            positionX = binaryReader.ReadSingle();
            positionY = binaryReader.ReadSingle();
            positionZ = binaryReader.ReadSingle();
            size = binaryReader.ReadSingle();
            color = binaryReader.ReadRGBColor();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(positionX);
                binaryWriter.Write(positionY);
                binaryWriter.Write(positionZ);
                binaryWriter.Write(size);
                binaryWriter.Write(color);
                return nextAddress;
            }
        }
    };
}
