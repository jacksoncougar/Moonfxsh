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
    [TagClassAttribute("weat")]
    [TagBlockOriginalNameAttribute("weather_system_block")]
    public partial class WeatherSystemBlock : GuerillaBlock, IWriteDeferrable
    {
        public GlobalParticleSystemLiteBlock[] ParticleSystem = new GlobalParticleSystemLiteBlock[0];
        public GlobalWeatherBackgroundPlateBlock[] BackgroundPlates = new GlobalWeatherBackgroundPlateBlock[0];
        public GlobalWindModelStructBlock WindModel = new GlobalWindModelStructBlock();
        public float FadeRadius;
        public override int SerializedSize
        {
            get
            {
                return 176;
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
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(140));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(936));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.WindModel.ReadFields(binaryReader)));
            this.FadeRadius = binaryReader.ReadSingle();
            return pointerQueue;
        }
        public override void ReadInstances(Moonfish.Guerilla.BlamBinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.ParticleSystem = base.ReadBlockArrayData<GlobalParticleSystemLiteBlock>(binaryReader, pointerQueue.Dequeue());
            this.BackgroundPlates = base.ReadBlockArrayData<GlobalWeatherBackgroundPlateBlock>(binaryReader, pointerQueue.Dequeue());
            this.WindModel.ReadInstances(binaryReader, pointerQueue);
        }
        public override void DeferReferences(Moonfish.Guerilla.LinearBinaryWriter queueableBinaryWriter)
        {
            base.DeferReferences(queueableBinaryWriter);
            queueableBinaryWriter.Defer(this.ParticleSystem);
            queueableBinaryWriter.Defer(this.BackgroundPlates);
            this.WindModel.DeferReferences(queueableBinaryWriter);
        }
        public override void Write(Moonfish.Guerilla.LinearBinaryWriter queueableBinaryWriter)
        {
            base.Write(queueableBinaryWriter);
            queueableBinaryWriter.WritePointer(this.ParticleSystem);
            queueableBinaryWriter.WritePointer(this.BackgroundPlates);
            this.WindModel.Write(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.FadeRadius);
        }
    }
}
namespace Moonfish.Tags
{
    
    public partial struct TagClass
    {
        public static TagClass Weat = ((TagClass)("weat"));
    }
}
