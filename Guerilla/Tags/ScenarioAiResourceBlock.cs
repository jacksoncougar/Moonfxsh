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
        public  ScenarioAiResourceBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  ScenarioAiResourceBlockBase(BinaryReader binaryReader)
        {
            this.stylePalette = ReadStylePaletteBlockArray(binaryReader);
            this.squadGroups = ReadSquadGroupsBlockArray(binaryReader);
            this.squads = ReadSquadsBlockArray(binaryReader);
            this.zones = ReadZoneBlockArray(binaryReader);
            this.characterPalette = ReadCharacterPaletteBlockArray(binaryReader);
            this.aIAnimationReferences = ReadAiAnimationReferenceBlockArray(binaryReader);
            this.aIScriptReferences = ReadAiScriptReferenceBlockArray(binaryReader);
            this.aIRecordingReferences = ReadAiRecordingReferenceBlockArray(binaryReader);
            this.aIConversations = ReadAiConversationBlockArray(binaryReader);
            this.scriptingData = ReadCsScriptDataBlockArray(binaryReader);
            this.orders = ReadOrdersBlockArray(binaryReader);
            this.triggers = ReadTriggersBlockArray(binaryReader);
            this.bSPPreferences = ReadScenarioStructureBspReferenceBlockArray(binaryReader);
            this.weaponReferences = ReadScenarioWeaponPaletteBlockArray(binaryReader);
            this.vehicleReferences = ReadScenarioVehiclePaletteBlockArray(binaryReader);
            this.vehicleDatumReferences = ReadScenarioVehicleBlockArray(binaryReader);
            this.missionDialogueScenes = ReadAiSceneBlockArray(binaryReader);
            this.flocks = ReadFlockDefinitionBlockArray(binaryReader);
            this.triggerVolumeReferences = ReadScenarioTriggerVolumeBlockArray(binaryReader);
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
        internal  virtual StylePaletteBlock[] ReadStylePaletteBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StylePaletteBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StylePaletteBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StylePaletteBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual SquadGroupsBlock[] ReadSquadGroupsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SquadGroupsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SquadGroupsBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SquadGroupsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual SquadsBlock[] ReadSquadsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SquadsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SquadsBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SquadsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ZoneBlock[] ReadZoneBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ZoneBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ZoneBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ZoneBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CharacterPaletteBlock[] ReadCharacterPaletteBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CharacterPaletteBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CharacterPaletteBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CharacterPaletteBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual AiAnimationReferenceBlock[] ReadAiAnimationReferenceBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(AiAnimationReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new AiAnimationReferenceBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new AiAnimationReferenceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual AiScriptReferenceBlock[] ReadAiScriptReferenceBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(AiScriptReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new AiScriptReferenceBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new AiScriptReferenceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual AiRecordingReferenceBlock[] ReadAiRecordingReferenceBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(AiRecordingReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new AiRecordingReferenceBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new AiRecordingReferenceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual AiConversationBlock[] ReadAiConversationBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(AiConversationBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new AiConversationBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new AiConversationBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CsScriptDataBlock[] ReadCsScriptDataBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CsScriptDataBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CsScriptDataBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CsScriptDataBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual OrdersBlock[] ReadOrdersBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(OrdersBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new OrdersBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new OrdersBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual TriggersBlock[] ReadTriggersBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(TriggersBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new TriggersBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new TriggersBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioStructureBspReferenceBlock[] ReadScenarioStructureBspReferenceBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioStructureBspReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioStructureBspReferenceBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioStructureBspReferenceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioWeaponPaletteBlock[] ReadScenarioWeaponPaletteBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioWeaponPaletteBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioWeaponPaletteBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioWeaponPaletteBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioVehiclePaletteBlock[] ReadScenarioVehiclePaletteBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioVehiclePaletteBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioVehiclePaletteBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioVehiclePaletteBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioVehicleBlock[] ReadScenarioVehicleBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioVehicleBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioVehicleBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioVehicleBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual AiSceneBlock[] ReadAiSceneBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(AiSceneBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new AiSceneBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new AiSceneBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual FlockDefinitionBlock[] ReadFlockDefinitionBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(FlockDefinitionBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new FlockDefinitionBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new FlockDefinitionBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioTriggerVolumeBlock[] ReadScenarioTriggerVolumeBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioTriggerVolumeBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioTriggerVolumeBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioTriggerVolumeBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
