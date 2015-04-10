// ReSharper disable All
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
        public  StructureBspClusterPortalBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  StructureBspClusterPortalBlockBase(System.IO.BinaryReader binaryReader)
        {
            backCluster = binaryReader.ReadInt16();
            frontCluster = binaryReader.ReadInt16();
            planeIndex = binaryReader.ReadInt32();
            centroid = binaryReader.ReadVector3();
            boundingRadius = binaryReader.ReadSingle();
            flags = (Flags)binaryReader.ReadInt32();
            ReadStructureBspClusterPortalVertexBlockArray(binaryReader);
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
        internal  virtual StructureBspClusterPortalVertexBlock[] ReadStructureBspClusterPortalVertexBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteStructureBspClusterPortalVertexBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(backCluster);
                binaryWriter.Write(frontCluster);
                binaryWriter.Write(planeIndex);
                binaryWriter.Write(centroid);
                binaryWriter.Write(boundingRadius);
                binaryWriter.Write((Int32)flags);
                WriteStructureBspClusterPortalVertexBlockArray(binaryWriter);
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
