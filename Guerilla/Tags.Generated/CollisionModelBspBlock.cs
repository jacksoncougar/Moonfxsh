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
    public partial class CollisionModelBspBlock : CollisionModelBspBlockBase
    {
        public CollisionModelBspBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 68, Alignment = 4)]
    public class CollisionModelBspBlockBase : GuerillaBlock
    {
        internal short nodeIndex;
        internal byte[] invalidName_;
        internal GlobalCollisionBspStructBlock bsp;
        public override int SerializedSize { get { return 68; } }
        public override int Alignment { get { return 4; } }
        public CollisionModelBspBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            nodeIndex = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            bsp = new GlobalCollisionBspStructBlock();
            blamPointers.Concat(bsp.ReadFields(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            bsp.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(nodeIndex);
                binaryWriter.Write(invalidName_, 0, 2);
                bsp.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
