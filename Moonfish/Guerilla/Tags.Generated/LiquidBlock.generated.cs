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
    [TagClassAttribute("tdtl")]
    [TagBlockOriginalNameAttribute("liquid_block")]
    public partial class LiquidBlock : GuerillaBlock, IWriteQueueable
    {
        private byte[] fieldpad = new byte[2];
        public TypeEnum Type;
        public Moonfish.Tags.StringIdent AttachmentMarkerName;
        private byte[] fieldpad0 = new byte[56];
        public float FalloffDistanceFromCamera;
        public float CutoffDistanceFromCamera;
        private byte[] fieldpad1 = new byte[32];
        public LiquidArcBlock[] Arcs = new LiquidArcBlock[0];
        public override int SerializedSize
        {
            get
            {
                return 112;
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
            this.fieldpad = binaryReader.ReadBytes(2);
            this.Type = ((TypeEnum)(binaryReader.ReadInt16()));
            this.AttachmentMarkerName = binaryReader.ReadStringIdent();
            this.fieldpad0 = binaryReader.ReadBytes(56);
            this.FalloffDistanceFromCamera = binaryReader.ReadSingle();
            this.CutoffDistanceFromCamera = binaryReader.ReadSingle();
            this.fieldpad1 = binaryReader.ReadBytes(32);
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(236));
            return pointerQueue;
        }
        public override void ReadInstances(Moonfish.Guerilla.BlamBinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.Arcs = base.ReadBlockArrayData<LiquidArcBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            queueableBinaryWriter.QueueWrite(this.Arcs);
        }
        public override void Write(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBinaryWriter)
        {
            base.Write(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.Write(((short)(this.Type)));
            queueableBinaryWriter.Write(this.AttachmentMarkerName);
            queueableBinaryWriter.Write(this.fieldpad0);
            queueableBinaryWriter.Write(this.FalloffDistanceFromCamera);
            queueableBinaryWriter.Write(this.CutoffDistanceFromCamera);
            queueableBinaryWriter.Write(this.fieldpad1);
            queueableBinaryWriter.WritePointer(this.Arcs);
        }
        public enum TypeEnum : short
        {
            Standard = 0,
            WeaponToProjectile = 1,
            ProjectileFromWeapon = 2,
        }
    }
}
namespace Moonfish.Tags
{
    
    public partial struct TagClass
    {
        public static TagClass Tdtl = ((TagClass)("tdtl"));
    }
}
