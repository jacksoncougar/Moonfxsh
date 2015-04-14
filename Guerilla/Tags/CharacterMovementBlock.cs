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
    [LayoutAttribute(Size = 36)]
    public class CharacterMovementBlockBase
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
            this.movementFlags = (MovementFlags)binaryReader.ReadInt32();
            this.pathfindingRadius = binaryReader.ReadSingle();
            this.destinationRadius = binaryReader.ReadSingle();
            this.diveGrenadeChance = binaryReader.ReadSingle();
            this.obstacleLeapMinSize = (ObstacleLeapMinSize)binaryReader.ReadInt16();
            this.obstacleLeapMaxSize = (ObstacleLeapMaxSize)binaryReader.ReadInt16();
            this.obstacleIgnoreSize = (ObstacleIgnoreSize)binaryReader.ReadInt16();
            this.obstacleSmashableSize = (ObstacleSmashableSize)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.jumpHeight = (JumpHeight)binaryReader.ReadInt16();
            this.movementHints = (MovementHints)binaryReader.ReadInt32();
            this.throttleScale = binaryReader.ReadSingle();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
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
