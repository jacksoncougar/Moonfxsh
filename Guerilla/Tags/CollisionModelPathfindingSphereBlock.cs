// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class CollisionModelPathfindingSphereBlock : CollisionModelPathfindingSphereBlockBase
    {
        public  CollisionModelPathfindingSphereBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class CollisionModelPathfindingSphereBlockBase  : IGuerilla
    {
        internal Moonfish.Tags.ShortBlockIndex1 node;
        internal Flags flags;
        internal OpenTK.Vector3 center;
        internal float radius;
        internal  CollisionModelPathfindingSphereBlockBase(BinaryReader binaryReader)
        {
            node = binaryReader.ReadShortBlockIndex1();
            flags = (Flags)binaryReader.ReadInt16();
            center = binaryReader.ReadVector3();
            radius = binaryReader.ReadSingle();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(node);
                binaryWriter.Write((Int16)flags);
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
