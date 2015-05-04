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
    public partial class ClothVerticesBlock : ClothVerticesBlockBase
    {
        public ClothVerticesBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class ClothVerticesBlockBase : GuerillaBlock
    {
        internal OpenTK.Vector3 initialPosition;
        internal OpenTK.Vector2 uv;

        public override int SerializedSize
        {
            get { return 20; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ClothVerticesBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            initialPosition = binaryReader.ReadVector3();
            uv = binaryReader.ReadVector2();
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
                binaryWriter.Write(initialPosition);
                binaryWriter.Write(uv);
                return nextAddress;
            }
        }
    };
}