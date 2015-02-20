using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ScenarioClusterDataBlock : ScenarioClusterDataBlockBase
    {
        public  ScenarioClusterDataBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 52)]
    public class ScenarioClusterDataBlockBase
    {
        [TagReference("sbsp")]
        internal Moonfish.Tags.TagReference bSP;
        internal ScenarioClusterBackgroundSoundsBlock[] backgroundSounds;
        internal ScenarioClusterSoundEnvironmentsBlock[] soundEnvironments;
        internal int bSPChecksum;
        internal ScenarioClusterPointsBlock[] clusterCentroids;
        internal ScenarioClusterWeatherPropertiesBlock[] weatherProperties;
        internal ScenarioClusterAtmosphericFogPropertiesBlock[] atmosphericFogProperties;
        internal  ScenarioClusterDataBlockBase(BinaryReader binaryReader)
        {
            this.bSP = binaryReader.ReadTagReference();
            this.backgroundSounds = ReadScenarioClusterBackgroundSoundsBlockArray(binaryReader);
            this.soundEnvironments = ReadScenarioClusterSoundEnvironmentsBlockArray(binaryReader);
            this.bSPChecksum = binaryReader.ReadInt32();
            this.clusterCentroids = ReadScenarioClusterPointsBlockArray(binaryReader);
            this.weatherProperties = ReadScenarioClusterWeatherPropertiesBlockArray(binaryReader);
            this.atmosphericFogProperties = ReadScenarioClusterAtmosphericFogPropertiesBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
        internal  virtual ScenarioClusterBackgroundSoundsBlock[] ReadScenarioClusterBackgroundSoundsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioClusterBackgroundSoundsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioClusterBackgroundSoundsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioClusterBackgroundSoundsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioClusterSoundEnvironmentsBlock[] ReadScenarioClusterSoundEnvironmentsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioClusterSoundEnvironmentsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioClusterSoundEnvironmentsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioClusterSoundEnvironmentsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioClusterPointsBlock[] ReadScenarioClusterPointsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioClusterPointsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioClusterPointsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioClusterPointsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioClusterWeatherPropertiesBlock[] ReadScenarioClusterWeatherPropertiesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioClusterWeatherPropertiesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioClusterWeatherPropertiesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioClusterWeatherPropertiesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioClusterAtmosphericFogPropertiesBlock[] ReadScenarioClusterAtmosphericFogPropertiesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioClusterAtmosphericFogPropertiesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioClusterAtmosphericFogPropertiesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioClusterAtmosphericFogPropertiesBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
