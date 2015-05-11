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
    public partial class StructureBspAudibilityBlock : StructureBspAudibilityBlockBase
    {
        public StructureBspAudibilityBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 52, Alignment = 4)]
    public class StructureBspAudibilityBlockBase : GuerillaBlock
    {
        internal int doorPortalCount;
        internal Moonfish.Model.Range clusterDistanceBounds;
        internal DoorEncodedPasBlock[] encodedDoorPas;
        internal ClusterDoorPortalEncodedPasBlock[] clusterDoorPortalEncodedPas;
        internal AiDeafeningEncodedPasBlock[] aiDeafeningPas;
        internal EncodedClusterDistancesBlock[] clusterDistances;
        internal OccluderToMachineDoorMapping[] machineDoorMapping;

        public override int SerializedSize
        {
            get { return 52; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public StructureBspAudibilityBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            doorPortalCount = binaryReader.ReadInt32();
            clusterDistanceBounds = binaryReader.ReadRange();
            blamPointers.Enqueue(ReadBlockArrayPointer<DoorEncodedPasBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ClusterDoorPortalEncodedPasBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<AiDeafeningEncodedPasBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<EncodedClusterDistancesBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<OccluderToMachineDoorMapping>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            encodedDoorPas = ReadBlockArrayData<DoorEncodedPasBlock>(binaryReader, blamPointers.Dequeue());
            clusterDoorPortalEncodedPas = ReadBlockArrayData<ClusterDoorPortalEncodedPasBlock>(binaryReader,
                blamPointers.Dequeue());
            aiDeafeningPas = ReadBlockArrayData<AiDeafeningEncodedPasBlock>(binaryReader, blamPointers.Dequeue());
            clusterDistances = ReadBlockArrayData<EncodedClusterDistancesBlock>(binaryReader, blamPointers.Dequeue());
            machineDoorMapping = ReadBlockArrayData<OccluderToMachineDoorMapping>(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(doorPortalCount);
                binaryWriter.Write(clusterDistanceBounds);
                nextAddress = Guerilla.WriteBlockArray<DoorEncodedPasBlock>(binaryWriter, encodedDoorPas, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ClusterDoorPortalEncodedPasBlock>(binaryWriter,
                    clusterDoorPortalEncodedPas, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<AiDeafeningEncodedPasBlock>(binaryWriter, aiDeafeningPas,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<EncodedClusterDistancesBlock>(binaryWriter, clusterDistances,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<OccluderToMachineDoorMapping>(binaryWriter, machineDoorMapping,
                    nextAddress);
                return nextAddress;
            }
        }
    };
}