// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class StructureBspAudibilityBlock : StructureBspAudibilityBlockBase
    {
        public  StructureBspAudibilityBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 52)]
    public class StructureBspAudibilityBlockBase
    {
        internal int doorPortalCount;
        internal Moonfish.Model.Range clusterDistanceBounds;
        internal DoorEncodedPasBlock[] encodedDoorPas;
        internal ClusterDoorPortalEncodedPasBlock[] clusterDoorPortalEncodedPas;
        internal AiDeafeningEncodedPasBlock[] aiDeafeningPas;
        internal EncodedClusterDistancesBlock[] clusterDistances;
        internal OccluderToMachineDoorMapping[] machineDoorMapping;
        internal  StructureBspAudibilityBlockBase(System.IO.BinaryReader binaryReader)
        {
            doorPortalCount = binaryReader.ReadInt32();
            clusterDistanceBounds = binaryReader.ReadRange();
            ReadDoorEncodedPasBlockArray(binaryReader);
            ReadClusterDoorPortalEncodedPasBlockArray(binaryReader);
            ReadAiDeafeningEncodedPasBlockArray(binaryReader);
            ReadEncodedClusterDistancesBlockArray(binaryReader);
            ReadOccluderToMachineDoorMappingArray(binaryReader);
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
        internal  virtual DoorEncodedPasBlock[] ReadDoorEncodedPasBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(DoorEncodedPasBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new DoorEncodedPasBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new DoorEncodedPasBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ClusterDoorPortalEncodedPasBlock[] ReadClusterDoorPortalEncodedPasBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ClusterDoorPortalEncodedPasBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ClusterDoorPortalEncodedPasBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ClusterDoorPortalEncodedPasBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual AiDeafeningEncodedPasBlock[] ReadAiDeafeningEncodedPasBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(AiDeafeningEncodedPasBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new AiDeafeningEncodedPasBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new AiDeafeningEncodedPasBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual EncodedClusterDistancesBlock[] ReadEncodedClusterDistancesBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(EncodedClusterDistancesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new EncodedClusterDistancesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new EncodedClusterDistancesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual OccluderToMachineDoorMapping[] ReadOccluderToMachineDoorMappingArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(OccluderToMachineDoorMapping));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new OccluderToMachineDoorMapping[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new OccluderToMachineDoorMapping(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteDoorEncodedPasBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteClusterDoorPortalEncodedPasBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteAiDeafeningEncodedPasBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteEncodedClusterDistancesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteOccluderToMachineDoorMappingArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(doorPortalCount);
                binaryWriter.Write(clusterDistanceBounds);
                WriteDoorEncodedPasBlockArray(binaryWriter);
                WriteClusterDoorPortalEncodedPasBlockArray(binaryWriter);
                WriteAiDeafeningEncodedPasBlockArray(binaryWriter);
                WriteEncodedClusterDistancesBlockArray(binaryWriter);
                WriteOccluderToMachineDoorMappingArray(binaryWriter);
            }
        }
    };
}
