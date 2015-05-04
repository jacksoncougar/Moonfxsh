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
    public partial class ParticlesRenderDataBlock : ParticlesRenderDataBlockBase
    {
        public ParticlesRenderDataBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 19, Alignment = 4)]
    public class ParticlesRenderDataBlockBase : GuerillaBlock
    {
        internal float positionX;
        internal float positionY;
        internal float positionZ;
        internal float size;
        internal Moonfish.Tags.ColourR1G1B1 color;

        public override int SerializedSize
        {
            get { return 19; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ParticlesRenderDataBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            positionX = binaryReader.ReadSingle();
            positionY = binaryReader.ReadSingle();
            positionZ = binaryReader.ReadSingle();
            size = binaryReader.ReadSingle();
            color = binaryReader.ReadColourR1G1B1();
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