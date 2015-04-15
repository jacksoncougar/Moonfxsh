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
        public static readonly TagClass Char = (TagClass)"char";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("char")]
    public  partial class CharacterBlock : CharacterBlockBase
    {
        public  CharacterBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 236, Alignment = 4)]
    public class CharacterBlockBase  : IGuerilla
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
            characterFlags = (CharacterFlags)binaryReader.ReadInt32();
            parentCharacter = binaryReader.ReadTagReference();
            unit = binaryReader.ReadTagReference();
            creature = binaryReader.ReadTagReference();
            style = binaryReader.ReadTagReference();
            majorCharacter = binaryReader.ReadTagReference();
            variants = Guerilla.ReadBlockArray<CharacterVariantsBlock>(binaryReader);
            generalProperties = Guerilla.ReadBlockArray<CharacterGeneralBlock>(binaryReader);
            vitalityProperties = Guerilla.ReadBlockArray<CharacterVitalityBlock>(binaryReader);
            placementProperties = Guerilla.ReadBlockArray<CharacterPlacementBlock>(binaryReader);
            perceptionProperties = Guerilla.ReadBlockArray<CharacterPerceptionBlock>(binaryReader);
            lookProperties = Guerilla.ReadBlockArray<CharacterLookBlock>(binaryReader);
            movementProperties = Guerilla.ReadBlockArray<CharacterMovementBlock>(binaryReader);
            swarmProperties = Guerilla.ReadBlockArray<CharacterSwarmBlock>(binaryReader);
            readyProperties = Guerilla.ReadBlockArray<CharacterReadyBlock>(binaryReader);
            engageProperties = Guerilla.ReadBlockArray<CharacterEngageBlock>(binaryReader);
            chargeProperties = Guerilla.ReadBlockArray<CharacterChargeBlock>(binaryReader);
            evasionProperties = Guerilla.ReadBlockArray<CharacterEvasionBlock>(binaryReader);
            coverProperties = Guerilla.ReadBlockArray<CharacterCoverBlock>(binaryReader);
            retreatProperties = Guerilla.ReadBlockArray<CharacterRetreatBlock>(binaryReader);
            searchProperties = Guerilla.ReadBlockArray<CharacterSearchBlock>(binaryReader);
            preSearchProperties = Guerilla.ReadBlockArray<CharacterPresearchBlock>(binaryReader);
            idleProperties = Guerilla.ReadBlockArray<CharacterIdleBlock>(binaryReader);
            vocalizationProperties = Guerilla.ReadBlockArray<CharacterVocalizationBlock>(binaryReader);
            boardingProperties = Guerilla.ReadBlockArray<CharacterBoardingBlock>(binaryReader);
            bossProperties = Guerilla.ReadBlockArray<CharacterBossBlock>(binaryReader);
            weaponsProperties = Guerilla.ReadBlockArray<CharacterWeaponsBlock>(binaryReader);
            firingPatternProperties = Guerilla.ReadBlockArray<CharacterFiringPatternPropertiesBlock>(binaryReader);
            grenadesProperties = Guerilla.ReadBlockArray<CharacterGrenadesBlock>(binaryReader);
            vehicleProperties = Guerilla.ReadBlockArray<CharacterVehicleBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)characterFlags);
                binaryWriter.Write(parentCharacter);
                binaryWriter.Write(unit);
                binaryWriter.Write(creature);
                binaryWriter.Write(style);
                binaryWriter.Write(majorCharacter);
                nextAddress = Guerilla.WriteBlockArray<CharacterVariantsBlock>(binaryWriter, variants, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CharacterGeneralBlock>(binaryWriter, generalProperties, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CharacterVitalityBlock>(binaryWriter, vitalityProperties, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CharacterPlacementBlock>(binaryWriter, placementProperties, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CharacterPerceptionBlock>(binaryWriter, perceptionProperties, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CharacterLookBlock>(binaryWriter, lookProperties, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CharacterMovementBlock>(binaryWriter, movementProperties, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CharacterSwarmBlock>(binaryWriter, swarmProperties, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CharacterReadyBlock>(binaryWriter, readyProperties, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CharacterEngageBlock>(binaryWriter, engageProperties, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CharacterChargeBlock>(binaryWriter, chargeProperties, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CharacterEvasionBlock>(binaryWriter, evasionProperties, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CharacterCoverBlock>(binaryWriter, coverProperties, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CharacterRetreatBlock>(binaryWriter, retreatProperties, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CharacterSearchBlock>(binaryWriter, searchProperties, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CharacterPresearchBlock>(binaryWriter, preSearchProperties, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CharacterIdleBlock>(binaryWriter, idleProperties, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CharacterVocalizationBlock>(binaryWriter, vocalizationProperties, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CharacterBoardingBlock>(binaryWriter, boardingProperties, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CharacterBossBlock>(binaryWriter, bossProperties, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CharacterWeaponsBlock>(binaryWriter, weaponsProperties, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CharacterFiringPatternPropertiesBlock>(binaryWriter, firingPatternProperties, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CharacterGrenadesBlock>(binaryWriter, grenadesProperties, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CharacterVehicleBlock>(binaryWriter, vehicleProperties, nextAddress);
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
