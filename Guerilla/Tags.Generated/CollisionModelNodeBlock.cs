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
    public partial class CollisionModelNodeBlock : CollisionModelNodeBlockBase
    {
        public CollisionModelNodeBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class CollisionModelNodeBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent name;
        internal byte[] invalidName_;
        internal Moonfish.Tags.ShortBlockIndex1 parentNode;
        internal Moonfish.Tags.ShortBlockIndex1 nextSiblingNode;
        internal Moonfish.Tags.ShortBlockIndex1 firstChildNode;

        public override int SerializedSize
        {
            get { return 12; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public CollisionModelNodeBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            name = binaryReader.ReadStringID();
            invalidName_ = binaryReader.ReadBytes(2);
            parentNode = binaryReader.ReadShortBlockIndex1();
            nextSiblingNode = binaryReader.ReadShortBlockIndex1();
            firstChildNode = binaryReader.ReadShortBlockIndex1();
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
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(parentNode);
                binaryWriter.Write(nextSiblingNode);
                binaryWriter.Write(firstChildNode);
                return nextAddress;
            }
        }
    };
}