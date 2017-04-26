//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Moonfish.Guerilla.Tags
{
    using JetBrains.Annotations;
    using Moonfish.Tags;
    using Moonfish.Model;
    using Moonfish.Guerilla;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    
    [JetBrains.Annotations.UsedImplicitlyAttribute(ImplicitUseTargetFlags.WithMembers)]
    [TagBlockOriginalNameAttribute("multiplayer_runtime_block")]
    public partial class MultiplayerRuntimeBlock : GuerillaBlock, IWriteDeferrable
    {
        [Moonfish.Tags.TagReferenceAttribute("item")]
        public Moonfish.Tags.TagReference Flag;
        [Moonfish.Tags.TagReferenceAttribute("item")]
        public Moonfish.Tags.TagReference Ball;
        [Moonfish.Tags.TagReferenceAttribute("unit")]
        public Moonfish.Tags.TagReference Unit;
        [Moonfish.Tags.TagReferenceAttribute("shad")]
        public Moonfish.Tags.TagReference FlagShader;
        [Moonfish.Tags.TagReferenceAttribute("shad")]
        public Moonfish.Tags.TagReference HillShader;
        [Moonfish.Tags.TagReferenceAttribute("item")]
        public Moonfish.Tags.TagReference Head;
        [Moonfish.Tags.TagReferenceAttribute("item")]
        public Moonfish.Tags.TagReference JuggernautPowerup;
        [Moonfish.Tags.TagReferenceAttribute("item")]
        public Moonfish.Tags.TagReference DaBomb;
        [Moonfish.Tags.TagReferenceAttribute("null")]
        public Moonfish.Tags.TagReference TagReference;
        [Moonfish.Tags.TagReferenceAttribute("null")]
        public Moonfish.Tags.TagReference TagReference0;
        [Moonfish.Tags.TagReferenceAttribute("null")]
        public Moonfish.Tags.TagReference TagReference1;
        [Moonfish.Tags.TagReferenceAttribute("null")]
        public Moonfish.Tags.TagReference TagReference2;
        [Moonfish.Tags.TagReferenceAttribute("null")]
        public Moonfish.Tags.TagReference TagReference3;
        public WeaponsBlock[] Weapons = new WeaponsBlock[0];
        public VehiclesBlock[] Vehicles = new VehiclesBlock[0];
        public GrenadeAndPowerupStructBlock Arr = new GrenadeAndPowerupStructBlock();
        [Moonfish.Tags.TagReferenceAttribute("unic")]
        public Moonfish.Tags.TagReference InGameText;
        public SoundsBlock[] Sounds = new SoundsBlock[0];
        public GameEngineGeneralEventBlock[] GeneralEvents = new GameEngineGeneralEventBlock[0];
        public GameEngineFlavorEventBlock[] FlavorEvents = new GameEngineFlavorEventBlock[0];
        public GameEngineSlayerEventBlock[] SlayerEvents = new GameEngineSlayerEventBlock[0];
        public GameEngineCtfEventBlock[] CtfEvents = new GameEngineCtfEventBlock[0];
        public GameEngineOddballEventBlock[] OddballEvents = new GameEngineOddballEventBlock[0];
        public GNullBlock[] GNullBlock = new GNullBlock[0];
        public GameEngineKingEventBlock[] KingEvents = new GameEngineKingEventBlock[0];
        public GNullBlock[] GNullBlock0 = new GNullBlock[0];
        public GameEngineJuggernautEventBlock[] JuggernautEvents = new GameEngineJuggernautEventBlock[0];
        public GameEngineTerritoriesEventBlock[] TerritoriesEvents = new GameEngineTerritoriesEventBlock[0];
        public GameEngineAssaultEventBlock[] InvasionEvents = new GameEngineAssaultEventBlock[0];
        public GNullBlock[] GNullBlock1 = new GNullBlock[0];
        public GNullBlock[] GNullBlock2 = new GNullBlock[0];
        public GNullBlock[] GNullBlock3 = new GNullBlock[0];
        public GNullBlock[] GNullBlock4 = new GNullBlock[0];
        [Moonfish.Tags.TagReferenceAttribute("itmc")]
        public Moonfish.Tags.TagReference DefaultItemCollection1;
        [Moonfish.Tags.TagReferenceAttribute("itmc")]
        public Moonfish.Tags.TagReference DefaultItemCollection2;
        public int DefaultFragGrenadeCount;
        public int DefaultPlasmaGrenadeCount;
        private byte[] fieldpad = new byte[40];
        public float DynamicZoneUpperHeight;
        public float DynamicZoneLowerHeight;
        private byte[] fieldpad0 = new byte[40];
        public float EnemyInnerRadius;
        public float EnemyOuterRadius;
        public float EnemyWeight;
        private byte[] fieldpad1 = new byte[16];
        public float FriendInnerRadius;
        public float FriendOuterRadius;
        public float FriendWeight;
        private byte[] fieldpad2 = new byte[16];
        public float EnemyVehicleInnerRadius;
        public float EnemyVehicleOuterRadius;
        public float EnemyVehicleWeight;
        private byte[] fieldpad3 = new byte[16];
        public float FriendlyVehicleInnerRadius;
        public float FriendlyVehicleOuterRadius;
        public float FriendlyVehicleWeight;
        private byte[] fieldpad4 = new byte[16];
        public float EmptyVehicleInnerRadius;
        public float EmptyVehicleOuterRadius;
        public float EmptyVehicleWeight;
        private byte[] fieldpad5 = new byte[16];
        public float OddballInclusionInnerRadius;
        public float OddballInclusionOuterRadius;
        public float OddballInclusionWeight;
        private byte[] fieldpad6 = new byte[16];
        public float OddballExclusionInnerRadius;
        public float OddballExclusionOuterRadius;
        public float OddballExclusionWeight;
        private byte[] fieldpad7 = new byte[16];
        public float HillInclusionInnerRadius;
        public float HillInclusionOuterRadius;
        public float HillInclusionWeight;
        private byte[] fieldpad8 = new byte[16];
        public float HillExclusionInnerRadius;
        public float HillExclusionOuterRadius;
        public float HillExclusionWeight;
        private byte[] fieldpad9 = new byte[16];
        public float LastRaceFlagInnerRadius;
        public float LastRaceFlagOuterRadius;
        public float LastRaceFlagWeight;
        private byte[] fieldpad10 = new byte[16];
        public float DeadAllyInnerRadius;
        public float DeadAllyOuterRadius;
        public float DeadAllyWeight;
        private byte[] fieldpad11 = new byte[16];
        public float ControlledTerritoryInnerRadius;
        public float ControlledTerritoryOuterRadius;
        public float ControlledTerritoryWeight;
        private byte[] fieldpad12 = new byte[16];
        private byte[] fieldpad13 = new byte[560];
        private byte[] fieldpad14 = new byte[48];
        public MultiplayerConstantsBlock[] MultiplayerConstants = new MultiplayerConstantsBlock[0];
        public GameEngineStatusResponseBlock[] StateResponses = new GameEngineStatusResponseBlock[0];
        [Moonfish.Tags.TagReferenceAttribute("nhdt")]
        public Moonfish.Tags.TagReference ScoreboardHudDefinition;
        [Moonfish.Tags.TagReferenceAttribute("shad")]
        public Moonfish.Tags.TagReference ScoreboardEmblemShader;
        [Moonfish.Tags.TagReferenceAttribute("bitm")]
        public Moonfish.Tags.TagReference ScoreboardEmblemBitmap;
        [Moonfish.Tags.TagReferenceAttribute("shad")]
        public Moonfish.Tags.TagReference ScoreboardDeadEmblemShader;
        [Moonfish.Tags.TagReferenceAttribute("bitm")]
        public Moonfish.Tags.TagReference ScoreboardDeadEmblemBitmap;
        public override int SerializedSize
        {
            get
            {
                return 1384;
            }
        }
        public override int Alignment
        {
            get
            {
                return 4;
            }
        }
        public override System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> ReadFields(Moonfish.Guerilla.BlamBinaryReader binaryReader)
        {
            System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(base.ReadFields(binaryReader));
            this.Flag = binaryReader.ReadTagReference();
            this.Ball = binaryReader.ReadTagReference();
            this.Unit = binaryReader.ReadTagReference();
            this.FlagShader = binaryReader.ReadTagReference();
            this.HillShader = binaryReader.ReadTagReference();
            this.Head = binaryReader.ReadTagReference();
            this.JuggernautPowerup = binaryReader.ReadTagReference();
            this.DaBomb = binaryReader.ReadTagReference();
            this.TagReference = binaryReader.ReadTagReference();
            this.TagReference0 = binaryReader.ReadTagReference();
            this.TagReference1 = binaryReader.ReadTagReference();
            this.TagReference2 = binaryReader.ReadTagReference();
            this.TagReference3 = binaryReader.ReadTagReference();
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(8));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(8));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.Arr.ReadFields(binaryReader)));
            this.InGameText = binaryReader.ReadTagReference();
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(8));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(168));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(168));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(168));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(168));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(168));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(0));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(168));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(0));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(168));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(168));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(168));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(0));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(0));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(0));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(0));
            this.DefaultItemCollection1 = binaryReader.ReadTagReference();
            this.DefaultItemCollection2 = binaryReader.ReadTagReference();
            this.DefaultFragGrenadeCount = binaryReader.ReadInt32();
            this.DefaultPlasmaGrenadeCount = binaryReader.ReadInt32();
            this.fieldpad = binaryReader.ReadBytes(40);
            this.DynamicZoneUpperHeight = binaryReader.ReadSingle();
            this.DynamicZoneLowerHeight = binaryReader.ReadSingle();
            this.fieldpad0 = binaryReader.ReadBytes(40);
            this.EnemyInnerRadius = binaryReader.ReadSingle();
            this.EnemyOuterRadius = binaryReader.ReadSingle();
            this.EnemyWeight = binaryReader.ReadSingle();
            this.fieldpad1 = binaryReader.ReadBytes(16);
            this.FriendInnerRadius = binaryReader.ReadSingle();
            this.FriendOuterRadius = binaryReader.ReadSingle();
            this.FriendWeight = binaryReader.ReadSingle();
            this.fieldpad2 = binaryReader.ReadBytes(16);
            this.EnemyVehicleInnerRadius = binaryReader.ReadSingle();
            this.EnemyVehicleOuterRadius = binaryReader.ReadSingle();
            this.EnemyVehicleWeight = binaryReader.ReadSingle();
            this.fieldpad3 = binaryReader.ReadBytes(16);
            this.FriendlyVehicleInnerRadius = binaryReader.ReadSingle();
            this.FriendlyVehicleOuterRadius = binaryReader.ReadSingle();
            this.FriendlyVehicleWeight = binaryReader.ReadSingle();
            this.fieldpad4 = binaryReader.ReadBytes(16);
            this.EmptyVehicleInnerRadius = binaryReader.ReadSingle();
            this.EmptyVehicleOuterRadius = binaryReader.ReadSingle();
            this.EmptyVehicleWeight = binaryReader.ReadSingle();
            this.fieldpad5 = binaryReader.ReadBytes(16);
            this.OddballInclusionInnerRadius = binaryReader.ReadSingle();
            this.OddballInclusionOuterRadius = binaryReader.ReadSingle();
            this.OddballInclusionWeight = binaryReader.ReadSingle();
            this.fieldpad6 = binaryReader.ReadBytes(16);
            this.OddballExclusionInnerRadius = binaryReader.ReadSingle();
            this.OddballExclusionOuterRadius = binaryReader.ReadSingle();
            this.OddballExclusionWeight = binaryReader.ReadSingle();
            this.fieldpad7 = binaryReader.ReadBytes(16);
            this.HillInclusionInnerRadius = binaryReader.ReadSingle();
            this.HillInclusionOuterRadius = binaryReader.ReadSingle();
            this.HillInclusionWeight = binaryReader.ReadSingle();
            this.fieldpad8 = binaryReader.ReadBytes(16);
            this.HillExclusionInnerRadius = binaryReader.ReadSingle();
            this.HillExclusionOuterRadius = binaryReader.ReadSingle();
            this.HillExclusionWeight = binaryReader.ReadSingle();
            this.fieldpad9 = binaryReader.ReadBytes(16);
            this.LastRaceFlagInnerRadius = binaryReader.ReadSingle();
            this.LastRaceFlagOuterRadius = binaryReader.ReadSingle();
            this.LastRaceFlagWeight = binaryReader.ReadSingle();
            this.fieldpad10 = binaryReader.ReadBytes(16);
            this.DeadAllyInnerRadius = binaryReader.ReadSingle();
            this.DeadAllyOuterRadius = binaryReader.ReadSingle();
            this.DeadAllyWeight = binaryReader.ReadSingle();
            this.fieldpad11 = binaryReader.ReadBytes(16);
            this.ControlledTerritoryInnerRadius = binaryReader.ReadSingle();
            this.ControlledTerritoryOuterRadius = binaryReader.ReadSingle();
            this.ControlledTerritoryWeight = binaryReader.ReadSingle();
            this.fieldpad12 = binaryReader.ReadBytes(16);
            this.fieldpad13 = binaryReader.ReadBytes(560);
            this.fieldpad14 = binaryReader.ReadBytes(48);
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(352));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(28));
            this.ScoreboardHudDefinition = binaryReader.ReadTagReference();
            this.ScoreboardEmblemShader = binaryReader.ReadTagReference();
            this.ScoreboardEmblemBitmap = binaryReader.ReadTagReference();
            this.ScoreboardDeadEmblemShader = binaryReader.ReadTagReference();
            this.ScoreboardDeadEmblemBitmap = binaryReader.ReadTagReference();
            return pointerQueue;
        }
        public override void ReadInstances(Moonfish.Guerilla.BlamBinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.Weapons = base.ReadBlockArrayData<WeaponsBlock>(binaryReader, pointerQueue.Dequeue());
            this.Vehicles = base.ReadBlockArrayData<VehiclesBlock>(binaryReader, pointerQueue.Dequeue());
            this.Arr.ReadInstances(binaryReader, pointerQueue);
            this.Sounds = base.ReadBlockArrayData<SoundsBlock>(binaryReader, pointerQueue.Dequeue());
            this.GeneralEvents = base.ReadBlockArrayData<GameEngineGeneralEventBlock>(binaryReader, pointerQueue.Dequeue());
            this.FlavorEvents = base.ReadBlockArrayData<GameEngineFlavorEventBlock>(binaryReader, pointerQueue.Dequeue());
            this.SlayerEvents = base.ReadBlockArrayData<GameEngineSlayerEventBlock>(binaryReader, pointerQueue.Dequeue());
            this.CtfEvents = base.ReadBlockArrayData<GameEngineCtfEventBlock>(binaryReader, pointerQueue.Dequeue());
            this.OddballEvents = base.ReadBlockArrayData<GameEngineOddballEventBlock>(binaryReader, pointerQueue.Dequeue());
            this.GNullBlock = base.ReadBlockArrayData<GNullBlock>(binaryReader, pointerQueue.Dequeue());
            this.KingEvents = base.ReadBlockArrayData<GameEngineKingEventBlock>(binaryReader, pointerQueue.Dequeue());
            this.GNullBlock0 = base.ReadBlockArrayData<GNullBlock>(binaryReader, pointerQueue.Dequeue());
            this.JuggernautEvents = base.ReadBlockArrayData<GameEngineJuggernautEventBlock>(binaryReader, pointerQueue.Dequeue());
            this.TerritoriesEvents = base.ReadBlockArrayData<GameEngineTerritoriesEventBlock>(binaryReader, pointerQueue.Dequeue());
            this.InvasionEvents = base.ReadBlockArrayData<GameEngineAssaultEventBlock>(binaryReader, pointerQueue.Dequeue());
            this.GNullBlock1 = base.ReadBlockArrayData<GNullBlock>(binaryReader, pointerQueue.Dequeue());
            this.GNullBlock2 = base.ReadBlockArrayData<GNullBlock>(binaryReader, pointerQueue.Dequeue());
            this.GNullBlock3 = base.ReadBlockArrayData<GNullBlock>(binaryReader, pointerQueue.Dequeue());
            this.GNullBlock4 = base.ReadBlockArrayData<GNullBlock>(binaryReader, pointerQueue.Dequeue());
            this.MultiplayerConstants = base.ReadBlockArrayData<MultiplayerConstantsBlock>(binaryReader, pointerQueue.Dequeue());
            this.StateResponses = base.ReadBlockArrayData<GameEngineStatusResponseBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void DeferReferences(Moonfish.Guerilla.LinearBinaryWriter writer)
        {
            base.DeferReferences(writer);
            writer.Defer(this.Weapons);
            writer.Defer(this.Vehicles);
            this.Arr.DeferReferences(writer);
            writer.Defer(this.Sounds);
            writer.Defer(this.GeneralEvents);
            writer.Defer(this.FlavorEvents);
            writer.Defer(this.SlayerEvents);
            writer.Defer(this.CtfEvents);
            writer.Defer(this.OddballEvents);
            writer.Defer(this.GNullBlock);
            writer.Defer(this.KingEvents);
            writer.Defer(this.GNullBlock0);
            writer.Defer(this.JuggernautEvents);
            writer.Defer(this.TerritoriesEvents);
            writer.Defer(this.InvasionEvents);
            writer.Defer(this.GNullBlock1);
            writer.Defer(this.GNullBlock2);
            writer.Defer(this.GNullBlock3);
            writer.Defer(this.GNullBlock4);
            writer.Defer(this.MultiplayerConstants);
            writer.Defer(this.StateResponses);
        }
        public override void Write(Moonfish.Guerilla.LinearBinaryWriter writer)
        {
            base.Write(writer);
            writer.Write(this.Flag);
            writer.Write(this.Ball);
            writer.Write(this.Unit);
            writer.Write(this.FlagShader);
            writer.Write(this.HillShader);
            writer.Write(this.Head);
            writer.Write(this.JuggernautPowerup);
            writer.Write(this.DaBomb);
            writer.Write(this.TagReference);
            writer.Write(this.TagReference0);
            writer.Write(this.TagReference1);
            writer.Write(this.TagReference2);
            writer.Write(this.TagReference3);
            writer.WritePointer(this.Weapons);
            writer.WritePointer(this.Vehicles);
            this.Arr.Write(writer);
            writer.Write(this.InGameText);
            writer.WritePointer(this.Sounds);
            writer.WritePointer(this.GeneralEvents);
            writer.WritePointer(this.FlavorEvents);
            writer.WritePointer(this.SlayerEvents);
            writer.WritePointer(this.CtfEvents);
            writer.WritePointer(this.OddballEvents);
            writer.WritePointer(this.GNullBlock);
            writer.WritePointer(this.KingEvents);
            writer.WritePointer(this.GNullBlock0);
            writer.WritePointer(this.JuggernautEvents);
            writer.WritePointer(this.TerritoriesEvents);
            writer.WritePointer(this.InvasionEvents);
            writer.WritePointer(this.GNullBlock1);
            writer.WritePointer(this.GNullBlock2);
            writer.WritePointer(this.GNullBlock3);
            writer.WritePointer(this.GNullBlock4);
            writer.Write(this.DefaultItemCollection1);
            writer.Write(this.DefaultItemCollection2);
            writer.Write(this.DefaultFragGrenadeCount);
            writer.Write(this.DefaultPlasmaGrenadeCount);
            writer.Write(this.fieldpad);
            writer.Write(this.DynamicZoneUpperHeight);
            writer.Write(this.DynamicZoneLowerHeight);
            writer.Write(this.fieldpad0);
            writer.Write(this.EnemyInnerRadius);
            writer.Write(this.EnemyOuterRadius);
            writer.Write(this.EnemyWeight);
            writer.Write(this.fieldpad1);
            writer.Write(this.FriendInnerRadius);
            writer.Write(this.FriendOuterRadius);
            writer.Write(this.FriendWeight);
            writer.Write(this.fieldpad2);
            writer.Write(this.EnemyVehicleInnerRadius);
            writer.Write(this.EnemyVehicleOuterRadius);
            writer.Write(this.EnemyVehicleWeight);
            writer.Write(this.fieldpad3);
            writer.Write(this.FriendlyVehicleInnerRadius);
            writer.Write(this.FriendlyVehicleOuterRadius);
            writer.Write(this.FriendlyVehicleWeight);
            writer.Write(this.fieldpad4);
            writer.Write(this.EmptyVehicleInnerRadius);
            writer.Write(this.EmptyVehicleOuterRadius);
            writer.Write(this.EmptyVehicleWeight);
            writer.Write(this.fieldpad5);
            writer.Write(this.OddballInclusionInnerRadius);
            writer.Write(this.OddballInclusionOuterRadius);
            writer.Write(this.OddballInclusionWeight);
            writer.Write(this.fieldpad6);
            writer.Write(this.OddballExclusionInnerRadius);
            writer.Write(this.OddballExclusionOuterRadius);
            writer.Write(this.OddballExclusionWeight);
            writer.Write(this.fieldpad7);
            writer.Write(this.HillInclusionInnerRadius);
            writer.Write(this.HillInclusionOuterRadius);
            writer.Write(this.HillInclusionWeight);
            writer.Write(this.fieldpad8);
            writer.Write(this.HillExclusionInnerRadius);
            writer.Write(this.HillExclusionOuterRadius);
            writer.Write(this.HillExclusionWeight);
            writer.Write(this.fieldpad9);
            writer.Write(this.LastRaceFlagInnerRadius);
            writer.Write(this.LastRaceFlagOuterRadius);
            writer.Write(this.LastRaceFlagWeight);
            writer.Write(this.fieldpad10);
            writer.Write(this.DeadAllyInnerRadius);
            writer.Write(this.DeadAllyOuterRadius);
            writer.Write(this.DeadAllyWeight);
            writer.Write(this.fieldpad11);
            writer.Write(this.ControlledTerritoryInnerRadius);
            writer.Write(this.ControlledTerritoryOuterRadius);
            writer.Write(this.ControlledTerritoryWeight);
            writer.Write(this.fieldpad12);
            writer.Write(this.fieldpad13);
            writer.Write(this.fieldpad14);
            writer.WritePointer(this.MultiplayerConstants);
            writer.WritePointer(this.StateResponses);
            writer.Write(this.ScoreboardHudDefinition);
            writer.Write(this.ScoreboardEmblemShader);
            writer.Write(this.ScoreboardEmblemBitmap);
            writer.Write(this.ScoreboardDeadEmblemShader);
            writer.Write(this.ScoreboardDeadEmblemBitmap);
        }
    }
}
