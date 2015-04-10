// ReSharper disable All
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
        public  GlobalsBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  GlobalsBlockBase(System.IO.BinaryReader binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(172);
            language = (Language)binaryReader.ReadInt32();
            ReadHavokCleanupResourcesBlockArray(binaryReader);
            ReadCollisionDamageBlockArray(binaryReader);
            ReadSoundGlobalsBlockArray(binaryReader);
            ReadAiGlobalsBlockArray(binaryReader);
            ReadGameGlobalsDamageBlockArray(binaryReader);
            ReadGNullBlockArray(binaryReader);
            ReadSoundBlockArray(binaryReader);
            ReadCameraBlockArray(binaryReader);
            ReadPlayerControlBlockArray(binaryReader);
            ReadDifficultyBlockArray(binaryReader);
            ReadGrenadesBlockArray(binaryReader);
            ReadRasterizerDataBlockArray(binaryReader);
            ReadInterfaceTagReferencesArray(binaryReader);
            ReadCheatWeaponsBlockArray(binaryReader);
            ReadCheatPowerupsBlockArray(binaryReader);
            ReadMultiplayerInformationBlockArray(binaryReader);
            ReadPlayerInformationBlockArray(binaryReader);
            ReadPlayerRepresentationBlockArray(binaryReader);
            ReadFallingDamageBlockArray(binaryReader);
            ReadOldMaterialsBlockArray(binaryReader);
            ReadMaterialsBlockArray(binaryReader);
            ReadMultiplayerUiBlockArray(binaryReader);
            ReadMultiplayerColorBlockArray(binaryReader);
            multiplayerGlobals = binaryReader.ReadTagReference();
            ReadRuntimeLevelsDefinitionBlockArray(binaryReader);
            ReadUiLevelsDefinitionBlockArray(binaryReader);
            defaultGlobalLighting = binaryReader.ReadTagReference();
            invalidName_0 = binaryReader.ReadBytes(252);
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
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
        internal  virtual HavokCleanupResourcesBlock[] ReadHavokCleanupResourcesBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(HavokCleanupResourcesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new HavokCleanupResourcesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new HavokCleanupResourcesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CollisionDamageBlock[] ReadCollisionDamageBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CollisionDamageBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CollisionDamageBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CollisionDamageBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual SoundGlobalsBlock[] ReadSoundGlobalsBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SoundGlobalsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SoundGlobalsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SoundGlobalsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual AiGlobalsBlock[] ReadAiGlobalsBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(AiGlobalsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new AiGlobalsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new AiGlobalsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GameGlobalsDamageBlock[] ReadGameGlobalsDamageBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GameGlobalsDamageBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GameGlobalsDamageBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GameGlobalsDamageBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GNullBlock[] ReadGNullBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual SoundBlock[] ReadSoundBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SoundBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SoundBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SoundBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CameraBlock[] ReadCameraBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CameraBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CameraBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CameraBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PlayerControlBlock[] ReadPlayerControlBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PlayerControlBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PlayerControlBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PlayerControlBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual DifficultyBlock[] ReadDifficultyBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(DifficultyBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new DifficultyBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new DifficultyBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GrenadesBlock[] ReadGrenadesBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GrenadesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GrenadesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GrenadesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual RasterizerDataBlock[] ReadRasterizerDataBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(RasterizerDataBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new RasterizerDataBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new RasterizerDataBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual InterfaceTagReferences[] ReadInterfaceTagReferencesArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(InterfaceTagReferences));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new InterfaceTagReferences[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new InterfaceTagReferences(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CheatWeaponsBlock[] ReadCheatWeaponsBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CheatWeaponsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CheatWeaponsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CheatWeaponsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CheatPowerupsBlock[] ReadCheatPowerupsBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CheatPowerupsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CheatPowerupsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CheatPowerupsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual MultiplayerInformationBlock[] ReadMultiplayerInformationBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(MultiplayerInformationBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new MultiplayerInformationBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new MultiplayerInformationBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PlayerInformationBlock[] ReadPlayerInformationBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PlayerInformationBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PlayerInformationBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PlayerInformationBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PlayerRepresentationBlock[] ReadPlayerRepresentationBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PlayerRepresentationBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PlayerRepresentationBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PlayerRepresentationBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual FallingDamageBlock[] ReadFallingDamageBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(FallingDamageBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new FallingDamageBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new FallingDamageBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual OldMaterialsBlock[] ReadOldMaterialsBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(OldMaterialsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new OldMaterialsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new OldMaterialsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual MaterialsBlock[] ReadMaterialsBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(MaterialsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new MaterialsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new MaterialsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual MultiplayerUiBlock[] ReadMultiplayerUiBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(MultiplayerUiBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new MultiplayerUiBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new MultiplayerUiBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual MultiplayerColorBlock[] ReadMultiplayerColorBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(MultiplayerColorBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new MultiplayerColorBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new MultiplayerColorBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual RuntimeLevelsDefinitionBlock[] ReadRuntimeLevelsDefinitionBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(RuntimeLevelsDefinitionBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new RuntimeLevelsDefinitionBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new RuntimeLevelsDefinitionBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual UiLevelsDefinitionBlock[] ReadUiLevelsDefinitionBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(UiLevelsDefinitionBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new UiLevelsDefinitionBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new UiLevelsDefinitionBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteHavokCleanupResourcesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteCollisionDamageBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteSoundGlobalsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteAiGlobalsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGameGlobalsDamageBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGNullBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteSoundBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteCameraBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WritePlayerControlBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteDifficultyBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGrenadesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteRasterizerDataBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteInterfaceTagReferencesArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteCheatWeaponsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteCheatPowerupsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteMultiplayerInformationBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WritePlayerInformationBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WritePlayerRepresentationBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteFallingDamageBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteOldMaterialsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteMaterialsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteMultiplayerUiBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteMultiplayerColorBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteRuntimeLevelsDefinitionBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteUiLevelsDefinitionBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_, 0, 172);
                binaryWriter.Write((Int32)language);
                WriteHavokCleanupResourcesBlockArray(binaryWriter);
                WriteCollisionDamageBlockArray(binaryWriter);
                WriteSoundGlobalsBlockArray(binaryWriter);
                WriteAiGlobalsBlockArray(binaryWriter);
                WriteGameGlobalsDamageBlockArray(binaryWriter);
                WriteGNullBlockArray(binaryWriter);
                WriteSoundBlockArray(binaryWriter);
                WriteCameraBlockArray(binaryWriter);
                WritePlayerControlBlockArray(binaryWriter);
                WriteDifficultyBlockArray(binaryWriter);
                WriteGrenadesBlockArray(binaryWriter);
                WriteRasterizerDataBlockArray(binaryWriter);
                WriteInterfaceTagReferencesArray(binaryWriter);
                WriteCheatWeaponsBlockArray(binaryWriter);
                WriteCheatPowerupsBlockArray(binaryWriter);
                WriteMultiplayerInformationBlockArray(binaryWriter);
                WritePlayerInformationBlockArray(binaryWriter);
                WritePlayerRepresentationBlockArray(binaryWriter);
                WriteFallingDamageBlockArray(binaryWriter);
                WriteOldMaterialsBlockArray(binaryWriter);
                WriteMaterialsBlockArray(binaryWriter);
                WriteMultiplayerUiBlockArray(binaryWriter);
                WriteMultiplayerColorBlockArray(binaryWriter);
                binaryWriter.Write(multiplayerGlobals);
                WriteRuntimeLevelsDefinitionBlockArray(binaryWriter);
                WriteUiLevelsDefinitionBlockArray(binaryWriter);
                binaryWriter.Write(defaultGlobalLighting);
                binaryWriter.Write(invalidName_0, 0, 252);
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
