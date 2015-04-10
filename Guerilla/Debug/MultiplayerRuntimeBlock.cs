// ReSharper disable All
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
        public  MultiplayerRuntimeBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  MultiplayerRuntimeBlockBase(System.IO.BinaryReader binaryReader)
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
            ReadWeaponsBlockArray(binaryReader);
            ReadVehiclesBlockArray(binaryReader);
            arr = new GrenadeAndPowerupStructBlock(binaryReader);
            inGameText = binaryReader.ReadTagReference();
            ReadSoundsBlockArray(binaryReader);
            ReadGameEngineGeneralEventBlockArray(binaryReader);
            ReadGameEngineFlavorEventBlockArray(binaryReader);
            ReadGameEngineSlayerEventBlockArray(binaryReader);
            ReadGameEngineCtfEventBlockArray(binaryReader);
            ReadGameEngineOddballEventBlockArray(binaryReader);
            ReadGNullBlockArray(binaryReader);
            ReadGameEngineKingEventBlockArray(binaryReader);
            ReadGNullBlockArray(binaryReader);
            ReadGameEngineJuggernautEventBlockArray(binaryReader);
            ReadGameEngineTerritoriesEventBlockArray(binaryReader);
            ReadGameEngineAssaultEventBlockArray(binaryReader);
            ReadGNullBlockArray(binaryReader);
            ReadGNullBlockArray(binaryReader);
            ReadGNullBlockArray(binaryReader);
            ReadGNullBlockArray(binaryReader);
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
            ReadMultiplayerConstantsBlockArray(binaryReader);
            ReadGameEngineStatusResponseBlockArray(binaryReader);
            scoreboardHudDefinition = binaryReader.ReadTagReference();
            scoreboardEmblemShader = binaryReader.ReadTagReference();
            scoreboardEmblemBitmap = binaryReader.ReadTagReference();
            scoreboardDeadEmblemShader = binaryReader.ReadTagReference();
            scoreboardDeadEmblemBitmap = binaryReader.ReadTagReference();
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
        internal  virtual WeaponsBlock[] ReadWeaponsBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual VehiclesBlock[] ReadVehiclesBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual SoundsBlock[] ReadSoundsBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual GameEngineGeneralEventBlock[] ReadGameEngineGeneralEventBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual GameEngineFlavorEventBlock[] ReadGameEngineFlavorEventBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual GameEngineSlayerEventBlock[] ReadGameEngineSlayerEventBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual GameEngineCtfEventBlock[] ReadGameEngineCtfEventBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual GameEngineOddballEventBlock[] ReadGameEngineOddballEventBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual GameEngineKingEventBlock[] ReadGameEngineKingEventBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual GameEngineJuggernautEventBlock[] ReadGameEngineJuggernautEventBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual GameEngineTerritoriesEventBlock[] ReadGameEngineTerritoriesEventBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual GameEngineAssaultEventBlock[] ReadGameEngineAssaultEventBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual MultiplayerConstantsBlock[] ReadMultiplayerConstantsBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual GameEngineStatusResponseBlock[] ReadGameEngineStatusResponseBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteWeaponsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteVehiclesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteSoundsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGameEngineGeneralEventBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGameEngineFlavorEventBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGameEngineSlayerEventBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGameEngineCtfEventBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGameEngineOddballEventBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGNullBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGameEngineKingEventBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGameEngineJuggernautEventBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGameEngineTerritoriesEventBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGameEngineAssaultEventBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteMultiplayerConstantsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGameEngineStatusResponseBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
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
                WriteWeaponsBlockArray(binaryWriter);
                WriteVehiclesBlockArray(binaryWriter);
                arr.Write(binaryWriter);
                binaryWriter.Write(inGameText);
                WriteSoundsBlockArray(binaryWriter);
                WriteGameEngineGeneralEventBlockArray(binaryWriter);
                WriteGameEngineFlavorEventBlockArray(binaryWriter);
                WriteGameEngineSlayerEventBlockArray(binaryWriter);
                WriteGameEngineCtfEventBlockArray(binaryWriter);
                WriteGameEngineOddballEventBlockArray(binaryWriter);
                WriteGNullBlockArray(binaryWriter);
                WriteGameEngineKingEventBlockArray(binaryWriter);
                WriteGNullBlockArray(binaryWriter);
                WriteGameEngineJuggernautEventBlockArray(binaryWriter);
                WriteGameEngineTerritoriesEventBlockArray(binaryWriter);
                WriteGameEngineAssaultEventBlockArray(binaryWriter);
                WriteGNullBlockArray(binaryWriter);
                WriteGNullBlockArray(binaryWriter);
                WriteGNullBlockArray(binaryWriter);
                WriteGNullBlockArray(binaryWriter);
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
                WriteMultiplayerConstantsBlockArray(binaryWriter);
                WriteGameEngineStatusResponseBlockArray(binaryWriter);
                binaryWriter.Write(scoreboardHudDefinition);
                binaryWriter.Write(scoreboardEmblemShader);
                binaryWriter.Write(scoreboardEmblemBitmap);
                binaryWriter.Write(scoreboardDeadEmblemShader);
                binaryWriter.Write(scoreboardDeadEmblemBitmap);
            }
        }
    };
}
