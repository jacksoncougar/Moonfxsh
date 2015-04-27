// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class DecoratorPlacementBlock : DecoratorPlacementBlockBase
    {
        public  DecoratorPlacementBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  DecoratorPlacementBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 22, Alignment = 4)]
    public class DecoratorPlacementBlockBase : GuerillaBlock
    {
        internal int internalData1;
        internal int compressedPosition;
        internal Moonfish.Tags.RGBColor tintColor;
        internal Moonfish.Tags.RGBColor lightmapColor;
        internal int compressedLightDirection;
        internal int compressedLight2Direction;
        
        public override int SerializedSize{get { return 22; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  DecoratorPlacementBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            internalData1 = binaryReader.ReadInt32();
            compressedPosition = binaryReader.ReadInt32();
            tintColor = binaryReader.ReadRGBColor();
            lightmapColor = binaryReader.ReadRGBColor();
            compressedLightDirection = binaryReader.ReadInt32();
            compressedLight2Direction = binaryReader.ReadInt32();
        }
        public  DecoratorPlacementBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            internalData1 = binaryReader.ReadInt32();
            compressedPosition = binaryReader.ReadInt32();
            tintColor = binaryReader.ReadRGBColor();
            lightmapColor = binaryReader.ReadRGBColor();
            compressedLightDirection = binaryReader.ReadInt32();
            compressedLight2Direction = binaryReader.ReadInt32();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(internalData1);
                binaryWriter.Write(compressedPosition);
                binaryWriter.Write(tintColor);
                binaryWriter.Write(lightmapColor);
                binaryWriter.Write(compressedLightDirection);
                binaryWriter.Write(compressedLight2Direction);
                return nextAddress;
            }
        }
    };
}
