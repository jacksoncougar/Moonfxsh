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
        public  DecoratorPlacementBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  DecoratorPlacementBlockBase(BinaryReader binaryReader)
        {
            this.internalData1 = binaryReader.ReadInt32();
            this.compressedPosition = binaryReader.ReadInt32();
            this.tintColor = binaryReader.ReadRGBColor();
            this.lightmapColor = binaryReader.ReadRGBColor();
            this.compressedLightDirection = binaryReader.ReadInt32();
            this.compressedLight2Direction = binaryReader.ReadInt32();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
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
    };
}
