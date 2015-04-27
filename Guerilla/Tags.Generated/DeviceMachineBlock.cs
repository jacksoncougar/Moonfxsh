// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Mach = ( TagClass ) "mach";
    };
} ;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute( "mach" )]
    public partial class DeviceMachineBlock : DeviceMachineBlockBase
    {
        public DeviceMachineBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 24, Alignment = 4 )]
    public class DeviceMachineBlockBase : DeviceBlock
    {
        internal Type type;
        internal Flags flags;
        internal float doorOpenTimeSeconds;

        /// <summary>
        /// maps position [0,1] to occlusion
        /// </summary>
        internal OpenTK.Vector2 doorOcclusionBounds;

        internal CollisionResponse collisionResponse;
        internal short elevatorNode;
        internal PathfindingPolicy pathfindingPolicy;
        internal byte[] invalidName_;

        internal DeviceMachineBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            type = ( Type ) binaryReader.ReadInt16( );
            flags = ( Flags ) binaryReader.ReadInt16( );
            doorOpenTimeSeconds = binaryReader.ReadSingle( );
            doorOcclusionBounds = binaryReader.ReadVector2( );
            collisionResponse = ( CollisionResponse ) binaryReader.ReadInt16( );
            elevatorNode = binaryReader.ReadInt16( );
            pathfindingPolicy = ( PathfindingPolicy ) binaryReader.ReadInt16( );
            invalidName_ = binaryReader.ReadBytes( 2 );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( ( Int16 ) type );
                binaryWriter.Write( ( Int16 ) flags );
                binaryWriter.Write( doorOpenTimeSeconds );
                binaryWriter.Write( doorOcclusionBounds );
                binaryWriter.Write( ( Int16 ) collisionResponse );
                binaryWriter.Write( elevatorNode );
                binaryWriter.Write( ( Int16 ) pathfindingPolicy );
                binaryWriter.Write( invalidName_, 0, 2 );
                return nextAddress;
            }
        }

        internal enum Type : short
        {
            Door = 0,
            Platform = 1,
            Gear = 2,
        };

        [FlagsAttribute]
        internal enum Flags : short
        {
            PathfindingObstacle = 1,
            ButNotWhenOpen = 2,
            ElevatorLightingBasedOnWhatsAroundRatherThanWhatsBelow = 4,
        };

        internal enum CollisionResponse : short
        {
            PauseUntilCrushed = 0,
            ReverseDirections = 1,
        };

        internal enum PathfindingPolicy : short
        {
            Discs = 0,
            Sectors = 1,
            CutOut = 2,
            None = 3,
        };
    };
}