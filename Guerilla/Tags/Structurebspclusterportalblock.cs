using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class StructureBspClusterPortalBlock : StructureBspClusterPortalBlockBase
    {
        public  StructureBspClusterPortalBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 36)]
    public class StructureBspClusterPortalBlockBase
    {
        internal short backCluster;
        internal short frontCluster;
        internal int planeIndex;
        internal OpenTK.Vector3 centroid;
        internal float boundingRadius;
        internal Flags flags;
        internal StructureBspClusterPortalVertexBlock[] vertices;
        internal  StructureBspClusterPortalBlockBase(BinaryReader binaryReader)
        {
            this.backCluster = binaryReader.ReadInt16();
            this.frontCluster = binaryReader.ReadInt16();
            this.planeIndex = binaryReader.ReadInt32();
            this.centroid = binaryReader.ReadVector3();
            this.boundingRadius = binaryReader.ReadSingle();
            this.flags = (Flags)binaryReader.ReadInt32();
            this.vertices = ReadStructureBspClusterPortalVertexBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
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
        internal  virtual StructureBspClusterPortalVertexBlock[] ReadStructureBspClusterPortalVertexBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspClusterPortalVertexBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspClusterPortalVertexBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspClusterPortalVertexBlock(binaryReader);
                }
            }
            return array;
        }
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
