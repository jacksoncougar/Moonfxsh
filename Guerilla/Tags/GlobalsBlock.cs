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
        public static readonly TagClass MatgClass = (TagClass)"matg";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("matg")]
    public  partial class GlobalsBlock : GlobalsBlockBase
    {
        public  GlobalsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 644, Alignment = 4)]
    public class GlobalsBlockBase  : IGuerilla
    {
        internal byte[] invalidName_;
        internal Language language;
        internal HavokCleanupResourcesBlock[] havokCleanupResources;
        internal CollisionDamageBlock[] collisionDamage;
        internal SoundGlobalsBlock[] soundGlobals;
        internal AiGlobalsBlock[] aiGlobals;
        internal GameGlobalsDamageBlock[] damageTable;
        internal GNullBlock[] gNullBlock;
        internal SoundBlock[] sounds;
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
        [TagReference("mulg")]
        internal Moonfish.Tags.TagReference multiplayerGlobals;
        internal RuntimeLevelsDefinitionBlock[] runtimeLevelData;
        internal UiLevelsDefinitionBlock[] uiLevelData;
        [TagReference("gldf")]
        internal Moonfish.Tags.TagReference defaultGlobalLighting;
        internal byte[] invalidName_0;
        internal  GlobalsBlockBase(BinaryReader binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(172);
            language = (Language)binaryReader.ReadInt32();
            havokCleanupResources = Guerilla.ReadBlockArray<HavokCleanupResourcesBlock>(binaryReader);
            collisionDamage = Guerilla.ReadBlockArray<CollisionDamageBlock>(binaryReader);
            soundGlobals = Guerilla.ReadBlockArray<SoundGlobalsBlock>(binaryReader);
            aiGlobals = Guerilla.ReadBlockArray<AiGlobalsBlock>(binaryReader);
            damageTable = Guerilla.ReadBlockArray<GameGlobalsDamageBlock>(binaryReader);
            gNullBlock = Guerilla.ReadBlockArray<GNullBlock>(binaryReader);
            sounds = Guerilla.ReadBlockArray<SoundBlock>(binaryReader);
            camera = Guerilla.ReadBlockArray<CameraBlock>(binaryReader);
            playerControl = Guerilla.ReadBlockArray<PlayerControlBlock>(binaryReader);
            difficulty = Guerilla.ReadBlockArray<DifficultyBlock>(binaryReader);
            grenades = Guerilla.ReadBlockArray<GrenadesBlock>(binaryReader);
            rasterizerData = Guerilla.ReadBlockArray<RasterizerDataBlock>(binaryReader);
            interfaceTags = Guerilla.ReadBlockArray<InterfaceTagReferences>(binaryReader);
            weaponListUpdateWeaponListEnumInGameGlobalsH = Guerilla.ReadBlockArray<CheatWeaponsBlock>(binaryReader);
            cheatPowerups = Guerilla.ReadBlockArray<CheatPowerupsBlock>(binaryReader);
            multiplayerInformation = Guerilla.ReadBlockArray<MultiplayerInformationBlock>(binaryReader);
            playerInformation = Guerilla.ReadBlockArray<PlayerInformationBlock>(binaryReader);
            playerRepresentation = Guerilla.ReadBlockArray<PlayerRepresentationBlock>(binaryReader);
            fallingDamage = Guerilla.ReadBlockArray<FallingDamageBlock>(binaryReader);
            oldMaterials = Guerilla.ReadBlockArray<OldMaterialsBlock>(binaryReader);
            materials = Guerilla.ReadBlockArray<MaterialsBlock>(binaryReader);
            multiplayerUI = Guerilla.ReadBlockArray<MultiplayerUiBlock>(binaryReader);
            profileColors = Guerilla.ReadBlockArray<MultiplayerColorBlock>(binaryReader);
            multiplayerGlobals = binaryReader.ReadTagReference();
            runtimeLevelData = Guerilla.ReadBlockArray<RuntimeLevelsDefinitionBlock>(binaryReader);
            uiLevelData = Guerilla.ReadBlockArray<UiLevelsDefinitionBlock>(binaryReader);
            defaultGlobalLighting = binaryReader.ReadTagReference();
            invalidName_0 = binaryReader.ReadBytes(252);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_, 0, 172);
                binaryWriter.Write((Int32)language);
                Guerilla.WriteBlockArray<HavokCleanupResourcesBlock>(binaryWriter, havokCleanupResources, nextAddress);
                Guerilla.WriteBlockArray<CollisionDamageBlock>(binaryWriter, collisionDamage, nextAddress);
                Guerilla.WriteBlockArray<SoundGlobalsBlock>(binaryWriter, soundGlobals, nextAddress);
                Guerilla.WriteBlockArray<AiGlobalsBlock>(binaryWriter, aiGlobals, nextAddress);
                Guerilla.WriteBlockArray<GameGlobalsDamageBlock>(binaryWriter, damageTable, nextAddress);
                Guerilla.WriteBlockArray<GNullBlock>(binaryWriter, gNullBlock, nextAddress);
                Guerilla.WriteBlockArray<SoundBlock>(binaryWriter, sounds, nextAddress);
                Guerilla.WriteBlockArray<CameraBlock>(binaryWriter, camera, nextAddress);
                Guerilla.WriteBlockArray<PlayerControlBlock>(binaryWriter, playerControl, nextAddress);
                Guerilla.WriteBlockArray<DifficultyBlock>(binaryWriter, difficulty, nextAddress);
                Guerilla.WriteBlockArray<GrenadesBlock>(binaryWriter, grenades, nextAddress);
                Guerilla.WriteBlockArray<RasterizerDataBlock>(binaryWriter, rasterizerData, nextAddress);
                Guerilla.WriteBlockArray<InterfaceTagReferences>(binaryWriter, interfaceTags, nextAddress);
                Guerilla.WriteBlockArray<CheatWeaponsBlock>(binaryWriter, weaponListUpdateWeaponListEnumInGameGlobalsH, nextAddress);
                Guerilla.WriteBlockArray<CheatPowerupsBlock>(binaryWriter, cheatPowerups, nextAddress);
                Guerilla.WriteBlockArray<MultiplayerInformationBlock>(binaryWriter, multiplayerInformation, nextAddress);
                Guerilla.WriteBlockArray<PlayerInformationBlock>(binaryWriter, playerInformation, nextAddress);
                Guerilla.WriteBlockArray<PlayerRepresentationBlock>(binaryWriter, playerRepresentation, nextAddress);
                Guerilla.WriteBlockArray<FallingDamageBlock>(binaryWriter, fallingDamage, nextAddress);
                Guerilla.WriteBlockArray<OldMaterialsBlock>(binaryWriter, oldMaterials, nextAddress);
                Guerilla.WriteBlockArray<MaterialsBlock>(binaryWriter, materials, nextAddress);
                Guerilla.WriteBlockArray<MultiplayerUiBlock>(binaryWriter, multiplayerUI, nextAddress);
                Guerilla.WriteBlockArray<MultiplayerColorBlock>(binaryWriter, profileColors, nextAddress);
                binaryWriter.Write(multiplayerGlobals);
                Guerilla.WriteBlockArray<RuntimeLevelsDefinitionBlock>(binaryWriter, runtimeLevelData, nextAddress);
                Guerilla.WriteBlockArray<UiLevelsDefinitionBlock>(binaryWriter, uiLevelData, nextAddress);
                binaryWriter.Write(defaultGlobalLighting);
                binaryWriter.Write(invalidName_0, 0, 252);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
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
