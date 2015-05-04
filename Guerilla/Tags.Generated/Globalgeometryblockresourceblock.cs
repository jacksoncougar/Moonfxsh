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
    public partial class GlobalGeometryBlockResourceBlock : GlobalGeometryBlockResourceBlockBase
    {
        public GlobalGeometryBlockResourceBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class GlobalGeometryBlockResourceBlockBase : GuerillaBlock
    {
        internal Type type;
        internal byte[] invalidName_;
        internal short primaryLocator;
        internal short secondaryLocator;
        internal int resourceDataSize;
        internal int resourceDataOffset;

        public override int SerializedSize
        {
            get { return 16; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public GlobalGeometryBlockResourceBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            type = (Type) binaryReader.ReadByte();
            invalidName_ = binaryReader.ReadBytes(3);
            primaryLocator = binaryReader.ReadInt16();
            secondaryLocator = binaryReader.ReadInt16();
            resourceDataSize = binaryReader.ReadInt32();
            resourceDataOffset = binaryReader.ReadInt32();
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
                binaryWriter.Write((Byte) type);
                binaryWriter.Write(invalidName_, 0, 3);
                binaryWriter.Write(primaryLocator);
                binaryWriter.Write(secondaryLocator);
                binaryWriter.Write(resourceDataSize);
                binaryWriter.Write(resourceDataOffset);
                return nextAddress;
            }
        }

        internal enum Type : byte
        {
            TagBlock = 0,
            TagData = 1,
            VertexBuffer = 2,
        };
    };
}