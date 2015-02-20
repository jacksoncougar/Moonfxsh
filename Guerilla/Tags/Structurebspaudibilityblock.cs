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
        public  StructureBspAudibilityBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  StructureBspAudibilityBlockBase(BinaryReader binaryReader)
        {
            this.doorPortalCount = binaryReader.ReadInt32();
            this.clusterDistanceBounds = binaryReader.ReadRange();
            this.encodedDoorPas = ReadDoorEncodedPasBlockArray(binaryReader);
            this.clusterDoorPortalEncodedPas = ReadClusterDoorPortalEncodedPasBlockArray(binaryReader);
            this.aiDeafeningPas = ReadAiDeafeningEncodedPasBlockArray(binaryReader);
            this.clusterDistances = ReadEncodedClusterDistancesBlockArray(binaryReader);
            this.machineDoorMapping = ReadOccluderToMachineDoorMappingArray(binaryReader);
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
        internal  virtual DoorEncodedPasBlock[] ReadDoorEncodedPasBlockArray(BinaryReader binaryReader)
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
        internal  virtual ClusterDoorPortalEncodedPasBlock[] ReadClusterDoorPortalEncodedPasBlockArray(BinaryReader binaryReader)
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
        internal  virtual AiDeafeningEncodedPasBlock[] ReadAiDeafeningEncodedPasBlockArray(BinaryReader binaryReader)
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
        internal  virtual EncodedClusterDistancesBlock[] ReadEncodedClusterDistancesBlockArray(BinaryReader binaryReader)
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
        internal  virtual OccluderToMachineDoorMapping[] ReadOccluderToMachineDoorMappingArray(BinaryReader binaryReader)
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
    };
}
