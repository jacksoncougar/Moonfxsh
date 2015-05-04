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
        public static readonly TagClass Char = (TagClass) "char";
    };
} ;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("char")]
    public partial class CharacterBlock : CharacterBlockBase
    {
        public CharacterBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 236, Alignment = 4)]
    public class CharacterBlockBase : GuerillaBlock
    {
        internal CharacterFlags characterFlags;
        [TagReference("char")] internal Moonfish.Tags.TagReference parentCharacter;
        [TagReference("unit")] internal Moonfish.Tags.TagReference unit;

        /// <summary>
        /// Creature reference for swarm characters ONLY
        /// </summary>
        [TagReference("crea")] internal Moonfish.Tags.TagReference creature;

        [TagReference("styl")] internal Moonfish.Tags.TagReference style;
        [TagReference("char")] internal Moonfish.Tags.TagReference majorCharacter;
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

        public override int SerializedSize
        {
            get { return 236; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public CharacterBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            characterFlags = (CharacterFlags) binaryReader.ReadInt32();
            parentCharacter = binaryReader.ReadTagReference();
            unit = binaryReader.ReadTagReference();
            creature = binaryReader.ReadTagReference();
            style = binaryReader.ReadTagReference();
            majorCharacter = binaryReader.ReadTagReference();
            blamPointers.Enqueue(ReadBlockArrayPointer<CharacterVariantsBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<CharacterGeneralBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<CharacterVitalityBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<CharacterPlacementBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<CharacterPerceptionBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<CharacterLookBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<CharacterMovementBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<CharacterSwarmBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<CharacterReadyBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<CharacterEngageBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<CharacterChargeBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<CharacterEvasionBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<CharacterCoverBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<CharacterRetreatBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<CharacterSearchBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<CharacterPresearchBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<CharacterIdleBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<CharacterVocalizationBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<CharacterBoardingBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<CharacterBossBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<CharacterWeaponsBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<CharacterFiringPatternPropertiesBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<CharacterGrenadesBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<CharacterVehicleBlock>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            variants = ReadBlockArrayData<CharacterVariantsBlock>(binaryReader, blamPointers.Dequeue());
            generalProperties = ReadBlockArrayData<CharacterGeneralBlock>(binaryReader, blamPointers.Dequeue());
            vitalityProperties = ReadBlockArrayData<CharacterVitalityBlock>(binaryReader, blamPointers.Dequeue());
            placementProperties = ReadBlockArrayData<CharacterPlacementBlock>(binaryReader, blamPointers.Dequeue());
            perceptionProperties = ReadBlockArrayData<CharacterPerceptionBlock>(binaryReader, blamPointers.Dequeue());
            lookProperties = ReadBlockArrayData<CharacterLookBlock>(binaryReader, blamPointers.Dequeue());
            movementProperties = ReadBlockArrayData<CharacterMovementBlock>(binaryReader, blamPointers.Dequeue());
            swarmProperties = ReadBlockArrayData<CharacterSwarmBlock>(binaryReader, blamPointers.Dequeue());
            readyProperties = ReadBlockArrayData<CharacterReadyBlock>(binaryReader, blamPointers.Dequeue());
            engageProperties = ReadBlockArrayData<CharacterEngageBlock>(binaryReader, blamPointers.Dequeue());
            chargeProperties = ReadBlockArrayData<CharacterChargeBlock>(binaryReader, blamPointers.Dequeue());
            evasionProperties = ReadBlockArrayData<CharacterEvasionBlock>(binaryReader, blamPointers.Dequeue());
            coverProperties = ReadBlockArrayData<CharacterCoverBlock>(binaryReader, blamPointers.Dequeue());
            retreatProperties = ReadBlockArrayData<CharacterRetreatBlock>(binaryReader, blamPointers.Dequeue());
            searchProperties = ReadBlockArrayData<CharacterSearchBlock>(binaryReader, blamPointers.Dequeue());
            preSearchProperties = ReadBlockArrayData<CharacterPresearchBlock>(binaryReader, blamPointers.Dequeue());
            idleProperties = ReadBlockArrayData<CharacterIdleBlock>(binaryReader, blamPointers.Dequeue());
            vocalizationProperties = ReadBlockArrayData<CharacterVocalizationBlock>(binaryReader, blamPointers.Dequeue());
            boardingProperties = ReadBlockArrayData<CharacterBoardingBlock>(binaryReader, blamPointers.Dequeue());
            bossProperties = ReadBlockArrayData<CharacterBossBlock>(binaryReader, blamPointers.Dequeue());
            weaponsProperties = ReadBlockArrayData<CharacterWeaponsBlock>(binaryReader, blamPointers.Dequeue());
            firingPatternProperties = ReadBlockArrayData<CharacterFiringPatternPropertiesBlock>(binaryReader,
                blamPointers.Dequeue());
            grenadesProperties = ReadBlockArrayData<CharacterGrenadesBlock>(binaryReader, blamPointers.Dequeue());
            vehicleProperties = ReadBlockArrayData<CharacterVehicleBlock>(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32) characterFlags);
                binaryWriter.Write(parentCharacter);
                binaryWriter.Write(unit);
                binaryWriter.Write(creature);
                binaryWriter.Write(style);
                binaryWriter.Write(majorCharacter);
                nextAddress = Guerilla.WriteBlockArray<CharacterVariantsBlock>(binaryWriter, variants, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CharacterGeneralBlock>(binaryWriter, generalProperties,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CharacterVitalityBlock>(binaryWriter, vitalityProperties,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CharacterPlacementBlock>(binaryWriter, placementProperties,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CharacterPerceptionBlock>(binaryWriter, perceptionProperties,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CharacterLookBlock>(binaryWriter, lookProperties, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CharacterMovementBlock>(binaryWriter, movementProperties,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CharacterSwarmBlock>(binaryWriter, swarmProperties, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CharacterReadyBlock>(binaryWriter, readyProperties, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CharacterEngageBlock>(binaryWriter, engageProperties, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CharacterChargeBlock>(binaryWriter, chargeProperties, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CharacterEvasionBlock>(binaryWriter, evasionProperties,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CharacterCoverBlock>(binaryWriter, coverProperties, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CharacterRetreatBlock>(binaryWriter, retreatProperties,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CharacterSearchBlock>(binaryWriter, searchProperties, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CharacterPresearchBlock>(binaryWriter, preSearchProperties,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CharacterIdleBlock>(binaryWriter, idleProperties, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CharacterVocalizationBlock>(binaryWriter, vocalizationProperties,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CharacterBoardingBlock>(binaryWriter, boardingProperties,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CharacterBossBlock>(binaryWriter, bossProperties, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CharacterWeaponsBlock>(binaryWriter, weaponsProperties,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CharacterFiringPatternPropertiesBlock>(binaryWriter,
                    firingPatternProperties, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CharacterGrenadesBlock>(binaryWriter, grenadesProperties,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CharacterVehicleBlock>(binaryWriter, vehicleProperties,
                    nextAddress);
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum CharacterFlags : int
        {
            Flag1 = 1,
        };
    };
}