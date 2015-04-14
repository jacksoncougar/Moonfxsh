// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class CharacterMovementBlock : CharacterMovementBlockBase
    {
        public  CharacterMovementBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 36, Alignment = 4)]
    public class CharacterMovementBlockBase  : IGuerilla
    {
        internal MovementFlags movementFlags;
        internal float pathfindingRadius;
        internal float destinationRadius;
        internal float diveGrenadeChance;
        internal ObstacleLeapMinSize obstacleLeapMinSize;
        internal ObstacleLeapMaxSize obstacleLeapMaxSize;
        internal ObstacleIgnoreSize obstacleIgnoreSize;
        internal ObstacleSmashableSize obstacleSmashableSize;
        internal byte[] invalidName_;
        internal JumpHeight jumpHeight;
        internal MovementHints movementHints;
        internal float throttleScale;
        internal  CharacterMovementBlockBase(BinaryReader binaryReader)
        {
            movementFlags = (MovementFlags)binaryReader.ReadInt32();
            pathfindingRadius = binaryReader.ReadSingle();
            destinationRadius = binaryReader.ReadSingle();
            diveGrenadeChance = binaryReader.ReadSingle();
            obstacleLeapMinSize = (ObstacleLeapMinSize)binaryReader.ReadInt16();
            obstacleLeapMaxSize = (ObstacleLeapMaxSize)binaryReader.ReadInt16();
            obstacleIgnoreSize = (ObstacleIgnoreSize)binaryReader.ReadInt16();
            obstacleSmashableSize = (ObstacleSmashableSize)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            jumpHeight = (JumpHeight)binaryReader.ReadInt16();
            movementHints = (MovementHints)binaryReader.ReadInt32();
            throttleScale = binaryReader.ReadSingle();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)movementFlags);
                binaryWriter.Write(pathfindingRadius);
                binaryWriter.Write(destinationRadius);
                binaryWriter.Write(diveGrenadeChance);
                binaryWriter.Write((Int16)obstacleLeapMinSize);
                binaryWriter.Write((Int16)obstacleLeapMaxSize);
                binaryWriter.Write((Int16)obstacleIgnoreSize);
                binaryWriter.Write((Int16)obstacleSmashableSize);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write((Int16)jumpHeight);
                binaryWriter.Write((Int32)movementHints);
                binaryWriter.Write(throttleScale);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
        [FlagsAttribute]
        internal enum MovementFlags : int
        {
            DangerCrouchAllowMovement = 1,
            NoSideStep = 2,
            PreferToCombarNearFriends = 4,
            HopToCoverPathSegements = 8,
            Perch = 16,
            HasFlyingMode = 32,
            DisallowCrouch = 64,
        };
        internal enum ObstacleLeapMinSize : short
        {
            None = 0,
            Tiny = 1,
            Small = 2,
            Medium = 3,
            Large = 4,
            Huge = 5,
            Immobile = 6,
        };
        internal enum ObstacleLeapMaxSize : short
        {
            None = 0,
            Tiny = 1,
            Small = 2,
            Medium = 3,
            Large = 4,
            Huge = 5,
            Immobile = 6,
        };
        internal enum ObstacleIgnoreSize : short
        {
            None = 0,
            Tiny = 1,
            Small = 2,
            Medium = 3,
            Large = 4,
            Huge = 5,
            Immobile = 6,
        };
        internal enum ObstacleSmashableSize : short
        {
            None = 0,
            Tiny = 1,
            Small = 2,
            Medium = 3,
            Large = 4,
            Huge = 5,
            Immobile = 6,
        };
        internal enum JumpHeight : short
        {
            NONE = 0,
            Down = 1,
            Step = 2,
            Crouch = 3,
            Stand = 4,
            Storey = 5,
            Tower = 6,
            Infinite = 7,
        };
        [FlagsAttribute]
        internal enum MovementHints : int
        {
            VaultStep = 1,
            VaultCrouch = 2,
            InvalidName = 4,
            InvalidName0 = 8,
            InvalidName1 = 16,
            MountStep = 32,
            MountCrouch = 64,
            MountStand = 128,
            InvalidName2 = 256,
            InvalidName3 = 512,
            InvalidName4 = 1024,
            HoistCrouch = 2048,
            HoistStand = 4096,
            InvalidName5 = 8192,
            InvalidName6 = 16384,
            InvalidName7 = 32768,
        };
    };
}
