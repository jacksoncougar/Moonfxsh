// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ParticlesUpdateDataBlock : ParticlesUpdateDataBlockBase
    {
        public ParticlesUpdateDataBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 32, Alignment = 4 )]
    public class ParticlesUpdateDataBlockBase : IGuerilla
    {
        internal float velocityX;
        internal float velocityY;
        internal float velocityZ;
        internal byte[] invalidName_;
        internal float mass;
        internal float creationTimeStamp;

        internal ParticlesUpdateDataBlockBase( BinaryReader binaryReader )
        {
            velocityX = binaryReader.ReadSingle( );
            velocityY = binaryReader.ReadSingle( );
            velocityZ = binaryReader.ReadSingle( );
            invalidName_ = binaryReader.ReadBytes( 12 );
            mass = binaryReader.ReadSingle( );
            creationTimeStamp = binaryReader.ReadSingle( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( velocityX );
                binaryWriter.Write( velocityY );
                binaryWriter.Write( velocityZ );
                binaryWriter.Write( invalidName_, 0, 12 );
                binaryWriter.Write( mass );
                binaryWriter.Write( creationTimeStamp );
                return nextAddress;
            }
        }
    };
}