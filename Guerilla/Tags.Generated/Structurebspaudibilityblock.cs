// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class StructureBspAudibilityBlock : StructureBspAudibilityBlockBase
    {
        public StructureBspAudibilityBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 52, Alignment = 4 )]
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

        internal StructureBspAudibilityBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            doorPortalCount = binaryReader.ReadInt32( );
            clusterDistanceBounds = binaryReader.ReadRange( );
            encodedDoorPas = Guerilla.ReadBlockArray<DoorEncodedPasBlock>( binaryReader );
            clusterDoorPortalEncodedPas = Guerilla.ReadBlockArray<ClusterDoorPortalEncodedPasBlock>( binaryReader );
            aiDeafeningPas = Guerilla.ReadBlockArray<AiDeafeningEncodedPasBlock>( binaryReader );
            clusterDistances = Guerilla.ReadBlockArray<EncodedClusterDistancesBlock>( binaryReader );
            machineDoorMapping = Guerilla.ReadBlockArray<OccluderToMachineDoorMapping>( binaryReader );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( doorPortalCount );
                binaryWriter.Write( clusterDistanceBounds );
                nextAddress = Guerilla.WriteBlockArray<DoorEncodedPasBlock>( binaryWriter, encodedDoorPas, nextAddress );
                nextAddress = Guerilla.WriteBlockArray<ClusterDoorPortalEncodedPasBlock>( binaryWriter,
                    clusterDoorPortalEncodedPas, nextAddress );
                nextAddress = Guerilla.WriteBlockArray<AiDeafeningEncodedPasBlock>( binaryWriter, aiDeafeningPas,
                    nextAddress );
                nextAddress = Guerilla.WriteBlockArray<EncodedClusterDistancesBlock>( binaryWriter, clusterDistances,
                    nextAddress );
                nextAddress = Guerilla.WriteBlockArray<OccluderToMachineDoorMapping>( binaryWriter, machineDoorMapping,
                    nextAddress );
                return nextAddress;
            }
        }
    };
}