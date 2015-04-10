using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("mach")]
    public  partial class DeviceMachineBlock : DeviceMachineBlockBase
    {
        public  DeviceMachineBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 24)]
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
        internal  DeviceMachineBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            this.type = (Type)binaryReader.ReadInt16();
            this.flags = (Flags)binaryReader.ReadInt16();
            this.doorOpenTimeSeconds = binaryReader.ReadSingle();
            this.doorOcclusionBounds = binaryReader.ReadVector2();
            this.collisionResponse = (CollisionResponse)binaryReader.ReadInt16();
            this.elevatorNode = binaryReader.ReadInt16();
            this.pathfindingPolicy = (PathfindingPolicy)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
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
