// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass ScnrClass = (TagClass)"scnr";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("scnr")]
    public  partial class ScenarioBlock : ScenarioBlockBase
    {
        public  ScenarioBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 992, Alignment = 4)]
    public class ScenarioBlockBase  : IGuerilla
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
            doNotUse = binaryReader.ReadTagReference();
            skies = Guerilla.ReadBlockArray<ScenarioSkyReferenceBlock>(binaryReader);
            type = (Type)binaryReader.ReadInt16();
            flags = (Flags)binaryReader.ReadInt16();
            childScenarios = Guerilla.ReadBlockArray<ScenarioChildScenarioBlock>(binaryReader);
            localNorth = binaryReader.ReadSingle();
            predictedResources = Guerilla.ReadBlockArray<PredictedResourceBlock>(binaryReader);
            functions = Guerilla.ReadBlockArray<ScenarioFunctionBlock>(binaryReader);
            editorScenarioData = Guerilla.ReadData(binaryReader);
            comments = Guerilla.ReadBlockArray<EditorCommentBlock>(binaryReader);
            invalidName_ = Guerilla.ReadBlockArray<DontUseMeScenarioEnvironmentObjectBlock>(binaryReader);
            objectNames = Guerilla.ReadBlockArray<ScenarioObjectNamesBlock>(binaryReader);
            scenery = Guerilla.ReadBlockArray<ScenarioSceneryBlock>(binaryReader);
            sceneryPalette = Guerilla.ReadBlockArray<ScenarioSceneryPaletteBlock>(binaryReader);
            bipeds = Guerilla.ReadBlockArray<ScenarioBipedBlock>(binaryReader);
            bipedPalette = Guerilla.ReadBlockArray<ScenarioBipedPaletteBlock>(binaryReader);
            vehicles = Guerilla.ReadBlockArray<ScenarioVehicleBlock>(binaryReader);
            vehiclePalette = Guerilla.ReadBlockArray<ScenarioVehiclePaletteBlock>(binaryReader);
            equipment = Guerilla.ReadBlockArray<ScenarioEquipmentBlock>(binaryReader);
            equipmentPalette = Guerilla.ReadBlockArray<ScenarioEquipmentPaletteBlock>(binaryReader);
            weapons = Guerilla.ReadBlockArray<ScenarioWeaponBlock>(binaryReader);
            weaponPalette = Guerilla.ReadBlockArray<ScenarioWeaponPaletteBlock>(binaryReader);
            deviceGroups = Guerilla.ReadBlockArray<DeviceGroupBlock>(binaryReader);
            machines = Guerilla.ReadBlockArray<ScenarioMachineBlock>(binaryReader);
            machinePalette = Guerilla.ReadBlockArray<ScenarioMachinePaletteBlock>(binaryReader);
            controls = Guerilla.ReadBlockArray<ScenarioControlBlock>(binaryReader);
            controlPalette = Guerilla.ReadBlockArray<ScenarioControlPaletteBlock>(binaryReader);
            lightFixtures = Guerilla.ReadBlockArray<ScenarioLightFixtureBlock>(binaryReader);
            lightFixturesPalette = Guerilla.ReadBlockArray<ScenarioLightFixturePaletteBlock>(binaryReader);
            soundScenery = Guerilla.ReadBlockArray<ScenarioSoundSceneryBlock>(binaryReader);
            soundSceneryPalette = Guerilla.ReadBlockArray<ScenarioSoundSceneryPaletteBlock>(binaryReader);
            lightVolumes = Guerilla.ReadBlockArray<ScenarioLightBlock>(binaryReader);
            lightVolumesPalette = Guerilla.ReadBlockArray<ScenarioLightPaletteBlock>(binaryReader);
            playerStartingProfile = Guerilla.ReadBlockArray<ScenarioProfilesBlock>(binaryReader);
            playerStartingLocations = Guerilla.ReadBlockArray<ScenarioPlayersBlock>(binaryReader);
            killTriggerVolumes = Guerilla.ReadBlockArray<ScenarioTriggerVolumeBlock>(binaryReader);
            recordedAnimations = Guerilla.ReadBlockArray<RecordedAnimationBlock>(binaryReader);
            netgameFlags = Guerilla.ReadBlockArray<ScenarioNetpointsBlock>(binaryReader);
            netgameEquipment = Guerilla.ReadBlockArray<ScenarioNetgameEquipmentBlock>(binaryReader);
            startingEquipment = Guerilla.ReadBlockArray<ScenarioStartingEquipmentBlock>(binaryReader);
            bSPSwitchTriggerVolumes = Guerilla.ReadBlockArray<ScenarioBspSwitchTriggerVolumeBlock>(binaryReader);
            decals = Guerilla.ReadBlockArray<ScenarioDecalsBlock>(binaryReader);
            decalsPalette = Guerilla.ReadBlockArray<ScenarioDecalPaletteBlock>(binaryReader);
            detailObjectCollectionPalette = Guerilla.ReadBlockArray<ScenarioDetailObjectCollectionPaletteBlock>(binaryReader);
            stylePalette = Guerilla.ReadBlockArray<StylePaletteBlock>(binaryReader);
            squadGroups = Guerilla.ReadBlockArray<SquadGroupsBlock>(binaryReader);
            squads = Guerilla.ReadBlockArray<SquadsBlock>(binaryReader);
            zones = Guerilla.ReadBlockArray<ZoneBlock>(binaryReader);
            missionScenes = Guerilla.ReadBlockArray<AiSceneBlock>(binaryReader);
            characterPalette = Guerilla.ReadBlockArray<CharacterPaletteBlock>(binaryReader);
            aIPathfindingData = Guerilla.ReadBlockArray<PathfindingDataBlock>(binaryReader);
            aIAnimationReferences = Guerilla.ReadBlockArray<AiAnimationReferenceBlock>(binaryReader);
            aIScriptReferences = Guerilla.ReadBlockArray<AiScriptReferenceBlock>(binaryReader);
            aIRecordingReferences = Guerilla.ReadBlockArray<AiRecordingReferenceBlock>(binaryReader);
            aIConversations = Guerilla.ReadBlockArray<AiConversationBlock>(binaryReader);
            scriptSyntaxData = Guerilla.ReadData(binaryReader);
            scriptStringData = Guerilla.ReadData(binaryReader);
            scripts = Guerilla.ReadBlockArray<HsScriptsBlock>(binaryReader);
            globals = Guerilla.ReadBlockArray<HsGlobalsBlock>(binaryReader);
            references = Guerilla.ReadBlockArray<HsReferencesBlock>(binaryReader);
            sourceFiles = Guerilla.ReadBlockArray<HsSourceFilesBlock>(binaryReader);
            scriptingData = Guerilla.ReadBlockArray<CsScriptDataBlock>(binaryReader);
            cutsceneFlags = Guerilla.ReadBlockArray<ScenarioCutsceneFlagBlock>(binaryReader);
            cutsceneCameraPoints = Guerilla.ReadBlockArray<ScenarioCutsceneCameraPointBlock>(binaryReader);
            cutsceneTitles = Guerilla.ReadBlockArray<ScenarioCutsceneTitleBlock>(binaryReader);
            customObjectNames = binaryReader.ReadTagReference();
            chapterTitleText = binaryReader.ReadTagReference();
            hUDMessages = binaryReader.ReadTagReference();
            structureBSPs = Guerilla.ReadBlockArray<ScenarioStructureBspReferenceBlock>(binaryReader);
            scenarioResources = Guerilla.ReadBlockArray<ScenarioResourcesBlock>(binaryReader);
            scenarioResources0 = Guerilla.ReadBlockArray<OldUnusedStrucurePhysicsBlock>(binaryReader);
            hsUnitSeats = Guerilla.ReadBlockArray<HsUnitSeatBlock>(binaryReader);
            scenarioKillTriggers = Guerilla.ReadBlockArray<ScenarioKillTriggerVolumesBlock>(binaryReader);
            hsSyntaxDatums = Guerilla.ReadBlockArray<SyntaxDatumBlock>(binaryReader);
            orders = Guerilla.ReadBlockArray<OrdersBlock>(binaryReader);
            triggers = Guerilla.ReadBlockArray<TriggersBlock>(binaryReader);
            backgroundSoundPalette = Guerilla.ReadBlockArray<StructureBspBackgroundSoundPaletteBlock>(binaryReader);
            soundEnvironmentPalette = Guerilla.ReadBlockArray<StructureBspSoundEnvironmentPaletteBlock>(binaryReader);
            weatherPalette = Guerilla.ReadBlockArray<StructureBspWeatherPaletteBlock>(binaryReader);
            eMPTYSTRING = Guerilla.ReadBlockArray<GNullBlock>(binaryReader);
            eMPTYSTRING0 = Guerilla.ReadBlockArray<GNullBlock>(binaryReader);
            eMPTYSTRING1 = Guerilla.ReadBlockArray<GNullBlock>(binaryReader);
            eMPTYSTRING2 = Guerilla.ReadBlockArray<GNullBlock>(binaryReader);
            eMPTYSTRING3 = Guerilla.ReadBlockArray<GNullBlock>(binaryReader);
            scenarioClusterData = Guerilla.ReadBlockArray<ScenarioClusterDataBlock>(binaryReader);
            objectSalts = new []{ new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader), new ObjectSalts(binaryReader),  };
            spawnData = Guerilla.ReadBlockArray<ScenarioSpawnDataBlock>(binaryReader);
            soundEffectCollection = binaryReader.ReadTagReference();
            crates = Guerilla.ReadBlockArray<ScenarioCrateBlock>(binaryReader);
            cratesPalette = Guerilla.ReadBlockArray<ScenarioCratePaletteBlock>(binaryReader);
            globalLighting = binaryReader.ReadTagReference();
            atmosphericFogPalette = Guerilla.ReadBlockArray<ScenarioAtmosphericFogPalette>(binaryReader);
            planarFogPalette = Guerilla.ReadBlockArray<ScenarioPlanarFogPalette>(binaryReader);
            flocks = Guerilla.ReadBlockArray<FlockDefinitionBlock>(binaryReader);
            subtitles = binaryReader.ReadTagReference();
            decorators = Guerilla.ReadBlockArray<DecoratorPlacementDefinitionBlock>(binaryReader);
            creatures = Guerilla.ReadBlockArray<ScenarioCreatureBlock>(binaryReader);
            creaturesPalette = Guerilla.ReadBlockArray<ScenarioCreaturePaletteBlock>(binaryReader);
            decoratorsPalette = Guerilla.ReadBlockArray<ScenarioDecoratorSetPaletteEntryBlock>(binaryReader);
            bSPTransitionVolumes = Guerilla.ReadBlockArray<ScenarioBspSwitchTransitionVolumeBlock>(binaryReader);
            structureBSPLighting = Guerilla.ReadBlockArray<ScenarioStructureBspSphericalHarmonicLightingBlock>(binaryReader);
            editorFolders = Guerilla.ReadBlockArray<GScenarioEditorFolderBlock>(binaryReader);
            levelData = Guerilla.ReadBlockArray<ScenarioLevelDataBlock>(binaryReader);
            territoryLocationNames = binaryReader.ReadTagReference();
            invalidName_0 = binaryReader.ReadBytes(8);
            missionDialogue = Guerilla.ReadBlockArray<AiScenarioMissionDialogueBlock>(binaryReader);
            objectives = binaryReader.ReadTagReference();
            interpolators = Guerilla.ReadBlockArray<ScenarioInterpolatorBlock>(binaryReader);
            sharedReferences = Guerilla.ReadBlockArray<HsReferencesBlock>(binaryReader);
            screenEffectReferences = Guerilla.ReadBlockArray<ScenarioScreenEffectReferenceBlock>(binaryReader);
            simulationDefinitionTable = Guerilla.ReadBlockArray<ScenarioSimulationDefinitionTableBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(doNotUse);
                Guerilla.WriteBlockArray<ScenarioSkyReferenceBlock>(binaryWriter, skies, nextAddress);
                binaryWriter.Write((Int16)type);
                binaryWriter.Write((Int16)flags);
                Guerilla.WriteBlockArray<ScenarioChildScenarioBlock>(binaryWriter, childScenarios, nextAddress);
                binaryWriter.Write(localNorth);
                Guerilla.WriteBlockArray<PredictedResourceBlock>(binaryWriter, predictedResources, nextAddress);
                Guerilla.WriteBlockArray<ScenarioFunctionBlock>(binaryWriter, functions, nextAddress);
                Guerilla.WriteData(binaryWriter);
                Guerilla.WriteBlockArray<EditorCommentBlock>(binaryWriter, comments, nextAddress);
                Guerilla.WriteBlockArray<DontUseMeScenarioEnvironmentObjectBlock>(binaryWriter, invalidName_, nextAddress);
                Guerilla.WriteBlockArray<ScenarioObjectNamesBlock>(binaryWriter, objectNames, nextAddress);
                Guerilla.WriteBlockArray<ScenarioSceneryBlock>(binaryWriter, scenery, nextAddress);
                Guerilla.WriteBlockArray<ScenarioSceneryPaletteBlock>(binaryWriter, sceneryPalette, nextAddress);
                Guerilla.WriteBlockArray<ScenarioBipedBlock>(binaryWriter, bipeds, nextAddress);
                Guerilla.WriteBlockArray<ScenarioBipedPaletteBlock>(binaryWriter, bipedPalette, nextAddress);
                Guerilla.WriteBlockArray<ScenarioVehicleBlock>(binaryWriter, vehicles, nextAddress);
                Guerilla.WriteBlockArray<ScenarioVehiclePaletteBlock>(binaryWriter, vehiclePalette, nextAddress);
                Guerilla.WriteBlockArray<ScenarioEquipmentBlock>(binaryWriter, equipment, nextAddress);
                Guerilla.WriteBlockArray<ScenarioEquipmentPaletteBlock>(binaryWriter, equipmentPalette, nextAddress);
                Guerilla.WriteBlockArray<ScenarioWeaponBlock>(binaryWriter, weapons, nextAddress);
                Guerilla.WriteBlockArray<ScenarioWeaponPaletteBlock>(binaryWriter, weaponPalette, nextAddress);
                Guerilla.WriteBlockArray<DeviceGroupBlock>(binaryWriter, deviceGroups, nextAddress);
                Guerilla.WriteBlockArray<ScenarioMachineBlock>(binaryWriter, machines, nextAddress);
                Guerilla.WriteBlockArray<ScenarioMachinePaletteBlock>(binaryWriter, machinePalette, nextAddress);
                Guerilla.WriteBlockArray<ScenarioControlBlock>(binaryWriter, controls, nextAddress);
                Guerilla.WriteBlockArray<ScenarioControlPaletteBlock>(binaryWriter, controlPalette, nextAddress);
                Guerilla.WriteBlockArray<ScenarioLightFixtureBlock>(binaryWriter, lightFixtures, nextAddress);
                Guerilla.WriteBlockArray<ScenarioLightFixturePaletteBlock>(binaryWriter, lightFixturesPalette, nextAddress);
                Guerilla.WriteBlockArray<ScenarioSoundSceneryBlock>(binaryWriter, soundScenery, nextAddress);
                Guerilla.WriteBlockArray<ScenarioSoundSceneryPaletteBlock>(binaryWriter, soundSceneryPalette, nextAddress);
                Guerilla.WriteBlockArray<ScenarioLightBlock>(binaryWriter, lightVolumes, nextAddress);
                Guerilla.WriteBlockArray<ScenarioLightPaletteBlock>(binaryWriter, lightVolumesPalette, nextAddress);
                Guerilla.WriteBlockArray<ScenarioProfilesBlock>(binaryWriter, playerStartingProfile, nextAddress);
                Guerilla.WriteBlockArray<ScenarioPlayersBlock>(binaryWriter, playerStartingLocations, nextAddress);
                Guerilla.WriteBlockArray<ScenarioTriggerVolumeBlock>(binaryWriter, killTriggerVolumes, nextAddress);
                Guerilla.WriteBlockArray<RecordedAnimationBlock>(binaryWriter, recordedAnimations, nextAddress);
                Guerilla.WriteBlockArray<ScenarioNetpointsBlock>(binaryWriter, netgameFlags, nextAddress);
                Guerilla.WriteBlockArray<ScenarioNetgameEquipmentBlock>(binaryWriter, netgameEquipment, nextAddress);
                Guerilla.WriteBlockArray<ScenarioStartingEquipmentBlock>(binaryWriter, startingEquipment, nextAddress);
                Guerilla.WriteBlockArray<ScenarioBspSwitchTriggerVolumeBlock>(binaryWriter, bSPSwitchTriggerVolumes, nextAddress);
                Guerilla.WriteBlockArray<ScenarioDecalsBlock>(binaryWriter, decals, nextAddress);
                Guerilla.WriteBlockArray<ScenarioDecalPaletteBlock>(binaryWriter, decalsPalette, nextAddress);
                Guerilla.WriteBlockArray<ScenarioDetailObjectCollectionPaletteBlock>(binaryWriter, detailObjectCollectionPalette, nextAddress);
                Guerilla.WriteBlockArray<StylePaletteBlock>(binaryWriter, stylePalette, nextAddress);
                Guerilla.WriteBlockArray<SquadGroupsBlock>(binaryWriter, squadGroups, nextAddress);
                Guerilla.WriteBlockArray<SquadsBlock>(binaryWriter, squads, nextAddress);
                Guerilla.WriteBlockArray<ZoneBlock>(binaryWriter, zones, nextAddress);
                Guerilla.WriteBlockArray<AiSceneBlock>(binaryWriter, missionScenes, nextAddress);
                Guerilla.WriteBlockArray<CharacterPaletteBlock>(binaryWriter, characterPalette, nextAddress);
                Guerilla.WriteBlockArray<PathfindingDataBlock>(binaryWriter, aIPathfindingData, nextAddress);
                Guerilla.WriteBlockArray<AiAnimationReferenceBlock>(binaryWriter, aIAnimationReferences, nextAddress);
                Guerilla.WriteBlockArray<AiScriptReferenceBlock>(binaryWriter, aIScriptReferences, nextAddress);
                Guerilla.WriteBlockArray<AiRecordingReferenceBlock>(binaryWriter, aIRecordingReferences, nextAddress);
                Guerilla.WriteBlockArray<AiConversationBlock>(binaryWriter, aIConversations, nextAddress);
                Guerilla.WriteData(binaryWriter);
                Guerilla.WriteData(binaryWriter);
                Guerilla.WriteBlockArray<HsScriptsBlock>(binaryWriter, scripts, nextAddress);
                Guerilla.WriteBlockArray<HsGlobalsBlock>(binaryWriter, globals, nextAddress);
                Guerilla.WriteBlockArray<HsReferencesBlock>(binaryWriter, references, nextAddress);
                Guerilla.WriteBlockArray<HsSourceFilesBlock>(binaryWriter, sourceFiles, nextAddress);
                Guerilla.WriteBlockArray<CsScriptDataBlock>(binaryWriter, scriptingData, nextAddress);
                Guerilla.WriteBlockArray<ScenarioCutsceneFlagBlock>(binaryWriter, cutsceneFlags, nextAddress);
                Guerilla.WriteBlockArray<ScenarioCutsceneCameraPointBlock>(binaryWriter, cutsceneCameraPoints, nextAddress);
                Guerilla.WriteBlockArray<ScenarioCutsceneTitleBlock>(binaryWriter, cutsceneTitles, nextAddress);
                binaryWriter.Write(customObjectNames);
                binaryWriter.Write(chapterTitleText);
                binaryWriter.Write(hUDMessages);
                Guerilla.WriteBlockArray<ScenarioStructureBspReferenceBlock>(binaryWriter, structureBSPs, nextAddress);
                Guerilla.WriteBlockArray<ScenarioResourcesBlock>(binaryWriter, scenarioResources, nextAddress);
                Guerilla.WriteBlockArray<OldUnusedStrucurePhysicsBlock>(binaryWriter, scenarioResources0, nextAddress);
                Guerilla.WriteBlockArray<HsUnitSeatBlock>(binaryWriter, hsUnitSeats, nextAddress);
                Guerilla.WriteBlockArray<ScenarioKillTriggerVolumesBlock>(binaryWriter, scenarioKillTriggers, nextAddress);
                Guerilla.WriteBlockArray<SyntaxDatumBlock>(binaryWriter, hsSyntaxDatums, nextAddress);
                Guerilla.WriteBlockArray<OrdersBlock>(binaryWriter, orders, nextAddress);
                Guerilla.WriteBlockArray<TriggersBlock>(binaryWriter, triggers, nextAddress);
                Guerilla.WriteBlockArray<StructureBspBackgroundSoundPaletteBlock>(binaryWriter, backgroundSoundPalette, nextAddress);
                Guerilla.WriteBlockArray<StructureBspSoundEnvironmentPaletteBlock>(binaryWriter, soundEnvironmentPalette, nextAddress);
                Guerilla.WriteBlockArray<StructureBspWeatherPaletteBlock>(binaryWriter, weatherPalette, nextAddress);
                Guerilla.WriteBlockArray<GNullBlock>(binaryWriter, eMPTYSTRING, nextAddress);
                Guerilla.WriteBlockArray<GNullBlock>(binaryWriter, eMPTYSTRING0, nextAddress);
                Guerilla.WriteBlockArray<GNullBlock>(binaryWriter, eMPTYSTRING1, nextAddress);
                Guerilla.WriteBlockArray<GNullBlock>(binaryWriter, eMPTYSTRING2, nextAddress);
                Guerilla.WriteBlockArray<GNullBlock>(binaryWriter, eMPTYSTRING3, nextAddress);
                Guerilla.WriteBlockArray<ScenarioClusterDataBlock>(binaryWriter, scenarioClusterData, nextAddress);
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
                Guerilla.WriteBlockArray<ScenarioSpawnDataBlock>(binaryWriter, spawnData, nextAddress);
                binaryWriter.Write(soundEffectCollection);
                Guerilla.WriteBlockArray<ScenarioCrateBlock>(binaryWriter, crates, nextAddress);
                Guerilla.WriteBlockArray<ScenarioCratePaletteBlock>(binaryWriter, cratesPalette, nextAddress);
                binaryWriter.Write(globalLighting);
                Guerilla.WriteBlockArray<ScenarioAtmosphericFogPalette>(binaryWriter, atmosphericFogPalette, nextAddress);
                Guerilla.WriteBlockArray<ScenarioPlanarFogPalette>(binaryWriter, planarFogPalette, nextAddress);
                Guerilla.WriteBlockArray<FlockDefinitionBlock>(binaryWriter, flocks, nextAddress);
                binaryWriter.Write(subtitles);
                Guerilla.WriteBlockArray<DecoratorPlacementDefinitionBlock>(binaryWriter, decorators, nextAddress);
                Guerilla.WriteBlockArray<ScenarioCreatureBlock>(binaryWriter, creatures, nextAddress);
                Guerilla.WriteBlockArray<ScenarioCreaturePaletteBlock>(binaryWriter, creaturesPalette, nextAddress);
                Guerilla.WriteBlockArray<ScenarioDecoratorSetPaletteEntryBlock>(binaryWriter, decoratorsPalette, nextAddress);
                Guerilla.WriteBlockArray<ScenarioBspSwitchTransitionVolumeBlock>(binaryWriter, bSPTransitionVolumes, nextAddress);
                Guerilla.WriteBlockArray<ScenarioStructureBspSphericalHarmonicLightingBlock>(binaryWriter, structureBSPLighting, nextAddress);
                Guerilla.WriteBlockArray<GScenarioEditorFolderBlock>(binaryWriter, editorFolders, nextAddress);
                Guerilla.WriteBlockArray<ScenarioLevelDataBlock>(binaryWriter, levelData, nextAddress);
                binaryWriter.Write(territoryLocationNames);
                binaryWriter.Write(invalidName_0, 0, 8);
                Guerilla.WriteBlockArray<AiScenarioMissionDialogueBlock>(binaryWriter, missionDialogue, nextAddress);
                binaryWriter.Write(objectives);
                Guerilla.WriteBlockArray<ScenarioInterpolatorBlock>(binaryWriter, interpolators, nextAddress);
                Guerilla.WriteBlockArray<HsReferencesBlock>(binaryWriter, sharedReferences, nextAddress);
                Guerilla.WriteBlockArray<ScenarioScreenEffectReferenceBlock>(binaryWriter, screenEffectReferences, nextAddress);
                Guerilla.WriteBlockArray<ScenarioSimulationDefinitionTableBlock>(binaryWriter, simulationDefinitionTable, nextAddress);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
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
        public class ObjectSalts  : IGuerilla
        {
            internal int eMPTYSTRING;
            internal  ObjectSalts(BinaryReader binaryReader)
            {
                eMPTYSTRING = binaryReader.ReadInt32();
            }
            public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
            {
                using(binaryWriter.BaseStream.Pin())
                {
                    binaryWriter.Write(eMPTYSTRING);
                    return nextAddress = (int)binaryWriter.BaseStream.Position;
                }
            }
        };
    };
}
