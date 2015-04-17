// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ModelTargetLockOnDataStructBlock : ModelTargetLockOnDataStructBlockBase
    {
        public ModelTargetLockOnDataStructBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 8, Alignment = 4 )]
    public class ModelTargetLockOnDataStructBlockBase : IGuerilla
    {
        internal Flags flags;
        internal float lockOnDistance;

        internal ModelTargetLockOnDataStructBlockBase( BinaryReader binaryReader )
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
            LockedByHumanTracking = 1,
            LockedByPlasmaTracking = 2,
            Headshot = 4,
            Vulnerable = 8,
            AlwasLockedByPlasmaTracking = 16,
        };
    };
}