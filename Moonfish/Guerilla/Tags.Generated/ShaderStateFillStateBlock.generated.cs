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
    [TagBlockOriginalNameAttribute("shader_state_fill_state_block")]
    public partial class ShaderStateFillStateBlock : GuerillaBlock, IWriteDeferrable
    {
        public Flags ShaderStateFillStateFlags;
        public FillModeEnum FillMode;
        public BackFillModeEnum BackFillMode;
        private byte[] fieldpad = new byte[2];
        public float LineWidth;
        public override int SerializedSize
        {
            get
            {
                return 12;
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
            this.ShaderStateFillStateFlags = ((Flags)(binaryReader.ReadInt16()));
            this.FillMode = ((FillModeEnum)(binaryReader.ReadInt16()));
            this.BackFillMode = ((BackFillModeEnum)(binaryReader.ReadInt16()));
            this.fieldpad = binaryReader.ReadBytes(2);
            this.LineWidth = binaryReader.ReadSingle();
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
            queueableBinaryWriter.Write(((short)(this.ShaderStateFillStateFlags)));
            queueableBinaryWriter.Write(((short)(this.FillMode)));
            queueableBinaryWriter.Write(((short)(this.BackFillMode)));
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.Write(this.LineWidth);
        }
        [System.FlagsAttribute()]
        public enum Flags : short
        {
            None = 0,
            FlatShading = 1,
            EdgeAntialiasing = 2,
        }
        public enum FillModeEnum : short
        {
            Solid = 0,
            Wireframe = 1,
            Points = 2,
        }
        public enum BackFillModeEnum : short
        {
            Solid = 0,
            Wireframe = 1,
            Points = 2,
        }
    }
}
