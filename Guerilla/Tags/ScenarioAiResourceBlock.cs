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
        public static readonly TagClass Ai = (TagClass)"ai**";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("ai**")]
    public  partial class ScenarioAiResourceBlock : ScenarioAiResourceBlockBase
    {
        public  ScenarioAiResourceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 152, Alignment = 4)]
    public class ScenarioAiResourceBlockBase  : IGuerilla
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
            stylePalette = Guerilla.ReadBlockArray<StylePaletteBlock>(binaryReader);
            squadGroups = Guerilla.ReadBlockArray<SquadGroupsBlock>(binaryReader);
            squads = Guerilla.ReadBlockArray<SquadsBlock>(binaryReader);
            zones = Guerilla.ReadBlockArray<ZoneBlock>(binaryReader);
            characterPalette = Guerilla.ReadBlockArray<CharacterPaletteBlock>(binaryReader);
            aIAnimationReferences = Guerilla.ReadBlockArray<AiAnimationReferenceBlock>(binaryReader);
            aIScriptReferences = Guerilla.ReadBlockArray<AiScriptReferenceBlock>(binaryReader);
            aIRecordingReferences = Guerilla.ReadBlockArray<AiRecordingReferenceBlock>(binaryReader);
            aIConversations = Guerilla.ReadBlockArray<AiConversationBlock>(binaryReader);
            scriptingData = Guerilla.ReadBlockArray<CsScriptDataBlock>(binaryReader);
            orders = Guerilla.ReadBlockArray<OrdersBlock>(binaryReader);
            triggers = Guerilla.ReadBlockArray<TriggersBlock>(binaryReader);
            bSPPreferences = Guerilla.ReadBlockArray<ScenarioStructureBspReferenceBlock>(binaryReader);
            weaponReferences = Guerilla.ReadBlockArray<ScenarioWeaponPaletteBlock>(binaryReader);
            vehicleReferences = Guerilla.ReadBlockArray<ScenarioVehiclePaletteBlock>(binaryReader);
            vehicleDatumReferences = Guerilla.ReadBlockArray<ScenarioVehicleBlock>(binaryReader);
            missionDialogueScenes = Guerilla.ReadBlockArray<AiSceneBlock>(binaryReader);
            flocks = Guerilla.ReadBlockArray<FlockDefinitionBlock>(binaryReader);
            triggerVolumeReferences = Guerilla.ReadBlockArray<ScenarioTriggerVolumeBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<StylePaletteBlock>(binaryWriter, stylePalette, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<SquadGroupsBlock>(binaryWriter, squadGroups, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<SquadsBlock>(binaryWriter, squads, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ZoneBlock>(binaryWriter, zones, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CharacterPaletteBlock>(binaryWriter, characterPalette, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<AiAnimationReferenceBlock>(binaryWriter, aIAnimationReferences, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<AiScriptReferenceBlock>(binaryWriter, aIScriptReferences, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<AiRecordingReferenceBlock>(binaryWriter, aIRecordingReferences, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<AiConversationBlock>(binaryWriter, aIConversations, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CsScriptDataBlock>(binaryWriter, scriptingData, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<OrdersBlock>(binaryWriter, orders, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<TriggersBlock>(binaryWriter, triggers, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioStructureBspReferenceBlock>(binaryWriter, bSPPreferences, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioWeaponPaletteBlock>(binaryWriter, weaponReferences, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioVehiclePaletteBlock>(binaryWriter, vehicleReferences, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioVehicleBlock>(binaryWriter, vehicleDatumReferences, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<AiSceneBlock>(binaryWriter, missionDialogueScenes, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<FlockDefinitionBlock>(binaryWriter, flocks, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioTriggerVolumeBlock>(binaryWriter, triggerVolumeReferences, nextAddress);
                return nextAddress;
            }
        }
    };
}
