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
        public static readonly TagClass Matg = (TagClass)"matg";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("matg")]
    public partial class GlobalsBlock : GlobalsBlockBase
    {
        public  GlobalsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  GlobalsBlock(): base()
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
        [TagReference("mulg")]
        internal Moonfish.Tags.TagReference multiplayerGlobals;
        internal RuntimeLevelsDefinitionBlock[] runtimeLevelData;
        internal UiLevelsDefinitionBlock[] uiLevelData;
        [TagReference("gldf")]
        internal Moonfish.Tags.TagReference defaultGlobalLighting;
        internal byte[] invalidName_0;
        
        public override int SerializedSize{get { return 644; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  GlobalsBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(172);
            language = (Language)binaryReader.ReadInt32();
            havokCleanupResources = Guerilla.ReadBlockArray<HavokCleanupResourcesBlock>(binaryReader);
            collisionDamage = Guerilla.ReadBlockArray<CollisionDamageBlock>(binaryReader);
            soundGlobals = Guerilla.ReadBlockArray<SoundGlobalsBlock>(binaryReader);
            aiGlobals = Guerilla.ReadBlockArray<AiGlobalsBlock>(binaryReader);
            damageTable = Guerilla.ReadBlockArray<GameGlobalsDamageBlock>(binaryReader);
            gNullBlock = Guerilla.ReadBlockArray<GNullBlock>(binaryReader);
            sounds = Guerilla.ReadBlockArray<MoonfishSoundReferencesBlock>(binaryReader);
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
        public  GlobalsBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_, 0, 172);
                binaryWriter.Write((Int32)language);
                nextAddress = Guerilla.WriteBlockArray<HavokCleanupResourcesBlock>(binaryWriter, havokCleanupResources, nextAddress);
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
                nextAddress = Guerilla.WriteBlockArray<CheatWeaponsBlock>(binaryWriter, weaponListUpdateWeaponListEnumInGameGlobalsH, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CheatPowerupsBlock>(binaryWriter, cheatPowerups, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<MultiplayerInformationBlock>(binaryWriter, multiplayerInformation, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<PlayerInformationBlock>(binaryWriter, playerInformation, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<PlayerRepresentationBlock>(binaryWriter, playerRepresentation, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<FallingDamageBlock>(binaryWriter, fallingDamage, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<OldMaterialsBlock>(binaryWriter, oldMaterials, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<MaterialsBlock>(binaryWriter, materials, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<MultiplayerUiBlock>(binaryWriter, multiplayerUI, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<MultiplayerColorBlock>(binaryWriter, profileColors, nextAddress);
                binaryWriter.Write(multiplayerGlobals);
                nextAddress = Guerilla.WriteBlockArray<RuntimeLevelsDefinitionBlock>(binaryWriter, runtimeLevelData, nextAddress);
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
