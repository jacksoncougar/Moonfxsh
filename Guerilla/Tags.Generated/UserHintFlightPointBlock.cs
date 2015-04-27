// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class UserHintFlightPointBlock : UserHintFlightPointBlockBase
    {
        public UserHintFlightPointBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 12, Alignment = 4 )]
    public class UserHintFlightPointBlockBase : GuerillaBlock
    {
        internal OpenTK.Vector3 point;

        public override int SerializedSize
        {
            get { return 12; }
        }

        internal UserHintFlightPointBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            point = binaryReader.ReadVector3( );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( point );
                return nextAddress;
            }
        }
    };
}