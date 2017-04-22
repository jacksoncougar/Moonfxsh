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
    [TagClassAttribute("clu*")]
    [TagBlockOriginalNameAttribute("scenario_cluster_data_resource_block")]
    public partial class ScenarioClusterDataResourceBlock : GuerillaBlock, IWriteQueueable
    {
        public ScenarioClusterDataBlock[] ClusterData = new ScenarioClusterDataBlock[0];
        public StructureBspBackgroundSoundPaletteBlock[] BackgroundSoundPalette = new StructureBspBackgroundSoundPaletteBlock[0];
        public StructureBspSoundEnvironmentPaletteBlock[] SoundEnvironmentPalette = new StructureBspSoundEnvironmentPaletteBlock[0];
        public StructureBspWeatherPaletteBlock[] WeatherPalette = new StructureBspWeatherPaletteBlock[0];
        public ScenarioAtmosphericFogPalette[] AtmosphericFogPalette = new ScenarioAtmosphericFogPalette[0];
        public override int SerializedSize
        {
            get
            {
                return 40;
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
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(52));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(100));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(72));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(136));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(244));
            return pointerQueue;
        }
        public override void ReadInstances(Moonfish.Guerilla.BlamBinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.ClusterData = base.ReadBlockArrayData<ScenarioClusterDataBlock>(binaryReader, pointerQueue.Dequeue());
            this.BackgroundSoundPalette = base.ReadBlockArrayData<StructureBspBackgroundSoundPaletteBlock>(binaryReader, pointerQueue.Dequeue());
            this.SoundEnvironmentPalette = base.ReadBlockArrayData<StructureBspSoundEnvironmentPaletteBlock>(binaryReader, pointerQueue.Dequeue());
            this.WeatherPalette = base.ReadBlockArrayData<StructureBspWeatherPaletteBlock>(binaryReader, pointerQueue.Dequeue());
            this.AtmosphericFogPalette = base.ReadBlockArrayData<ScenarioAtmosphericFogPalette>(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            queueableBinaryWriter.QueueWrite(this.ClusterData);
            queueableBinaryWriter.QueueWrite(this.BackgroundSoundPalette);
            queueableBinaryWriter.QueueWrite(this.SoundEnvironmentPalette);
            queueableBinaryWriter.QueueWrite(this.WeatherPalette);
            queueableBinaryWriter.QueueWrite(this.AtmosphericFogPalette);
        }
        public override void Write(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBinaryWriter)
        {
            base.Write(queueableBinaryWriter);
            queueableBinaryWriter.WritePointer(this.ClusterData);
            queueableBinaryWriter.WritePointer(this.BackgroundSoundPalette);
            queueableBinaryWriter.WritePointer(this.SoundEnvironmentPalette);
            queueableBinaryWriter.WritePointer(this.WeatherPalette);
            queueableBinaryWriter.WritePointer(this.AtmosphericFogPalette);
        }
    }
}
namespace Moonfish.Tags
{
    
    public partial struct TagClass
    {
        public static TagClass Clu = ((TagClass)("clu*"));
    }
}
