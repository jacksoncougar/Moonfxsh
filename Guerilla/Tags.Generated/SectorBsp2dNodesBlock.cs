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
    public partial class SectorBsp2dNodesBlock : SectorBsp2dNodesBlockBase
    {
        public SectorBsp2dNodesBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class SectorBsp2dNodesBlockBase : GuerillaBlock
    {
        internal OpenTK.Vector3 plane;
        internal int leftChild;
        internal int rightChild;
        public override int SerializedSize { get { return 20; } }
        public override int Alignment { get { return 4; } }
        public SectorBsp2dNodesBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            plane = binaryReader.ReadVector3();
            leftChild = binaryReader.ReadInt32();
            rightChild = binaryReader.ReadInt32();
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(plane);
                binaryWriter.Write(leftChild);
                binaryWriter.Write(rightChild);
                return nextAddress;
            }
        }
    };
}
