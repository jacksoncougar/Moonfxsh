//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Moonfish.Guerilla.Tags
{
    using Moonfish.Tags;
    using Moonfish.Model;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    
    [TagClassAttribute("matg")]
    public partial class GlobalsBlock : GuerillaBlock, IWriteQueueable
    {
        private byte[] fieldpad = new byte[172];
        public LanguageEnum Language;
        public HavokCleanupResourcesBlock[] HavokCleanupResources = new HavokCleanupResourcesBlock[0];
        public CollisionDamageBlock[] CollisionDamage = new CollisionDamageBlock[0];
        public SoundGlobalsBlock[] SoundGlobals = new SoundGlobalsBlock[0];
        public AiGlobalsBlock[] AiGlobals = new AiGlobalsBlock[0];
        public GameGlobalsDamageBlock[] DamageTable = new GameGlobalsDamageBlock[0];
        public GNullBlock[] GNullBlock = new GNullBlock[0];
        public MoonfishSoundReferencesBlock[] Sounds = new MoonfishSoundReferencesBlock[0];
        public CameraBlock[] Camera = new CameraBlock[0];
        public PlayerControlBlock[] PlayerControl = new PlayerControlBlock[0];
        public DifficultyBlock[] Difficulty = new DifficultyBlock[0];
        public GrenadesBlock[] Grenades = new GrenadesBlock[0];
        public RasterizerDataBlock[] RasterizerData = new RasterizerDataBlock[0];
        public InterfaceTagReferences[] InterfaceTags = new InterfaceTagReferences[0];
        public CheatWeaponsBlock[] weaponList = new CheatWeaponsBlock[0];
        public CheatPowerupsBlock[] cheatPowerups = new CheatPowerupsBlock[0];
        public MultiplayerInformationBlock[] multiplayerInformation = new MultiplayerInformationBlock[0];
        public PlayerInformationBlock[] playerInformation = new PlayerInformationBlock[0];
        public PlayerRepresentationBlock[] playerRepresentation = new PlayerRepresentationBlock[0];
        public FallingDamageBlock[] FallingDamage = new FallingDamageBlock[0];
        public OldMaterialsBlock[] OldMaterials = new OldMaterialsBlock[0];
        public MaterialsBlock[] Materials = new MaterialsBlock[0];
        public MultiplayerUiBlock[] MultiplayerUI = new MultiplayerUiBlock[0];
        public MultiplayerColorBlock[] ProfileColors = new MultiplayerColorBlock[0];
        [Moonfish.Tags.TagReferenceAttribute("mulg")]
        public Moonfish.Tags.TagReference MultiplayerGlobals;
        public RuntimeLevelsDefinitionBlock[] RuntimeLevelData = new RuntimeLevelsDefinitionBlock[0];
        public UiLevelsDefinitionBlock[] UiLevelData = new UiLevelsDefinitionBlock[0];
        [Moonfish.Tags.TagReferenceAttribute("gldf")]
        public Moonfish.Tags.TagReference DefaultGlobalLighting;
        private byte[] fieldpad0 = new byte[252];
        public override int SerializedSize
        {
            get
            {
                return 644;
            }
        }
        public override int Alignment
        {
            get
            {
                return 4;
            }
        }
        public override System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> ReadFields(System.IO.BinaryReader binaryReader)
        {
            System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(base.ReadFields(binaryReader));
            this.fieldpad = binaryReader.ReadBytes(172);
            this.Language = ((LanguageEnum)(binaryReader.ReadInt32()));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(8));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(72));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(36));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(360));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(8));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(0));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(8));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(20));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(128));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(644));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(44));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(264));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(152));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(8));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(8));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(152));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(284));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(188));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(104));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(36));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(180));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(32));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(12));
            this.MultiplayerGlobals = binaryReader.ReadTagReference();
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(8));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(24));
            this.DefaultGlobalLighting = binaryReader.ReadTagReference();
            this.fieldpad0 = binaryReader.ReadBytes(252);
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.HavokCleanupResources = base.ReadBlockArrayData<HavokCleanupResourcesBlock>(binaryReader, pointerQueue.Dequeue());
            this.CollisionDamage = base.ReadBlockArrayData<CollisionDamageBlock>(binaryReader, pointerQueue.Dequeue());
            this.SoundGlobals = base.ReadBlockArrayData<SoundGlobalsBlock>(binaryReader, pointerQueue.Dequeue());
            this.AiGlobals = base.ReadBlockArrayData<AiGlobalsBlock>(binaryReader, pointerQueue.Dequeue());
            this.DamageTable = base.ReadBlockArrayData<GameGlobalsDamageBlock>(binaryReader, pointerQueue.Dequeue());
            this.GNullBlock = base.ReadBlockArrayData<GNullBlock>(binaryReader, pointerQueue.Dequeue());
            this.Sounds = base.ReadBlockArrayData<MoonfishSoundReferencesBlock>(binaryReader, pointerQueue.Dequeue());
            this.Camera = base.ReadBlockArrayData<CameraBlock>(binaryReader, pointerQueue.Dequeue());
            this.PlayerControl = base.ReadBlockArrayData<PlayerControlBlock>(binaryReader, pointerQueue.Dequeue());
            this.Difficulty = base.ReadBlockArrayData<DifficultyBlock>(binaryReader, pointerQueue.Dequeue());
            this.Grenades = base.ReadBlockArrayData<GrenadesBlock>(binaryReader, pointerQueue.Dequeue());
            this.RasterizerData = base.ReadBlockArrayData<RasterizerDataBlock>(binaryReader, pointerQueue.Dequeue());
            this.InterfaceTags = base.ReadBlockArrayData<InterfaceTagReferences>(binaryReader, pointerQueue.Dequeue());
            this.weaponList = base.ReadBlockArrayData<CheatWeaponsBlock>(binaryReader, pointerQueue.Dequeue());
            this.cheatPowerups = base.ReadBlockArrayData<CheatPowerupsBlock>(binaryReader, pointerQueue.Dequeue());
            this.multiplayerInformation = base.ReadBlockArrayData<MultiplayerInformationBlock>(binaryReader, pointerQueue.Dequeue());
            this.playerInformation = base.ReadBlockArrayData<PlayerInformationBlock>(binaryReader, pointerQueue.Dequeue());
            this.playerRepresentation = base.ReadBlockArrayData<PlayerRepresentationBlock>(binaryReader, pointerQueue.Dequeue());
            this.FallingDamage = base.ReadBlockArrayData<FallingDamageBlock>(binaryReader, pointerQueue.Dequeue());
            this.OldMaterials = base.ReadBlockArrayData<OldMaterialsBlock>(binaryReader, pointerQueue.Dequeue());
            this.Materials = base.ReadBlockArrayData<MaterialsBlock>(binaryReader, pointerQueue.Dequeue());
            this.MultiplayerUI = base.ReadBlockArrayData<MultiplayerUiBlock>(binaryReader, pointerQueue.Dequeue());
            this.ProfileColors = base.ReadBlockArrayData<MultiplayerColorBlock>(binaryReader, pointerQueue.Dequeue());
            this.RuntimeLevelData = base.ReadBlockArrayData<RuntimeLevelsDefinitionBlock>(binaryReader, pointerQueue.Dequeue());
            this.UiLevelData = base.ReadBlockArrayData<UiLevelsDefinitionBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            queueableBinaryWriter.QueueWrite(this.HavokCleanupResources);
            queueableBinaryWriter.QueueWrite(this.CollisionDamage);
            queueableBinaryWriter.QueueWrite(this.SoundGlobals);
            queueableBinaryWriter.QueueWrite(this.AiGlobals);
            queueableBinaryWriter.QueueWrite(this.DamageTable);
            queueableBinaryWriter.QueueWrite(this.GNullBlock);
            queueableBinaryWriter.QueueWrite(this.Sounds);
            queueableBinaryWriter.QueueWrite(this.Camera);
            queueableBinaryWriter.QueueWrite(this.PlayerControl);
            queueableBinaryWriter.QueueWrite(this.Difficulty);
            queueableBinaryWriter.QueueWrite(this.Grenades);
            queueableBinaryWriter.QueueWrite(this.RasterizerData);
            queueableBinaryWriter.QueueWrite(this.InterfaceTags);
            queueableBinaryWriter.QueueWrite(this.weaponList);
            queueableBinaryWriter.QueueWrite(this.cheatPowerups);
            queueableBinaryWriter.QueueWrite(this.multiplayerInformation);
            queueableBinaryWriter.QueueWrite(this.playerInformation);
            queueableBinaryWriter.QueueWrite(this.playerRepresentation);
            queueableBinaryWriter.QueueWrite(this.FallingDamage);
            queueableBinaryWriter.QueueWrite(this.OldMaterials);
            queueableBinaryWriter.QueueWrite(this.Materials);
            queueableBinaryWriter.QueueWrite(this.MultiplayerUI);
            queueableBinaryWriter.QueueWrite(this.ProfileColors);
            queueableBinaryWriter.QueueWrite(this.RuntimeLevelData);
            queueableBinaryWriter.QueueWrite(this.UiLevelData);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.Write_(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.Write(((int)(this.Language)));
            queueableBinaryWriter.WritePointer(this.HavokCleanupResources);
            queueableBinaryWriter.WritePointer(this.CollisionDamage);
            queueableBinaryWriter.WritePointer(this.SoundGlobals);
            queueableBinaryWriter.WritePointer(this.AiGlobals);
            queueableBinaryWriter.WritePointer(this.DamageTable);
            queueableBinaryWriter.WritePointer(this.GNullBlock);
            queueableBinaryWriter.WritePointer(this.Sounds);
            queueableBinaryWriter.WritePointer(this.Camera);
            queueableBinaryWriter.WritePointer(this.PlayerControl);
            queueableBinaryWriter.WritePointer(this.Difficulty);
            queueableBinaryWriter.WritePointer(this.Grenades);
            queueableBinaryWriter.WritePointer(this.RasterizerData);
            queueableBinaryWriter.WritePointer(this.InterfaceTags);
            queueableBinaryWriter.WritePointer(this.weaponList);
            queueableBinaryWriter.WritePointer(this.cheatPowerups);
            queueableBinaryWriter.WritePointer(this.multiplayerInformation);
            queueableBinaryWriter.WritePointer(this.playerInformation);
            queueableBinaryWriter.WritePointer(this.playerRepresentation);
            queueableBinaryWriter.WritePointer(this.FallingDamage);
            queueableBinaryWriter.WritePointer(this.OldMaterials);
            queueableBinaryWriter.WritePointer(this.Materials);
            queueableBinaryWriter.WritePointer(this.MultiplayerUI);
            queueableBinaryWriter.WritePointer(this.ProfileColors);
            queueableBinaryWriter.Write(this.MultiplayerGlobals);
            queueableBinaryWriter.WritePointer(this.RuntimeLevelData);
            queueableBinaryWriter.WritePointer(this.UiLevelData);
            queueableBinaryWriter.Write(this.DefaultGlobalLighting);
            queueableBinaryWriter.Write(this.fieldpad0);
        }
        public enum LanguageEnum : int
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
        }
    }
}
namespace Moonfish.Tags
{
    
    public partial struct TagClass
    {
        public static TagClass Matg = ((TagClass)("matg"));
    }
}
