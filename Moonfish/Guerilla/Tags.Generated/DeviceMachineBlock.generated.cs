//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Moonfish.Guerilla.Tags
{
    using JetBrains.Annotations;
    using Moonfish.Tags;
    using Moonfish.Model;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    
    [JetBrains.Annotations.UsedImplicitlyAttribute(ImplicitUseTargetFlags.WithMembers)]
    [TagClassAttribute("mach")]
    [TagBlockOriginalNameAttribute("device_machine_block")]
    public partial class DeviceMachineBlock : DeviceBlock, IWriteQueueable
    {
        public TypeEnum Type;
        public DeviceMachineFlags DeviceMachineDeviceMachineFlags;
        public float DoorOpenTime;
        public OpenTK.Vector2 DoorOcclusionBounds;
        public CollisionResponseEnum CollisionResponse;
        public short ElevatorNode;
        public PathfindingPolicyEnum PathfindingPolicy;
        private byte[] fieldpad4 = new byte[2];
        public override int SerializedSize
        {
            get
            {
                return 308;
            }
        }
        public override int Alignment
        {
            get
            {
                return 4;
            }
        }
        public override System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> ReadFields(Moonfish.Guerilla.BlamBinaryReader binaryReader)
        {
            System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(base.ReadFields(binaryReader));
            this.Type = ((TypeEnum)(binaryReader.ReadInt16()));
            this.DeviceMachineDeviceMachineFlags = ((DeviceMachineFlags)(binaryReader.ReadInt16()));
            this.DoorOpenTime = binaryReader.ReadSingle();
            this.DoorOcclusionBounds = binaryReader.ReadVector2();
            this.CollisionResponse = ((CollisionResponseEnum)(binaryReader.ReadInt16()));
            this.ElevatorNode = binaryReader.ReadInt16();
            this.PathfindingPolicy = ((PathfindingPolicyEnum)(binaryReader.ReadInt16()));
            this.fieldpad4 = binaryReader.ReadBytes(2);
            return pointerQueue;
        }
        public override void ReadInstances(Moonfish.Guerilla.BlamBinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
        }
        public override void Write(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBinaryWriter)
        {
            base.Write(queueableBinaryWriter);
            queueableBinaryWriter.Write(((short)(this.Type)));
            queueableBinaryWriter.Write(((short)(this.DeviceMachineDeviceMachineFlags)));
            queueableBinaryWriter.Write(this.DoorOpenTime);
            queueableBinaryWriter.Write(this.DoorOcclusionBounds);
            queueableBinaryWriter.Write(((short)(this.CollisionResponse)));
            queueableBinaryWriter.Write(this.ElevatorNode);
            queueableBinaryWriter.Write(((short)(this.PathfindingPolicy)));
            queueableBinaryWriter.Write(this.fieldpad4);
        }
        public enum TypeEnum : short
        {
            Door = 0,
            Platform = 1,
            Gear = 2,
        }
        [System.FlagsAttribute()]
        public enum DeviceMachineFlags : short
        {
            None = 0,
            PathfindingObstacle = 1,
            butNotWhenOpen = 2,
            ElevatorlightingBasedOnWhatsAroundRatherThanWhatsBelow = 4,
        }
        public enum CollisionResponseEnum : short
        {
            PauseUntilCrushed = 0,
            ReverseDirections = 1,
        }
        public enum PathfindingPolicyEnum : short
        {
            Discs = 0,
            Sectors = 1,
            CutOut = 2,
            None = 3,
        }
    }
}
namespace Moonfish.Tags
{
    
    public partial struct TagClass
    {
        public static TagClass Mach = ((TagClass)("mach"));
    }
}
