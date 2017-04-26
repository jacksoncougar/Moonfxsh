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
    [TagBlockOriginalNameAttribute("platform_sound_effect_function_block")]
    public partial class PlatformSoundEffectFunctionBlock : GuerillaBlock, IWriteDeferrable
    {
        public InputEnum Input;
        public RangeEnum Range;
        public MappingFunctionBlock Function = new MappingFunctionBlock();
        public float TimePeriod;
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
            this.Input = ((InputEnum)(binaryReader.ReadInt16()));
            this.Range = ((RangeEnum)(binaryReader.ReadInt16()));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.Function.ReadFields(binaryReader)));
            this.TimePeriod = binaryReader.ReadSingle();
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
            queueableBinaryWriter.Write(((short)(this.Input)));
            queueableBinaryWriter.Write(((short)(this.Range)));
            this.Function.Write(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.TimePeriod);
        }
        public enum InputEnum : short
        {
            Zero = 0,
            Time = 1,
            Scale = 2,
            Rolloff = 3,
        }
        public enum RangeEnum : short
        {
            Zero = 0,
            Time = 1,
            Scale = 2,
            Rolloff = 3,
        }
    }
}
