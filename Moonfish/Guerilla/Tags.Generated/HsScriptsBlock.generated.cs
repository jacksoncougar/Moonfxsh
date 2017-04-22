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
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    
    [JetBrains.Annotations.UsedImplicitlyAttribute(ImplicitUseTargetFlags.WithMembers)]
    [TagBlockOriginalNameAttribute("hs_scripts_block")]
    public partial class HsScriptsBlock : GuerillaBlock, IWriteQueueable
    {
        public Moonfish.Tags.String32 Name;
        public ScriptTypeEnum ScriptType;
        public ReturnTypeEnum ReturnType;
        public int RootExpressionIndex;
        public override int SerializedSize
        {
            get
            {
                return 40;
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
            this.Name = binaryReader.ReadString32();
            this.ScriptType = ((ScriptTypeEnum)(binaryReader.ReadInt16()));
            this.ReturnType = ((ReturnTypeEnum)(binaryReader.ReadInt16()));
            this.RootExpressionIndex = binaryReader.ReadInt32();
            return pointerQueue;
        }
        public override void ReadInstances(Moonfish.Guerilla.BlamBinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
        }
        public override void Write(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBinaryWriter)
        {
            base.Write(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.Name);
            queueableBinaryWriter.Write(((short)(this.ScriptType)));
            queueableBinaryWriter.Write(((short)(this.ReturnType)));
            queueableBinaryWriter.Write(this.RootExpressionIndex);
        }
        public enum ScriptTypeEnum : short
        {
            Startup = 0,
            Dormant = 1,
            Continuous = 2,
            Static = 3,
            Stub = 4,
            CommandScript = 5,
        }
        public enum ReturnTypeEnum : short
        {
            Unparsed = 0,
            SpecialForm = 1,
            FunctionName = 2,
            Passthrough = 3,
            Void = 4,
            Boolean = 5,
            Real = 6,
            Short = 7,
            Long = 8,
            String = 9,
            Script = 10,
            StringId = 11,
            UnitSeatMapping = 12,
            TriggerVolume = 13,
            CutsceneFlag = 14,
            CutsceneCameraPoint = 15,
            CutsceneTitle = 16,
            CutsceneRecording = 17,
            DeviceGroup = 18,
            Ai = 19,
            AiCommandList = 20,
            AiCommandScript = 21,
            AiBehavior = 22,
            AiOrders = 23,
            StartingProfile = 24,
            Conversation = 25,
            StructureBsp = 26,
            Navpoint = 27,
            PointReference = 28,
            Style = 29,
            HudMessage = 30,
            ObjectList = 31,
            Sound = 32,
            Effect = 33,
            Damage = 34,
            LoopingSound = 35,
            AnimationGraph = 36,
            DamageEffect = 37,
            ObjectDefinition = 38,
            Bitmap = 39,
            Shader = 40,
            RenderModel = 41,
            StructureDefinition = 42,
            LightmapDefinition = 43,
            GameDifficulty = 44,
            Team = 45,
            ActorType = 46,
            HudCorner = 47,
            ModelState = 48,
            NetworkEvent = 49,
            Object = 50,
            Unit = 51,
            Vehicle = 52,
            Weapon = 53,
            Device = 54,
            Scenery = 55,
            ObjectName = 56,
            UnitName = 57,
            VehicleName = 58,
            WeaponName = 59,
            DeviceName = 60,
            SceneryName = 61,
        }
    }
}
