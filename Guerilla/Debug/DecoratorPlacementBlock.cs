// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class DecoratorPlacementBlock : DecoratorPlacementBlockBase
    {
        public  DecoratorPlacementBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 22)]
    public class DecoratorPlacementBlockBase
    {
        internal int internalData1;
        internal int compressedPosition;
        internal Moonfish.Tags.RGBColor tintColor;
        internal Moonfish.Tags.RGBColor lightmapColor;
        internal int compressedLightDirection;
        internal int compressedLight2Direction;
        internal  DecoratorPlacementBlockBase(System.IO.BinaryReader binaryReader)
        {
            internalData1 = binaryReader.ReadInt32();
            compressedPosition = binaryReader.ReadInt32();
            tintColor = binaryReader.ReadRGBColor();
            lightmapColor = binaryReader.ReadRGBColor();
            compressedLightDirection = binaryReader.ReadInt32();
            compressedLight2Direction = binaryReader.ReadInt32();
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
                binaryWriter.Write(internalData1);
                binaryWriter.Write(compressedPosition);
                binaryWriter.Write(tintColor);
                binaryWriter.Write(lightmapColor);
                binaryWriter.Write(compressedLightDirection);
                binaryWriter.Write(compressedLight2Direction);
            }
        }
    };
}
