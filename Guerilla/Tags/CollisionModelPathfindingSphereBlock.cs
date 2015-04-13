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
    [LayoutAttribute(Size = 20)]
    public class CollisionModelPathfindingSphereBlockBase
    {
        internal Moonfish.Tags.ShortBlockIndex1 node;
        internal Flags flags;
        internal OpenTK.Vector3 center;
        internal float radius;
        internal  CollisionModelPathfindingSphereBlockBase(BinaryReader binaryReader)
        {
            this.node = binaryReader.ReadShortBlockIndex1();
            this.flags = (Flags)binaryReader.ReadInt16();
            this.center = binaryReader.ReadVector3();
            this.radius = binaryReader.ReadSingle();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
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
