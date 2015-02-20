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
        public  ScenarioBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  ScenarioBlockBase(BinaryReader binaryReader)
        {
            this.doNotUse = binaryReader.ReadTagReference();
            this.skies = ReadScenarioSkyReferenceBlockArray(binaryReader);
            this.type = (Type)binaryReader.ReadInt16();
            this.flags = (Flags)binaryReader.ReadInt16();
            this.childScenarios = ReadScenarioChildScenarioBlockArray(binaryReader);
            this.localNorth = binaryReader.ReadSingle();
            this.predictedResources = ReadPredictedResourceBlockArray(binaryReader);
            this.functions = ReadScenarioFunctionBlockArray(binaryReader);
            this.editorScenarioData = ReadData(binaryReader);
            this.comments = ReadEditorCommentBlockArray(binaryReader);
            this.invalidName_ = ReadDontUseMeScenarioEnvironmentObjectBlockArray(binaryReader);
            this.objectNames = ReadScenarioObjectNamesBlockArray(binaryReader);
            this.scenery = ReadScenarioSceneryBlockArray(binaryReader);
            this.sceneryPalette = ReadScenarioSceneryPaletteBlockArray(binaryReader);
            this.bipeds = ReadScenarioBipedBlockArray(binaryReader);
            this.bipedPalette = ReadScenarioBipedPaletteBlockArray(binaryReader);
            this.vehicles = ReadScenarioVehicleBlockArray(binaryReader);
            this.vehiclePalette = ReadScenarioVehiclePaletteBlockArray(binaryReader);
            this.equipment = ReadScenarioEquipmentBlockArray(binaryReader);
            this.equipmentPalette = ReadScenarioEquipmentPaletteBlockArray(binaryReader);
            this.weapons = ReadScenarioWeaponBlockArray(binaryReader);
            this.weaponPalette = ReadScenarioWeaponPaletteBlockArray(binaryReader);
            this.deviceGroups = ReadDeviceGroupBlockArray(binaryReader);
            this.machines = ReadScenarioMachineBlockArray(binaryReader);
            this.machinePalette = ReadScenarioMachinePaletteBlockArray(binaryReader);
            this.controls = ReadScenarioControlBlockArray(binaryReader);
            this.controlPalette = ReadScenarioControlPaletteBlockArray(binaryReader);
            this.lightFixtures = ReadScenarioLightFixtureBlockArray(binaryReader);
            this.lightFixturesPalette = ReadScenarioLightFixturePaletteBlockArray(binaryReader);
            this.soundScenery = ReadScenarioSoundSceneryBlockArray(binaryReader);
            this.soundSceneryPalette = ReadScenarioSoundSceneryPaletteBlockArray(binaryReader);
            this.lightVolumes = ReadScenarioLightBlockArray(binaryReader);
            this.lightVolumesPalette = ReadScenarioLightPaletteBlockArray(binaryReader);
            this.playerStartingProfile = ReadScenarioProfilesBlockArray(binaryReader);
            this.playerStartingLocations = ReadScenarioPlayersBlockArray(binaryReader);
            this.killTriggerVolumes = ReadScenarioTriggerVolumeBlockArray(binaryReader);
            this.recordedAnimations = ReadRecordedAnimationBlockArray(binaryReader);
            this.netgameFlags = ReadScenarioNetpointsBlockArray(binaryReader);
            this.netgameEquipment = ReadScenarioNetgameEquipmentBlockArray(binaryReader);
            this.startingEquipment = ReadScenarioStartingEquipmentBlockArray(binaryReader);
            this.bSPSwitchTriggerVolumes = ReadScenarioBspSwitchTriggerVolumeBlockArray(binaryReader);
            this.decals = ReadScenarioDecalsBlockArray(binaryReader);
            this.decalsPalette = ReadScenarioDecalPaletteBlockArray(binaryReader);
            this.detailObjectCollectionPalette = ReadScenarioDetailObjectCollectionPaletteBlockArray(binaryReader);
            this.stylePalette = ReadStylePaletteBlockArray(binaryReader);
            this.squadGroups = ReadSquadGroupsBlockArray(binaryReader);
            this.squads = ReadSquadsBlockArray(binaryReader);
            this.zones = ReadZoneBlockArray(binaryReader);
            this.missionScenes = ReadAiSceneBlockArray(binaryReader);
            this.characterPalette = ReadCharacterPaletteBlockArray(binaryReader);
            this.aIPathfindingData = ReadPathfindingDataBlockArray(binaryReader);
            this.aIAnimationReferences = ReadAiAnimationReferenceBlockArray(binaryReader);
            this.aIScriptReferences = ReadAiScriptReferenceBlockArray(binaryReader);
            this.aIRecordingReferences = ReadAiRecordingReferenceBlockArray(binaryReader);
            this.aIConversations = ReadAiConversationBlockArray(binaryReader);
            this.scriptSyntaxData = ReadData(binaryReader);
            this.scriptStringData = ReadData(binaryReader);
            this.scripts = ReadHsScriptsBlockArray(binaryReader);
            this.globals = ReadHsGlobalsBlockArray(binaryReader);
            this.references = ReadHsReferencesBlockArray(binaryReader);
            this.sourceFiles = ReadHsSourceFilesBlockArray(binaryReader);
            this.scriptingData = ReadCsScriptDataBlockArray(binaryReader);
            this.cutsceneFlags = ReadScenarioCutsceneFlagBlockArray(binaryReader);
            this.cutsceneCameraPoints = ReadScenarioCutsceneCameraPointBlockArray(binaryReader);
            this.cutsceneTitles = ReadScenarioCutsceneTitleBlockArray(binaryReader);
            this.customObjectNames = binaryReader.ReadTagReference();
            this.chapterTitleText = binaryReader.ReadTagReference();
            this.hUDMessages = binaryReader.ReadTagReference();
            this.structureBSPs = ReadScenarioStructureBspReferenceBlockArray(binaryReader);
            this.scenarioResources = ReadScenarioResourcesBlockArray(binaryReader);
            this.scenarioResources0 = ReadOldUnusedStrucurePhysicsBlockArray(binaryReader);
            this.hsUnitSeats = ReadHsUnitSeatBlockArray(binaryReader);
            this.scenarioKillTriggers = ReadScenarioKillTriggerVolumesBlockArray(binaryReader);
            this.hsSyntaxDatums = ReadSyntaxDatumBlockArray(binaryReader);
            this.orders = ReadOrdersBlockArray(binaryReader);
            this.triggers = ReadTriggersBlockArray(binaryReader);
            this.backgroundSoundPalette = ReadStructureBspBackgroundSoundPaletteBlockArray(binaryReader);
            this.soundEnvironmentPalette = ReadStructureBspSoundEnvironmentPaletteBlockArray(binaryReader);
            this.weatherPalette = ReadStructureBspWeatherPaletteBlockArray(binaryReader);
            this.eMPTYSTRING = ReadGNullBlockArray(binaryReader);
            this.eMPTYSTRING0 = ReadGNullBlockArray(binaryReader);
            this.eMPTYSTRING1 = ReadGNullBlockArray(binaryReader);
            this.eMPTYSTRING2 = ReadGNullBlockArray(binaryReader);
            this.eMPTYSTRING3 = ReadGNullBlockArray(binaryReader);
            this.scenarioClusterData = ReadScenarioClusterDataBlockArray(binaryReader);
            this.objectSalts = new []{ new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader),  };
            this.spawnData = ReadScenarioSpawnDataBlockArray(binaryReader);
            this.soundEffectCollection = binaryReader.ReadTagReference();
            this.crates = ReadScenarioCrateBlockArray(binaryReader);
            this.cratesPalette = ReadScenarioCratePaletteBlockArray(binaryReader);
            this.globalLighting = binaryReader.ReadTagReference();
            this.atmosphericFogPalette = ReadScenarioAtmosphericFogPaletteArray(binaryReader);
            this.planarFogPalette = ReadScenarioPlanarFogPaletteArray(binaryReader);
            this.flocks = ReadFlockDefinitionBlockArray(binaryReader);
            this.subtitles = binaryReader.ReadTagReference();
            this.decorators = ReadDecoratorPlacementDefinitionBlockArray(binaryReader);
            this.creatures = ReadScenarioCreatureBlockArray(binaryReader);
            this.creaturesPalette = ReadScenarioCreaturePaletteBlockArray(binaryReader);
            this.decoratorsPalette = ReadScenarioDecoratorSetPaletteEntryBlockArray(binaryReader);
            this.bSPTransitionVolumes = ReadScenarioBspSwitchTransitionVolumeBlockArray(binaryReader);
            this.structureBSPLighting = ReadScenarioStructureBspSphericalHarmonicLightingBlockArray(binaryReader);
            this.editorFolders = ReadGScenarioEditorFolderBlockArray(binaryReader);
            this.levelData = ReadScenarioLevelDataBlockArray(binaryReader);
            this.territoryLocationNames = binaryReader.ReadTagReference();
            this.invalidName_0 = binaryReader.ReadBytes(8);
            this.missionDialogue = ReadAiScenarioMissionDialogueBlockArray(binaryReader);
            this.objectives = binaryReader.ReadTagReference();
            this.interpolators = ReadScenarioInterpolatorBlockArray(binaryReader);
            this.sharedReferences = ReadHsReferencesBlockArray(binaryReader);
            this.screenEffectReferences = ReadScenarioScreenEffectReferenceBlockArray(binaryReader);
            this.simulationDefinitionTable = ReadScenarioSimulationDefinitionTableBlockArray(binaryReader);
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
        internal  virtual ScenarioSkyReferenceBlock[] ReadScenarioSkyReferenceBlockArray(BinaryReader binaryReader)
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
        internal  virtual ScenarioChildScenarioBlock[] ReadScenarioChildScenarioBlockArray(BinaryReader binaryReader)
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
        internal  virtual PredictedResourceBlock[] ReadPredictedResourceBlockArray(BinaryReader binaryReader)
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
        internal  virtual ScenarioFunctionBlock[] ReadScenarioFunctionBlockArray(BinaryReader binaryReader)
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
        internal  virtual EditorCommentBlock[] ReadEditorCommentBlockArray(BinaryReader binaryReader)
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
        internal  virtual DontUseMeScenarioEnvironmentObjectBlock[] ReadDontUseMeScenarioEnvironmentObjectBlockArray(BinaryReader binaryReader)
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
        internal  virtual ScenarioObjectNamesBlock[] ReadScenarioObjectNamesBlockArray(BinaryReader binaryReader)
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
        internal  virtual ScenarioSceneryBlock[] ReadScenarioSceneryBlockArray(BinaryReader binaryReader)
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
        internal  virtual ScenarioSceneryPaletteBlock[] ReadScenarioSceneryPaletteBlockArray(BinaryReader binaryReader)
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
        internal  virtual ScenarioBipedBlock[] ReadScenarioBipedBlockArray(BinaryReader binaryReader)
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
        internal  virtual ScenarioBipedPaletteBlock[] ReadScenarioBipedPaletteBlockArray(BinaryReader binaryReader)
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
        internal  virtual ScenarioVehicleBlock[] ReadScenarioVehicleBlockArray(BinaryReader binaryReader)
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
        internal  virtual ScenarioVehiclePaletteBlock[] ReadScenarioVehiclePaletteBlockArray(BinaryReader binaryReader)
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
        internal  virtual ScenarioEquipmentBlock[] ReadScenarioEquipmentBlockArray(BinaryReader binaryReader)
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
        internal  virtual ScenarioEquipmentPaletteBlock[] ReadScenarioEquipmentPaletteBlockArray(BinaryReader binaryReader)
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
        internal  virtual ScenarioWeaponBlock[] ReadScenarioWeaponBlockArray(BinaryReader binaryReader)
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
        internal  virtual ScenarioWeaponPaletteBlock[] ReadScenarioWeaponPaletteBlockArray(BinaryReader binaryReader)
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
        internal  virtual DeviceGroupBlock[] ReadDeviceGroupBlockArray(BinaryReader binaryReader)
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
        internal  virtual ScenarioMachineBlock[] ReadScenarioMachineBlockArray(BinaryReader binaryReader)
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
        internal  virtual ScenarioMachinePaletteBlock[] ReadScenarioMachinePaletteBlockArray(BinaryReader binaryReader)
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
        internal  virtual ScenarioControlBlock[] ReadScenarioControlBlockArray(BinaryReader binaryReader)
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
        internal  virtual ScenarioControlPaletteBlock[] ReadScenarioControlPaletteBlockArray(BinaryReader binaryReader)
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
        internal  virtual ScenarioLightFixtureBlock[] ReadScenarioLightFixtureBlockArray(BinaryReader binaryReader)
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
        internal  virtual ScenarioLightFixturePaletteBlock[] ReadScenarioLightFixturePaletteBlockArray(BinaryReader binaryReader)
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
        internal  virtual ScenarioSoundSceneryBlock[] ReadScenarioSoundSceneryBlockArray(BinaryReader binaryReader)
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
        internal  virtual ScenarioSoundSceneryPaletteBlock[] ReadScenarioSoundSceneryPaletteBlockArray(BinaryReader binaryReader)
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
        internal  virtual ScenarioLightBlock[] ReadScenarioLightBlockArray(BinaryReader binaryReader)
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
        internal  virtual ScenarioLightPaletteBlock[] ReadScenarioLightPaletteBlockArray(BinaryReader binaryReader)
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
        internal  virtual ScenarioProfilesBlock[] ReadScenarioProfilesBlockArray(BinaryReader binaryReader)
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
        internal  virtual ScenarioPlayersBlock[] ReadScenarioPlayersBlockArray(BinaryReader binaryReader)
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
        internal  virtual ScenarioTriggerVolumeBlock[] ReadScenarioTriggerVolumeBlockArray(BinaryReader binaryReader)
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
        internal  virtual RecordedAnimationBlock[] ReadRecordedAnimationBlockArray(BinaryReader binaryReader)
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
        internal  virtual ScenarioNetpointsBlock[] ReadScenarioNetpointsBlockArray(BinaryReader binaryReader)
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
        internal  virtual ScenarioNetgameEquipmentBlock[] ReadScenarioNetgameEquipmentBlockArray(BinaryReader binaryReader)
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
        internal  virtual ScenarioStartingEquipmentBlock[] ReadScenarioStartingEquipmentBlockArray(BinaryReader binaryReader)
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
        internal  virtual ScenarioBspSwitchTriggerVolumeBlock[] ReadScenarioBspSwitchTriggerVolumeBlockArray(BinaryReader binaryReader)
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
        internal  virtual ScenarioDecalsBlock[] ReadScenarioDecalsBlockArray(BinaryReader binaryReader)
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
        internal  virtual ScenarioDecalPaletteBlock[] ReadScenarioDecalPaletteBlockArray(BinaryReader binaryReader)
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
        internal  virtual ScenarioDetailObjectCollectionPaletteBlock[] ReadScenarioDetailObjectCollectionPaletteBlockArray(BinaryReader binaryReader)
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
        internal  virtual StylePaletteBlock[] ReadStylePaletteBlockArray(BinaryReader binaryReader)
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
        internal  virtual SquadGroupsBlock[] ReadSquadGroupsBlockArray(BinaryReader binaryReader)
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
        internal  virtual SquadsBlock[] ReadSquadsBlockArray(BinaryReader binaryReader)
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
        internal  virtual ZoneBlock[] ReadZoneBlockArray(BinaryReader binaryReader)
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
        internal  virtual AiSceneBlock[] ReadAiSceneBlockArray(BinaryReader binaryReader)
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
        internal  virtual CharacterPaletteBlock[] ReadCharacterPaletteBlockArray(BinaryReader binaryReader)
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
        internal  virtual PathfindingDataBlock[] ReadPathfindingDataBlockArray(BinaryReader binaryReader)
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
        internal  virtual AiAnimationReferenceBlock[] ReadAiAnimationReferenceBlockArray(BinaryReader binaryReader)
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
        internal  virtual AiScriptReferenceBlock[] ReadAiScriptReferenceBlockArray(BinaryReader binaryReader)
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
        internal  virtual AiRecordingReferenceBlock[] ReadAiRecordingReferenceBlockArray(BinaryReader binaryReader)
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
        internal  virtual AiConversationBlock[] ReadAiConversationBlockArray(BinaryReader binaryReader)
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
        internal  virtual HsScriptsBlock[] ReadHsScriptsBlockArray(BinaryReader binaryReader)
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
        internal  virtual HsGlobalsBlock[] ReadHsGlobalsBlockArray(BinaryReader binaryReader)
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
        internal  virtual HsReferencesBlock[] ReadHsReferencesBlockArray(BinaryReader binaryReader)
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
        internal  virtual HsSourceFilesBlock[] ReadHsSourceFilesBlockArray(BinaryReader binaryReader)
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
        internal  virtual CsScriptDataBlock[] ReadCsScriptDataBlockArray(BinaryReader binaryReader)
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
        internal  virtual ScenarioCutsceneFlagBlock[] ReadScenarioCutsceneFlagBlockArray(BinaryReader binaryReader)
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
        internal  virtual ScenarioCutsceneCameraPointBlock[] ReadScenarioCutsceneCameraPointBlockArray(BinaryReader binaryReader)
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
        internal  virtual ScenarioCutsceneTitleBlock[] ReadScenarioCutsceneTitleBlockArray(BinaryReader binaryReader)
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
        internal  virtual ScenarioStructureBspReferenceBlock[] ReadScenarioStructureBspReferenceBlockArray(BinaryReader binaryReader)
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
        internal  virtual ScenarioResourcesBlock[] ReadScenarioResourcesBlockArray(BinaryReader binaryReader)
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
        internal  virtual OldUnusedStrucurePhysicsBlock[] ReadOldUnusedStrucurePhysicsBlockArray(BinaryReader binaryReader)
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
        internal  virtual HsUnitSeatBlock[] ReadHsUnitSeatBlockArray(BinaryReader binaryReader)
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
        internal  virtual ScenarioKillTriggerVolumesBlock[] ReadScenarioKillTriggerVolumesBlockArray(BinaryReader binaryReader)
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
        internal  virtual SyntaxDatumBlock[] ReadSyntaxDatumBlockArray(BinaryReader binaryReader)
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
        internal  virtual OrdersBlock[] ReadOrdersBlockArray(BinaryReader binaryReader)
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
        internal  virtual TriggersBlock[] ReadTriggersBlockArray(BinaryReader binaryReader)
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
        internal  virtual StructureBspBackgroundSoundPaletteBlock[] ReadStructureBspBackgroundSoundPaletteBlockArray(BinaryReader binaryReader)
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
        internal  virtual StructureBspSoundEnvironmentPaletteBlock[] ReadStructureBspSoundEnvironmentPaletteBlockArray(BinaryReader binaryReader)
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
        internal  virtual StructureBspWeatherPaletteBlock[] ReadStructureBspWeatherPaletteBlockArray(BinaryReader binaryReader)
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
        internal  virtual GNullBlock[] ReadGNullBlockArray(BinaryReader binaryReader)
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
        internal  virtual ScenarioClusterDataBlock[] ReadScenarioClusterDataBlockArray(BinaryReader binaryReader)
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
        internal  virtual ScenarioSpawnDataBlock[] ReadScenarioSpawnDataBlockArray(BinaryReader binaryReader)
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
        internal  virtual ScenarioCrateBlock[] ReadScenarioCrateBlockArray(BinaryReader binaryReader)
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
        internal  virtual ScenarioCratePaletteBlock[] ReadScenarioCratePaletteBlockArray(BinaryReader binaryReader)
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
        internal  virtual ScenarioAtmosphericFogPalette[] ReadScenarioAtmosphericFogPaletteArray(BinaryReader binaryReader)
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
        internal  virtual ScenarioPlanarFogPalette[] ReadScenarioPlanarFogPaletteArray(BinaryReader binaryReader)
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
        internal  virtual FlockDefinitionBlock[] ReadFlockDefinitionBlockArray(BinaryReader binaryReader)
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
        internal  virtual DecoratorPlacementDefinitionBlock[] ReadDecoratorPlacementDefinitionBlockArray(BinaryReader binaryReader)
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
        internal  virtual ScenarioCreatureBlock[] ReadScenarioCreatureBlockArray(BinaryReader binaryReader)
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
        internal  virtual ScenarioCreaturePaletteBlock[] ReadScenarioCreaturePaletteBlockArray(BinaryReader binaryReader)
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
        internal  virtual ScenarioDecoratorSetPaletteEntryBlock[] ReadScenarioDecoratorSetPaletteEntryBlockArray(BinaryReader binaryReader)
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
        internal  virtual ScenarioBspSwitchTransitionVolumeBlock[] ReadScenarioBspSwitchTransitionVolumeBlockArray(BinaryReader binaryReader)
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
        internal  virtual ScenarioStructureBspSphericalHarmonicLightingBlock[] ReadScenarioStructureBspSphericalHarmonicLightingBlockArray(BinaryReader binaryReader)
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
        internal  virtual GScenarioEditorFolderBlock[] ReadGScenarioEditorFolderBlockArray(BinaryReader binaryReader)
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
        internal  virtual ScenarioLevelDataBlock[] ReadScenarioLevelDataBlockArray(BinaryReader binaryReader)
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
        internal  virtual AiScenarioMissionDialogueBlock[] ReadAiScenarioMissionDialogueBlockArray(BinaryReader binaryReader)
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
        internal  virtual ScenarioInterpolatorBlock[] ReadScenarioInterpolatorBlockArray(BinaryReader binaryReader)
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
        internal  virtual ScenarioScreenEffectReferenceBlock[] ReadScenarioScreenEffectReferenceBlockArray(BinaryReader binaryReader)
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
        internal  virtual ScenarioSimulationDefinitionTableBlock[] ReadScenarioSimulationDefinitionTableBlockArray(BinaryReader binaryReader)
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
            internal  ObjectSalts(BinaryReader binaryReader)
            {
                this.eMPTYSTRING = binaryReader.ReadInt32();
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
        };
    };
}
