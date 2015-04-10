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
        public  ParticlesRenderDataBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  ParticlesRenderDataBlockBase(System.IO.BinaryReader binaryReader)
        {
            positionX = binaryReader.ReadSingle();
            positionY = binaryReader.ReadSingle();
            positionZ = binaryReader.ReadSingle();
            size = binaryReader.ReadSingle();
            color = binaryReader.ReadRGBColor();
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(positionX);
                binaryWriter.Write(positionY);
                binaryWriter.Write(positionZ);
                binaryWriter.Write(size);
                binaryWriter.Write(color);
            }
        }
    };
}
