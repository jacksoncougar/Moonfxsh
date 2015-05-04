// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class DecoratorPlacementBlock : DecoratorPlacementBlockBase
    {
        public DecoratorPlacementBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 22, Alignment = 4)]
    public class DecoratorPlacementBlockBase : GuerillaBlock
    {
        internal int internalData1;
        internal int compressedPosition;
        internal Moonfish.Tags.ColourR1G1B1 tintColor;
        internal Moonfish.Tags.ColourR1G1B1 lightmapColor;
        internal int compressedLightDirection;
        internal int compressedLight2Direction;

        public override int SerializedSize
        {
            get { return 22; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public DecoratorPlacementBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            internalData1 = binaryReader.ReadInt32();
            compressedPosition = binaryReader.ReadInt32();
            tintColor = binaryReader.ReadColourR1G1B1();
            lightmapColor = binaryReader.ReadColourR1G1B1();
            compressedLightDirection = binaryReader.ReadInt32();
            compressedLight2Direction = binaryReader.ReadInt32();
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
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