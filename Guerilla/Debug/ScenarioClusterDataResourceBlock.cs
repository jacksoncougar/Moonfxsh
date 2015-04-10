// ReSharper disable All
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
        public  ScenarioClusterDataResourceBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  ScenarioClusterDataResourceBlockBase(System.IO.BinaryReader binaryReader)
        {
            ReadScenarioClusterDataBlockArray(binaryReader);
            ReadStructureBspBackgroundSoundPaletteBlockArray(binaryReader);
            ReadStructureBspSoundEnvironmentPaletteBlockArray(binaryReader);
            ReadStructureBspWeatherPaletteBlockArray(binaryReader);
            ReadScenarioAtmosphericFogPaletteArray(binaryReader);
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
        internal  virtual ScenarioClusterDataBlock[] ReadScenarioClusterDataBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioClusterDataBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioClusterDataBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioClusterDataBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual StructureBspBackgroundSoundPaletteBlock[] ReadStructureBspBackgroundSoundPaletteBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspBackgroundSoundPaletteBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspBackgroundSoundPaletteBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspBackgroundSoundPaletteBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual StructureBspSoundEnvironmentPaletteBlock[] ReadStructureBspSoundEnvironmentPaletteBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspSoundEnvironmentPaletteBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspSoundEnvironmentPaletteBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspSoundEnvironmentPaletteBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual StructureBspWeatherPaletteBlock[] ReadStructureBspWeatherPaletteBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureBspWeatherPaletteBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureBspWeatherPaletteBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureBspWeatherPaletteBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioAtmosphericFogPalette[] ReadScenarioAtmosphericFogPaletteArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioAtmosphericFogPalette));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioAtmosphericFogPalette[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioAtmosphericFogPalette(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioClusterDataBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteStructureBspBackgroundSoundPaletteBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteStructureBspSoundEnvironmentPaletteBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteStructureBspWeatherPaletteBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioAtmosphericFogPaletteArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                WriteScenarioClusterDataBlockArray(binaryWriter);
                WriteStructureBspBackgroundSoundPaletteBlockArray(binaryWriter);
                WriteStructureBspSoundEnvironmentPaletteBlockArray(binaryWriter);
                WriteStructureBspWeatherPaletteBlockArray(binaryWriter);
                WriteScenarioAtmosphericFogPaletteArray(binaryWriter);
            }
        }
    };
}
