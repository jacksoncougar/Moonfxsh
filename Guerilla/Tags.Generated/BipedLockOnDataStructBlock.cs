// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class BipedLockOnDataStructBlock : BipedLockOnDataStructBlockBase
    {
        public BipedLockOnDataStructBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 8, Alignment = 4 )]
    public class BipedLockOnDataStructBlockBase : IGuerilla
    {
        internal Flags flags;
        internal float lockOnDistance;

        internal BipedLockOnDataStructBlockBase( BinaryReader binaryReader )
        {
            flags = ( Flags ) binaryReader.ReadInt32( );
            lockOnDistance = binaryReader.ReadSingle( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( ( Int32 ) flags );
                binaryWriter.Write( lockOnDistance );
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum Flags : int
        {
            LockedByHumanTargeting = 1,
            LockedByPlasmaTargeting = 2,
            AlwaysLockedByPlasmaTargeting = 4,
        };
    };
}