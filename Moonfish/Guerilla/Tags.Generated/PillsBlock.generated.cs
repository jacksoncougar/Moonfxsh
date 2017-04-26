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
    [TagBlockOriginalNameAttribute("pills_block")]
    public partial class PillsBlock : GuerillaBlock, IWriteDeferrable
    {
        public Moonfish.Tags.StringIdent Name;
        public Moonfish.Tags.ShortBlockIndex1 Material;
        public Flags PillsFlags;
        public float RelativeMassScale;
        public float Friction;
        public float Restitution;
        public float Volume;
        public float Mass;
        private byte[] fieldskip = new byte[2];
        public Moonfish.Tags.ShortBlockIndex1 Phantom;
        private byte[] fieldskip0 = new byte[4];
        public short Size;
        public short Count;
        private byte[] fieldskip1 = new byte[4];
        public float Radius;
        public OpenTK.Vector3 Bottom;
        private byte[] fieldskip2 = new byte[4];
        public OpenTK.Vector3 Top;
        private byte[] fieldskip3 = new byte[4];
        public override int SerializedSize
        {
            get
            {
                return 80;
            }
        }
        public override int Alignment
        {
            get
            {
                return 16;
            }
        }
        public override System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> ReadFields(Moonfish.Guerilla.BlamBinaryReader binaryReader)
        {
            System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(base.ReadFields(binaryReader));
            this.Name = binaryReader.ReadStringIdent();
            this.Material = binaryReader.ReadShortBlockIndex1();
            this.PillsFlags = ((Flags)(binaryReader.ReadInt16()));
            this.RelativeMassScale = binaryReader.ReadSingle();
            this.Friction = binaryReader.ReadSingle();
            this.Restitution = binaryReader.ReadSingle();
            this.Volume = binaryReader.ReadSingle();
            this.Mass = binaryReader.ReadSingle();
            this.fieldskip = binaryReader.ReadBytes(2);
            this.Phantom = binaryReader.ReadShortBlockIndex1();
            this.fieldskip0 = binaryReader.ReadBytes(4);
            this.Size = binaryReader.ReadInt16();
            this.Count = binaryReader.ReadInt16();
            this.fieldskip1 = binaryReader.ReadBytes(4);
            this.Radius = binaryReader.ReadSingle();
            this.Bottom = binaryReader.ReadVector3();
            this.fieldskip2 = binaryReader.ReadBytes(4);
            this.Top = binaryReader.ReadVector3();
            this.fieldskip3 = binaryReader.ReadBytes(4);
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
            queueableBinaryWriter.Write(this.Name);
            queueableBinaryWriter.Write(this.Material);
            queueableBinaryWriter.Write(((short)(this.PillsFlags)));
            queueableBinaryWriter.Write(this.RelativeMassScale);
            queueableBinaryWriter.Write(this.Friction);
            queueableBinaryWriter.Write(this.Restitution);
            queueableBinaryWriter.Write(this.Volume);
            queueableBinaryWriter.Write(this.Mass);
            queueableBinaryWriter.Write(this.fieldskip);
            queueableBinaryWriter.Write(this.Phantom);
            queueableBinaryWriter.Write(this.fieldskip0);
            queueableBinaryWriter.Write(this.Size);
            queueableBinaryWriter.Write(this.Count);
            queueableBinaryWriter.Write(this.fieldskip1);
            queueableBinaryWriter.Write(this.Radius);
            queueableBinaryWriter.Write(this.Bottom);
            queueableBinaryWriter.Write(this.fieldskip2);
            queueableBinaryWriter.Write(this.Top);
            queueableBinaryWriter.Write(this.fieldskip3);
        }
        [System.FlagsAttribute()]
        public enum Flags : short
        {
            None = 0,
            Unused = 1,
        }
    }
}
