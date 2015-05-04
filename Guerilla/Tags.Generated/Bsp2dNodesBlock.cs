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
    public partial class Bsp2dNodesBlock : Bsp2dNodesBlockBase
    {
        public Bsp2dNodesBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 16, Alignment = 16)]
    public class Bsp2dNodesBlockBase : GuerillaBlock
    {
        internal OpenTK.Vector3 plane;
        internal short leftChild;
        internal short rightChild;

        public override int SerializedSize
        {
            get { return 16; }
        }

        public override int Alignment
        {
            get { return 16; }
        }

        public Bsp2dNodesBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            plane = binaryReader.ReadVector3();
            leftChild = binaryReader.ReadInt16();
            rightChild = binaryReader.ReadInt16();
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
                binaryWriter.Write(plane);
                binaryWriter.Write(leftChild);
                binaryWriter.Write(rightChild);
                return nextAddress;
            }
        }
    };
}