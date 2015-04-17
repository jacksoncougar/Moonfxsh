// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class UserHintRayBlock : UserHintRayBlockBase
    {
        public UserHintRayBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 28, Alignment = 4 )]
    public class UserHintRayBlockBase : IGuerilla
    {
        internal OpenTK.Vector3 point;
        internal short referenceFrame;
        internal byte[] invalidName_;
        internal OpenTK.Vector3 vector;

        internal UserHintRayBlockBase( BinaryReader binaryReader )
        {
            point = binaryReader.ReadVector3( );
            referenceFrame = binaryReader.ReadInt16( );
            invalidName_ = binaryReader.ReadBytes( 2 );
            vector = binaryReader.ReadVector3( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( point );
                binaryWriter.Write( referenceFrame );
                binaryWriter.Write( invalidName_, 0, 2 );
                binaryWriter.Write( vector );
                return nextAddress;
            }
        }
    };
}