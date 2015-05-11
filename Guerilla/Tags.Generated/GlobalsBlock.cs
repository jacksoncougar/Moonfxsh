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
        public static readonly TagClass Matg = (TagClass) "matg";
    };
} ;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("matg")]
    public partial class GlobalsBlock : GlobalsBlockBase
    {
        public GlobalsBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 644, Alignment = 4)]
    public class GlobalsBlockBase : GuerillaBlock
    {
        internal byte[] invalidName_;
        internal Language language;
        internal HavokCleanupResourcesBlock[] havokCleanupResources;
        internal CollisionDamageBlock[] collisionDamage;
        internal SoundGlobalsBlock[] soundGlobals;
        internal AiGlobalsBlock[] aiGlobals;
        internal GameGlobalsDamageBlock[] damageTable;
        internal GNullBlock[] gNullBlock;
        internal MoonfishSoundReferencesBlock[] sounds;
        internal CameraBlock[] camera;
        internal PlayerControlBlock[] playerControl;
        internal DifficultyBlock[] difficulty;
        internal GrenadesBlock[] grenades;
        internal RasterizerDataBlock[] rasterizerData;
        internal InterfaceTagReferences[] interfaceTags;
        internal CheatWeaponsBlock[] weaponListUpdateWeaponListEnumInGameGlobalsH;
        internal CheatPowerupsBlock[] cheatPowerups;
        internal MultiplayerInformationBlock[] multiplayerInformation;
        internal PlayerInformationBlock[] playerInformation;
        internal PlayerRepresentationBlock[] playerRepresentation;
        internal FallingDamageBlock[] fallingDamage;
        internal OldMaterialsBlock[] oldMaterials;
        internal MaterialsBlock[] materials;
        internal MultiplayerUiBlock[] multiplayerUI;
        internal MultiplayerColorBlock[] profileColors;
        [TagReference("mulg")] internal Moonfish.Tags.TagReference multiplayerGlobals;
        internal RuntimeLevelsDefinitionBlock[] runtimeLevelData;
        internal UiLevelsDefinitionBlock[] uiLevelData;
        [TagReference("gldf")] internal Moonfish.Tags.TagReference defaultGlobalLighting;
        internal byte[] invalidName_0;

        public override int SerializedSize
        {
            get { return 644; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public GlobalsBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            invalidName_ = binaryReader.ReadBytes(172);
            language = (Language) binaryReader.ReadInt32();
            blamPointers.Enqueue(ReadBlockArrayPointer<HavokCleanupResourcesBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<CollisionDamageBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<SoundGlobalsBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<AiGlobalsBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<GameGlobalsDamageBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<GNullBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<MoonfishSoundReferencesBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<CameraBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<PlayerControlBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<DifficultyBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<GrenadesBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<RasterizerDataBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<InterfaceTagReferences>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<CheatWeaponsBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<CheatPowerupsBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<MultiplayerInformationBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<PlayerInformationBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<PlayerRepresentationBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<FallingDamageBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<OldMaterialsBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<MaterialsBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<MultiplayerUiBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<MultiplayerColorBlock>(binaryReader));
            multiplayerGlobals = binaryReader.ReadTagReference();
            blamPointers.Enqueue(ReadBlockArrayPointer<RuntimeLevelsDefinitionBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<UiLevelsDefinitionBlock>(binaryReader));
            defaultGlobalLighting = binaryReader.ReadTagReference();
            invalidName_0 = binaryReader.ReadBytes(252);
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            havokCleanupResources = ReadBlockArrayData<HavokCleanupResourcesBlock>(binaryReader, blamPointers.Dequeue());
            collisionDamage = ReadBlockArrayData<CollisionDamageBlock>(binaryReader, blamPointers.Dequeue());
            soundGlobals = ReadBlockArrayData<SoundGlobalsBlock>(binaryReader, blamPointers.Dequeue());
            aiGlobals = ReadBlockArrayData<AiGlobalsBlock>(binaryReader, blamPointers.Dequeue());
            damageTable = ReadBlockArrayData<GameGlobalsDamageBlock>(binaryReader, blamPointers.Dequeue());
            gNullBlock = ReadBlockArrayData<GNullBlock>(binaryReader, blamPointers.Dequeue());
            sounds = ReadBlockArrayData<MoonfishSoundReferencesBlock>(binaryReader, blamPointers.Dequeue());
            camera = ReadBlockArrayData<CameraBlock>(binaryReader, blamPointers.Dequeue());
            playerControl = ReadBlockArrayData<PlayerControlBlock>(binaryReader, blamPointers.Dequeue());
            difficulty = ReadBlockArrayData<DifficultyBlock>(binaryReader, blamPointers.Dequeue());
            grenades = ReadBlockArrayData<GrenadesBlock>(binaryReader, blamPointers.Dequeue());
            rasterizerData = ReadBlockArrayData<RasterizerDataBlock>(binaryReader, blamPointers.Dequeue());
            interfaceTags = ReadBlockArrayData<InterfaceTagReferences>(binaryReader, blamPointers.Dequeue());
            weaponListUpdateWeaponListEnumInGameGlobalsH = ReadBlockArrayData<CheatWeaponsBlock>(binaryReader,
                blamPointers.Dequeue());
            cheatPowerups = ReadBlockArrayData<CheatPowerupsBlock>(binaryReader, blamPointers.Dequeue());
            multiplayerInformation = ReadBlockArrayData<MultiplayerInformationBlock>(binaryReader,
                blamPointers.Dequeue());
            playerInformation = ReadBlockArrayData<PlayerInformationBlock>(binaryReader, blamPointers.Dequeue());
            playerRepresentation = ReadBlockArrayData<PlayerRepresentationBlock>(binaryReader, blamPointers.Dequeue());
            fallingDamage = ReadBlockArrayData<FallingDamageBlock>(binaryReader, blamPointers.Dequeue());
            oldMaterials = ReadBlockArrayData<OldMaterialsBlock>(binaryReader, blamPointers.Dequeue());
            materials = ReadBlockArrayData<MaterialsBlock>(binaryReader, blamPointers.Dequeue());
            multiplayerUI = ReadBlockArrayData<MultiplayerUiBlock>(binaryReader, blamPointers.Dequeue());
            profileColors = ReadBlockArrayData<MultiplayerColorBlock>(binaryReader, blamPointers.Dequeue());
            runtimeLevelData = ReadBlockArrayData<RuntimeLevelsDefinitionBlock>(binaryReader, blamPointers.Dequeue());
            uiLevelData = ReadBlockArrayData<UiLevelsDefinitionBlock>(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_, 0, 172);
                binaryWriter.Write((Int32) language);
                nextAddress = Guerilla.WriteBlockArray<HavokCleanupResourcesBlock>(binaryWriter, havokCleanupResources,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CollisionDamageBlock>(binaryWriter, collisionDamage, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<SoundGlobalsBlock>(binaryWriter, soundGlobals, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<AiGlobalsBlock>(binaryWriter, aiGlobals, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GameGlobalsDamageBlock>(binaryWriter, damageTable, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GNullBlock>(binaryWriter, gNullBlock, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<MoonfishSoundReferencesBlock>(binaryWriter, sounds, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CameraBlock>(binaryWriter, camera, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<PlayerControlBlock>(binaryWriter, playerControl, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<DifficultyBlock>(binaryWriter, difficulty, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GrenadesBlock>(binaryWriter, grenades, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<RasterizerDataBlock>(binaryWriter, rasterizerData, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<InterfaceTagReferences>(binaryWriter, interfaceTags, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CheatWeaponsBlock>(binaryWriter,
                    weaponListUpdateWeaponListEnumInGameGlobalsH, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CheatPowerupsBlock>(binaryWriter, cheatPowerups, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<MultiplayerInformationBlock>(binaryWriter, multiplayerInformation,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<PlayerInformationBlock>(binaryWriter, playerInformation,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<PlayerRepresentationBlock>(binaryWriter, playerRepresentation,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<FallingDamageBlock>(binaryWriter, fallingDamage, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<OldMaterialsBlock>(binaryWriter, oldMaterials, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<MaterialsBlock>(binaryWriter, materials, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<MultiplayerUiBlock>(binaryWriter, multiplayerUI, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<MultiplayerColorBlock>(binaryWriter, profileColors, nextAddress);
                binaryWriter.Write(multiplayerGlobals);
                nextAddress = Guerilla.WriteBlockArray<RuntimeLevelsDefinitionBlock>(binaryWriter, runtimeLevelData,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<UiLevelsDefinitionBlock>(binaryWriter, uiLevelData, nextAddress);
                binaryWriter.Write(defaultGlobalLighting);
                binaryWriter.Write(invalidName_0, 0, 252);
                return nextAddress;
            }
        }

        internal enum Language : int
        {
            English = 0,
            Japanese = 1,
            German = 2,
            French = 3,
            Spanish = 4,
            Italian = 5,
            Korean = 6,
            Chinese = 7,
            Portuguese = 8,
        };
    };
}