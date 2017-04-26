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
    [TagBlockOriginalNameAttribute("aim_assist_struct_block")]
    public partial class AimAssistStructBlock : GuerillaBlock, IWriteDeferrable
    {
        public float AutoaimAngle;
        public float AutoaimRange;
        public float MagnetismAngle;
        public float MagnetismRange;
        public float DeviationAngle;
        private byte[] fieldpad = new byte[4];
        private byte[] fieldpad0 = new byte[12];
        public override int SerializedSize
        {
            get
            {
                return 36;
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
            this.AutoaimAngle = binaryReader.ReadSingle();
            this.AutoaimRange = binaryReader.ReadSingle();
            this.MagnetismAngle = binaryReader.ReadSingle();
            this.MagnetismRange = binaryReader.ReadSingle();
            this.DeviationAngle = binaryReader.ReadSingle();
            this.fieldpad = binaryReader.ReadBytes(4);
            this.fieldpad0 = binaryReader.ReadBytes(12);
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
            queueableBinaryWriter.Write(this.AutoaimAngle);
            queueableBinaryWriter.Write(this.AutoaimRange);
            queueableBinaryWriter.Write(this.MagnetismAngle);
            queueableBinaryWriter.Write(this.MagnetismRange);
            queueableBinaryWriter.Write(this.DeviationAngle);
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.Write(this.fieldpad0);
        }
    }
}
