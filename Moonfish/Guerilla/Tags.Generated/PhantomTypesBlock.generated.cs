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
    [TagBlockOriginalNameAttribute("phantom_types_block")]
    public partial class PhantomTypesBlock : GuerillaBlock, IWriteDeferrable
    {
        public Flags PhantomTypesFlags;
        public MinimumSizeEnum MinimumSize;
        public MaximumSizeEnum MaximumSize;
        private byte[] fieldpad = new byte[2];
        public Moonfish.Tags.StringIdent MarkerName;
        public Moonfish.Tags.StringIdent AlignmentMarkerName;
        /// <summary>
        /// 0 - means do nothing
        ///CENTER: motion towards marker position 
        ///AXIS: motion towards marker axis, such that object is on the axis
        ///DIRECTION: motion along marker direction
        /// </summary>
        private byte[] fieldpad0 = new byte[8];
        public float HookesLawE;
        public float LinearDeadRadius;
        public float CenterAcc;
        public float CenterMaxVel;
        public float AxisAcc;
        public float AxisMaxVel;
        public float DirectionAcc;
        public float DirectionMaxVel;
        private byte[] fieldpad1 = new byte[28];
        /// <summary>
        /// 0 - means do nothing
        ///ALIGNMENT: algin objects in the phantom with the marker
        ///SPIN: spin the object about the marker axis
        /// </summary>
        public float AlignmentHookesLawE;
        public float AlignmentAcc;
        public float AlignmentMaxVel;
        private byte[] fieldpad2 = new byte[8];
        public override int SerializedSize
        {
            get
            {
                return 104;
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
            this.PhantomTypesFlags = ((Flags)(binaryReader.ReadInt32()));
            this.MinimumSize = ((MinimumSizeEnum)(binaryReader.ReadByte()));
            this.MaximumSize = ((MaximumSizeEnum)(binaryReader.ReadByte()));
            this.fieldpad = binaryReader.ReadBytes(2);
            this.MarkerName = binaryReader.ReadStringIdent();
            this.AlignmentMarkerName = binaryReader.ReadStringIdent();
            this.fieldpad0 = binaryReader.ReadBytes(8);
            this.HookesLawE = binaryReader.ReadSingle();
            this.LinearDeadRadius = binaryReader.ReadSingle();
            this.CenterAcc = binaryReader.ReadSingle();
            this.CenterMaxVel = binaryReader.ReadSingle();
            this.AxisAcc = binaryReader.ReadSingle();
            this.AxisMaxVel = binaryReader.ReadSingle();
            this.DirectionAcc = binaryReader.ReadSingle();
            this.DirectionMaxVel = binaryReader.ReadSingle();
            this.fieldpad1 = binaryReader.ReadBytes(28);
            this.AlignmentHookesLawE = binaryReader.ReadSingle();
            this.AlignmentAcc = binaryReader.ReadSingle();
            this.AlignmentMaxVel = binaryReader.ReadSingle();
            this.fieldpad2 = binaryReader.ReadBytes(8);
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
            queueableBinaryWriter.Write(((int)(this.PhantomTypesFlags)));
            queueableBinaryWriter.Write(((byte)(this.MinimumSize)));
            queueableBinaryWriter.Write(((byte)(this.MaximumSize)));
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.Write(this.MarkerName);
            queueableBinaryWriter.Write(this.AlignmentMarkerName);
            queueableBinaryWriter.Write(this.fieldpad0);
            queueableBinaryWriter.Write(this.HookesLawE);
            queueableBinaryWriter.Write(this.LinearDeadRadius);
            queueableBinaryWriter.Write(this.CenterAcc);
            queueableBinaryWriter.Write(this.CenterMaxVel);
            queueableBinaryWriter.Write(this.AxisAcc);
            queueableBinaryWriter.Write(this.AxisMaxVel);
            queueableBinaryWriter.Write(this.DirectionAcc);
            queueableBinaryWriter.Write(this.DirectionMaxVel);
            queueableBinaryWriter.Write(this.fieldpad1);
            queueableBinaryWriter.Write(this.AlignmentHookesLawE);
            queueableBinaryWriter.Write(this.AlignmentAcc);
            queueableBinaryWriter.Write(this.AlignmentMaxVel);
            queueableBinaryWriter.Write(this.fieldpad2);
        }
        [System.FlagsAttribute()]
        public enum Flags : int
        {
            None = 0,
            GeneratesEffects = 1,
            UseAccAsForce = 2,
            NegatesGravity = 4,
            IgnoresPlayers = 8,
            IgnoresNonplayers = 16,
            IgnoresBipeds = 32,
            IgnoresVehicles = 64,
            IgnoresWeapons = 128,
            IgnoresEquipment = 256,
            IgnoresGarbage = 512,
            IgnoresProjectiles = 1024,
            IgnoresScenery = 2048,
            IgnoresMachines = 4096,
            IgnoresControls = 8192,
            IgnoresLightFixtures = 16384,
            IgnoresSoundScenery = 32768,
            IgnoresCrates = 65536,
            IgnoresCreatures = 131072,
            LocalizesPhysics = 16777216,
            DisableLinearDamping = 33554432,
            DisableAngularDamping = 67108864,
            IgnoresDeadBipeds = 134217728,
        }
        public enum MinimumSizeEnum : byte
        {
            Default = 0,
            Tiny = 1,
            Small = 2,
            Medium = 3,
            Large = 4,
            Huge = 5,
            ExtraHuge = 6,
        }
        public enum MaximumSizeEnum : byte
        {
            Default = 0,
            Tiny = 1,
            Small = 2,
            Medium = 3,
            Large = 4,
            Huge = 5,
            ExtraHuge = 6,
        }
    }
}
