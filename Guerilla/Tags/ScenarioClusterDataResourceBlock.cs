using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("clu*")]
    public  partial class ScenarioClusterDataResourceBlock : ScenarioClusterDataResourceBlockBase
    {
        public  ScenarioClusterDataResourceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 40)]
    public class ScenarioClusterDataResourceBlockBase
    {
        internal ScenarioClusterDataBlock[] clusterData;
        internal StructureBspBackgroundSoundPaletteBlock[] backgroundSoundPalette;
        internal StructureBspSoundEnvironmentPaletteBlock[] soundEnvironmentPalette;
        internal StructureBspWeatherPaletteBlock[] weatherPalette;
        internal ScenarioAtmosphericFogPalette[] atmosphericFogPalette;
        internal  ScenarioClusterDataResourceBlockBase(BinaryReader binaryReader)
        {
            this.clusterData = ReadScenarioClusterDataBlockArray(binaryReader);
            this.backgroundSoundPalette = ReadStructureBspBackgroundSoundPaletteBlockArray(binaryReader);
            this.soundEnvironmentPalette = ReadStructureBspSoundEnvironmentPaletteBlockArray(binaryReader);
            this.weatherPalette = ReadStructureBspWeatherPaletteBlockArray(binaryReader);
            this.atmosphericFogPalette = ReadScenarioAtmosphericFogPaletteArray(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
        }
        internal  virtual ScenarioClusterDataBlock[] ReadScenarioClusterDataBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioClusterDataBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioClusterDataBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioClusterDataBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual StructureBspBackgroundSoundPaletteBlock[] ReadStructureBspBackgroundSoundPaletteBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspBackgroundSoundPaletteBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspBackgroundSoundPaletteBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspBackgroundSoundPaletteBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual StructureBspSoundEnvironmentPaletteBlock[] ReadStructureBspSoundEnvironmentPaletteBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspSoundEnvironmentPaletteBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspSoundEnvironmentPaletteBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspSoundEnvironmentPaletteBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual StructureBspWeatherPaletteBlock[] ReadStructureBspWeatherPaletteBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspWeatherPaletteBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspWeatherPaletteBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspWeatherPaletteBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioAtmosphericFogPalette[] ReadScenarioAtmosphericFogPaletteArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioAtmosphericFogPalette));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioAtmosphericFogPalette[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioAtmosphericFogPalette(binaryReader);
                }
            }
            return array;
        }
    };
}
