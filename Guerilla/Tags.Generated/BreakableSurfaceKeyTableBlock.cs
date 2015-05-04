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
    public partial class BreakableSurfaceKeyTableBlock : BreakableSurfaceKeyTableBlockBase
    {
        public BreakableSurfaceKeyTableBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 32, Alignment = 4)]
    public class BreakableSurfaceKeyTableBlockBase : GuerillaBlock
    {
        internal short instancedGeometryIndex;
        internal short breakableSurfaceIndex;
        internal int seedSurfaceIndex;
        internal float x0;
        internal float x1;
        internal float y0;
        internal float y1;
        internal float z0;
        internal float z1;

        public override int SerializedSize
        {
            get { return 32; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public BreakableSurfaceKeyTableBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            instancedGeometryIndex = binaryReader.ReadInt16();
            breakableSurfaceIndex = binaryReader.ReadInt16();
            seedSurfaceIndex = binaryReader.ReadInt32();
            x0 = binaryReader.ReadSingle();
            x1 = binaryReader.ReadSingle();
            y0 = binaryReader.ReadSingle();
            y1 = binaryReader.ReadSingle();
            z0 = binaryReader.ReadSingle();
            z1 = binaryReader.ReadSingle();
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
                binaryWriter.Write(instancedGeometryIndex);
                binaryWriter.Write(breakableSurfaceIndex);
                binaryWriter.Write(seedSurfaceIndex);
                binaryWriter.Write(x0);
                binaryWriter.Write(x1);
                binaryWriter.Write(y0);
                binaryWriter.Write(y1);
                binaryWriter.Write(z0);
                binaryWriter.Write(z1);
                return nextAddress;
            }
        }
    };
}