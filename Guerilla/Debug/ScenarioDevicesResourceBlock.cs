// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("dgr*")]
    public  partial class ScenarioDevicesResourceBlock : ScenarioDevicesResourceBlockBase
    {
        public  ScenarioDevicesResourceBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 100)]
    public class ScenarioDevicesResourceBlockBase
    {
        internal ScenarioObjectNamesBlock[] names;
        internal DontUseMeScenarioEnvironmentObjectBlock[] invalidName_;
        internal ScenarioStructureBspReferenceBlock[] structureReferences;
        internal DeviceGroupBlock[] deviceGroups;
        internal ScenarioMachineBlock[] machines;
        internal ScenarioMachinePaletteBlock[] machinesPalette;
        internal ScenarioControlBlock[] controls;
        internal ScenarioControlPaletteBlock[] controlsPalette;
        internal ScenarioLightFixtureBlock[] lightFixtures;
        internal ScenarioLightFixturePaletteBlock[] lightFixturesPalette;
        internal int nextMachineIdSalt;
        internal int nextControlIDSalt;
        internal int nextLightFixtureIDSalt;
        internal GScenarioEditorFolderBlock[] editorFolders;
        internal  ScenarioDevicesResourceBlockBase(System.IO.BinaryReader binaryReader)
        {
            ReadScenarioObjectNamesBlockArray(binaryReader);
            ReadDontUseMeScenarioEnvironmentObjectBlockArray(binaryReader);
            ReadScenarioStructureBspReferenceBlockArray(binaryReader);
            ReadDeviceGroupBlockArray(binaryReader);
            ReadScenarioMachineBlockArray(binaryReader);
            ReadScenarioMachinePaletteBlockArray(binaryReader);
            ReadScenarioControlBlockArray(binaryReader);
            ReadScenarioControlPaletteBlockArray(binaryReader);
            ReadScenarioLightFixtureBlockArray(binaryReader);
            ReadScenarioLightFixturePaletteBlockArray(binaryReader);
            nextMachineIdSalt = binaryReader.ReadInt32();
            nextControlIDSalt = binaryReader.ReadInt32();
            nextLightFixtureIDSalt = binaryReader.ReadInt32();
            ReadGScenarioEditorFolderBlockArray(binaryReader);
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
        internal  virtual ScenarioObjectNamesBlock[] ReadScenarioObjectNamesBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioObjectNamesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioObjectNamesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioObjectNamesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual DontUseMeScenarioEnvironmentObjectBlock[] ReadDontUseMeScenarioEnvironmentObjectBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(DontUseMeScenarioEnvironmentObjectBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new DontUseMeScenarioEnvironmentObjectBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new DontUseMeScenarioEnvironmentObjectBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioStructureBspReferenceBlock[] ReadScenarioStructureBspReferenceBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioStructureBspReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioStructureBspReferenceBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioStructureBspReferenceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual DeviceGroupBlock[] ReadDeviceGroupBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(DeviceGroupBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new DeviceGroupBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new DeviceGroupBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioMachineBlock[] ReadScenarioMachineBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioMachineBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioMachineBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioMachineBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioMachinePaletteBlock[] ReadScenarioMachinePaletteBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioMachinePaletteBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioMachinePaletteBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioMachinePaletteBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioControlBlock[] ReadScenarioControlBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioControlBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioControlBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioControlBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioControlPaletteBlock[] ReadScenarioControlPaletteBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioControlPaletteBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioControlPaletteBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioControlPaletteBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioLightFixtureBlock[] ReadScenarioLightFixtureBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioLightFixtureBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioLightFixtureBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioLightFixtureBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioLightFixturePaletteBlock[] ReadScenarioLightFixturePaletteBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioLightFixturePaletteBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioLightFixturePaletteBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioLightFixturePaletteBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GScenarioEditorFolderBlock[] ReadGScenarioEditorFolderBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GScenarioEditorFolderBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GScenarioEditorFolderBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GScenarioEditorFolderBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioObjectNamesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteDontUseMeScenarioEnvironmentObjectBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioStructureBspReferenceBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteDeviceGroupBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioMachineBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioMachinePaletteBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioControlBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioControlPaletteBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioLightFixtureBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioLightFixturePaletteBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGScenarioEditorFolderBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                WriteScenarioObjectNamesBlockArray(binaryWriter);
                WriteDontUseMeScenarioEnvironmentObjectBlockArray(binaryWriter);
                WriteScenarioStructureBspReferenceBlockArray(binaryWriter);
                WriteDeviceGroupBlockArray(binaryWriter);
                WriteScenarioMachineBlockArray(binaryWriter);
                WriteScenarioMachinePaletteBlockArray(binaryWriter);
                WriteScenarioControlBlockArray(binaryWriter);
                WriteScenarioControlPaletteBlockArray(binaryWriter);
                WriteScenarioLightFixtureBlockArray(binaryWriter);
                WriteScenarioLightFixturePaletteBlockArray(binaryWriter);
                binaryWriter.Write(nextMachineIdSalt);
                binaryWriter.Write(nextControlIDSalt);
                binaryWriter.Write(nextLightFixtureIDSalt);
                WriteGScenarioEditorFolderBlockArray(binaryWriter);
            }
        }
    };
}
