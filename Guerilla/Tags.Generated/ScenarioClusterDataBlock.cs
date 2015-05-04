// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioClusterDataBlock : ScenarioClusterDataBlockBase
    {
        public ScenarioClusterDataBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 52, Alignment = 4)]
    public class ScenarioClusterDataBlockBase : GuerillaBlock
    {
        [TagReference("sbsp")]
        internal Moonfish.Tags.TagReference bSP;
        internal ScenarioClusterBackgroundSoundsBlock[] backgroundSounds;
        internal ScenarioClusterSoundEnvironmentsBlock[] soundEnvironments;
        internal int bSPChecksum;
        internal ScenarioClusterPointsBlock[] clusterCentroids;
        internal ScenarioClusterWeatherPropertiesBlock[] weatherProperties;
        internal ScenarioClusterAtmosphericFogPropertiesBlock[] atmosphericFogProperties;
        public override int SerializedSize { get { return 52; } }
        public override int Alignment { get { return 4; } }
        public ScenarioClusterDataBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            bSP = binaryReader.ReadTagReference();
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioClusterBackgroundSoundsBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioClusterSoundEnvironmentsBlock>(binaryReader));
            bSPChecksum = binaryReader.ReadInt32();
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioClusterPointsBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioClusterWeatherPropertiesBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioClusterAtmosphericFogPropertiesBlock>(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            backgroundSounds = ReadBlockArrayData<ScenarioClusterBackgroundSoundsBlock>(binaryReader, blamPointers.Dequeue());
            soundEnvironments = ReadBlockArrayData<ScenarioClusterSoundEnvironmentsBlock>(binaryReader, blamPointers.Dequeue());
            clusterCentroids = ReadBlockArrayData<ScenarioClusterPointsBlock>(binaryReader, blamPointers.Dequeue());
            weatherProperties = ReadBlockArrayData<ScenarioClusterWeatherPropertiesBlock>(binaryReader, blamPointers.Dequeue());
            atmosphericFogProperties = ReadBlockArrayData<ScenarioClusterAtmosphericFogPropertiesBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(bSP);
                nextAddress = Guerilla.WriteBlockArray<ScenarioClusterBackgroundSoundsBlock>(binaryWriter, backgroundSounds, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioClusterSoundEnvironmentsBlock>(binaryWriter, soundEnvironments, nextAddress);
                binaryWriter.Write(bSPChecksum);
                nextAddress = Guerilla.WriteBlockArray<ScenarioClusterPointsBlock>(binaryWriter, clusterCentroids, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioClusterWeatherPropertiesBlock>(binaryWriter, weatherProperties, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioClusterAtmosphericFogPropertiesBlock>(binaryWriter, atmosphericFogProperties, nextAddress);
                return nextAddress;
            }
        }
    };
}
