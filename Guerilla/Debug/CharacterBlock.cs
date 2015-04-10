// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("char")]
    public  partial class CharacterBlock : CharacterBlockBase
    {
        public  CharacterBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 236)]
    public class CharacterBlockBase
    {
        internal CharacterFlags characterFlags;
        [TagReference("char")]
        internal Moonfish.Tags.TagReference parentCharacter;
        [TagReference("unit")]
        internal Moonfish.Tags.TagReference unit;
        /// <summary>
        /// Creature reference for swarm characters ONLY
        /// </summary>
        [TagReference("crea")]
        internal Moonfish.Tags.TagReference creature;
        [TagReference("styl")]
        internal Moonfish.Tags.TagReference style;
        [TagReference("char")]
        internal Moonfish.Tags.TagReference majorCharacter;
        internal CharacterVariantsBlock[] variants;
        internal CharacterGeneralBlock[] generalProperties;
        internal CharacterVitalityBlock[] vitalityProperties;
        internal CharacterPlacementBlock[] placementProperties;
        internal CharacterPerceptionBlock[] perceptionProperties;
        internal CharacterLookBlock[] lookProperties;
        internal CharacterMovementBlock[] movementProperties;
        internal CharacterSwarmBlock[] swarmProperties;
        internal CharacterReadyBlock[] readyProperties;
        internal CharacterEngageBlock[] engageProperties;
        internal CharacterChargeBlock[] chargeProperties;
        internal CharacterEvasionBlock[] evasionProperties;
        internal CharacterCoverBlock[] coverProperties;
        internal CharacterRetreatBlock[] retreatProperties;
        internal CharacterSearchBlock[] searchProperties;
        internal CharacterPresearchBlock[] preSearchProperties;
        internal CharacterIdleBlock[] idleProperties;
        internal CharacterVocalizationBlock[] vocalizationProperties;
        internal CharacterBoardingBlock[] boardingProperties;
        internal CharacterBossBlock[] bossProperties;
        internal CharacterWeaponsBlock[] weaponsProperties;
        internal CharacterFiringPatternPropertiesBlock[] firingPatternProperties;
        internal CharacterGrenadesBlock[] grenadesProperties;
        internal CharacterVehicleBlock[] vehicleProperties;
        internal  CharacterBlockBase(System.IO.BinaryReader binaryReader)
        {
            characterFlags = (CharacterFlags)binaryReader.ReadInt32();
            parentCharacter = binaryReader.ReadTagReference();
            unit = binaryReader.ReadTagReference();
            creature = binaryReader.ReadTagReference();
            style = binaryReader.ReadTagReference();
            majorCharacter = binaryReader.ReadTagReference();
            ReadCharacterVariantsBlockArray(binaryReader);
            ReadCharacterGeneralBlockArray(binaryReader);
            ReadCharacterVitalityBlockArray(binaryReader);
            ReadCharacterPlacementBlockArray(binaryReader);
            ReadCharacterPerceptionBlockArray(binaryReader);
            ReadCharacterLookBlockArray(binaryReader);
            ReadCharacterMovementBlockArray(binaryReader);
            ReadCharacterSwarmBlockArray(binaryReader);
            ReadCharacterReadyBlockArray(binaryReader);
            ReadCharacterEngageBlockArray(binaryReader);
            ReadCharacterChargeBlockArray(binaryReader);
            ReadCharacterEvasionBlockArray(binaryReader);
            ReadCharacterCoverBlockArray(binaryReader);
            ReadCharacterRetreatBlockArray(binaryReader);
            ReadCharacterSearchBlockArray(binaryReader);
            ReadCharacterPresearchBlockArray(binaryReader);
            ReadCharacterIdleBlockArray(binaryReader);
            ReadCharacterVocalizationBlockArray(binaryReader);
            ReadCharacterBoardingBlockArray(binaryReader);
            ReadCharacterBossBlockArray(binaryReader);
            ReadCharacterWeaponsBlockArray(binaryReader);
            ReadCharacterFiringPatternPropertiesBlockArray(binaryReader);
            ReadCharacterGrenadesBlockArray(binaryReader);
            ReadCharacterVehicleBlockArray(binaryReader);
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
        internal  virtual CharacterVariantsBlock[] ReadCharacterVariantsBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CharacterVariantsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CharacterVariantsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CharacterVariantsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CharacterGeneralBlock[] ReadCharacterGeneralBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CharacterGeneralBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CharacterGeneralBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CharacterGeneralBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CharacterVitalityBlock[] ReadCharacterVitalityBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CharacterVitalityBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CharacterVitalityBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CharacterVitalityBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CharacterPlacementBlock[] ReadCharacterPlacementBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CharacterPlacementBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CharacterPlacementBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CharacterPlacementBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CharacterPerceptionBlock[] ReadCharacterPerceptionBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CharacterPerceptionBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CharacterPerceptionBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CharacterPerceptionBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CharacterLookBlock[] ReadCharacterLookBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CharacterLookBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CharacterLookBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CharacterLookBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CharacterMovementBlock[] ReadCharacterMovementBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CharacterMovementBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CharacterMovementBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CharacterMovementBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CharacterSwarmBlock[] ReadCharacterSwarmBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CharacterSwarmBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CharacterSwarmBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CharacterSwarmBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CharacterReadyBlock[] ReadCharacterReadyBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CharacterReadyBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CharacterReadyBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CharacterReadyBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CharacterEngageBlock[] ReadCharacterEngageBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CharacterEngageBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CharacterEngageBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CharacterEngageBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CharacterChargeBlock[] ReadCharacterChargeBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CharacterChargeBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CharacterChargeBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CharacterChargeBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CharacterEvasionBlock[] ReadCharacterEvasionBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CharacterEvasionBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CharacterEvasionBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CharacterEvasionBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CharacterCoverBlock[] ReadCharacterCoverBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CharacterCoverBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CharacterCoverBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CharacterCoverBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CharacterRetreatBlock[] ReadCharacterRetreatBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CharacterRetreatBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CharacterRetreatBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CharacterRetreatBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CharacterSearchBlock[] ReadCharacterSearchBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CharacterSearchBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CharacterSearchBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CharacterSearchBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CharacterPresearchBlock[] ReadCharacterPresearchBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CharacterPresearchBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CharacterPresearchBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CharacterPresearchBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CharacterIdleBlock[] ReadCharacterIdleBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CharacterIdleBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CharacterIdleBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CharacterIdleBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CharacterVocalizationBlock[] ReadCharacterVocalizationBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CharacterVocalizationBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CharacterVocalizationBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CharacterVocalizationBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CharacterBoardingBlock[] ReadCharacterBoardingBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CharacterBoardingBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CharacterBoardingBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CharacterBoardingBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CharacterBossBlock[] ReadCharacterBossBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CharacterBossBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CharacterBossBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CharacterBossBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CharacterWeaponsBlock[] ReadCharacterWeaponsBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CharacterWeaponsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CharacterWeaponsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CharacterWeaponsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CharacterFiringPatternPropertiesBlock[] ReadCharacterFiringPatternPropertiesBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CharacterFiringPatternPropertiesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CharacterFiringPatternPropertiesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CharacterFiringPatternPropertiesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CharacterGrenadesBlock[] ReadCharacterGrenadesBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CharacterGrenadesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CharacterGrenadesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CharacterGrenadesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CharacterVehicleBlock[] ReadCharacterVehicleBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CharacterVehicleBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CharacterVehicleBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CharacterVehicleBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteCharacterVariantsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteCharacterGeneralBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteCharacterVitalityBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteCharacterPlacementBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteCharacterPerceptionBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteCharacterLookBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteCharacterMovementBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteCharacterSwarmBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteCharacterReadyBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteCharacterEngageBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteCharacterChargeBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteCharacterEvasionBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteCharacterCoverBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteCharacterRetreatBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteCharacterSearchBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteCharacterPresearchBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteCharacterIdleBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteCharacterVocalizationBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteCharacterBoardingBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteCharacterBossBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteCharacterWeaponsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteCharacterFiringPatternPropertiesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteCharacterGrenadesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteCharacterVehicleBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)characterFlags);
                binaryWriter.Write(parentCharacter);
                binaryWriter.Write(unit);
                binaryWriter.Write(creature);
                binaryWriter.Write(style);
                binaryWriter.Write(majorCharacter);
                WriteCharacterVariantsBlockArray(binaryWriter);
                WriteCharacterGeneralBlockArray(binaryWriter);
                WriteCharacterVitalityBlockArray(binaryWriter);
                WriteCharacterPlacementBlockArray(binaryWriter);
                WriteCharacterPerceptionBlockArray(binaryWriter);
                WriteCharacterLookBlockArray(binaryWriter);
                WriteCharacterMovementBlockArray(binaryWriter);
                WriteCharacterSwarmBlockArray(binaryWriter);
                WriteCharacterReadyBlockArray(binaryWriter);
                WriteCharacterEngageBlockArray(binaryWriter);
                WriteCharacterChargeBlockArray(binaryWriter);
                WriteCharacterEvasionBlockArray(binaryWriter);
                WriteCharacterCoverBlockArray(binaryWriter);
                WriteCharacterRetreatBlockArray(binaryWriter);
                WriteCharacterSearchBlockArray(binaryWriter);
                WriteCharacterPresearchBlockArray(binaryWriter);
                WriteCharacterIdleBlockArray(binaryWriter);
                WriteCharacterVocalizationBlockArray(binaryWriter);
                WriteCharacterBoardingBlockArray(binaryWriter);
                WriteCharacterBossBlockArray(binaryWriter);
                WriteCharacterWeaponsBlockArray(binaryWriter);
                WriteCharacterFiringPatternPropertiesBlockArray(binaryWriter);
                WriteCharacterGrenadesBlockArray(binaryWriter);
                WriteCharacterVehicleBlockArray(binaryWriter);
            }
        }
        [FlagsAttribute]
        internal enum CharacterFlags : int
        
        {
            Flag1 = 1,
        };
    };
}
