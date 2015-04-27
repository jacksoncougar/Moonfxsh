// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class UserHintClimbBlock : UserHintClimbBlockBase
    {
        public UserHintClimbBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 4, Alignment = 4 )]
    public class UserHintClimbBlockBase : GuerillaBlock
    {
        internal Flags flags;
        internal Moonfish.Tags.ShortBlockIndex1 geometryIndex;

        public override int SerializedSize
        {
            get { return 4; }
        }

        internal UserHintClimbBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            flags = ( Flags ) binaryReader.ReadInt16( );
            geometryIndex = binaryReader.ReadShortBlockIndex1( );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( ( Int16 ) flags );
                binaryWriter.Write( geometryIndex );
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum Flags : short
        {
            Bidirectional = 1,
            Closed = 2,
        };
    };
}