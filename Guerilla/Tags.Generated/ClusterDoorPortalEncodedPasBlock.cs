// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ClusterDoorPortalEncodedPasBlock : ClusterDoorPortalEncodedPasBlockBase
    {
        public ClusterDoorPortalEncodedPasBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 4, Alignment = 4 )]
    public class ClusterDoorPortalEncodedPasBlockBase : IGuerilla
    {
        internal int invalidName_;

        internal ClusterDoorPortalEncodedPasBlockBase( BinaryReader binaryReader )
        {
            invalidName_ = binaryReader.ReadInt32( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( invalidName_ );
                return nextAddress;
            }
        }
    };
}