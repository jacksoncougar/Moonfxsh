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
    [LayoutAttribute(Size = 19)]
    public class ParticlesRenderDataBlockBase
    {
        internal float positionX;
        internal float positionY;
        internal float positionZ;
        internal float size;
        internal Moonfish.Tags.RGBColor color;
        internal  ParticlesRenderDataBlockBase(BinaryReader binaryReader)
        {
            this.positionX = binaryReader.ReadSingle();
            this.positionY = binaryReader.ReadSingle();
            this.positionZ = binaryReader.ReadSingle();
            this.size = binaryReader.ReadSingle();
            this.color = binaryReader.ReadRGBColor();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
        }
    };
}
