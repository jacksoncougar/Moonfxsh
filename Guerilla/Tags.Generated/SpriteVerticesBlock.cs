// ReSharper disable All

using Moonfish.Model;

using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class SpriteVerticesBlock : SpriteVerticesBlockBase
    {
        public SpriteVerticesBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 47, Alignment = 4)]
    public class SpriteVerticesBlockBase : GuerillaBlock
    {
        internal OpenTK.Vector3 position;
        internal OpenTK.Vector3 offset;
        internal OpenTK.Vector3 axis;
        internal OpenTK.Vector2 texcoord;
        internal Moonfish.Tags.ColourR1G1B1 color;

        public override int SerializedSize
        {
            get { return 47; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public SpriteVerticesBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            position = binaryReader.ReadVector3();
            offset = binaryReader.ReadVector3();
            axis = binaryReader.ReadVector3();
            texcoord = binaryReader.ReadVector2();
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
                binaryWriter.Write(position);
                binaryWriter.Write(offset);
                binaryWriter.Write(axis);
                binaryWriter.Write(texcoord);
                binaryWriter.Write(color);
                return nextAddress;
            }
        }
    };
}