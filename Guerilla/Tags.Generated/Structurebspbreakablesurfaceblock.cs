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
    public partial class StructureBspBreakableSurfaceBlock : StructureBspBreakableSurfaceBlockBase
    {
        public StructureBspBreakableSurfaceBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class StructureBspBreakableSurfaceBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.ShortBlockIndex1 instancedGeometryInstance;
        internal short breakableSurfaceIndex;
        internal OpenTK.Vector3 centroid;
        internal float radius;
        internal int collisionSurfaceIndex;

        public override int SerializedSize
        {
            get { return 24; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public StructureBspBreakableSurfaceBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            instancedGeometryInstance = binaryReader.ReadShortBlockIndex1();
            breakableSurfaceIndex = binaryReader.ReadInt16();
            centroid = binaryReader.ReadVector3();
            radius = binaryReader.ReadSingle();
            collisionSurfaceIndex = binaryReader.ReadInt32();
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
                binaryWriter.Write(instancedGeometryInstance);
                binaryWriter.Write(breakableSurfaceIndex);
                binaryWriter.Write(centroid);
                binaryWriter.Write(radius);
                binaryWriter.Write(collisionSurfaceIndex);
                return nextAddress;
            }
        }
    };
}