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
    public partial class StructureBspClusterPortalBlock : StructureBspClusterPortalBlockBase
    {
        public StructureBspClusterPortalBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 36, Alignment = 4)]
    public class StructureBspClusterPortalBlockBase : GuerillaBlock
    {
        internal short backCluster;
        internal short frontCluster;
        internal int planeIndex;
        internal OpenTK.Vector3 centroid;
        internal float boundingRadius;
        internal Flags flags;
        internal StructureBspClusterPortalVertexBlock[] vertices;

        public override int SerializedSize
        {
            get { return 36; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public StructureBspClusterPortalBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            backCluster = binaryReader.ReadInt16();
            frontCluster = binaryReader.ReadInt16();
            planeIndex = binaryReader.ReadInt32();
            centroid = binaryReader.ReadVector3();
            boundingRadius = binaryReader.ReadSingle();
            flags = (Flags) binaryReader.ReadInt32();
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureBspClusterPortalVertexBlock>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            vertices = ReadBlockArrayData<StructureBspClusterPortalVertexBlock>(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(backCluster);
                binaryWriter.Write(frontCluster);
                binaryWriter.Write(planeIndex);
                binaryWriter.Write(centroid);
                binaryWriter.Write(boundingRadius);
                binaryWriter.Write((Int32) flags);
                nextAddress = Guerilla.WriteBlockArray<StructureBspClusterPortalVertexBlock>(binaryWriter, vertices,
                    nextAddress);
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum Flags : int
        {
            AICannotHearThroughThis = 1,
            OneWay = 2,
            Door = 4,
            NoWay = 8,
            OneWayReversed = 16,
            NoOneCanHearThroughThis = 32,
        };
    };
}