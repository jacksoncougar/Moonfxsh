// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

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
        public ScenarioBlock() : base()
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
        public override int SerializedSize { get { return 992; } }
        public override int Alignment { get { return 4; } }
        public ScenarioBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            doNotUse = binaryReader.ReadTagReference();
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioSkyReferenceBlock>(binaryReader));
            type = (Type)binaryReader.ReadInt16();
            flags = (Flags)binaryReader.ReadInt16();
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioChildScenarioBlock>(binaryReader));
            localNorth = binaryReader.ReadSingle();
            blamPointers.Enqueue(ReadBlockArrayPointer<PredictedResourceBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioFunctionBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer(binaryReader, 1));
            blamPointers.Enqueue(ReadBlockArrayPointer<EditorCommentBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<DontUseMeScenarioEnvironmentObjectBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioObjectNamesBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioSceneryBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioSceneryPaletteBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioBipedBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioBipedPaletteBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioVehicleBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioVehiclePaletteBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioEquipmentBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioEquipmentPaletteBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioWeaponBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioWeaponPaletteBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<DeviceGroupBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioMachineBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioMachinePaletteBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioControlBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioControlPaletteBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioLightFixtureBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioLightFixturePaletteBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioSoundSceneryBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioSoundSceneryPaletteBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioLightBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioLightPaletteBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioProfilesBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioPlayersBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioTriggerVolumeBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<RecordedAnimationBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioNetpointsBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioNetgameEquipmentBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioStartingEquipmentBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioBspSwitchTriggerVolumeBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioDecalsBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioDecalPaletteBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioDetailObjectCollectionPaletteBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<StylePaletteBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<SquadGroupsBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<SquadsBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ZoneBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<AiSceneBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<CharacterPaletteBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<PathfindingDataBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<AiAnimationReferenceBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<AiScriptReferenceBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<AiRecordingReferenceBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<AiConversationBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer(binaryReader, 1));
            blamPointers.Enqueue(ReadBlockArrayPointer(binaryReader, 1));
            blamPointers.Enqueue(ReadBlockArrayPointer<HsScriptsBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<HsGlobalsBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<HsReferencesBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<HsSourceFilesBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<CsScriptDataBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioCutsceneFlagBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioCutsceneCameraPointBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioCutsceneTitleBlock>(binaryReader));
            customObjectNames = binaryReader.ReadTagReference();
            chapterTitleText = binaryReader.ReadTagReference();
            hUDMessages = binaryReader.ReadTagReference();
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioStructureBspReferenceBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioResourcesBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<OldUnusedStrucurePhysicsBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<HsUnitSeatBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioKillTriggerVolumesBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<SyntaxDatumBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<OrdersBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<TriggersBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureBspBackgroundSoundPaletteBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureBspSoundEnvironmentPaletteBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureBspWeatherPaletteBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<GNullBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<GNullBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<GNullBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<GNullBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<GNullBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioClusterDataBlock>(binaryReader));
            objectSalts = new []{ new ObjectSalts(), new ObjectSalts(), new ObjectSalts(), new ObjectSalts(), new ObjectSalts(), new ObjectSalts(), new ObjectSalts(), new ObjectSalts(), new ObjectSalts(), new ObjectSalts(), new ObjectSalts(), new ObjectSalts(), new ObjectSalts(), new ObjectSalts(), new ObjectSalts(), new ObjectSalts(), new ObjectSalts(), new ObjectSalts(), new ObjectSalts(), new ObjectSalts(), new ObjectSalts(), new ObjectSalts(), new ObjectSalts(), new ObjectSalts(), new ObjectSalts(), new ObjectSalts(), new ObjectSalts(), new ObjectSalts(), new ObjectSalts(), new ObjectSalts(), new ObjectSalts(), new ObjectSalts() };
            blamPointers.Concat(objectSalts[0].ReadFields(binaryReader));
            blamPointers.Concat(objectSalts[1].ReadFields(binaryReader));
            blamPointers.Concat(objectSalts[2].ReadFields(binaryReader));
            blamPointers.Concat(objectSalts[3].ReadFields(binaryReader));
            blamPointers.Concat(objectSalts[4].ReadFields(binaryReader));
            blamPointers.Concat(objectSalts[5].ReadFields(binaryReader));
            blamPointers.Concat(objectSalts[6].ReadFields(binaryReader));
            blamPointers.Concat(objectSalts[7].ReadFields(binaryReader));
            blamPointers.Concat(objectSalts[8].ReadFields(binaryReader));
            blamPointers.Concat(objectSalts[9].ReadFields(binaryReader));
            blamPointers.Concat(objectSalts[10].ReadFields(binaryReader));
            blamPointers.Concat(objectSalts[11].ReadFields(binaryReader));
            blamPointers.Concat(objectSalts[12].ReadFields(binaryReader));
            blamPointers.Concat(objectSalts[13].ReadFields(binaryReader));
            blamPointers.Concat(objectSalts[14].ReadFields(binaryReader));
            blamPointers.Concat(objectSalts[15].ReadFields(binaryReader));
            blamPointers.Concat(objectSalts[16].ReadFields(binaryReader));
            blamPointers.Concat(objectSalts[17].ReadFields(binaryReader));
            blamPointers.Concat(objectSalts[18].ReadFields(binaryReader));
            blamPointers.Concat(objectSalts[19].ReadFields(binaryReader));
            blamPointers.Concat(objectSalts[20].ReadFields(binaryReader));
            blamPointers.Concat(objectSalts[21].ReadFields(binaryReader));
            blamPointers.Concat(objectSalts[22].ReadFields(binaryReader));
            blamPointers.Concat(objectSalts[23].ReadFields(binaryReader));
            blamPointers.Concat(objectSalts[24].ReadFields(binaryReader));
            blamPointers.Concat(objectSalts[25].ReadFields(binaryReader));
            blamPointers.Concat(objectSalts[26].ReadFields(binaryReader));
            blamPointers.Concat(objectSalts[27].ReadFields(binaryReader));
            blamPointers.Concat(objectSalts[28].ReadFields(binaryReader));
            blamPointers.Concat(objectSalts[29].ReadFields(binaryReader));
            blamPointers.Concat(objectSalts[30].ReadFields(binaryReader));
            blamPointers.Concat(objectSalts[31].ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioSpawnDataBlock>(binaryReader));
            soundEffectCollection = binaryReader.ReadTagReference();
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioCrateBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioCratePaletteBlock>(binaryReader));
            globalLighting = binaryReader.ReadTagReference();
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioAtmosphericFogPalette>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioPlanarFogPalette>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<FlockDefinitionBlock>(binaryReader));
            subtitles = binaryReader.ReadTagReference();
            blamPointers.Enqueue(ReadBlockArrayPointer<DecoratorPlacementDefinitionBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioCreatureBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioCreaturePaletteBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioDecoratorSetPaletteEntryBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioBspSwitchTransitionVolumeBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioStructureBspSphericalHarmonicLightingBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<GScenarioEditorFolderBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioLevelDataBlock>(binaryReader));
            territoryLocationNames = binaryReader.ReadTagReference();
            invalidName_0 = binaryReader.ReadBytes(8);
            blamPointers.Enqueue(ReadBlockArrayPointer<AiScenarioMissionDialogueBlock>(binaryReader));
            objectives = binaryReader.ReadTagReference();
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioInterpolatorBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<HsReferencesBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioScreenEffectReferenceBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioSimulationDefinitionTableBlock>(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            skies = ReadBlockArrayData<ScenarioSkyReferenceBlock>(binaryReader, blamPointers.Dequeue());
            childScenarios = ReadBlockArrayData<ScenarioChildScenarioBlock>(binaryReader, blamPointers.Dequeue());
            predictedResources = ReadBlockArrayData<PredictedResourceBlock>(binaryReader, blamPointers.Dequeue());
            functions = ReadBlockArrayData<ScenarioFunctionBlock>(binaryReader, blamPointers.Dequeue());
            editorScenarioData = ReadDataByteArray(binaryReader, blamPointers.Dequeue());
            comments = ReadBlockArrayData<EditorCommentBlock>(binaryReader, blamPointers.Dequeue());
            invalidName_ = ReadBlockArrayData<DontUseMeScenarioEnvironmentObjectBlock>(binaryReader, blamPointers.Dequeue());
            objectNames = ReadBlockArrayData<ScenarioObjectNamesBlock>(binaryReader, blamPointers.Dequeue());
            scenery = ReadBlockArrayData<ScenarioSceneryBlock>(binaryReader, blamPointers.Dequeue());
            sceneryPalette = ReadBlockArrayData<ScenarioSceneryPaletteBlock>(binaryReader, blamPointers.Dequeue());
            bipeds = ReadBlockArrayData<ScenarioBipedBlock>(binaryReader, blamPointers.Dequeue());
            bipedPalette = ReadBlockArrayData<ScenarioBipedPaletteBlock>(binaryReader, blamPointers.Dequeue());
            vehicles = ReadBlockArrayData<ScenarioVehicleBlock>(binaryReader, blamPointers.Dequeue());
            vehiclePalette = ReadBlockArrayData<ScenarioVehiclePaletteBlock>(binaryReader, blamPointers.Dequeue());
            equipment = ReadBlockArrayData<ScenarioEquipmentBlock>(binaryReader, blamPointers.Dequeue());
            equipmentPalette = ReadBlockArrayData<ScenarioEquipmentPaletteBlock>(binaryReader, blamPointers.Dequeue());
            weapons = ReadBlockArrayData<ScenarioWeaponBlock>(binaryReader, blamPointers.Dequeue());
            weaponPalette = ReadBlockArrayData<ScenarioWeaponPaletteBlock>(binaryReader, blamPointers.Dequeue());
            deviceGroups = ReadBlockArrayData<DeviceGroupBlock>(binaryReader, blamPointers.Dequeue());
            machines = ReadBlockArrayData<ScenarioMachineBlock>(binaryReader, blamPointers.Dequeue());
            machinePalette = ReadBlockArrayData<ScenarioMachinePaletteBlock>(binaryReader, blamPointers.Dequeue());
            controls = ReadBlockArrayData<ScenarioControlBlock>(binaryReader, blamPointers.Dequeue());
            controlPalette = ReadBlockArrayData<ScenarioControlPaletteBlock>(binaryReader, blamPointers.Dequeue());
            lightFixtures = ReadBlockArrayData<ScenarioLightFixtureBlock>(binaryReader, blamPointers.Dequeue());
            lightFixturesPalette = ReadBlockArrayData<ScenarioLightFixturePaletteBlock>(binaryReader, blamPointers.Dequeue());
            soundScenery = ReadBlockArrayData<ScenarioSoundSceneryBlock>(binaryReader, blamPointers.Dequeue());
            soundSceneryPalette = ReadBlockArrayData<ScenarioSoundSceneryPaletteBlock>(binaryReader, blamPointers.Dequeue());
            lightVolumes = ReadBlockArrayData<ScenarioLightBlock>(binaryReader, blamPointers.Dequeue());
            lightVolumesPalette = ReadBlockArrayData<ScenarioLightPaletteBlock>(binaryReader, blamPointers.Dequeue());
            playerStartingProfile = ReadBlockArrayData<ScenarioProfilesBlock>(binaryReader, blamPointers.Dequeue());
            playerStartingLocations = ReadBlockArrayData<ScenarioPlayersBlock>(binaryReader, blamPointers.Dequeue());
            killTriggerVolumes = ReadBlockArrayData<ScenarioTriggerVolumeBlock>(binaryReader, blamPointers.Dequeue());
            recordedAnimations = ReadBlockArrayData<RecordedAnimationBlock>(binaryReader, blamPointers.Dequeue());
            netgameFlags = ReadBlockArrayData<ScenarioNetpointsBlock>(binaryReader, blamPointers.Dequeue());
            netgameEquipment = ReadBlockArrayData<ScenarioNetgameEquipmentBlock>(binaryReader, blamPointers.Dequeue());
            startingEquipment = ReadBlockArrayData<ScenarioStartingEquipmentBlock>(binaryReader, blamPointers.Dequeue());
            bSPSwitchTriggerVolumes = ReadBlockArrayData<ScenarioBspSwitchTriggerVolumeBlock>(binaryReader, blamPointers.Dequeue());
            decals = ReadBlockArrayData<ScenarioDecalsBlock>(binaryReader, blamPointers.Dequeue());
            decalsPalette = ReadBlockArrayData<ScenarioDecalPaletteBlock>(binaryReader, blamPointers.Dequeue());
            detailObjectCollectionPalette = ReadBlockArrayData<ScenarioDetailObjectCollectionPaletteBlock>(binaryReader, blamPointers.Dequeue());
            stylePalette = ReadBlockArrayData<StylePaletteBlock>(binaryReader, blamPointers.Dequeue());
            squadGroups = ReadBlockArrayData<SquadGroupsBlock>(binaryReader, blamPointers.Dequeue());
            squads = ReadBlockArrayData<SquadsBlock>(binaryReader, blamPointers.Dequeue());
            zones = ReadBlockArrayData<ZoneBlock>(binaryReader, blamPointers.Dequeue());
            missionScenes = ReadBlockArrayData<AiSceneBlock>(binaryReader, blamPointers.Dequeue());
            characterPalette = ReadBlockArrayData<CharacterPaletteBlock>(binaryReader, blamPointers.Dequeue());
            aIPathfindingData = ReadBlockArrayData<PathfindingDataBlock>(binaryReader, blamPointers.Dequeue());
            aIAnimationReferences = ReadBlockArrayData<AiAnimationReferenceBlock>(binaryReader, blamPointers.Dequeue());
            aIScriptReferences = ReadBlockArrayData<AiScriptReferenceBlock>(binaryReader, blamPointers.Dequeue());
            aIRecordingReferences = ReadBlockArrayData<AiRecordingReferenceBlock>(binaryReader, blamPointers.Dequeue());
            aIConversations = ReadBlockArrayData<AiConversationBlock>(binaryReader, blamPointers.Dequeue());
            scriptSyntaxData = ReadDataByteArray(binaryReader, blamPointers.Dequeue());
            scriptStringData = ReadDataByteArray(binaryReader, blamPointers.Dequeue());
            scripts = ReadBlockArrayData<HsScriptsBlock>(binaryReader, blamPointers.Dequeue());
            globals = ReadBlockArrayData<HsGlobalsBlock>(binaryReader, blamPointers.Dequeue());
            references = ReadBlockArrayData<HsReferencesBlock>(binaryReader, blamPointers.Dequeue());
            sourceFiles = ReadBlockArrayData<HsSourceFilesBlock>(binaryReader, blamPointers.Dequeue());
            scriptingData = ReadBlockArrayData<CsScriptDataBlock>(binaryReader, blamPointers.Dequeue());
            cutsceneFlags = ReadBlockArrayData<ScenarioCutsceneFlagBlock>(binaryReader, blamPointers.Dequeue());
            cutsceneCameraPoints = ReadBlockArrayData<ScenarioCutsceneCameraPointBlock>(binaryReader, blamPointers.Dequeue());
            cutsceneTitles = ReadBlockArrayData<ScenarioCutsceneTitleBlock>(binaryReader, blamPointers.Dequeue());
            structureBSPs = ReadBlockArrayData<ScenarioStructureBspReferenceBlock>(binaryReader, blamPointers.Dequeue());
            scenarioResources = ReadBlockArrayData<ScenarioResourcesBlock>(binaryReader, blamPointers.Dequeue());
            scenarioResources0 = ReadBlockArrayData<OldUnusedStrucurePhysicsBlock>(binaryReader, blamPointers.Dequeue());
            hsUnitSeats = ReadBlockArrayData<HsUnitSeatBlock>(binaryReader, blamPointers.Dequeue());
            scenarioKillTriggers = ReadBlockArrayData<ScenarioKillTriggerVolumesBlock>(binaryReader, blamPointers.Dequeue());
            hsSyntaxDatums = ReadBlockArrayData<SyntaxDatumBlock>(binaryReader, blamPointers.Dequeue());
            orders = ReadBlockArrayData<OrdersBlock>(binaryReader, blamPointers.Dequeue());
            triggers = ReadBlockArrayData<TriggersBlock>(binaryReader, blamPointers.Dequeue());
            backgroundSoundPalette = ReadBlockArrayData<StructureBspBackgroundSoundPaletteBlock>(binaryReader, blamPointers.Dequeue());
            soundEnvironmentPalette = ReadBlockArrayData<StructureBspSoundEnvironmentPaletteBlock>(binaryReader, blamPointers.Dequeue());
            weatherPalette = ReadBlockArrayData<StructureBspWeatherPaletteBlock>(binaryReader, blamPointers.Dequeue());
            eMPTYSTRING = ReadBlockArrayData<GNullBlock>(binaryReader, blamPointers.Dequeue());
            eMPTYSTRING0 = ReadBlockArrayData<GNullBlock>(binaryReader, blamPointers.Dequeue());
            eMPTYSTRING1 = ReadBlockArrayData<GNullBlock>(binaryReader, blamPointers.Dequeue());
            eMPTYSTRING2 = ReadBlockArrayData<GNullBlock>(binaryReader, blamPointers.Dequeue());
            eMPTYSTRING3 = ReadBlockArrayData<GNullBlock>(binaryReader, blamPointers.Dequeue());
            scenarioClusterData = ReadBlockArrayData<ScenarioClusterDataBlock>(binaryReader, blamPointers.Dequeue());
            objectSalts = ReadBlockArrayData<ObjectSalts>(binaryReader, blamPointers.Dequeue());
            spawnData = ReadBlockArrayData<ScenarioSpawnDataBlock>(binaryReader, blamPointers.Dequeue());
            crates = ReadBlockArrayData<ScenarioCrateBlock>(binaryReader, blamPointers.Dequeue());
            cratesPalette = ReadBlockArrayData<ScenarioCratePaletteBlock>(binaryReader, blamPointers.Dequeue());
            atmosphericFogPalette = ReadBlockArrayData<ScenarioAtmosphericFogPalette>(binaryReader, blamPointers.Dequeue());
            planarFogPalette = ReadBlockArrayData<ScenarioPlanarFogPalette>(binaryReader, blamPointers.Dequeue());
            flocks = ReadBlockArrayData<FlockDefinitionBlock>(binaryReader, blamPointers.Dequeue());
            decorators = ReadBlockArrayData<DecoratorPlacementDefinitionBlock>(binaryReader, blamPointers.Dequeue());
            creatures = ReadBlockArrayData<ScenarioCreatureBlock>(binaryReader, blamPointers.Dequeue());
            creaturesPalette = ReadBlockArrayData<ScenarioCreaturePaletteBlock>(binaryReader, blamPointers.Dequeue());
            decoratorsPalette = ReadBlockArrayData<ScenarioDecoratorSetPaletteEntryBlock>(binaryReader, blamPointers.Dequeue());
            bSPTransitionVolumes = ReadBlockArrayData<ScenarioBspSwitchTransitionVolumeBlock>(binaryReader, blamPointers.Dequeue());
            structureBSPLighting = ReadBlockArrayData<ScenarioStructureBspSphericalHarmonicLightingBlock>(binaryReader, blamPointers.Dequeue());
            editorFolders = ReadBlockArrayData<GScenarioEditorFolderBlock>(binaryReader, blamPointers.Dequeue());
            levelData = ReadBlockArrayData<ScenarioLevelDataBlock>(binaryReader, blamPointers.Dequeue());
            invalidName_0[0].ReadPointers(binaryReader, blamPointers);
            invalidName_0[1].ReadPointers(binaryReader, blamPointers);
            invalidName_0[2].ReadPointers(binaryReader, blamPointers);
            invalidName_0[3].ReadPointers(binaryReader, blamPointers);
            invalidName_0[4].ReadPointers(binaryReader, blamPointers);
            invalidName_0[5].ReadPointers(binaryReader, blamPointers);
            invalidName_0[6].ReadPointers(binaryReader, blamPointers);
            invalidName_0[7].ReadPointers(binaryReader, blamPointers);
            missionDialogue = ReadBlockArrayData<AiScenarioMissionDialogueBlock>(binaryReader, blamPointers.Dequeue());
            interpolators = ReadBlockArrayData<ScenarioInterpolatorBlock>(binaryReader, blamPointers.Dequeue());
            sharedReferences = ReadBlockArrayData<HsReferencesBlock>(binaryReader, blamPointers.Dequeue());
            screenEffectReferences = ReadBlockArrayData<ScenarioScreenEffectReferenceBlock>(binaryReader, blamPointers.Dequeue());
            simulationDefinitionTable = ReadBlockArrayData<ScenarioSimulationDefinitionTableBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
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
            public override int SerializedSize { get { return 4; } }
            public override int Alignment { get { return 1; } }
            public ObjectSalts() : base()
            {
            }
            public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
            {
                var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
                eMPTYSTRING = binaryReader.ReadInt32();
                return blamPointers;
            }
            public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
            {
                base.ReadPointers(binaryReader, blamPointers);
            }
            public override int Write(BinaryWriter binaryWriter, int nextAddress)
            {
                base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
                {
                    binaryWriter.Write(eMPTYSTRING);
                    return nextAddress;
                }
            }
        };
    };
}
