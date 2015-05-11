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
    public partial class ObjectSpaceNodeDataBlock : ObjectSpaceNodeDataBlockBase
    {
        public ObjectSpaceNodeDataBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 28, Alignment = 4)]
    public class ObjectSpaceNodeDataBlockBase : GuerillaBlock
    {
        internal short nodeIndex;
        internal ComponentFlags componentFlags;
        internal QuantizedOrientationStructBlock orientation;

        public override int SerializedSize
        {
            get { return 28; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ObjectSpaceNodeDataBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            nodeIndex = binaryReader.ReadInt16();
            componentFlags = (ComponentFlags) binaryReader.ReadInt16();
            orientation = new QuantizedOrientationStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(orientation.ReadFields(binaryReader)));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            orientation.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(nodeIndex);
                binaryWriter.Write((Int16) componentFlags);
                orientation.Write(binaryWriter);
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum ComponentFlags : short
        {
            Rotation = 1,
            Translation = 2,
            Scale = 4,
        };
    };
}