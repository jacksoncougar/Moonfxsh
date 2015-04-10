// ReSharper disable All
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
        public  ScenarioClusterDataBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  ScenarioClusterDataBlockBase(System.IO.BinaryReader binaryReader)
        {
            bSP = binaryReader.ReadTagReference();
            ReadScenarioClusterBackgroundSoundsBlockArray(binaryReader);
            ReadScenarioClusterSoundEnvironmentsBlockArray(binaryReader);
            bSPChecksum = binaryReader.ReadInt32();
            ReadScenarioClusterPointsBlockArray(binaryReader);
            ReadScenarioClusterWeatherPropertiesBlockArray(binaryReader);
            ReadScenarioClusterAtmosphericFogPropertiesBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
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
        internal  virtual ScenarioClusterBackgroundSoundsBlock[] ReadScenarioClusterBackgroundSoundsBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual ScenarioClusterSoundEnvironmentsBlock[] ReadScenarioClusterSoundEnvironmentsBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual ScenarioClusterPointsBlock[] ReadScenarioClusterPointsBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual ScenarioClusterWeatherPropertiesBlock[] ReadScenarioClusterWeatherPropertiesBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual ScenarioClusterAtmosphericFogPropertiesBlock[] ReadScenarioClusterAtmosphericFogPropertiesBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioClusterBackgroundSoundsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioClusterSoundEnvironmentsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioClusterPointsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioClusterWeatherPropertiesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioClusterAtmosphericFogPropertiesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(bSP);
                WriteScenarioClusterBackgroundSoundsBlockArray(binaryWriter);
                WriteScenarioClusterSoundEnvironmentsBlockArray(binaryWriter);
                binaryWriter.Write(bSPChecksum);
                WriteScenarioClusterPointsBlockArray(binaryWriter);
                WriteScenarioClusterWeatherPropertiesBlockArray(binaryWriter);
                WriteScenarioClusterAtmosphericFogPropertiesBlockArray(binaryWriter);
            }
        }
    };
}
