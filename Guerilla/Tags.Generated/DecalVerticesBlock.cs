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
    public partial class DecalVerticesBlock : DecalVerticesBlockBase
    {
        public DecalVerticesBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 31, Alignment = 4)]
    public class DecalVerticesBlockBase : GuerillaBlock
    {
        internal OpenTK.Vector3 position;
        internal OpenTK.Vector2 texcoord0;
        internal OpenTK.Vector2 texcoord1;
        internal Moonfish.Tags.ColourR1G1B1 color;

        public override int SerializedSize
        {
            get { return 31; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public DecalVerticesBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            position = binaryReader.ReadVector3();
            texcoord0 = binaryReader.ReadVector2();
            texcoord1 = binaryReader.ReadVector2();
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
                binaryWriter.Write(texcoord0);
                binaryWriter.Write(texcoord1);
                binaryWriter.Write(color);
                return nextAddress;
            }
        }
    };
}