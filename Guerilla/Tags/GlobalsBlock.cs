using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("matg")]
    public  partial class GlobalsBlock : GlobalsBlockBase
    {
        public  GlobalsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 644)]
    public class GlobalsBlockBase
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
            this.invalidName_ = binaryReader.ReadBytes(172);
            this.language = (Language)binaryReader.ReadInt32();
            this.havokCleanupResources = ReadHavokCleanupResourcesBlockArray(binaryReader);
            this.collisionDamage = ReadCollisionDamageBlockArray(binaryReader);
            this.soundGlobals = ReadSoundGlobalsBlockArray(binaryReader);
            this.aiGlobals = ReadAiGlobalsBlockArray(binaryReader);
            this.damageTable = ReadGameGlobalsDamageBlockArray(binaryReader);
            this.gNullBlock = ReadGNullBlockArray(binaryReader);
            this.sounds = ReadSoundBlockArray(binaryReader);
            this.camera = ReadCameraBlockArray(binaryReader);
            this.playerControl = ReadPlayerControlBlockArray(binaryReader);
            this.difficulty = ReadDifficultyBlockArray(binaryReader);
            this.grenades = ReadGrenadesBlockArray(binaryReader);
            this.rasterizerData = ReadRasterizerDataBlockArray(binaryReader);
            this.interfaceTags = ReadInterfaceTagReferencesArray(binaryReader);
            this.weaponListUpdateWeaponListEnumInGameGlobalsH = ReadCheatWeaponsBlockArray(binaryReader);
            this.cheatPowerups = ReadCheatPowerupsBlockArray(binaryReader);
            this.multiplayerInformation = ReadMultiplayerInformationBlockArray(binaryReader);
            this.playerInformation = ReadPlayerInformationBlockArray(binaryReader);
            this.playerRepresentation = ReadPlayerRepresentationBlockArray(binaryReader);
            this.fallingDamage = ReadFallingDamageBlockArray(binaryReader);
            this.oldMaterials = ReadOldMaterialsBlockArray(binaryReader);
            this.materials = ReadMaterialsBlockArray(binaryReader);
            this.multiplayerUI = ReadMultiplayerUiBlockArray(binaryReader);
            this.profileColors = ReadMultiplayerColorBlockArray(binaryReader);
            this.multiplayerGlobals = binaryReader.ReadTagReference();
            this.runtimeLevelData = ReadRuntimeLevelsDefinitionBlockArray(binaryReader);
            this.uiLevelData = ReadUiLevelsDefinitionBlockArray(binaryReader);
            this.defaultGlobalLighting = binaryReader.ReadTagReference();
            this.invalidName_0 = binaryReader.ReadBytes(252);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
        }
        internal  virtual HavokCleanupResourcesBlock[] ReadHavokCleanupResourcesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(HavokCleanupResourcesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new HavokCleanupResourcesBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new HavokCleanupResourcesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CollisionDamageBlock[] ReadCollisionDamageBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CollisionDamageBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CollisionDamageBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CollisionDamageBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual SoundGlobalsBlock[] ReadSoundGlobalsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SoundGlobalsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SoundGlobalsBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SoundGlobalsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual AiGlobalsBlock[] ReadAiGlobalsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(AiGlobalsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new AiGlobalsBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new AiGlobalsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GameGlobalsDamageBlock[] ReadGameGlobalsDamageBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GameGlobalsDamageBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GameGlobalsDamageBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GameGlobalsDamageBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GNullBlock[] ReadGNullBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GNullBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GNullBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GNullBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual SoundBlock[] ReadSoundBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SoundBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SoundBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SoundBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CameraBlock[] ReadCameraBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CameraBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CameraBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CameraBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PlayerControlBlock[] ReadPlayerControlBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PlayerControlBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PlayerControlBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PlayerControlBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual DifficultyBlock[] ReadDifficultyBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(DifficultyBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new DifficultyBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new DifficultyBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GrenadesBlock[] ReadGrenadesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GrenadesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GrenadesBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GrenadesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual RasterizerDataBlock[] ReadRasterizerDataBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(RasterizerDataBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new RasterizerDataBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new RasterizerDataBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual InterfaceTagReferences[] ReadInterfaceTagReferencesArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(InterfaceTagReferences));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new InterfaceTagReferences[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new InterfaceTagReferences(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CheatWeaponsBlock[] ReadCheatWeaponsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CheatWeaponsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CheatWeaponsBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CheatWeaponsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CheatPowerupsBlock[] ReadCheatPowerupsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CheatPowerupsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CheatPowerupsBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CheatPowerupsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual MultiplayerInformationBlock[] ReadMultiplayerInformationBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(MultiplayerInformationBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new MultiplayerInformationBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new MultiplayerInformationBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PlayerInformationBlock[] ReadPlayerInformationBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PlayerInformationBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PlayerInformationBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PlayerInformationBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PlayerRepresentationBlock[] ReadPlayerRepresentationBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PlayerRepresentationBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PlayerRepresentationBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PlayerRepresentationBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual FallingDamageBlock[] ReadFallingDamageBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(FallingDamageBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new FallingDamageBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new FallingDamageBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual OldMaterialsBlock[] ReadOldMaterialsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(OldMaterialsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new OldMaterialsBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new OldMaterialsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual MaterialsBlock[] ReadMaterialsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(MaterialsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new MaterialsBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new MaterialsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual MultiplayerUiBlock[] ReadMultiplayerUiBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(MultiplayerUiBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new MultiplayerUiBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new MultiplayerUiBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual MultiplayerColorBlock[] ReadMultiplayerColorBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(MultiplayerColorBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new MultiplayerColorBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new MultiplayerColorBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual RuntimeLevelsDefinitionBlock[] ReadRuntimeLevelsDefinitionBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(RuntimeLevelsDefinitionBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new RuntimeLevelsDefinitionBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new RuntimeLevelsDefinitionBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual UiLevelsDefinitionBlock[] ReadUiLevelsDefinitionBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(UiLevelsDefinitionBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new UiLevelsDefinitionBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new UiLevelsDefinitionBlock(binaryReader);
                }
            }
            return array;
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
