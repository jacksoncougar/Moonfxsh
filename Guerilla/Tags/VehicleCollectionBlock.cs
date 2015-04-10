using Moonfish.Tags.BlamExtension;
using System.IO;
using Moonfish.Tags;

namespace Moonfish.Guerilla.Tags
{
    [TagClass( "vehc" )]
    public partial class VehicleCollectionBlock : VehicleCollectionBlockBase
    {
        public VehicleCollectionBlock( BinaryReader binaryReader )
            : base( binaryReader )
        {

        }
    };
    [Layout( Size = 12 )]
    public class VehicleCollectionBlockBase
    {
        internal VehiclePermutation[] vehiclePermutations;
        internal short spawnTimeInSeconds0Default;
        internal byte[] invalidName_;
        internal VehicleCollectionBlockBase( BinaryReader binaryReader )
        {
            this.vehiclePermutations = ReadVehiclePermutationArray( binaryReader );
            this.spawnTimeInSeconds0Default = binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes( 2 );
        }
        internal virtual byte[] ReadData( BinaryReader binaryReader )
        {
            var blamPointer = binaryReader.ReadBlamPointer( 1 );
            var data = new byte[ blamPointer.Count ];
            if ( blamPointer.Count > 0 )
            {
                using ( binaryReader.BaseStream.Pin() )
                {
                    binaryReader.BaseStream.Position = blamPointer[ 0 ];
                    data = binaryReader.ReadBytes( blamPointer.Count );
                }
            }
            return data;
        }
        internal virtual VehiclePermutation[] ReadVehiclePermutationArray( BinaryReader binaryReader )
        {
            var elementSize = Deserializer.SizeOf( typeof( VehiclePermutation ) );
            var blamPointer = binaryReader.ReadBlamPointer( elementSize );
            var array = new VehiclePermutation[ blamPointer.Count ];
            using ( binaryReader.BaseStream.Pin() )
            {
                for ( int i = 0; i < blamPointer.Count; ++i )
                {
                    binaryReader.BaseStream.Position = blamPointer[ i ];
                    array[ i ] = new VehiclePermutation( binaryReader );
                }
            }
            return array;
        }
    };
}
