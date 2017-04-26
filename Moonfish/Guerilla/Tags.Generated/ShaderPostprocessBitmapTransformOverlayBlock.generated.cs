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
    [TagBlockOriginalNameAttribute("shader_postprocess_bitmap_transform_overlay_block")]
    public partial class ShaderPostprocessBitmapTransformOverlayBlock : GuerillaBlock, IWriteDeferrable
    {
        public byte ParameterIndex;
        public byte TransformIndex;
        public byte AnimationPropertyType;
        public Moonfish.Tags.StringIdent InputName;
        public Moonfish.Tags.StringIdent RangeName;
        public float TimePeriodInSeconds;
        public ScalarFunctionStructBlock Function = new ScalarFunctionStructBlock();
        public override int SerializedSize
        {
            get
            {
                return 23;
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
            this.ParameterIndex = binaryReader.ReadByte();
            this.TransformIndex = binaryReader.ReadByte();
            this.AnimationPropertyType = binaryReader.ReadByte();
            this.InputName = binaryReader.ReadStringIdent();
            this.RangeName = binaryReader.ReadStringIdent();
            this.TimePeriodInSeconds = binaryReader.ReadSingle();
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.Function.ReadFields(binaryReader)));
            return pointerQueue;
        }
        public override void ReadInstances(Moonfish.Guerilla.BlamBinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.Function.ReadInstances(binaryReader, pointerQueue);
        }
        public override void DeferReferences(Moonfish.Guerilla.LinearBinaryWriter queueableBinaryWriter)
        {
            base.DeferReferences(queueableBinaryWriter);
            this.Function.DeferReferences(queueableBinaryWriter);
        }
        public override void Write(Moonfish.Guerilla.LinearBinaryWriter queueableBinaryWriter)
        {
            base.Write(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.ParameterIndex);
            queueableBinaryWriter.Write(this.TransformIndex);
            queueableBinaryWriter.Write(this.AnimationPropertyType);
            queueableBinaryWriter.Write(this.InputName);
            queueableBinaryWriter.Write(this.RangeName);
            queueableBinaryWriter.Write(this.TimePeriodInSeconds);
            this.Function.Write(queueableBinaryWriter);
        }
    }
}
