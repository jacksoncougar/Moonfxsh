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
    public partial class StructureBspFogPlaneBlock : StructureBspFogPlaneBlockBase
    {
        public StructureBspFogPlaneBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class StructureBspFogPlaneBlockBase : GuerillaBlock
    {
        internal short scenarioPlanarFogIndex;
        internal byte[] invalidName_;
        internal OpenTK.Vector4 plane;
        internal Flags flags;
        internal short priority;

        public override int SerializedSize
        {
            get { return 24; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public StructureBspFogPlaneBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            scenarioPlanarFogIndex = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            plane = binaryReader.ReadVector4();
            flags = (Flags) binaryReader.ReadInt16();
            priority = binaryReader.ReadInt16();
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
                binaryWriter.Write(scenarioPlanarFogIndex);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(plane);
                binaryWriter.Write((Int16) flags);
                binaryWriter.Write(priority);
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum Flags : short
        {
            ExtendInfinitelyWhileVisible = 1,
            DoNotFloodfill = 2,
            AggressiveFloodfill = 4,
        };
    };
}