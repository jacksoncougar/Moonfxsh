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
        public  CharacterBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  CharacterBlockBase(BinaryReader binaryReader)
        {
            this.characterFlags = (CharacterFlags)binaryReader.ReadInt32();
            this.parentCharacter = binaryReader.ReadTagReference();
            this.unit = binaryReader.ReadTagReference();
            this.creature = binaryReader.ReadTagReference();
            this.style = binaryReader.ReadTagReference();
            this.majorCharacter = binaryReader.ReadTagReference();
            this.variants = ReadCharacterVariantsBlockArray(binaryReader);
            this.generalProperties = ReadCharacterGeneralBlockArray(binaryReader);
            this.vitalityProperties = ReadCharacterVitalityBlockArray(binaryReader);
            this.placementProperties = ReadCharacterPlacementBlockArray(binaryReader);
            this.perceptionProperties = ReadCharacterPerceptionBlockArray(binaryReader);
            this.lookProperties = ReadCharacterLookBlockArray(binaryReader);
            this.movementProperties = ReadCharacterMovementBlockArray(binaryReader);
            this.swarmProperties = ReadCharacterSwarmBlockArray(binaryReader);
            this.readyProperties = ReadCharacterReadyBlockArray(binaryReader);
            this.engageProperties = ReadCharacterEngageBlockArray(binaryReader);
            this.chargeProperties = ReadCharacterChargeBlockArray(binaryReader);
            this.evasionProperties = ReadCharacterEvasionBlockArray(binaryReader);
            this.coverProperties = ReadCharacterCoverBlockArray(binaryReader);
            this.retreatProperties = ReadCharacterRetreatBlockArray(binaryReader);
            this.searchProperties = ReadCharacterSearchBlockArray(binaryReader);
            this.preSearchProperties = ReadCharacterPresearchBlockArray(binaryReader);
            this.idleProperties = ReadCharacterIdleBlockArray(binaryReader);
            this.vocalizationProperties = ReadCharacterVocalizationBlockArray(binaryReader);
            this.boardingProperties = ReadCharacterBoardingBlockArray(binaryReader);
            this.bossProperties = ReadCharacterBossBlockArray(binaryReader);
            this.weaponsProperties = ReadCharacterWeaponsBlockArray(binaryReader);
            this.firingPatternProperties = ReadCharacterFiringPatternPropertiesBlockArray(binaryReader);
            this.grenadesProperties = ReadCharacterGrenadesBlockArray(binaryReader);
            this.vehicleProperties = ReadCharacterVehicleBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
        }
        internal  virtual CharacterVariantsBlock[] ReadCharacterVariantsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CharacterVariantsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CharacterVariantsBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CharacterVariantsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CharacterGeneralBlock[] ReadCharacterGeneralBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CharacterGeneralBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CharacterGeneralBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CharacterGeneralBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CharacterVitalityBlock[] ReadCharacterVitalityBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CharacterVitalityBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CharacterVitalityBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CharacterVitalityBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CharacterPlacementBlock[] ReadCharacterPlacementBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CharacterPlacementBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CharacterPlacementBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CharacterPlacementBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CharacterPerceptionBlock[] ReadCharacterPerceptionBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CharacterPerceptionBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CharacterPerceptionBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CharacterPerceptionBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CharacterLookBlock[] ReadCharacterLookBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CharacterLookBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CharacterLookBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CharacterLookBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CharacterMovementBlock[] ReadCharacterMovementBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CharacterMovementBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CharacterMovementBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CharacterMovementBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CharacterSwarmBlock[] ReadCharacterSwarmBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CharacterSwarmBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CharacterSwarmBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CharacterSwarmBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CharacterReadyBlock[] ReadCharacterReadyBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CharacterReadyBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CharacterReadyBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CharacterReadyBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CharacterEngageBlock[] ReadCharacterEngageBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CharacterEngageBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CharacterEngageBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CharacterEngageBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CharacterChargeBlock[] ReadCharacterChargeBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CharacterChargeBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CharacterChargeBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CharacterChargeBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CharacterEvasionBlock[] ReadCharacterEvasionBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CharacterEvasionBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CharacterEvasionBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CharacterEvasionBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CharacterCoverBlock[] ReadCharacterCoverBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CharacterCoverBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CharacterCoverBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CharacterCoverBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CharacterRetreatBlock[] ReadCharacterRetreatBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CharacterRetreatBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CharacterRetreatBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CharacterRetreatBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CharacterSearchBlock[] ReadCharacterSearchBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CharacterSearchBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CharacterSearchBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CharacterSearchBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CharacterPresearchBlock[] ReadCharacterPresearchBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CharacterPresearchBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CharacterPresearchBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CharacterPresearchBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CharacterIdleBlock[] ReadCharacterIdleBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CharacterIdleBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CharacterIdleBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CharacterIdleBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CharacterVocalizationBlock[] ReadCharacterVocalizationBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CharacterVocalizationBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CharacterVocalizationBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CharacterVocalizationBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CharacterBoardingBlock[] ReadCharacterBoardingBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CharacterBoardingBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CharacterBoardingBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CharacterBoardingBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CharacterBossBlock[] ReadCharacterBossBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CharacterBossBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CharacterBossBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CharacterBossBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CharacterWeaponsBlock[] ReadCharacterWeaponsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CharacterWeaponsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CharacterWeaponsBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CharacterWeaponsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CharacterFiringPatternPropertiesBlock[] ReadCharacterFiringPatternPropertiesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CharacterFiringPatternPropertiesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CharacterFiringPatternPropertiesBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CharacterFiringPatternPropertiesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CharacterGrenadesBlock[] ReadCharacterGrenadesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CharacterGrenadesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CharacterGrenadesBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CharacterGrenadesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CharacterVehicleBlock[] ReadCharacterVehicleBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CharacterVehicleBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CharacterVehicleBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CharacterVehicleBlock(binaryReader);
                }
            }
            return array;
        }
        [FlagsAttribute]
        internal enum CharacterFlags : int
        
        {
            Flag1 = 1,
        };
    };
}
