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
    public partial class BspSurfaceReferenceBlock : BspSurfaceReferenceBlockBase
    {
        public BspSurfaceReferenceBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class BspSurfaceReferenceBlockBase : GuerillaBlock
    {
        internal short stripIndex;
        internal short lightmapTriangleIndex;
        internal int bspNodeIndex;

        public override int SerializedSize
        {
            get { return 8; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public BspSurfaceReferenceBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            stripIndex = binaryReader.ReadInt16();
            lightmapTriangleIndex = binaryReader.ReadInt16();
            bspNodeIndex = binaryReader.ReadInt32();
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
                binaryWriter.Write(stripIndex);
                binaryWriter.Write(lightmapTriangleIndex);
                binaryWriter.Write(bspNodeIndex);
                return nextAddress;
            }
        }
    };
}