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
    public partial class DecoratorPermutationsBlock : DecoratorPermutationsBlockBase
    {
        public DecoratorPermutationsBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 40, Alignment = 4)]
    public class DecoratorPermutationsBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent name;
        internal Moonfish.Tags.ByteBlockIndex1 shader;
        internal byte[] invalidName_;
        internal Flags flags;
        internal FadeDistance fadeDistance;
        internal byte index;
        internal byte distributionWeight;
        internal Moonfish.Model.Range scale;
        internal Moonfish.Tags.ColourR1G1B1 tint1;
        internal byte[] invalidName_0;
        internal Moonfish.Tags.ColourR1G1B1 tint2;
        internal byte[] invalidName_1;
        internal float baseMapTintPercentage;
        internal float lightmapTintPercentage;
        internal float windScale;

        public override int SerializedSize
        {
            get { return 40; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public DecoratorPermutationsBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            name = binaryReader.ReadStringID();
            shader = binaryReader.ReadByteBlockIndex1();
            invalidName_ = binaryReader.ReadBytes(3);
            flags = (Flags) binaryReader.ReadByte();
            fadeDistance = (FadeDistance) binaryReader.ReadByte();
            index = binaryReader.ReadByte();
            distributionWeight = binaryReader.ReadByte();
            scale = binaryReader.ReadRange();
            tint1 = binaryReader.ReadColourR1G1B1();
            invalidName_0 = binaryReader.ReadBytes(1);
            tint2 = binaryReader.ReadColourR1G1B1();
            invalidName_1 = binaryReader.ReadBytes(1);
            baseMapTintPercentage = binaryReader.ReadSingle();
            lightmapTintPercentage = binaryReader.ReadSingle();
            windScale = binaryReader.ReadSingle();
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
                binaryWriter.Write(name);
                binaryWriter.Write(shader);
                binaryWriter.Write(invalidName_, 0, 3);
                binaryWriter.Write((Byte) flags);
                binaryWriter.Write((Byte) fadeDistance);
                binaryWriter.Write(index);
                binaryWriter.Write(distributionWeight);
                binaryWriter.Write(scale);
                binaryWriter.Write(tint1);
                binaryWriter.Write(invalidName_0, 0, 1);
                binaryWriter.Write(tint2);
                binaryWriter.Write(invalidName_1, 0, 1);
                binaryWriter.Write(baseMapTintPercentage);
                binaryWriter.Write(lightmapTintPercentage);
                binaryWriter.Write(windScale);
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum Flags : byte
        {
            AlignToNormal = 1,
            OnlyOnGround = 2,
            Upright = 4,
        };

        internal enum FadeDistance : byte
        {
            Close = 0,
            Medium = 1,
            Far = 2,
        };
    };
}