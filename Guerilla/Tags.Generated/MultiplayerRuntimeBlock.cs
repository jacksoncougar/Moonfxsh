// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class MultiplayerRuntimeBlock : MultiplayerRuntimeBlockBase
    {
        public  MultiplayerRuntimeBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  MultiplayerRuntimeBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 1384, Alignment = 4)]
    public class MultiplayerRuntimeBlockBase : GuerillaBlock
    {
        [TagReference("item")]
        internal Moonfish.Tags.TagReference flag;
        [TagReference("item")]
        internal Moonfish.Tags.TagReference ball;
        [TagReference("unit")]
        internal Moonfish.Tags.TagReference unit;
        [TagReference("shad")]
        internal Moonfish.Tags.TagReference flagShader;
        [TagReference("shad")]
        internal Moonfish.Tags.TagReference hillShader;
        [TagReference("item")]
        internal Moonfish.Tags.TagReference head;
        [TagReference("item")]
        internal Moonfish.Tags.TagReference juggernautPowerup;
        [TagReference("item")]
        internal Moonfish.Tags.TagReference daBomb;
        [TagReference("null")]
        internal Moonfish.Tags.TagReference invalidName_;
        [TagReference("null")]
        internal Moonfish.Tags.TagReference invalidName_0;
        [TagReference("null")]
        internal Moonfish.Tags.TagReference invalidName_1;
        [TagReference("null")]
        internal Moonfish.Tags.TagReference invalidName_2;
        [TagReference("null")]
        internal Moonfish.Tags.TagReference invalidName_3;
        internal WeaponsBlock[] weapons;
        internal VehiclesBlock[] vehicles;
        internal GrenadeAndPowerupStructBlock arr;
        [TagReference("unic")]
        internal Moonfish.Tags.TagReference inGameText;
        internal SoundsBlock[] sounds;
        internal GameEngineGeneralEventBlock[] generalEvents;
        internal GameEngineFlavorEventBlock[] flavorEvents;
        internal GameEngineSlayerEventBlock[] slayerEvents;
        internal GameEngineCtfEventBlock[] ctfEvents;
        internal GameEngineOddballEventBlock[] oddballEvents;
        internal GNullBlock[] gNullBlock;
        internal GameEngineKingEventBlock[] kingEvents;
        internal GNullBlock[] gNullBlock0;
        internal GameEngineJuggernautEventBlock[] juggernautEvents;
        internal GameEngineTerritoriesEventBlock[] territoriesEvents;
        internal GameEngineAssaultEventBlock[] invasionEvents;
        internal GNullBlock[] gNullBlock1;
        internal GNullBlock[] gNullBlock2;
        internal GNullBlock[] gNullBlock3;
        internal GNullBlock[] gNullBlock4;
        [TagReference("itmc")]
        internal Moonfish.Tags.TagReference defaultItemCollection1;
        [TagReference("itmc")]
        internal Moonfish.Tags.TagReference defaultItemCollection2;
        internal int defaultFragGrenadeCount;
        internal int defaultPlasmaGrenadeCount;
        internal byte[] invalidName_4;
        internal float dynamicZoneUpperHeight;
        internal float dynamicZoneLowerHeight;
        internal byte[] invalidName_5;
        internal float enemyInnerRadius;
        internal float enemyOuterRadius;
        internal float enemyWeight;
        internal byte[] invalidName_6;
        internal float friendInnerRadius;
        internal float friendOuterRadius;
        internal float friendWeight;
        internal byte[] invalidName_7;
        internal float enemyVehicleInnerRadius;
        internal float enemyVehicleOuterRadius;
        internal float enemyVehicleWeight;
        internal byte[] invalidName_8;
        internal float friendlyVehicleInnerRadius;
        internal float friendlyVehicleOuterRadius;
        internal float friendlyVehicleWeight;
        internal byte[] invalidName_9;
        internal float emptyVehicleInnerRadius;
        internal float emptyVehicleOuterRadius;
        internal float emptyVehicleWeight;
        internal byte[] invalidName_10;
        internal float oddballInclusionInnerRadius;
        internal float oddballInclusionOuterRadius;
        internal float oddballInclusionWeight;
        internal byte[] invalidName_11;
        internal float oddballExclusionInnerRadius;
        internal float oddballExclusionOuterRadius;
        internal float oddballExclusionWeight;
        internal byte[] invalidName_12;
        internal float hillInclusionInnerRadius;
        internal float hillInclusionOuterRadius;
        internal float hillInclusionWeight;
        internal byte[] invalidName_13;
        internal float hillExclusionInnerRadius;
        internal float hillExclusionOuterRadius;
        internal float hillExclusionWeight;
        internal byte[] invalidName_14;
        internal float lastRaceFlagInnerRadius;
        internal float lastRaceFlagOuterRadius;
        internal float lastRaceFlagWeight;
        internal byte[] invalidName_15;
        internal float deadAllyInnerRadius;
        internal float deadAllyOuterRadius;
        internal float deadAllyWeight;
        internal byte[] invalidName_16;
        internal float controlledTerritoryInnerRadius;
        internal float controlledTerritoryOuterRadius;
        internal float controlledTerritoryWeight;
        internal byte[] invalidName_17;
        internal byte[] invalidName_18;
        internal byte[] invalidName_19;
        internal MultiplayerConstantsBlock[] multiplayerConstants;
        internal GameEngineStatusResponseBlock[] stateResponses;
        [TagReference("nhdt")]
        internal Moonfish.Tags.TagReference scoreboardHudDefinition;
        [TagReference("shad")]
        internal Moonfish.Tags.TagReference scoreboardEmblemShader;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference scoreboardEmblemBitmap;
        [TagReference("shad")]
        internal Moonfish.Tags.TagReference scoreboardDeadEmblemShader;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference scoreboardDeadEmblemBitmap;
        
        public override int SerializedSize{get { return 1384; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  MultiplayerRuntimeBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            flag = binaryReader.ReadTagReference();
            ball = binaryReader.ReadTagReference();
            unit = binaryReader.ReadTagReference();
            flagShader = binaryReader.ReadTagReference();
            hillShader = binaryReader.ReadTagReference();
            head = binaryReader.ReadTagReference();
            juggernautPowerup = binaryReader.ReadTagReference();
            daBomb = binaryReader.ReadTagReference();
            invalidName_ = binaryReader.ReadTagReference();
            invalidName_0 = binaryReader.ReadTagReference();
            invalidName_1 = binaryReader.ReadTagReference();
            invalidName_2 = binaryReader.ReadTagReference();
            invalidName_3 = binaryReader.ReadTagReference();
            weapons = Guerilla.ReadBlockArray<WeaponsBlock>(binaryReader);
            vehicles = Guerilla.ReadBlockArray<VehiclesBlock>(binaryReader);
            arr = new GrenadeAndPowerupStructBlock(binaryReader);
            inGameText = binaryReader.ReadTagReference();
            sounds = Guerilla.ReadBlockArray<SoundsBlock>(binaryReader);
            generalEvents = Guerilla.ReadBlockArray<GameEngineGeneralEventBlock>(binaryReader);
            flavorEvents = Guerilla.ReadBlockArray<GameEngineFlavorEventBlock>(binaryReader);
            slayerEvents = Guerilla.ReadBlockArray<GameEngineSlayerEventBlock>(binaryReader);
            ctfEvents = Guerilla.ReadBlockArray<GameEngineCtfEventBlock>(binaryReader);
            oddballEvents = Guerilla.ReadBlockArray<GameEngineOddballEventBlock>(binaryReader);
            gNullBlock = Guerilla.ReadBlockArray<GNullBlock>(binaryReader);
            kingEvents = Guerilla.ReadBlockArray<GameEngineKingEventBlock>(binaryReader);
            gNullBlock0 = Guerilla.ReadBlockArray<GNullBlock>(binaryReader);
            juggernautEvents = Guerilla.ReadBlockArray<GameEngineJuggernautEventBlock>(binaryReader);
            territoriesEvents = Guerilla.ReadBlockArray<GameEngineTerritoriesEventBlock>(binaryReader);
            invasionEvents = Guerilla.ReadBlockArray<GameEngineAssaultEventBlock>(binaryReader);
            gNullBlock1 = Guerilla.ReadBlockArray<GNullBlock>(binaryReader);
            gNullBlock2 = Guerilla.ReadBlockArray<GNullBlock>(binaryReader);
            gNullBlock3 = Guerilla.ReadBlockArray<GNullBlock>(binaryReader);
            gNullBlock4 = Guerilla.ReadBlockArray<GNullBlock>(binaryReader);
            defaultItemCollection1 = binaryReader.ReadTagReference();
            defaultItemCollection2 = binaryReader.ReadTagReference();
            defaultFragGrenadeCount = binaryReader.ReadInt32();
            defaultPlasmaGrenadeCount = binaryReader.ReadInt32();
            invalidName_4 = binaryReader.ReadBytes(40);
            dynamicZoneUpperHeight = binaryReader.ReadSingle();
            dynamicZoneLowerHeight = binaryReader.ReadSingle();
            invalidName_5 = binaryReader.ReadBytes(40);
            enemyInnerRadius = binaryReader.ReadSingle();
            enemyOuterRadius = binaryReader.ReadSingle();
            enemyWeight = binaryReader.ReadSingle();
            invalidName_6 = binaryReader.ReadBytes(16);
            friendInnerRadius = binaryReader.ReadSingle();
            friendOuterRadius = binaryReader.ReadSingle();
            friendWeight = binaryReader.ReadSingle();
            invalidName_7 = binaryReader.ReadBytes(16);
            enemyVehicleInnerRadius = binaryReader.ReadSingle();
            enemyVehicleOuterRadius = binaryReader.ReadSingle();
            enemyVehicleWeight = binaryReader.ReadSingle();
            invalidName_8 = binaryReader.ReadBytes(16);
            friendlyVehicleInnerRadius = binaryReader.ReadSingle();
            friendlyVehicleOuterRadius = binaryReader.ReadSingle();
            friendlyVehicleWeight = binaryReader.ReadSingle();
            invalidName_9 = binaryReader.ReadBytes(16);
            emptyVehicleInnerRadius = binaryReader.ReadSingle();
            emptyVehicleOuterRadius = binaryReader.ReadSingle();
            emptyVehicleWeight = binaryReader.ReadSingle();
            invalidName_10 = binaryReader.ReadBytes(16);
            oddballInclusionInnerRadius = binaryReader.ReadSingle();
            oddballInclusionOuterRadius = binaryReader.ReadSingle();
            oddballInclusionWeight = binaryReader.ReadSingle();
            invalidName_11 = binaryReader.ReadBytes(16);
            oddballExclusionInnerRadius = binaryReader.ReadSingle();
            oddballExclusionOuterRadius = binaryReader.ReadSingle();
            oddballExclusionWeight = binaryReader.ReadSingle();
            invalidName_12 = binaryReader.ReadBytes(16);
            hillInclusionInnerRadius = binaryReader.ReadSingle();
            hillInclusionOuterRadius = binaryReader.ReadSingle();
            hillInclusionWeight = binaryReader.ReadSingle();
            invalidName_13 = binaryReader.ReadBytes(16);
            hillExclusionInnerRadius = binaryReader.ReadSingle();
            hillExclusionOuterRadius = binaryReader.ReadSingle();
            hillExclusionWeight = binaryReader.ReadSingle();
            invalidName_14 = binaryReader.ReadBytes(16);
            lastRaceFlagInnerRadius = binaryReader.ReadSingle();
            lastRaceFlagOuterRadius = binaryReader.ReadSingle();
            lastRaceFlagWeight = binaryReader.ReadSingle();
            invalidName_15 = binaryReader.ReadBytes(16);
            deadAllyInnerRadius = binaryReader.ReadSingle();
            deadAllyOuterRadius = binaryReader.ReadSingle();
            deadAllyWeight = binaryReader.ReadSingle();
            invalidName_16 = binaryReader.ReadBytes(16);
            controlledTerritoryInnerRadius = binaryReader.ReadSingle();
            controlledTerritoryOuterRadius = binaryReader.ReadSingle();
            controlledTerritoryWeight = binaryReader.ReadSingle();
            invalidName_17 = binaryReader.ReadBytes(16);
            invalidName_18 = binaryReader.ReadBytes(560);
            invalidName_19 = binaryReader.ReadBytes(48);
            multiplayerConstants = Guerilla.ReadBlockArray<MultiplayerConstantsBlock>(binaryReader);
            stateResponses = Guerilla.ReadBlockArray<GameEngineStatusResponseBlock>(binaryReader);
            scoreboardHudDefinition = binaryReader.ReadTagReference();
            scoreboardEmblemShader = binaryReader.ReadTagReference();
            scoreboardEmblemBitmap = binaryReader.ReadTagReference();
            scoreboardDeadEmblemShader = binaryReader.ReadTagReference();
            scoreboardDeadEmblemBitmap = binaryReader.ReadTagReference();
        }
        public  MultiplayerRuntimeBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            flag = binaryReader.ReadTagReference();
            ball = binaryReader.ReadTagReference();
            unit = binaryReader.ReadTagReference();
            flagShader = binaryReader.ReadTagReference();
            hillShader = binaryReader.ReadTagReference();
            head = binaryReader.ReadTagReference();
            juggernautPowerup = binaryReader.ReadTagReference();
            daBomb = binaryReader.ReadTagReference();
            invalidName_ = binaryReader.ReadTagReference();
            invalidName_0 = binaryReader.ReadTagReference();
            invalidName_1 = binaryReader.ReadTagReference();
            invalidName_2 = binaryReader.ReadTagReference();
            invalidName_3 = binaryReader.ReadTagReference();
            weapons = Guerilla.ReadBlockArray<WeaponsBlock>(binaryReader);
            vehicles = Guerilla.ReadBlockArray<VehiclesBlock>(binaryReader);
            arr = new GrenadeAndPowerupStructBlock(binaryReader);
            inGameText = binaryReader.ReadTagReference();
            sounds = Guerilla.ReadBlockArray<SoundsBlock>(binaryReader);
            generalEvents = Guerilla.ReadBlockArray<GameEngineGeneralEventBlock>(binaryReader);
            flavorEvents = Guerilla.ReadBlockArray<GameEngineFlavorEventBlock>(binaryReader);
            slayerEvents = Guerilla.ReadBlockArray<GameEngineSlayerEventBlock>(binaryReader);
            ctfEvents = Guerilla.ReadBlockArray<GameEngineCtfEventBlock>(binaryReader);
            oddballEvents = Guerilla.ReadBlockArray<GameEngineOddballEventBlock>(binaryReader);
            gNullBlock = Guerilla.ReadBlockArray<GNullBlock>(binaryReader);
            kingEvents = Guerilla.ReadBlockArray<GameEngineKingEventBlock>(binaryReader);
            gNullBlock0 = Guerilla.ReadBlockArray<GNullBlock>(binaryReader);
            juggernautEvents = Guerilla.ReadBlockArray<GameEngineJuggernautEventBlock>(binaryReader);
            territoriesEvents = Guerilla.ReadBlockArray<GameEngineTerritoriesEventBlock>(binaryReader);
            invasionEvents = Guerilla.ReadBlockArray<GameEngineAssaultEventBlock>(binaryReader);
            gNullBlock1 = Guerilla.ReadBlockArray<GNullBlock>(binaryReader);
            gNullBlock2 = Guerilla.ReadBlockArray<GNullBlock>(binaryReader);
            gNullBlock3 = Guerilla.ReadBlockArray<GNullBlock>(binaryReader);
            gNullBlock4 = Guerilla.ReadBlockArray<GNullBlock>(binaryReader);
            defaultItemCollection1 = binaryReader.ReadTagReference();
            defaultItemCollection2 = binaryReader.ReadTagReference();
            defaultFragGrenadeCount = binaryReader.ReadInt32();
            defaultPlasmaGrenadeCount = binaryReader.ReadInt32();
            invalidName_4 = binaryReader.ReadBytes(40);
            dynamicZoneUpperHeight = binaryReader.ReadSingle();
            dynamicZoneLowerHeight = binaryReader.ReadSingle();
            invalidName_5 = binaryReader.ReadBytes(40);
            enemyInnerRadius = binaryReader.ReadSingle();
            enemyOuterRadius = binaryReader.ReadSingle();
            enemyWeight = binaryReader.ReadSingle();
            invalidName_6 = binaryReader.ReadBytes(16);
            friendInnerRadius = binaryReader.ReadSingle();
            friendOuterRadius = binaryReader.ReadSingle();
            friendWeight = binaryReader.ReadSingle();
            invalidName_7 = binaryReader.ReadBytes(16);
            enemyVehicleInnerRadius = binaryReader.ReadSingle();
            enemyVehicleOuterRadius = binaryReader.ReadSingle();
            enemyVehicleWeight = binaryReader.ReadSingle();
            invalidName_8 = binaryReader.ReadBytes(16);
            friendlyVehicleInnerRadius = binaryReader.ReadSingle();
            friendlyVehicleOuterRadius = binaryReader.ReadSingle();
            friendlyVehicleWeight = binaryReader.ReadSingle();
            invalidName_9 = binaryReader.ReadBytes(16);
            emptyVehicleInnerRadius = binaryReader.ReadSingle();
            emptyVehicleOuterRadius = binaryReader.ReadSingle();
            emptyVehicleWeight = binaryReader.ReadSingle();
            invalidName_10 = binaryReader.ReadBytes(16);
            oddballInclusionInnerRadius = binaryReader.ReadSingle();
            oddballInclusionOuterRadius = binaryReader.ReadSingle();
            oddballInclusionWeight = binaryReader.ReadSingle();
            invalidName_11 = binaryReader.ReadBytes(16);
            oddballExclusionInnerRadius = binaryReader.ReadSingle();
            oddballExclusionOuterRadius = binaryReader.ReadSingle();
            oddballExclusionWeight = binaryReader.ReadSingle();
            invalidName_12 = binaryReader.ReadBytes(16);
            hillInclusionInnerRadius = binaryReader.ReadSingle();
            hillInclusionOuterRadius = binaryReader.ReadSingle();
            hillInclusionWeight = binaryReader.ReadSingle();
            invalidName_13 = binaryReader.ReadBytes(16);
            hillExclusionInnerRadius = binaryReader.ReadSingle();
            hillExclusionOuterRadius = binaryReader.ReadSingle();
            hillExclusionWeight = binaryReader.ReadSingle();
            invalidName_14 = binaryReader.ReadBytes(16);
            lastRaceFlagInnerRadius = binaryReader.ReadSingle();
            lastRaceFlagOuterRadius = binaryReader.ReadSingle();
            lastRaceFlagWeight = binaryReader.ReadSingle();
            invalidName_15 = binaryReader.ReadBytes(16);
            deadAllyInnerRadius = binaryReader.ReadSingle();
            deadAllyOuterRadius = binaryReader.ReadSingle();
            deadAllyWeight = binaryReader.ReadSingle();
            invalidName_16 = binaryReader.ReadBytes(16);
            controlledTerritoryInnerRadius = binaryReader.ReadSingle();
            controlledTerritoryOuterRadius = binaryReader.ReadSingle();
            controlledTerritoryWeight = binaryReader.ReadSingle();
            invalidName_17 = binaryReader.ReadBytes(16);
            invalidName_18 = binaryReader.ReadBytes(560);
            invalidName_19 = binaryReader.ReadBytes(48);
            multiplayerConstants = Guerilla.ReadBlockArray<MultiplayerConstantsBlock>(binaryReader);
            stateResponses = Guerilla.ReadBlockArray<GameEngineStatusResponseBlock>(binaryReader);
            scoreboardHudDefinition = binaryReader.ReadTagReference();
            scoreboardEmblemShader = binaryReader.ReadTagReference();
            scoreboardEmblemBitmap = binaryReader.ReadTagReference();
            scoreboardDeadEmblemShader = binaryReader.ReadTagReference();
            scoreboardDeadEmblemBitmap = binaryReader.ReadTagReference();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(flag);
                binaryWriter.Write(ball);
                binaryWriter.Write(unit);
                binaryWriter.Write(flagShader);
                binaryWriter.Write(hillShader);
                binaryWriter.Write(head);
                binaryWriter.Write(juggernautPowerup);
                binaryWriter.Write(daBomb);
                binaryWriter.Write(invalidName_);
                binaryWriter.Write(invalidName_0);
                binaryWriter.Write(invalidName_1);
                binaryWriter.Write(invalidName_2);
                binaryWriter.Write(invalidName_3);
                nextAddress = Guerilla.WriteBlockArray<WeaponsBlock>(binaryWriter, weapons, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<VehiclesBlock>(binaryWriter, vehicles, nextAddress);
                arr.Write(binaryWriter);
                binaryWriter.Write(inGameText);
                nextAddress = Guerilla.WriteBlockArray<SoundsBlock>(binaryWriter, sounds, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GameEngineGeneralEventBlock>(binaryWriter, generalEvents, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GameEngineFlavorEventBlock>(binaryWriter, flavorEvents, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GameEngineSlayerEventBlock>(binaryWriter, slayerEvents, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GameEngineCtfEventBlock>(binaryWriter, ctfEvents, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GameEngineOddballEventBlock>(binaryWriter, oddballEvents, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GNullBlock>(binaryWriter, gNullBlock, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GameEngineKingEventBlock>(binaryWriter, kingEvents, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GNullBlock>(binaryWriter, gNullBlock0, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GameEngineJuggernautEventBlock>(binaryWriter, juggernautEvents, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GameEngineTerritoriesEventBlock>(binaryWriter, territoriesEvents, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GameEngineAssaultEventBlock>(binaryWriter, invasionEvents, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GNullBlock>(binaryWriter, gNullBlock1, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GNullBlock>(binaryWriter, gNullBlock2, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GNullBlock>(binaryWriter, gNullBlock3, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GNullBlock>(binaryWriter, gNullBlock4, nextAddress);
                binaryWriter.Write(defaultItemCollection1);
                binaryWriter.Write(defaultItemCollection2);
                binaryWriter.Write(defaultFragGrenadeCount);
                binaryWriter.Write(defaultPlasmaGrenadeCount);
                binaryWriter.Write(invalidName_4, 0, 40);
                binaryWriter.Write(dynamicZoneUpperHeight);
                binaryWriter.Write(dynamicZoneLowerHeight);
                binaryWriter.Write(invalidName_5, 0, 40);
                binaryWriter.Write(enemyInnerRadius);
                binaryWriter.Write(enemyOuterRadius);
                binaryWriter.Write(enemyWeight);
                binaryWriter.Write(invalidName_6, 0, 16);
                binaryWriter.Write(friendInnerRadius);
                binaryWriter.Write(friendOuterRadius);
                binaryWriter.Write(friendWeight);
                binaryWriter.Write(invalidName_7, 0, 16);
                binaryWriter.Write(enemyVehicleInnerRadius);
                binaryWriter.Write(enemyVehicleOuterRadius);
                binaryWriter.Write(enemyVehicleWeight);
                binaryWriter.Write(invalidName_8, 0, 16);
                binaryWriter.Write(friendlyVehicleInnerRadius);
                binaryWriter.Write(friendlyVehicleOuterRadius);
                binaryWriter.Write(friendlyVehicleWeight);
                binaryWriter.Write(invalidName_9, 0, 16);
                binaryWriter.Write(emptyVehicleInnerRadius);
                binaryWriter.Write(emptyVehicleOuterRadius);
                binaryWriter.Write(emptyVehicleWeight);
                binaryWriter.Write(invalidName_10, 0, 16);
                binaryWriter.Write(oddballInclusionInnerRadius);
                binaryWriter.Write(oddballInclusionOuterRadius);
                binaryWriter.Write(oddballInclusionWeight);
                binaryWriter.Write(invalidName_11, 0, 16);
                binaryWriter.Write(oddballExclusionInnerRadius);
                binaryWriter.Write(oddballExclusionOuterRadius);
                binaryWriter.Write(oddballExclusionWeight);
                binaryWriter.Write(invalidName_12, 0, 16);
                binaryWriter.Write(hillInclusionInnerRadius);
                binaryWriter.Write(hillInclusionOuterRadius);
                binaryWriter.Write(hillInclusionWeight);
                binaryWriter.Write(invalidName_13, 0, 16);
                binaryWriter.Write(hillExclusionInnerRadius);
                binaryWriter.Write(hillExclusionOuterRadius);
                binaryWriter.Write(hillExclusionWeight);
                binaryWriter.Write(invalidName_14, 0, 16);
                binaryWriter.Write(lastRaceFlagInnerRadius);
                binaryWriter.Write(lastRaceFlagOuterRadius);
                binaryWriter.Write(lastRaceFlagWeight);
                binaryWriter.Write(invalidName_15, 0, 16);
                binaryWriter.Write(deadAllyInnerRadius);
                binaryWriter.Write(deadAllyOuterRadius);
                binaryWriter.Write(deadAllyWeight);
                binaryWriter.Write(invalidName_16, 0, 16);
                binaryWriter.Write(controlledTerritoryInnerRadius);
                binaryWriter.Write(controlledTerritoryOuterRadius);
                binaryWriter.Write(controlledTerritoryWeight);
                binaryWriter.Write(invalidName_17, 0, 16);
                binaryWriter.Write(invalidName_18, 0, 560);
                binaryWriter.Write(invalidName_19, 0, 48);
                nextAddress = Guerilla.WriteBlockArray<MultiplayerConstantsBlock>(binaryWriter, multiplayerConstants, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GameEngineStatusResponseBlock>(binaryWriter, stateResponses, nextAddress);
                binaryWriter.Write(scoreboardHudDefinition);
                binaryWriter.Write(scoreboardEmblemShader);
                binaryWriter.Write(scoreboardEmblemBitmap);
                binaryWriter.Write(scoreboardDeadEmblemShader);
                binaryWriter.Write(scoreboardDeadEmblemBitmap);
                return nextAddress;
            }
        }
    };
}
