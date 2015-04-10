// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("scnr")]
    public  partial class ScenarioBlock : ScenarioBlockBase
    {
        public  ScenarioBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 992)]
    public class ScenarioBlockBase
    {
        [TagReference("sbsp")]
        internal Moonfish.Tags.TagReference doNotUse;
        internal ScenarioSkyReferenceBlock[] skies;
        internal Type type;
        internal Flags flags;
        internal ScenarioChildScenarioBlock[] childScenarios;
        internal float localNorth;
        internal PredictedResourceBlock[] predictedResources;
        internal ScenarioFunctionBlock[] functions;
        internal byte[] editorScenarioData;
        internal EditorCommentBlock[] comments;
        internal DontUseMeScenarioEnvironmentObjectBlock[] invalidName_;
        internal ScenarioObjectNamesBlock[] objectNames;
        internal ScenarioSceneryBlock[] scenery;
        internal ScenarioSceneryPaletteBlock[] sceneryPalette;
        internal ScenarioBipedBlock[] bipeds;
        internal ScenarioBipedPaletteBlock[] bipedPalette;
        internal ScenarioVehicleBlock[] vehicles;
        internal ScenarioVehiclePaletteBlock[] vehiclePalette;
        internal ScenarioEquipmentBlock[] equipment;
        internal ScenarioEquipmentPaletteBlock[] equipmentPalette;
        internal ScenarioWeaponBlock[] weapons;
        internal ScenarioWeaponPaletteBlock[] weaponPalette;
        internal DeviceGroupBlock[] deviceGroups;
        internal ScenarioMachineBlock[] machines;
        internal ScenarioMachinePaletteBlock[] machinePalette;
        internal ScenarioControlBlock[] controls;
        internal ScenarioControlPaletteBlock[] controlPalette;
        internal ScenarioLightFixtureBlock[] lightFixtures;
        internal ScenarioLightFixturePaletteBlock[] lightFixturesPalette;
        internal ScenarioSoundSceneryBlock[] soundScenery;
        internal ScenarioSoundSceneryPaletteBlock[] soundSceneryPalette;
        internal ScenarioLightBlock[] lightVolumes;
        internal ScenarioLightPaletteBlock[] lightVolumesPalette;
        internal ScenarioProfilesBlock[] playerStartingProfile;
        internal ScenarioPlayersBlock[] playerStartingLocations;
        internal ScenarioTriggerVolumeBlock[] killTriggerVolumes;
        internal RecordedAnimationBlock[] recordedAnimations;
        internal ScenarioNetpointsBlock[] netgameFlags;
        internal ScenarioNetgameEquipmentBlock[] netgameEquipment;
        internal ScenarioStartingEquipmentBlock[] startingEquipment;
        internal ScenarioBspSwitchTriggerVolumeBlock[] bSPSwitchTriggerVolumes;
        internal ScenarioDecalsBlock[] decals;
        internal ScenarioDecalPaletteBlock[] decalsPalette;
        internal ScenarioDetailObjectCollectionPaletteBlock[] detailObjectCollectionPalette;
        internal StylePaletteBlock[] stylePalette;
        internal SquadGroupsBlock[] squadGroups;
        internal SquadsBlock[] squads;
        internal ZoneBlock[] zones;
        internal AiSceneBlock[] missionScenes;
        internal CharacterPaletteBlock[] characterPalette;
        internal PathfindingDataBlock[] aIPathfindingData;
        internal AiAnimationReferenceBlock[] aIAnimationReferences;
        internal AiScriptReferenceBlock[] aIScriptReferences;
        internal AiRecordingReferenceBlock[] aIRecordingReferences;
        internal AiConversationBlock[] aIConversations;
        internal byte[] scriptSyntaxData;
        internal byte[] scriptStringData;
        internal HsScriptsBlock[] scripts;
        internal HsGlobalsBlock[] globals;
        internal HsReferencesBlock[] references;
        internal HsSourceFilesBlock[] sourceFiles;
        internal CsScriptDataBlock[] scriptingData;
        internal ScenarioCutsceneFlagBlock[] cutsceneFlags;
        internal ScenarioCutsceneCameraPointBlock[] cutsceneCameraPoints;
        internal ScenarioCutsceneTitleBlock[] cutsceneTitles;
        [TagReference("unic")]
        internal Moonfish.Tags.TagReference customObjectNames;
        [TagReference("unic")]
        internal Moonfish.Tags.TagReference chapterTitleText;
        [TagReference("hmt ")]
        internal Moonfish.Tags.TagReference hUDMessages;
        internal ScenarioStructureBspReferenceBlock[] structureBSPs;
        internal ScenarioResourcesBlock[] scenarioResources;
        internal OldUnusedStrucurePhysicsBlock[] scenarioResources0;
        internal HsUnitSeatBlock[] hsUnitSeats;
        internal ScenarioKillTriggerVolumesBlock[] scenarioKillTriggers;
        internal SyntaxDatumBlock[] hsSyntaxDatums;
        internal OrdersBlock[] orders;
        internal TriggersBlock[] triggers;
        internal StructureBspBackgroundSoundPaletteBlock[] backgroundSoundPalette;
        internal StructureBspSoundEnvironmentPaletteBlock[] soundEnvironmentPalette;
        internal StructureBspWeatherPaletteBlock[] weatherPalette;
        internal GNullBlock[] eMPTYSTRING;
        internal GNullBlock[] eMPTYSTRING0;
        internal GNullBlock[] eMPTYSTRING1;
        internal GNullBlock[] eMPTYSTRING2;
        internal GNullBlock[] eMPTYSTRING3;
        internal ScenarioClusterDataBlock[] scenarioClusterData;
        internal ObjectSalts[] objectSalts;
        internal ScenarioSpawnDataBlock[] spawnData;
        [TagReference("sfx+")]
        internal Moonfish.Tags.TagReference soundEffectCollection;
        internal ScenarioCrateBlock[] crates;
        internal ScenarioCratePaletteBlock[] cratesPalette;
        [TagReference("gldf")]
        internal Moonfish.Tags.TagReference globalLighting;
        internal ScenarioAtmosphericFogPalette[] atmosphericFogPalette;
        internal ScenarioPlanarFogPalette[] planarFogPalette;
        internal FlockDefinitionBlock[] flocks;
        [TagReference("unic")]
        internal Moonfish.Tags.TagReference subtitles;
        internal DecoratorPlacementDefinitionBlock[] decorators;
        internal ScenarioCreatureBlock[] creatures;
        internal ScenarioCreaturePaletteBlock[] creaturesPalette;
        internal ScenarioDecoratorSetPaletteEntryBlock[] decoratorsPalette;
        internal ScenarioBspSwitchTransitionVolumeBlock[] bSPTransitionVolumes;
        internal ScenarioStructureBspSphericalHarmonicLightingBlock[] structureBSPLighting;
        internal GScenarioEditorFolderBlock[] editorFolders;
        internal ScenarioLevelDataBlock[] levelData;
        [TagReference("unic")]
        internal Moonfish.Tags.TagReference territoryLocationNames;
        internal byte[] invalidName_0;
        internal AiScenarioMissionDialogueBlock[] missionDialogue;
        [TagReference("unic")]
        internal Moonfish.Tags.TagReference objectives;
        internal ScenarioInterpolatorBlock[] interpolators;
        internal HsReferencesBlock[] sharedReferences;
        internal ScenarioScreenEffectReferenceBlock[] screenEffectReferences;
        internal ScenarioSimulationDefinitionTableBlock[] simulationDefinitionTable;
        internal  ScenarioBlockBase(System.IO.BinaryReader binaryReader)
        {
            doNotUse = binaryReader.ReadTagReference();
            ReadScenarioSkyReferenceBlockArray(binaryReader);
            type = (Type)binaryReader.ReadInt16();
            flags = (Flags)binaryReader.ReadInt16();
            ReadScenarioChildScenarioBlockArray(binaryReader);
            localNorth = binaryReader.ReadSingle();
            ReadPredictedResourceBlockArray(binaryReader);
            ReadScenarioFunctionBlockArray(binaryReader);
            editorScenarioData = ReadData(binaryReader);
            ReadEditorCommentBlockArray(binaryReader);
            ReadDontUseMeScenarioEnvironmentObjectBlockArray(binaryReader);
            ReadScenarioObjectNamesBlockArray(binaryReader);
            ReadScenarioSceneryBlockArray(binaryReader);
            ReadScenarioSceneryPaletteBlockArray(binaryReader);
            ReadScenarioBipedBlockArray(binaryReader);
            ReadScenarioBipedPaletteBlockArray(binaryReader);
            ReadScenarioVehicleBlockArray(binaryReader);
            ReadScenarioVehiclePaletteBlockArray(binaryReader);
            ReadScenarioEquipmentBlockArray(binaryReader);
            ReadScenarioEquipmentPaletteBlockArray(binaryReader);
            ReadScenarioWeaponBlockArray(binaryReader);
            ReadScenarioWeaponPaletteBlockArray(binaryReader);
            ReadDeviceGroupBlockArray(binaryReader);
            ReadScenarioMachineBlockArray(binaryReader);
            ReadScenarioMachinePaletteBlockArray(binaryReader);
            ReadScenarioControlBlockArray(binaryReader);
            ReadScenarioControlPaletteBlockArray(binaryReader);
            ReadScenarioLightFixtureBlockArray(binaryReader);
            ReadScenarioLightFixturePaletteBlockArray(binaryReader);
            ReadScenarioSoundSceneryBlockArray(binaryReader);
            ReadScenarioSoundSceneryPaletteBlockArray(binaryReader);
            ReadScenarioLightBlockArray(binaryReader);
            ReadScenarioLightPaletteBlockArray(binaryReader);
            ReadScenarioProfilesBlockArray(binaryReader);
            ReadScenarioPlayersBlockArray(binaryReader);
            ReadScenarioTriggerVolumeBlockArray(binaryReader);
            ReadRecordedAnimationBlockArray(binaryReader);
            ReadScenarioNetpointsBlockArray(binaryReader);
            ReadScenarioNetgameEquipmentBlockArray(binaryReader);
            ReadScenarioStartingEquipmentBlockArray(binaryReader);
            ReadScenarioBspSwitchTriggerVolumeBlockArray(binaryReader);
            ReadScenarioDecalsBlockArray(binaryReader);
            ReadScenarioDecalPaletteBlockArray(binaryReader);
            ReadScenarioDetailObjectCollectionPaletteBlockArray(binaryReader);
            ReadStylePaletteBlockArray(binaryReader);
            ReadSquadGroupsBlockArray(binaryReader);
            ReadSquadsBlockArray(binaryReader);
            ReadZoneBlockArray(binaryReader);
            ReadAiSceneBlockArray(binaryReader);
            ReadCharacterPaletteBlockArray(binaryReader);
            ReadPathfindingDataBlockArray(binaryReader);
            ReadAiAnimationReferenceBlockArray(binaryReader);
            ReadAiScriptReferenceBlockArray(binaryReader);
            ReadAiRecordingReferenceBlockArray(binaryReader);
            ReadAiConversationBlockArray(binaryReader);
            scriptSyntaxData = ReadData(binaryReader);
            scriptStringData = ReadData(binaryReader);
            ReadHsScriptsBlockArray(binaryReader);
            ReadHsGlobalsBlockArray(binaryReader);
            ReadHsReferencesBlockArray(binaryReader);
            ReadHsSourceFilesBlockArray(binaryReader);
            ReadCsScriptDataBlockArray(binaryReader);
            ReadScenarioCutsceneFlagBlockArray(binaryReader);
            ReadScenarioCutsceneCameraPointBlockArray(binaryReader);
            ReadScenarioCutsceneTitleBlockArray(binaryReader);
            customObjectNames = binaryReader.ReadTagReference();
            chapterTitleText = binaryReader.ReadTagReference();
            hUDMessages = binaryReader.ReadTagReference();
            ReadScenarioStructureBspReferenceBlockArray(binaryReader);
            ReadScenarioResourcesBlockArray(binaryReader);
            ReadOldUnusedStrucurePhysicsBlockArray(binaryReader);
            ReadHsUnitSeatBlockArray(binaryReader);
            ReadScenarioKillTriggerVolumesBlockArray(binaryReader);
            ReadSyntaxDatumBlockArray(binaryReader);
            ReadOrdersBlockArray(binaryReader);
            ReadTriggersBlockArray(binaryReader);
            ReadStructureBspBackgroundSoundPaletteBlockArray(binaryReader);
            ReadStructureBspSoundEnvironmentPaletteBlockArray(binaryReader);
            ReadStructureBspWeatherPaletteBlockArray(binaryReader);
            ReadGNullBlockArray(binaryReader);
            ReadGNullBlockArray(binaryReader);
            ReadGNullBlockArray(binaryReader);
            ReadGNullBlockArray(binaryReader);
            ReadGNullBlockArray(binaryReader);
            ReadScenarioClusterDataBlockArray(binaryReader);
            objectSalts = new []{ new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader),  };
            ReadScenarioSpawnDataBlockArray(binaryReader);
            soundEffectCollection = binaryReader.ReadTagReference();
            ReadScenarioCrateBlockArray(binaryReader);
            ReadScenarioCratePaletteBlockArray(binaryReader);
            globalLighting = binaryReader.ReadTagReference();
            ReadScenarioAtmosphericFogPaletteArray(binaryReader);
            ReadScenarioPlanarFogPaletteArray(binaryReader);
            ReadFlockDefinitionBlockArray(binaryReader);
            subtitles = binaryReader.ReadTagReference();
            ReadDecoratorPlacementDefinitionBlockArray(binaryReader);
            ReadScenarioCreatureBlockArray(binaryReader);
            ReadScenarioCreaturePaletteBlockArray(binaryReader);
            ReadScenarioDecoratorSetPaletteEntryBlockArray(binaryReader);
            ReadScenarioBspSwitchTransitionVolumeBlockArray(binaryReader);
            ReadScenarioStructureBspSphericalHarmonicLightingBlockArray(binaryReader);
            ReadGScenarioEditorFolderBlockArray(binaryReader);
            ReadScenarioLevelDataBlockArray(binaryReader);
            territoryLocationNames = binaryReader.ReadTagReference();
            invalidName_0 = binaryReader.ReadBytes(8);
            ReadAiScenarioMissionDialogueBlockArray(binaryReader);
            objectives = binaryReader.ReadTagReference();
            ReadScenarioInterpolatorBlockArray(binaryReader);
            ReadHsReferencesBlockArray(binaryReader);
            ReadScenarioScreenEffectReferenceBlockArray(binaryReader);
            ReadScenarioSimulationDefinitionTableBlockArray(binaryReader);
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
        internal  virtual ScenarioSkyReferenceBlock[] ReadScenarioSkyReferenceBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioSkyReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioSkyReferenceBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioSkyReferenceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioChildScenarioBlock[] ReadScenarioChildScenarioBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioChildScenarioBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioChildScenarioBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioChildScenarioBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PredictedResourceBlock[] ReadPredictedResourceBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PredictedResourceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PredictedResourceBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PredictedResourceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioFunctionBlock[] ReadScenarioFunctionBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioFunctionBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioFunctionBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioFunctionBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual EditorCommentBlock[] ReadEditorCommentBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(EditorCommentBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new EditorCommentBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new EditorCommentBlock(binaryReader);
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
        internal  virtual ScenarioSceneryBlock[] ReadScenarioSceneryBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioSceneryBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioSceneryBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioSceneryBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioSceneryPaletteBlock[] ReadScenarioSceneryPaletteBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioSceneryPaletteBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioSceneryPaletteBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioSceneryPaletteBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioBipedBlock[] ReadScenarioBipedBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioBipedBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioBipedBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioBipedBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioBipedPaletteBlock[] ReadScenarioBipedPaletteBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioBipedPaletteBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioBipedPaletteBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioBipedPaletteBlock(binaryReader);
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
        internal  virtual ScenarioEquipmentBlock[] ReadScenarioEquipmentBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioEquipmentBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioEquipmentBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioEquipmentBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioEquipmentPaletteBlock[] ReadScenarioEquipmentPaletteBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioEquipmentPaletteBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioEquipmentPaletteBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioEquipmentPaletteBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioWeaponBlock[] ReadScenarioWeaponBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioWeaponBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioWeaponBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioWeaponBlock(binaryReader);
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
        internal  virtual ScenarioSoundSceneryBlock[] ReadScenarioSoundSceneryBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioSoundSceneryBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioSoundSceneryBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioSoundSceneryBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioSoundSceneryPaletteBlock[] ReadScenarioSoundSceneryPaletteBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioSoundSceneryPaletteBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioSoundSceneryPaletteBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioSoundSceneryPaletteBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioLightBlock[] ReadScenarioLightBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioLightBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioLightBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioLightBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioLightPaletteBlock[] ReadScenarioLightPaletteBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioLightPaletteBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioLightPaletteBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioLightPaletteBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioProfilesBlock[] ReadScenarioProfilesBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioProfilesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioProfilesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioProfilesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioPlayersBlock[] ReadScenarioPlayersBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioPlayersBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioPlayersBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioPlayersBlock(binaryReader);
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
        internal  virtual RecordedAnimationBlock[] ReadRecordedAnimationBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(RecordedAnimationBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new RecordedAnimationBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new RecordedAnimationBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioNetpointsBlock[] ReadScenarioNetpointsBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioNetpointsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioNetpointsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioNetpointsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioNetgameEquipmentBlock[] ReadScenarioNetgameEquipmentBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioNetgameEquipmentBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioNetgameEquipmentBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioNetgameEquipmentBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioStartingEquipmentBlock[] ReadScenarioStartingEquipmentBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioStartingEquipmentBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioStartingEquipmentBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioStartingEquipmentBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioBspSwitchTriggerVolumeBlock[] ReadScenarioBspSwitchTriggerVolumeBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioBspSwitchTriggerVolumeBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioBspSwitchTriggerVolumeBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioBspSwitchTriggerVolumeBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioDecalsBlock[] ReadScenarioDecalsBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioDecalsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioDecalsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioDecalsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioDecalPaletteBlock[] ReadScenarioDecalPaletteBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioDecalPaletteBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioDecalPaletteBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioDecalPaletteBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioDetailObjectCollectionPaletteBlock[] ReadScenarioDetailObjectCollectionPaletteBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioDetailObjectCollectionPaletteBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioDetailObjectCollectionPaletteBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioDetailObjectCollectionPaletteBlock(binaryReader);
                }
            }
            return array;
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
        internal  virtual PathfindingDataBlock[] ReadPathfindingDataBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PathfindingDataBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PathfindingDataBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PathfindingDataBlock(binaryReader);
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
        internal  virtual HsScriptsBlock[] ReadHsScriptsBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(HsScriptsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new HsScriptsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new HsScriptsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual HsGlobalsBlock[] ReadHsGlobalsBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(HsGlobalsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new HsGlobalsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new HsGlobalsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual HsReferencesBlock[] ReadHsReferencesBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(HsReferencesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new HsReferencesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new HsReferencesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual HsSourceFilesBlock[] ReadHsSourceFilesBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(HsSourceFilesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new HsSourceFilesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new HsSourceFilesBlock(binaryReader);
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
        internal  virtual ScenarioCutsceneFlagBlock[] ReadScenarioCutsceneFlagBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioCutsceneFlagBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioCutsceneFlagBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioCutsceneFlagBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioCutsceneCameraPointBlock[] ReadScenarioCutsceneCameraPointBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioCutsceneCameraPointBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioCutsceneCameraPointBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioCutsceneCameraPointBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioCutsceneTitleBlock[] ReadScenarioCutsceneTitleBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioCutsceneTitleBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioCutsceneTitleBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioCutsceneTitleBlock(binaryReader);
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
        internal  virtual ScenarioResourcesBlock[] ReadScenarioResourcesBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioResourcesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioResourcesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioResourcesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual OldUnusedStrucurePhysicsBlock[] ReadOldUnusedStrucurePhysicsBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(OldUnusedStrucurePhysicsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new OldUnusedStrucurePhysicsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new OldUnusedStrucurePhysicsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual HsUnitSeatBlock[] ReadHsUnitSeatBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(HsUnitSeatBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new HsUnitSeatBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new HsUnitSeatBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioKillTriggerVolumesBlock[] ReadScenarioKillTriggerVolumesBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioKillTriggerVolumesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioKillTriggerVolumesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioKillTriggerVolumesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual SyntaxDatumBlock[] ReadSyntaxDatumBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SyntaxDatumBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SyntaxDatumBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SyntaxDatumBlock(binaryReader);
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
        internal  virtual GNullBlock[] ReadGNullBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GNullBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GNullBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GNullBlock(binaryReader);
                }
            }
            return array;
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
        internal  virtual ScenarioSpawnDataBlock[] ReadScenarioSpawnDataBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioSpawnDataBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioSpawnDataBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioSpawnDataBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioCrateBlock[] ReadScenarioCrateBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioCrateBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioCrateBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioCrateBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioCratePaletteBlock[] ReadScenarioCratePaletteBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioCratePaletteBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioCratePaletteBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioCratePaletteBlock(binaryReader);
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
        internal  virtual ScenarioPlanarFogPalette[] ReadScenarioPlanarFogPaletteArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioPlanarFogPalette));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioPlanarFogPalette[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioPlanarFogPalette(binaryReader);
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
        internal  virtual DecoratorPlacementDefinitionBlock[] ReadDecoratorPlacementDefinitionBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(DecoratorPlacementDefinitionBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new DecoratorPlacementDefinitionBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new DecoratorPlacementDefinitionBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioCreatureBlock[] ReadScenarioCreatureBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioCreatureBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioCreatureBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioCreatureBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioCreaturePaletteBlock[] ReadScenarioCreaturePaletteBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioCreaturePaletteBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioCreaturePaletteBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioCreaturePaletteBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioDecoratorSetPaletteEntryBlock[] ReadScenarioDecoratorSetPaletteEntryBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioDecoratorSetPaletteEntryBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioDecoratorSetPaletteEntryBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioDecoratorSetPaletteEntryBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioBspSwitchTransitionVolumeBlock[] ReadScenarioBspSwitchTransitionVolumeBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioBspSwitchTransitionVolumeBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioBspSwitchTransitionVolumeBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioBspSwitchTransitionVolumeBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioStructureBspSphericalHarmonicLightingBlock[] ReadScenarioStructureBspSphericalHarmonicLightingBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioStructureBspSphericalHarmonicLightingBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioStructureBspSphericalHarmonicLightingBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioStructureBspSphericalHarmonicLightingBlock(binaryReader);
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
        internal  virtual ScenarioLevelDataBlock[] ReadScenarioLevelDataBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioLevelDataBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioLevelDataBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioLevelDataBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual AiScenarioMissionDialogueBlock[] ReadAiScenarioMissionDialogueBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(AiScenarioMissionDialogueBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new AiScenarioMissionDialogueBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new AiScenarioMissionDialogueBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioInterpolatorBlock[] ReadScenarioInterpolatorBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioInterpolatorBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioInterpolatorBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioInterpolatorBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioScreenEffectReferenceBlock[] ReadScenarioScreenEffectReferenceBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioScreenEffectReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioScreenEffectReferenceBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioScreenEffectReferenceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioSimulationDefinitionTableBlock[] ReadScenarioSimulationDefinitionTableBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioSimulationDefinitionTableBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioSimulationDefinitionTableBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioSimulationDefinitionTableBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioSkyReferenceBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioChildScenarioBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WritePredictedResourceBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioFunctionBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteEditorCommentBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteDontUseMeScenarioEnvironmentObjectBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioObjectNamesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioSceneryBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioSceneryPaletteBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioBipedBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioBipedPaletteBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioVehicleBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioVehiclePaletteBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioEquipmentBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioEquipmentPaletteBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioWeaponBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioWeaponPaletteBlockArray(System.IO.BinaryWriter binaryWriter)
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
        internal  virtual void WriteScenarioSoundSceneryBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioSoundSceneryPaletteBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioLightBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioLightPaletteBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioProfilesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioPlayersBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioTriggerVolumeBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteRecordedAnimationBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioNetpointsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioNetgameEquipmentBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioStartingEquipmentBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioBspSwitchTriggerVolumeBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioDecalsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioDecalPaletteBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioDetailObjectCollectionPaletteBlockArray(System.IO.BinaryWriter binaryWriter)
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
        internal  virtual void WriteAiSceneBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteCharacterPaletteBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WritePathfindingDataBlockArray(System.IO.BinaryWriter binaryWriter)
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
        internal  virtual void WriteHsScriptsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteHsGlobalsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteHsReferencesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteHsSourceFilesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteCsScriptDataBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioCutsceneFlagBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioCutsceneCameraPointBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioCutsceneTitleBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioStructureBspReferenceBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioResourcesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteOldUnusedStrucurePhysicsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteHsUnitSeatBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioKillTriggerVolumesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteSyntaxDatumBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteOrdersBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteTriggersBlockArray(System.IO.BinaryWriter binaryWriter)
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
        internal  virtual void WriteGNullBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioClusterDataBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioSpawnDataBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioCrateBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioCratePaletteBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioAtmosphericFogPaletteArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioPlanarFogPaletteArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteFlockDefinitionBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteDecoratorPlacementDefinitionBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioCreatureBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioCreaturePaletteBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioDecoratorSetPaletteEntryBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioBspSwitchTransitionVolumeBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioStructureBspSphericalHarmonicLightingBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGScenarioEditorFolderBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioLevelDataBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteAiScenarioMissionDialogueBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioInterpolatorBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioScreenEffectReferenceBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioSimulationDefinitionTableBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(doNotUse);
                WriteScenarioSkyReferenceBlockArray(binaryWriter);
                binaryWriter.Write((Int16)type);
                binaryWriter.Write((Int16)flags);
                WriteScenarioChildScenarioBlockArray(binaryWriter);
                binaryWriter.Write(localNorth);
                WritePredictedResourceBlockArray(binaryWriter);
                WriteScenarioFunctionBlockArray(binaryWriter);
                WriteData(binaryWriter);
                WriteEditorCommentBlockArray(binaryWriter);
                WriteDontUseMeScenarioEnvironmentObjectBlockArray(binaryWriter);
                WriteScenarioObjectNamesBlockArray(binaryWriter);
                WriteScenarioSceneryBlockArray(binaryWriter);
                WriteScenarioSceneryPaletteBlockArray(binaryWriter);
                WriteScenarioBipedBlockArray(binaryWriter);
                WriteScenarioBipedPaletteBlockArray(binaryWriter);
                WriteScenarioVehicleBlockArray(binaryWriter);
                WriteScenarioVehiclePaletteBlockArray(binaryWriter);
                WriteScenarioEquipmentBlockArray(binaryWriter);
                WriteScenarioEquipmentPaletteBlockArray(binaryWriter);
                WriteScenarioWeaponBlockArray(binaryWriter);
                WriteScenarioWeaponPaletteBlockArray(binaryWriter);
                WriteDeviceGroupBlockArray(binaryWriter);
                WriteScenarioMachineBlockArray(binaryWriter);
                WriteScenarioMachinePaletteBlockArray(binaryWriter);
                WriteScenarioControlBlockArray(binaryWriter);
                WriteScenarioControlPaletteBlockArray(binaryWriter);
                WriteScenarioLightFixtureBlockArray(binaryWriter);
                WriteScenarioLightFixturePaletteBlockArray(binaryWriter);
                WriteScenarioSoundSceneryBlockArray(binaryWriter);
                WriteScenarioSoundSceneryPaletteBlockArray(binaryWriter);
                WriteScenarioLightBlockArray(binaryWriter);
                WriteScenarioLightPaletteBlockArray(binaryWriter);
                WriteScenarioProfilesBlockArray(binaryWriter);
                WriteScenarioPlayersBlockArray(binaryWriter);
                WriteScenarioTriggerVolumeBlockArray(binaryWriter);
                WriteRecordedAnimationBlockArray(binaryWriter);
                WriteScenarioNetpointsBlockArray(binaryWriter);
                WriteScenarioNetgameEquipmentBlockArray(binaryWriter);
                WriteScenarioStartingEquipmentBlockArray(binaryWriter);
                WriteScenarioBspSwitchTriggerVolumeBlockArray(binaryWriter);
                WriteScenarioDecalsBlockArray(binaryWriter);
                WriteScenarioDecalPaletteBlockArray(binaryWriter);
                WriteScenarioDetailObjectCollectionPaletteBlockArray(binaryWriter);
                WriteStylePaletteBlockArray(binaryWriter);
                WriteSquadGroupsBlockArray(binaryWriter);
                WriteSquadsBlockArray(binaryWriter);
                WriteZoneBlockArray(binaryWriter);
                WriteAiSceneBlockArray(binaryWriter);
                WriteCharacterPaletteBlockArray(binaryWriter);
                WritePathfindingDataBlockArray(binaryWriter);
                WriteAiAnimationReferenceBlockArray(binaryWriter);
                WriteAiScriptReferenceBlockArray(binaryWriter);
                WriteAiRecordingReferenceBlockArray(binaryWriter);
                WriteAiConversationBlockArray(binaryWriter);
                WriteData(binaryWriter);
                WriteData(binaryWriter);
                WriteHsScriptsBlockArray(binaryWriter);
                WriteHsGlobalsBlockArray(binaryWriter);
                WriteHsReferencesBlockArray(binaryWriter);
                WriteHsSourceFilesBlockArray(binaryWriter);
                WriteCsScriptDataBlockArray(binaryWriter);
                WriteScenarioCutsceneFlagBlockArray(binaryWriter);
                WriteScenarioCutsceneCameraPointBlockArray(binaryWriter);
                WriteScenarioCutsceneTitleBlockArray(binaryWriter);
                binaryWriter.Write(customObjectNames);
                binaryWriter.Write(chapterTitleText);
                binaryWriter.Write(hUDMessages);
                WriteScenarioStructureBspReferenceBlockArray(binaryWriter);
                WriteScenarioResourcesBlockArray(binaryWriter);
                WriteOldUnusedStrucurePhysicsBlockArray(binaryWriter);
                WriteHsUnitSeatBlockArray(binaryWriter);
                WriteScenarioKillTriggerVolumesBlockArray(binaryWriter);
                WriteSyntaxDatumBlockArray(binaryWriter);
                WriteOrdersBlockArray(binaryWriter);
                WriteTriggersBlockArray(binaryWriter);
                WriteStructureBspBackgroundSoundPaletteBlockArray(binaryWriter);
                WriteStructureBspSoundEnvironmentPaletteBlockArray(binaryWriter);
                WriteStructureBspWeatherPaletteBlockArray(binaryWriter);
                WriteGNullBlockArray(binaryWriter);
                WriteGNullBlockArray(binaryWriter);
                WriteGNullBlockArray(binaryWriter);
                WriteGNullBlockArray(binaryWriter);
                WriteGNullBlockArray(binaryWriter);
                WriteScenarioClusterDataBlockArray(binaryWriter);
                objectSalts[0].Write(binaryWriter);
                objectSalts[1].Write(binaryWriter);
                objectSalts[2].Write(binaryWriter);
                objectSalts[3].Write(binaryWriter);
                objectSalts[4].Write(binaryWriter);
                objectSalts[5].Write(binaryWriter);
                objectSalts[6].Write(binaryWriter);
                objectSalts[7].Write(binaryWriter);
                objectSalts[8].Write(binaryWriter);
                objectSalts[9].Write(binaryWriter);
                objectSalts[10].Write(binaryWriter);
                objectSalts[11].Write(binaryWriter);
                objectSalts[12].Write(binaryWriter);
                objectSalts[13].Write(binaryWriter);
                objectSalts[14].Write(binaryWriter);
                objectSalts[15].Write(binaryWriter);
                objectSalts[16].Write(binaryWriter);
                objectSalts[17].Write(binaryWriter);
                objectSalts[18].Write(binaryWriter);
                objectSalts[19].Write(binaryWriter);
                objectSalts[20].Write(binaryWriter);
                objectSalts[21].Write(binaryWriter);
                objectSalts[22].Write(binaryWriter);
                objectSalts[23].Write(binaryWriter);
                objectSalts[24].Write(binaryWriter);
                objectSalts[25].Write(binaryWriter);
                objectSalts[26].Write(binaryWriter);
                objectSalts[27].Write(binaryWriter);
                objectSalts[28].Write(binaryWriter);
                objectSalts[29].Write(binaryWriter);
                objectSalts[30].Write(binaryWriter);
                objectSalts[31].Write(binaryWriter);
                WriteScenarioSpawnDataBlockArray(binaryWriter);
                binaryWriter.Write(soundEffectCollection);
                WriteScenarioCrateBlockArray(binaryWriter);
                WriteScenarioCratePaletteBlockArray(binaryWriter);
                binaryWriter.Write(globalLighting);
                WriteScenarioAtmosphericFogPaletteArray(binaryWriter);
                WriteScenarioPlanarFogPaletteArray(binaryWriter);
                WriteFlockDefinitionBlockArray(binaryWriter);
                binaryWriter.Write(subtitles);
                WriteDecoratorPlacementDefinitionBlockArray(binaryWriter);
                WriteScenarioCreatureBlockArray(binaryWriter);
                WriteScenarioCreaturePaletteBlockArray(binaryWriter);
                WriteScenarioDecoratorSetPaletteEntryBlockArray(binaryWriter);
                WriteScenarioBspSwitchTransitionVolumeBlockArray(binaryWriter);
                WriteScenarioStructureBspSphericalHarmonicLightingBlockArray(binaryWriter);
                WriteGScenarioEditorFolderBlockArray(binaryWriter);
                WriteScenarioLevelDataBlockArray(binaryWriter);
                binaryWriter.Write(territoryLocationNames);
                binaryWriter.Write(invalidName_0, 0, 8);
                WriteAiScenarioMissionDialogueBlockArray(binaryWriter);
                binaryWriter.Write(objectives);
                WriteScenarioInterpolatorBlockArray(binaryWriter);
                WriteHsReferencesBlockArray(binaryWriter);
                WriteScenarioScreenEffectReferenceBlockArray(binaryWriter);
                WriteScenarioSimulationDefinitionTableBlockArray(binaryWriter);
            }
        }
        internal enum Type : short
        
        {
            InvalidName = 0,
            Multiplayer = 1,
            InvalidName0 = 2,
            InvalidName1 = 3,
            InvalidName2 = 4,
        };
        [FlagsAttribute]
        internal enum Flags : short
        
        {
            CortanaHackSortsCortanaInFrontOfOtherTransparentGeometry = 1,
            AlwaysDrawSkyAlwaysDrawsSky0EvenIfNoSkyPolygonsAreVisible = 2,
            DontStripPathfindingAlwaysLeavesPathfindingInEvenForMultiplayerScenario = 4,
            SymmetricMultiplayerMap = 8,
            QuickLoadingCinematicOnlyScenario = 16,
            CharactersUsePreviousMissionWeapons = 32,
            LightmapsSmoothPalettesWithNeighbors = 64,
            SnapToWhiteAtStart = 128,
        };
        public class ObjectSalts
        {
            internal int eMPTYSTRING;
            internal  ObjectSalts(System.IO.BinaryReader binaryReader)
            {
                eMPTYSTRING = binaryReader.ReadInt32();
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
            internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
            {
                
            }
            public void Write(System.IO.BinaryWriter binaryWriter)
            {
                using(binaryWriter.BaseStream.Pin())
                {
                    binaryWriter.Write(eMPTYSTRING);
                }
            }
        };
    };
}
