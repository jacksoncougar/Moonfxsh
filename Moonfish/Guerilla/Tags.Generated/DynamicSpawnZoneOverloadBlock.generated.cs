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
    [TagBlockOriginalNameAttribute("dynamic_spawn_zone_overload_block")]
    public partial class DynamicSpawnZoneOverloadBlock : GuerillaBlock, IWriteDeferrable
    {
        public OverloadTypeEnum OverloadType;
        private byte[] fieldpad = new byte[2];
        public float InnerRadius;
        public float OuterRadius;
        public float Weight;
        public override int SerializedSize
        {
            get
            {
                return 16;
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
            this.OverloadType = ((OverloadTypeEnum)(binaryReader.ReadInt16()));
            this.fieldpad = binaryReader.ReadBytes(2);
            this.InnerRadius = binaryReader.ReadSingle();
            this.OuterRadius = binaryReader.ReadSingle();
            this.Weight = binaryReader.ReadSingle();
            return pointerQueue;
        }
        public override void ReadInstances(Moonfish.Guerilla.BlamBinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
        }
        public override void DeferReferences(Moonfish.Guerilla.LinearBinaryWriter queueableBinaryWriter)
        {
            base.DeferReferences(queueableBinaryWriter);
        }
        public override void Write(Moonfish.Guerilla.LinearBinaryWriter queueableBinaryWriter)
        {
            base.Write(queueableBinaryWriter);
            queueableBinaryWriter.Write(((short)(this.OverloadType)));
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.Write(this.InnerRadius);
            queueableBinaryWriter.Write(this.OuterRadius);
            queueableBinaryWriter.Write(this.Weight);
        }
        public enum OverloadTypeEnum : short
        {
            Enemy = 0,
            Friend = 1,
            EnemyVehicle = 2,
            FriendlyVehicle = 3,
            EmptyVehicle = 4,
            OddballInclusion = 5,
            OddballExclusion = 6,
            HillInclusion = 7,
            HillExclusion = 8,
            LastRaceFlag = 9,
            DeadAlly = 10,
            ControlledTerritory = 11,
        }
    }
}
