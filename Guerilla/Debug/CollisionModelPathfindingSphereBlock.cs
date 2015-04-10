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
        public  CollisionModelPathfindingSphereBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  CollisionModelPathfindingSphereBlockBase(System.IO.BinaryReader binaryReader)
        {
            node = binaryReader.ReadShortBlockIndex1();
            flags = (Flags)binaryReader.ReadInt16();
            center = binaryReader.ReadVector3();
            radius = binaryReader.ReadSingle();
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(node);
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(center);
                binaryWriter.Write(radius);
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
