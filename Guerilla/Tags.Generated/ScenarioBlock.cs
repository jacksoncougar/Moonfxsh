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
        public static readonly TagClass Scnr = (TagClass)"scnr";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("scnr")]
    public partial class ScenarioBlock : ScenarioBlockBase
    {
        public  ScenarioBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ScenarioBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 992, Alignment = 4)]
    public class ScenarioBlockBase : GuerillaBlock
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
        
        public override int SerializedSize{get { return 992; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ScenarioBlockBase(BinaryReader binaryReader): base(binaryReader)
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
        public  ScenarioBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(doNotUse);
                nextAddress = Guerilla.WriteBlockArray<ScenarioSkyReferenceBlock>(binaryWriter, skies, nextAddress);
                binaryWriter.Write((Int16)type);
                binaryWriter.Write((Int16)flags);
                nextAddress = Guerilla.WriteBlockArray<ScenarioChildScenarioBlock>(binaryWriter, childScenarios, nextAddress);
                binaryWriter.Write(localNorth);
                nextAddress = Guerilla.WriteBlockArray<PredictedResourceBlock>(binaryWriter, predictedResources, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioFunctionBlock>(binaryWriter, functions, nextAddress);
                nextAddress = Guerilla.WriteData(binaryWriter, editorScenarioData, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<EditorCommentBlock>(binaryWriter, comments, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<DontUseMeScenarioEnvironmentObjectBlock>(binaryWriter, invalidName_, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioObjectNamesBlock>(binaryWriter, objectNames, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioSceneryBlock>(binaryWriter, scenery, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioSceneryPaletteBlock>(binaryWriter, sceneryPalette, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioBipedBlock>(binaryWriter, bipeds, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioBipedPaletteBlock>(binaryWriter, bipedPalette, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioVehicleBlock>(binaryWriter, vehicles, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioVehiclePaletteBlock>(binaryWriter, vehiclePalette, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioEquipmentBlock>(binaryWriter, equipment, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioEquipmentPaletteBlock>(binaryWriter, equipmentPalette, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioWeaponBlock>(binaryWriter, weapons, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioWeaponPaletteBlock>(binaryWriter, weaponPalette, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<DeviceGroupBlock>(binaryWriter, deviceGroups, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioMachineBlock>(binaryWriter, machines, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioMachinePaletteBlock>(binaryWriter, machinePalette, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioControlBlock>(binaryWriter, controls, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioControlPaletteBlock>(binaryWriter, controlPalette, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioLightFixtureBlock>(binaryWriter, lightFixtures, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioLightFixturePaletteBlock>(binaryWriter, lightFixturesPalette, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioSoundSceneryBlock>(binaryWriter, soundScenery, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioSoundSceneryPaletteBlock>(binaryWriter, soundSceneryPalette, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioLightBlock>(binaryWriter, lightVolumes, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioLightPaletteBlock>(binaryWriter, lightVolumesPalette, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioProfilesBlock>(binaryWriter, playerStartingProfile, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioPlayersBlock>(binaryWriter, playerStartingLocations, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioTriggerVolumeBlock>(binaryWriter, killTriggerVolumes, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<RecordedAnimationBlock>(binaryWriter, recordedAnimations, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioNetpointsBlock>(binaryWriter, netgameFlags, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioNetgameEquipmentBlock>(binaryWriter, netgameEquipment, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioStartingEquipmentBlock>(binaryWriter, startingEquipment, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioBspSwitchTriggerVolumeBlock>(binaryWriter, bSPSwitchTriggerVolumes, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioDecalsBlock>(binaryWriter, decals, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioDecalPaletteBlock>(binaryWriter, decalsPalette, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioDetailObjectCollectionPaletteBlock>(binaryWriter, detailObjectCollectionPalette, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<StylePaletteBlock>(binaryWriter, stylePalette, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<SquadGroupsBlock>(binaryWriter, squadGroups, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<SquadsBlock>(binaryWriter, squads, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ZoneBlock>(binaryWriter, zones, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<AiSceneBlock>(binaryWriter, missionScenes, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CharacterPaletteBlock>(binaryWriter, characterPalette, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<PathfindingDataBlock>(binaryWriter, aIPathfindingData, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<AiAnimationReferenceBlock>(binaryWriter, aIAnimationReferences, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<AiScriptReferenceBlock>(binaryWriter, aIScriptReferences, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<AiRecordingReferenceBlock>(binaryWriter, aIRecordingReferences, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<AiConversationBlock>(binaryWriter, aIConversations, nextAddress);
                nextAddress = Guerilla.WriteData(binaryWriter, scriptSyntaxData, nextAddress);
                nextAddress = Guerilla.WriteData(binaryWriter, scriptStringData, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<HsScriptsBlock>(binaryWriter, scripts, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<HsGlobalsBlock>(binaryWriter, globals, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<HsReferencesBlock>(binaryWriter, references, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<HsSourceFilesBlock>(binaryWriter, sourceFiles, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CsScriptDataBlock>(binaryWriter, scriptingData, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioCutsceneFlagBlock>(binaryWriter, cutsceneFlags, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioCutsceneCameraPointBlock>(binaryWriter, cutsceneCameraPoints, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioCutsceneTitleBlock>(binaryWriter, cutsceneTitles, nextAddress);
                binaryWriter.Write(customObjectNames);
                binaryWriter.Write(chapterTitleText);
                binaryWriter.Write(hUDMessages);
                nextAddress = Guerilla.WriteBlockArray<ScenarioStructureBspReferenceBlock>(binaryWriter, structureBSPs, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioResourcesBlock>(binaryWriter, scenarioResources, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<OldUnusedStrucurePhysicsBlock>(binaryWriter, scenarioResources0, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<HsUnitSeatBlock>(binaryWriter, hsUnitSeats, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioKillTriggerVolumesBlock>(binaryWriter, scenarioKillTriggers, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<SyntaxDatumBlock>(binaryWriter, hsSyntaxDatums, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<OrdersBlock>(binaryWriter, orders, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<TriggersBlock>(binaryWriter, triggers, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<StructureBspBackgroundSoundPaletteBlock>(binaryWriter, backgroundSoundPalette, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<StructureBspSoundEnvironmentPaletteBlock>(binaryWriter, soundEnvironmentPalette, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<StructureBspWeatherPaletteBlock>(binaryWriter, weatherPalette, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GNullBlock>(binaryWriter, eMPTYSTRING, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GNullBlock>(binaryWriter, eMPTYSTRING0, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GNullBlock>(binaryWriter, eMPTYSTRING1, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GNullBlock>(binaryWriter, eMPTYSTRING2, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GNullBlock>(binaryWriter, eMPTYSTRING3, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioClusterDataBlock>(binaryWriter, scenarioClusterData, nextAddress);
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
                nextAddress = Guerilla.WriteBlockArray<ScenarioSpawnDataBlock>(binaryWriter, spawnData, nextAddress);
                binaryWriter.Write(soundEffectCollection);
                nextAddress = Guerilla.WriteBlockArray<ScenarioCrateBlock>(binaryWriter, crates, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioCratePaletteBlock>(binaryWriter, cratesPalette, nextAddress);
                binaryWriter.Write(globalLighting);
                nextAddress = Guerilla.WriteBlockArray<ScenarioAtmosphericFogPalette>(binaryWriter, atmosphericFogPalette, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioPlanarFogPalette>(binaryWriter, planarFogPalette, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<FlockDefinitionBlock>(binaryWriter, flocks, nextAddress);
                binaryWriter.Write(subtitles);
                nextAddress = Guerilla.WriteBlockArray<DecoratorPlacementDefinitionBlock>(binaryWriter, decorators, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioCreatureBlock>(binaryWriter, creatures, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioCreaturePaletteBlock>(binaryWriter, creaturesPalette, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioDecoratorSetPaletteEntryBlock>(binaryWriter, decoratorsPalette, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioBspSwitchTransitionVolumeBlock>(binaryWriter, bSPTransitionVolumes, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioStructureBspSphericalHarmonicLightingBlock>(binaryWriter, structureBSPLighting, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GScenarioEditorFolderBlock>(binaryWriter, editorFolders, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioLevelDataBlock>(binaryWriter, levelData, nextAddress);
                binaryWriter.Write(territoryLocationNames);
                binaryWriter.Write(invalidName_0, 0, 8);
                nextAddress = Guerilla.WriteBlockArray<AiScenarioMissionDialogueBlock>(binaryWriter, missionDialogue, nextAddress);
                binaryWriter.Write(objectives);
                nextAddress = Guerilla.WriteBlockArray<ScenarioInterpolatorBlock>(binaryWriter, interpolators, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<HsReferencesBlock>(binaryWriter, sharedReferences, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioScreenEffectReferenceBlock>(binaryWriter, screenEffectReferences, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioSimulationDefinitionTableBlock>(binaryWriter, simulationDefinitionTable, nextAddress);
                return nextAddress;
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
        [LayoutAttribute(Size = 4, Alignment = 1)]
        public class ObjectSalts : GuerillaBlock
        {
            internal int eMPTYSTRING;
            
            public override int SerializedSize{get { return 4; }}
            
            
            public override int Alignment{get { return 1; }}
            
            public  ObjectSalts(BinaryReader binaryReader): base(binaryReader)
            {
                eMPTYSTRING = binaryReader.ReadInt32();
            }
            public  ObjectSalts(): base()
            {
                
            }
            public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
            {
                using(binaryWriter.BaseStream.Pin())
                {
                    binaryWriter.Write(eMPTYSTRING);
                    return nextAddress;
                }
            }
        };
    };
}
