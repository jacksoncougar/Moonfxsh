// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class PolyhedronFourVectorsBlock : PolyhedronFourVectorsBlockBase
    {
        public PolyhedronFourVectorsBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 48, Alignment = 16 )]
    public class PolyhedronFourVectorsBlockBase : IGuerilla
    {
        internal OpenTK.Vector3 fourVectorsX;
        internal byte[] invalidName_;
        internal OpenTK.Vector3 fourVectorsY;
        internal byte[] invalidName_0;
        internal OpenTK.Vector3 fourVectorsZ;
        internal byte[] invalidName_1;

        internal PolyhedronFourVectorsBlockBase( BinaryReader binaryReader )
        {
            fourVectorsX = binaryReader.ReadVector3( );
            invalidName_ = binaryReader.ReadBytes( 4 );
            fourVectorsY = binaryReader.ReadVector3( );
            invalidName_0 = binaryReader.ReadBytes( 4 );
            fourVectorsZ = binaryReader.ReadVector3( );
            invalidName_1 = binaryReader.ReadBytes( 4 );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( fourVectorsX );
                binaryWriter.Write( invalidName_, 0, 4 );
                binaryWriter.Write( fourVectorsY );
                binaryWriter.Write( invalidName_0, 0, 4 );
                binaryWriter.Write( fourVectorsZ );
                binaryWriter.Write( invalidName_1, 0, 4 );
                return nextAddress;
            }
        }
    };
}