    // ReSharper disable All

using Moonfish.Model;

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
        public static readonly TagClass Ai = (TagClass) "ai**";
    };
} ;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("ai**")]
    public partial class ScenarioAiResourceBlock : ScenarioAiResourceBlockBase
    {
        public ScenarioAiResourceBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 152, Alignment = 4)]
    public class ScenarioAiResourceBlockBase : GuerillaBlock
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

        public override int SerializedSize
        {
            get { return 152; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ScenarioAiResourceBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<StylePaletteBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<SquadGroupsBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<SquadsBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ZoneBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<CharacterPaletteBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<AiAnimationReferenceBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<AiScriptReferenceBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<AiRecordingReferenceBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<AiConversationBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<CsScriptDataBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<OrdersBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<TriggersBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioStructureBspReferenceBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioWeaponPaletteBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioVehiclePaletteBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioVehicleBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<AiSceneBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<FlockDefinitionBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioTriggerVolumeBlock>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            stylePalette = ReadBlockArrayData<StylePaletteBlock>(binaryReader, blamPointers.Dequeue());
            squadGroups = ReadBlockArrayData<SquadGroupsBlock>(binaryReader, blamPointers.Dequeue());
            squads = ReadBlockArrayData<SquadsBlock>(binaryReader, blamPointers.Dequeue());
            zones = ReadBlockArrayData<ZoneBlock>(binaryReader, blamPointers.Dequeue());
            characterPalette = ReadBlockArrayData<CharacterPaletteBlock>(binaryReader, blamPointers.Dequeue());
            aIAnimationReferences = ReadBlockArrayData<AiAnimationReferenceBlock>(binaryReader, blamPointers.Dequeue());
            aIScriptReferences = ReadBlockArrayData<AiScriptReferenceBlock>(binaryReader, blamPointers.Dequeue());
            aIRecordingReferences = ReadBlockArrayData<AiRecordingReferenceBlock>(binaryReader, blamPointers.Dequeue());
            aIConversations = ReadBlockArrayData<AiConversationBlock>(binaryReader, blamPointers.Dequeue());
            scriptingData = ReadBlockArrayData<CsScriptDataBlock>(binaryReader, blamPointers.Dequeue());
            orders = ReadBlockArrayData<OrdersBlock>(binaryReader, blamPointers.Dequeue());
            triggers = ReadBlockArrayData<TriggersBlock>(binaryReader, blamPointers.Dequeue());
            bSPPreferences = ReadBlockArrayData<ScenarioStructureBspReferenceBlock>(binaryReader, blamPointers.Dequeue());
            weaponReferences = ReadBlockArrayData<ScenarioWeaponPaletteBlock>(binaryReader, blamPointers.Dequeue());
            vehicleReferences = ReadBlockArrayData<ScenarioVehiclePaletteBlock>(binaryReader, blamPointers.Dequeue());
            vehicleDatumReferences = ReadBlockArrayData<ScenarioVehicleBlock>(binaryReader, blamPointers.Dequeue());
            missionDialogueScenes = ReadBlockArrayData<AiSceneBlock>(binaryReader, blamPointers.Dequeue());
            flocks = ReadBlockArrayData<FlockDefinitionBlock>(binaryReader, blamPointers.Dequeue());
            triggerVolumeReferences = ReadBlockArrayData<ScenarioTriggerVolumeBlock>(binaryReader,
                blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<StylePaletteBlock>(binaryWriter, stylePalette, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<SquadGroupsBlock>(binaryWriter, squadGroups, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<SquadsBlock>(binaryWriter, squads, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ZoneBlock>(binaryWriter, zones, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CharacterPaletteBlock>(binaryWriter, characterPalette,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<AiAnimationReferenceBlock>(binaryWriter, aIAnimationReferences,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<AiScriptReferenceBlock>(binaryWriter, aIScriptReferences,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<AiRecordingReferenceBlock>(binaryWriter, aIRecordingReferences,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<AiConversationBlock>(binaryWriter, aIConversations, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CsScriptDataBlock>(binaryWriter, scriptingData, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<OrdersBlock>(binaryWriter, orders, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<TriggersBlock>(binaryWriter, triggers, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioStructureBspReferenceBlock>(binaryWriter, bSPPreferences,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioWeaponPaletteBlock>(binaryWriter, weaponReferences,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioVehiclePaletteBlock>(binaryWriter, vehicleReferences,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioVehicleBlock>(binaryWriter, vehicleDatumReferences,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<AiSceneBlock>(binaryWriter, missionDialogueScenes, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<FlockDefinitionBlock>(binaryWriter, flocks, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioTriggerVolumeBlock>(binaryWriter, triggerVolumeReferences,
                    nextAddress);
                return nextAddress;
            }
        }
    };
}