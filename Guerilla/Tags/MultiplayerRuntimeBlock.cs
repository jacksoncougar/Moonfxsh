using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class MultiplayerRuntimeBlock : MultiplayerRuntimeBlockBase
    {
        public  MultiplayerRuntimeBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 1384)]
    public class MultiplayerRuntimeBlockBase
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
        internal  MultiplayerRuntimeBlockBase(BinaryReader binaryReader)
        {
            this.flag = binaryReader.ReadTagReference();
            this.ball = binaryReader.ReadTagReference();
            this.unit = binaryReader.ReadTagReference();
            this.flagShader = binaryReader.ReadTagReference();
            this.hillShader = binaryReader.ReadTagReference();
            this.head = binaryReader.ReadTagReference();
            this.juggernautPowerup = binaryReader.ReadTagReference();
            this.daBomb = binaryReader.ReadTagReference();
            this.invalidName_ = binaryReader.ReadTagReference();
            this.invalidName_0 = binaryReader.ReadTagReference();
            this.invalidName_1 = binaryReader.ReadTagReference();
            this.invalidName_2 = binaryReader.ReadTagReference();
            this.invalidName_3 = binaryReader.ReadTagReference();
            this.weapons = ReadWeaponsBlockArray(binaryReader);
            this.vehicles = ReadVehiclesBlockArray(binaryReader);
            this.arr = new GrenadeAndPowerupStructBlock(binaryReader);
            this.inGameText = binaryReader.ReadTagReference();
            this.sounds = ReadSoundsBlockArray(binaryReader);
            this.generalEvents = ReadGameEngineGeneralEventBlockArray(binaryReader);
            this.flavorEvents = ReadGameEngineFlavorEventBlockArray(binaryReader);
            this.slayerEvents = ReadGameEngineSlayerEventBlockArray(binaryReader);
            this.ctfEvents = ReadGameEngineCtfEventBlockArray(binaryReader);
            this.oddballEvents = ReadGameEngineOddballEventBlockArray(binaryReader);
            this.gNullBlock = ReadGNullBlockArray(binaryReader);
            this.kingEvents = ReadGameEngineKingEventBlockArray(binaryReader);
            this.gNullBlock0 = ReadGNullBlockArray(binaryReader);
            this.juggernautEvents = ReadGameEngineJuggernautEventBlockArray(binaryReader);
            this.territoriesEvents = ReadGameEngineTerritoriesEventBlockArray(binaryReader);
            this.invasionEvents = ReadGameEngineAssaultEventBlockArray(binaryReader);
            this.gNullBlock1 = ReadGNullBlockArray(binaryReader);
            this.gNullBlock2 = ReadGNullBlockArray(binaryReader);
            this.gNullBlock3 = ReadGNullBlockArray(binaryReader);
            this.gNullBlock4 = ReadGNullBlockArray(binaryReader);
            this.defaultItemCollection1 = binaryReader.ReadTagReference();
            this.defaultItemCollection2 = binaryReader.ReadTagReference();
            this.defaultFragGrenadeCount = binaryReader.ReadInt32();
            this.defaultPlasmaGrenadeCount = binaryReader.ReadInt32();
            this.invalidName_4 = binaryReader.ReadBytes(40);
            this.dynamicZoneUpperHeight = binaryReader.ReadSingle();
            this.dynamicZoneLowerHeight = binaryReader.ReadSingle();
            this.invalidName_5 = binaryReader.ReadBytes(40);
            this.enemyInnerRadius = binaryReader.ReadSingle();
            this.enemyOuterRadius = binaryReader.ReadSingle();
            this.enemyWeight = binaryReader.ReadSingle();
            this.invalidName_6 = binaryReader.ReadBytes(16);
            this.friendInnerRadius = binaryReader.ReadSingle();
            this.friendOuterRadius = binaryReader.ReadSingle();
            this.friendWeight = binaryReader.ReadSingle();
            this.invalidName_7 = binaryReader.ReadBytes(16);
            this.enemyVehicleInnerRadius = binaryReader.ReadSingle();
            this.enemyVehicleOuterRadius = binaryReader.ReadSingle();
            this.enemyVehicleWeight = binaryReader.ReadSingle();
            this.invalidName_8 = binaryReader.ReadBytes(16);
            this.friendlyVehicleInnerRadius = binaryReader.ReadSingle();
            this.friendlyVehicleOuterRadius = binaryReader.ReadSingle();
            this.friendlyVehicleWeight = binaryReader.ReadSingle();
            this.invalidName_9 = binaryReader.ReadBytes(16);
            this.emptyVehicleInnerRadius = binaryReader.ReadSingle();
            this.emptyVehicleOuterRadius = binaryReader.ReadSingle();
            this.emptyVehicleWeight = binaryReader.ReadSingle();
            this.invalidName_10 = binaryReader.ReadBytes(16);
            this.oddballInclusionInnerRadius = binaryReader.ReadSingle();
            this.oddballInclusionOuterRadius = binaryReader.ReadSingle();
            this.oddballInclusionWeight = binaryReader.ReadSingle();
            this.invalidName_11 = binaryReader.ReadBytes(16);
            this.oddballExclusionInnerRadius = binaryReader.ReadSingle();
            this.oddballExclusionOuterRadius = binaryReader.ReadSingle();
            this.oddballExclusionWeight = binaryReader.ReadSingle();
            this.invalidName_12 = binaryReader.ReadBytes(16);
            this.hillInclusionInnerRadius = binaryReader.ReadSingle();
            this.hillInclusionOuterRadius = binaryReader.ReadSingle();
            this.hillInclusionWeight = binaryReader.ReadSingle();
            this.invalidName_13 = binaryReader.ReadBytes(16);
            this.hillExclusionInnerRadius = binaryReader.ReadSingle();
            this.hillExclusionOuterRadius = binaryReader.ReadSingle();
            this.hillExclusionWeight = binaryReader.ReadSingle();
            this.invalidName_14 = binaryReader.ReadBytes(16);
            this.lastRaceFlagInnerRadius = binaryReader.ReadSingle();
            this.lastRaceFlagOuterRadius = binaryReader.ReadSingle();
            this.lastRaceFlagWeight = binaryReader.ReadSingle();
            this.invalidName_15 = binaryReader.ReadBytes(16);
            this.deadAllyInnerRadius = binaryReader.ReadSingle();
            this.deadAllyOuterRadius = binaryReader.ReadSingle();
            this.deadAllyWeight = binaryReader.ReadSingle();
            this.invalidName_16 = binaryReader.ReadBytes(16);
            this.controlledTerritoryInnerRadius = binaryReader.ReadSingle();
            this.controlledTerritoryOuterRadius = binaryReader.ReadSingle();
            this.controlledTerritoryWeight = binaryReader.ReadSingle();
            this.invalidName_17 = binaryReader.ReadBytes(16);
            this.invalidName_18 = binaryReader.ReadBytes(560);
            this.invalidName_19 = binaryReader.ReadBytes(48);
            this.multiplayerConstants = ReadMultiplayerConstantsBlockArray(binaryReader);
            this.stateResponses = ReadGameEngineStatusResponseBlockArray(binaryReader);
            this.scoreboardHudDefinition = binaryReader.ReadTagReference();
            this.scoreboardEmblemShader = binaryReader.ReadTagReference();
            this.scoreboardEmblemBitmap = binaryReader.ReadTagReference();
            this.scoreboardDeadEmblemShader = binaryReader.ReadTagReference();
            this.scoreboardDeadEmblemBitmap = binaryReader.ReadTagReference();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
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
        internal  virtual WeaponsBlock[] ReadWeaponsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(WeaponsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new WeaponsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new WeaponsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual VehiclesBlock[] ReadVehiclesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(VehiclesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new VehiclesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new VehiclesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual SoundsBlock[] ReadSoundsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SoundsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SoundsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SoundsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GameEngineGeneralEventBlock[] ReadGameEngineGeneralEventBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GameEngineGeneralEventBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GameEngineGeneralEventBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GameEngineGeneralEventBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GameEngineFlavorEventBlock[] ReadGameEngineFlavorEventBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GameEngineFlavorEventBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GameEngineFlavorEventBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GameEngineFlavorEventBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GameEngineSlayerEventBlock[] ReadGameEngineSlayerEventBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GameEngineSlayerEventBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GameEngineSlayerEventBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GameEngineSlayerEventBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GameEngineCtfEventBlock[] ReadGameEngineCtfEventBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GameEngineCtfEventBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GameEngineCtfEventBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GameEngineCtfEventBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GameEngineOddballEventBlock[] ReadGameEngineOddballEventBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GameEngineOddballEventBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GameEngineOddballEventBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GameEngineOddballEventBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GNullBlock[] ReadGNullBlockArray(BinaryReader binaryReader)
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
        internal  virtual GameEngineKingEventBlock[] ReadGameEngineKingEventBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GameEngineKingEventBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GameEngineKingEventBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GameEngineKingEventBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GameEngineJuggernautEventBlock[] ReadGameEngineJuggernautEventBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GameEngineJuggernautEventBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GameEngineJuggernautEventBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GameEngineJuggernautEventBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GameEngineTerritoriesEventBlock[] ReadGameEngineTerritoriesEventBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GameEngineTerritoriesEventBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GameEngineTerritoriesEventBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GameEngineTerritoriesEventBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GameEngineAssaultEventBlock[] ReadGameEngineAssaultEventBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GameEngineAssaultEventBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GameEngineAssaultEventBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GameEngineAssaultEventBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual MultiplayerConstantsBlock[] ReadMultiplayerConstantsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(MultiplayerConstantsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new MultiplayerConstantsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new MultiplayerConstantsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GameEngineStatusResponseBlock[] ReadGameEngineStatusResponseBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GameEngineStatusResponseBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GameEngineStatusResponseBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GameEngineStatusResponseBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
