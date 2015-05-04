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
    public partial class CollisionModelPathfindingSphereBlock : CollisionModelPathfindingSphereBlockBase
    {
        public CollisionModelPathfindingSphereBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class CollisionModelPathfindingSphereBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.ShortBlockIndex1 node;
        internal Flags flags;
        internal OpenTK.Vector3 center;
        internal float radius;

        public override int SerializedSize
        {
            get { return 20; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public CollisionModelPathfindingSphereBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            node = binaryReader.ReadShortBlockIndex1();
            flags = (Flags) binaryReader.ReadInt16();
            center = binaryReader.ReadVector3();
            radius = binaryReader.ReadSingle();
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
                binaryWriter.Write(node);
                binaryWriter.Write((Int16) flags);
                binaryWriter.Write(center);
                binaryWriter.Write(radius);
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum Flags : short
        {
            RemainsWhenOpen = 1,
            VehicleOnly = 2,
            WithSectors = 4,
        };
    };
}