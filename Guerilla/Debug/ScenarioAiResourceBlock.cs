// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("ai**")]
    public  partial class ScenarioAiResourceBlock : ScenarioAiResourceBlockBase
    {
        public  ScenarioAiResourceBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 152)]
    public class ScenarioAiResourceBlockBase
    {
        internal StylePaletteBlock[] stylePalette;
        internal SquadGroupsBlock[] squadGroups;
        internal SquadsBlock[] squads;
        internal ZoneBlock[] zones;
        internal CharacterPaletteBlock[] characterPalette;
        internal AiAnimationReferenceBlock[] aIAnimationReferences;
        internal AiScriptReferenceBlock[] aIScriptReferences;
        internal AiRecordingReferenceBlock[] aIRecordingReferences;
        internal AiConversationBlock[] aIConversations;
        internal CsScriptDataBlock[] scriptingData;
        internal OrdersBlock[] orders;
        internal TriggersBlock[] triggers;
        internal ScenarioStructureBspReferenceBlock[] bSPPreferences;
        internal ScenarioWeaponPaletteBlock[] weaponReferences;
        internal ScenarioVehiclePaletteBlock[] vehicleReferences;
        internal ScenarioVehicleBlock[] vehicleDatumReferences;
        internal AiSceneBlock[] missionDialogueScenes;
        internal FlockDefinitionBlock[] flocks;
        internal ScenarioTriggerVolumeBlock[] triggerVolumeReferences;
        internal  ScenarioAiResourceBlockBase(System.IO.BinaryReader binaryReader)
        {
            ReadStylePaletteBlockArray(binaryReader);
            ReadSquadGroupsBlockArray(binaryReader);
            ReadSquadsBlockArray(binaryReader);
            ReadZoneBlockArray(binaryReader);
            ReadCharacterPaletteBlockArray(binaryReader);
            ReadAiAnimationReferenceBlockArray(binaryReader);
            ReadAiScriptReferenceBlockArray(binaryReader);
            ReadAiRecordingReferenceBlockArray(binaryReader);
            ReadAiConversationBlockArray(binaryReader);
            ReadCsScriptDataBlockArray(binaryReader);
            ReadOrdersBlockArray(binaryReader);
            ReadTriggersBlockArray(binaryReader);
            ReadScenarioStructureBspReferenceBlockArray(binaryReader);
            ReadScenarioWeaponPaletteBlockArray(binaryReader);
            ReadScenarioVehiclePaletteBlockArray(binaryReader);
            ReadScenarioVehicleBlockArray(binaryReader);
            ReadAiSceneBlockArray(binaryReader);
            ReadFlockDefinitionBlockArray(binaryReader);
            ReadScenarioTriggerVolumeBlockArray(binaryReader);
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
        internal  virtual StylePaletteBlock[] ReadStylePaletteBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StylePaletteBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StylePaletteBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StylePaletteBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual SquadGroupsBlock[] ReadSquadGroupsBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SquadGroupsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SquadGroupsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SquadGroupsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual SquadsBlock[] ReadSquadsBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SquadsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SquadsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SquadsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ZoneBlock[] ReadZoneBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ZoneBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ZoneBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ZoneBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CharacterPaletteBlock[] ReadCharacterPaletteBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CharacterPaletteBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CharacterPaletteBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CharacterPaletteBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual AiAnimationReferenceBlock[] ReadAiAnimationReferenceBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(AiAnimationReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new AiAnimationReferenceBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new AiAnimationReferenceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual AiScriptReferenceBlock[] ReadAiScriptReferenceBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(AiScriptReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new AiScriptReferenceBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new AiScriptReferenceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual AiRecordingReferenceBlock[] ReadAiRecordingReferenceBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(AiRecordingReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new AiRecordingReferenceBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new AiRecordingReferenceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual AiConversationBlock[] ReadAiConversationBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(AiConversationBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new AiConversationBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new AiConversationBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CsScriptDataBlock[] ReadCsScriptDataBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CsScriptDataBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CsScriptDataBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CsScriptDataBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual OrdersBlock[] ReadOrdersBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(OrdersBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new OrdersBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new OrdersBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual TriggersBlock[] ReadTriggersBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(TriggersBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new TriggersBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new TriggersBlock(binaryReader);
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
        internal  virtual ScenarioWeaponPaletteBlock[] ReadScenarioWeaponPaletteBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioWeaponPaletteBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioWeaponPaletteBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioWeaponPaletteBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioVehiclePaletteBlock[] ReadScenarioVehiclePaletteBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioVehiclePaletteBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioVehiclePaletteBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioVehiclePaletteBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioVehicleBlock[] ReadScenarioVehicleBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioVehicleBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioVehicleBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioVehicleBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual AiSceneBlock[] ReadAiSceneBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(AiSceneBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new AiSceneBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new AiSceneBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual FlockDefinitionBlock[] ReadFlockDefinitionBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(FlockDefinitionBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new FlockDefinitionBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new FlockDefinitionBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioTriggerVolumeBlock[] ReadScenarioTriggerVolumeBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioTriggerVolumeBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioTriggerVolumeBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioTriggerVolumeBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteStylePaletteBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteSquadGroupsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteSquadsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteZoneBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteCharacterPaletteBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteAiAnimationReferenceBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteAiScriptReferenceBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteAiRecordingReferenceBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteAiConversationBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteCsScriptDataBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteOrdersBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteTriggersBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioStructureBspReferenceBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioWeaponPaletteBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioVehiclePaletteBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioVehicleBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteAiSceneBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteFlockDefinitionBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioTriggerVolumeBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                WriteStylePaletteBlockArray(binaryWriter);
                WriteSquadGroupsBlockArray(binaryWriter);
                WriteSquadsBlockArray(binaryWriter);
                WriteZoneBlockArray(binaryWriter);
                WriteCharacterPaletteBlockArray(binaryWriter);
                WriteAiAnimationReferenceBlockArray(binaryWriter);
                WriteAiScriptReferenceBlockArray(binaryWriter);
                WriteAiRecordingReferenceBlockArray(binaryWriter);
                WriteAiConversationBlockArray(binaryWriter);
                WriteCsScriptDataBlockArray(binaryWriter);
                WriteOrdersBlockArray(binaryWriter);
                WriteTriggersBlockArray(binaryWriter);
                WriteScenarioStructureBspReferenceBlockArray(binaryWriter);
                WriteScenarioWeaponPaletteBlockArray(binaryWriter);
                WriteScenarioVehiclePaletteBlockArray(binaryWriter);
                WriteScenarioVehicleBlockArray(binaryWriter);
                WriteAiSceneBlockArray(binaryWriter);
                WriteFlockDefinitionBlockArray(binaryWriter);
                WriteScenarioTriggerVolumeBlockArray(binaryWriter);
            }
        }
    };
}
