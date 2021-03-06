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
    
    [TagClassAttribute("obje")]
    public partial class ObjectBlock : GuerillaBlock, IWriteQueueable
    {
        private byte[] fieldpad = new byte[2];
        public Flags ObjectFlags;
        public float BoundingRadius;
        public OpenTK.Vector3 BoundingOffset;
        public float AccelerationScale;
        public LightmapShadowModeEnum LightmapShadowMode;
        public SweetenerSizeEnum SweetenerSize;
        private byte[] fieldpad0 = new byte[1];
        private byte[] fieldpad1 = new byte[4];
        public float DynamicLightSphereRadius;
        public OpenTK.Vector3 DynamicLightSphereOffset;
        public Moonfish.Tags.StringIdent DefaultModelVariant;
        [Moonfish.Tags.TagReferenceAttribute("hlmt")]
        public Moonfish.Tags.TagReference Model;
        [Moonfish.Tags.TagReferenceAttribute("bloc")]
        public Moonfish.Tags.TagReference CrateObject;
        [Moonfish.Tags.TagReferenceAttribute("shad")]
        public Moonfish.Tags.TagReference ModifierShader;
        [Moonfish.Tags.TagReferenceAttribute("effe")]
        public Moonfish.Tags.TagReference CreationEffect;
        [Moonfish.Tags.TagReferenceAttribute("foot")]
        public Moonfish.Tags.TagReference MaterialEffects;
        public ObjectAiPropertiesBlock[] AiProperties = new ObjectAiPropertiesBlock[0];
        public ObjectFunctionBlock[] Functions = new ObjectFunctionBlock[0];
        /// <summary>
        /// for things that want to cause more or less collision damage
        /// </summary>
        public float ApplyCollisionDamageScale;
        /// <summary>
        /// 0 - means take default value from globals.globals
        /// </summary>
        public float MinGameAcc;
        public float MaxGameAcc;
        public float MinGameScale;
        public float MaxGameScale;
        /// <summary>
        /// 0 - means take default value from globals.globals
        /// </summary>
        public float MinAbsAcc;
        public float MaxAbsAcc;
        public float MinAbsScale;
        public float MaxAbsScale;
        public short HudTextMessageIndex;
        private byte[] fieldpad2 = new byte[2];
        public ObjectAttachmentBlock[] Attachments = new ObjectAttachmentBlock[0];
        public ObjectWidgetBlock[] Widgets = new ObjectWidgetBlock[0];
        public OldObjectFunctionBlock[] OldFunctions = new OldObjectFunctionBlock[0];
        public ObjectChangeColors[] ChangeColors = new ObjectChangeColors[0];
        public PredictedResourceBlock[] PredictedResources = new PredictedResourceBlock[0];
        public override int SerializedSize
        {
            get
            {
                return 188;
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
            this.fieldpad = binaryReader.ReadBytes(2);
            this.ObjectFlags = ((Flags)(binaryReader.ReadInt16()));
            this.BoundingRadius = binaryReader.ReadSingle();
            this.BoundingOffset = binaryReader.ReadVector3();
            this.AccelerationScale = binaryReader.ReadSingle();
            this.LightmapShadowMode = ((LightmapShadowModeEnum)(binaryReader.ReadInt16()));
            this.SweetenerSize = ((SweetenerSizeEnum)(binaryReader.ReadByte()));
            this.fieldpad0 = binaryReader.ReadBytes(1);
            this.fieldpad1 = binaryReader.ReadBytes(4);
            this.DynamicLightSphereRadius = binaryReader.ReadSingle();
            this.DynamicLightSphereOffset = binaryReader.ReadVector3();
            this.DefaultModelVariant = binaryReader.ReadStringID();
            this.Model = binaryReader.ReadTagReference();
            this.CrateObject = binaryReader.ReadTagReference();
            this.ModifierShader = binaryReader.ReadTagReference();
            this.CreationEffect = binaryReader.ReadTagReference();
            this.MaterialEffects = binaryReader.ReadTagReference();
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(16));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(32));
            this.ApplyCollisionDamageScale = binaryReader.ReadSingle();
            this.MinGameAcc = binaryReader.ReadSingle();
            this.MaxGameAcc = binaryReader.ReadSingle();
            this.MinGameScale = binaryReader.ReadSingle();
            this.MaxGameScale = binaryReader.ReadSingle();
            this.MinAbsAcc = binaryReader.ReadSingle();
            this.MaxAbsAcc = binaryReader.ReadSingle();
            this.MinAbsScale = binaryReader.ReadSingle();
            this.MaxAbsScale = binaryReader.ReadSingle();
            this.HudTextMessageIndex = binaryReader.ReadInt16();
            this.fieldpad2 = binaryReader.ReadBytes(2);
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(24));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(8));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(80));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(16));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(8));
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.AiProperties = base.ReadBlockArrayData<ObjectAiPropertiesBlock>(binaryReader, pointerQueue.Dequeue());
            this.Functions = base.ReadBlockArrayData<ObjectFunctionBlock>(binaryReader, pointerQueue.Dequeue());
            this.Attachments = base.ReadBlockArrayData<ObjectAttachmentBlock>(binaryReader, pointerQueue.Dequeue());
            this.Widgets = base.ReadBlockArrayData<ObjectWidgetBlock>(binaryReader, pointerQueue.Dequeue());
            this.OldFunctions = base.ReadBlockArrayData<OldObjectFunctionBlock>(binaryReader, pointerQueue.Dequeue());
            this.ChangeColors = base.ReadBlockArrayData<ObjectChangeColors>(binaryReader, pointerQueue.Dequeue());
            this.PredictedResources = base.ReadBlockArrayData<PredictedResourceBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            queueableBinaryWriter.QueueWrite(this.AiProperties);
            queueableBinaryWriter.QueueWrite(this.Functions);
            queueableBinaryWriter.QueueWrite(this.Attachments);
            queueableBinaryWriter.QueueWrite(this.Widgets);
            queueableBinaryWriter.QueueWrite(this.OldFunctions);
            queueableBinaryWriter.QueueWrite(this.ChangeColors);
            queueableBinaryWriter.QueueWrite(this.PredictedResources);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.Write_(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.Write(((short)(this.ObjectFlags)));
            queueableBinaryWriter.Write(this.BoundingRadius);
            queueableBinaryWriter.Write(this.BoundingOffset);
            queueableBinaryWriter.Write(this.AccelerationScale);
            queueableBinaryWriter.Write(((short)(this.LightmapShadowMode)));
            queueableBinaryWriter.Write(((byte)(this.SweetenerSize)));
            queueableBinaryWriter.Write(this.fieldpad0);
            queueableBinaryWriter.Write(this.fieldpad1);
            queueableBinaryWriter.Write(this.DynamicLightSphereRadius);
            queueableBinaryWriter.Write(this.DynamicLightSphereOffset);
            queueableBinaryWriter.Write(this.DefaultModelVariant);
            queueableBinaryWriter.Write(this.Model);
            queueableBinaryWriter.Write(this.CrateObject);
            queueableBinaryWriter.Write(this.ModifierShader);
            queueableBinaryWriter.Write(this.CreationEffect);
            queueableBinaryWriter.Write(this.MaterialEffects);
            queueableBinaryWriter.WritePointer(this.AiProperties);
            queueableBinaryWriter.WritePointer(this.Functions);
            queueableBinaryWriter.Write(this.ApplyCollisionDamageScale);
            queueableBinaryWriter.Write(this.MinGameAcc);
            queueableBinaryWriter.Write(this.MaxGameAcc);
            queueableBinaryWriter.Write(this.MinGameScale);
            queueableBinaryWriter.Write(this.MaxGameScale);
            queueableBinaryWriter.Write(this.MinAbsAcc);
            queueableBinaryWriter.Write(this.MaxAbsAcc);
            queueableBinaryWriter.Write(this.MinAbsScale);
            queueableBinaryWriter.Write(this.MaxAbsScale);
            queueableBinaryWriter.Write(this.HudTextMessageIndex);
            queueableBinaryWriter.Write(this.fieldpad2);
            queueableBinaryWriter.WritePointer(this.Attachments);
            queueableBinaryWriter.WritePointer(this.Widgets);
            queueableBinaryWriter.WritePointer(this.OldFunctions);
            queueableBinaryWriter.WritePointer(this.ChangeColors);
            queueableBinaryWriter.WritePointer(this.PredictedResources);
        }
        [System.FlagsAttribute()]
        public enum Flags : short
        {
            None = 0,
            DoesNotCastShadow = 1,
            SearchCardinalDirectionLightmapsOnFailure = 2,
            Unused = 4,
            NotAPathfindingObstacle = 8,
            ExtensionOfParentobjectPassesAllFunctionValuesToParentAndUsesParentsMarkers = 16,
            DoesNotCauseCollisionDamage = 32,
            EarlyMover = 64,
            EarlyMoverLocalizedPhysics = 128,
            UseStaticMassiveLightmapSamplecastATonOfRaysOnceAndStoreTheResultsForLighting = 256,
            ObjectScalesAttachments = 512,
            InheritsPlayersAppearance = 1024,
            DeadBipedsCantLocalize = 2048,
            AttachToClustersByDynamicSphereuseThisForTheMacGunOnSpacestation = 4096,
            EffectsCreatedByThisObjectDoNotSpawnObjectsInMultiplayer = 8192,
        }
        public enum LightmapShadowModeEnum : short
        {
            Default = 0,
            Never = 1,
            Always = 2,
        }
        public enum SweetenerSizeEnum : byte
        {
            Small = 0,
            Medium = 1,
            Large = 2,
        }
    }
}
namespace Moonfish.Tags
{
    
    public partial struct TagClass
    {
        public static TagClass Obje = ((TagClass)("obje"));
    }
}
