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
    [TagBlockOriginalNameAttribute("effect_part_block")]
    public partial class EffectPartBlock : GuerillaBlock, IWriteDeferrable
    {
        public CreateInEnum CreateIn;
        public EffectPartCreateInEnum EffectPartEffectPartCreateIn;
        public Moonfish.Tags.ShortBlockIndex1 Location;
        public Flags EffectPartFlags;
        private byte[] fieldpad = new byte[4];
        [Moonfish.Tags.TagReferenceAttribute("null")]
        public Moonfish.Tags.TagReference Type;
        public Moonfish.Model.Range VelocityBounds;
        public float VelocityConeAngle;
        public Moonfish.Model.Range AngularVelocityBounds;
        public Moonfish.Model.Range RadiusModifierBounds;
        public AScalesValues EffectPartAScalesValues;
        public BScalesValues EffectPartBScalesValues;
        public override int SerializedSize
        {
            get
            {
                return 56;
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
            this.CreateIn = ((CreateInEnum)(binaryReader.ReadInt16()));
            this.EffectPartEffectPartCreateIn = ((EffectPartCreateInEnum)(binaryReader.ReadInt16()));
            this.Location = binaryReader.ReadShortBlockIndex1();
            this.EffectPartFlags = ((Flags)(binaryReader.ReadInt16()));
            this.fieldpad = binaryReader.ReadBytes(4);
            this.Type = binaryReader.ReadTagReference();
            this.VelocityBounds = binaryReader.ReadRange();
            this.VelocityConeAngle = binaryReader.ReadSingle();
            this.AngularVelocityBounds = binaryReader.ReadRange();
            this.RadiusModifierBounds = binaryReader.ReadRange();
            this.EffectPartAScalesValues = ((AScalesValues)(binaryReader.ReadInt32()));
            this.EffectPartBScalesValues = ((BScalesValues)(binaryReader.ReadInt32()));
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
            queueableBinaryWriter.Write(((short)(this.CreateIn)));
            queueableBinaryWriter.Write(((short)(this.EffectPartEffectPartCreateIn)));
            queueableBinaryWriter.Write(this.Location);
            queueableBinaryWriter.Write(((short)(this.EffectPartFlags)));
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.Write(this.Type);
            queueableBinaryWriter.Write(this.VelocityBounds);
            queueableBinaryWriter.Write(this.VelocityConeAngle);
            queueableBinaryWriter.Write(this.AngularVelocityBounds);
            queueableBinaryWriter.Write(this.RadiusModifierBounds);
            queueableBinaryWriter.Write(((int)(this.EffectPartAScalesValues)));
            queueableBinaryWriter.Write(((int)(this.EffectPartBScalesValues)));
        }
        public enum CreateInEnum : short
        {
            AnyEnvironment = 0,
            AirOnly = 1,
            WaterOnly = 2,
            SpaceOnly = 3,
        }
        public enum EffectPartCreateInEnum : short
        {
            EitherMode = 0,
            ViolentModeOnly = 1,
            NonviolentModeOnly = 2,
        }
        [System.FlagsAttribute()]
        public enum Flags : short
        {
            None = 0,
            FaceDownRegardlessOfLocationdecals = 1,
            OffsetOriginAwayFromGeometrylights = 2,
            NeverAttachedToObject = 4,
            DisabledForDebugging = 8,
            DrawRegardlessOfDistance = 16,
        }
        [System.FlagsAttribute()]
        public enum AScalesValues : int
        {
            None = 0,
            Velocity = 1,
            VelocityDelta = 2,
            VelocityConeAngle = 4,
            AngularVelocity = 8,
            AngularVelocityDelta = 16,
            TypespecificScale = 32,
        }
        [System.FlagsAttribute()]
        public enum BScalesValues : int
        {
            None = 0,
            Velocity = 1,
            VelocityDelta = 2,
            VelocityConeAngle = 4,
            AngularVelocity = 8,
            AngularVelocityDelta = 16,
            TypespecificScale = 32,
        }
    }
}
