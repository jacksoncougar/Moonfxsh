using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("obje")]
    public  partial class ObjectBlock : ObjectBlockBase
    {
        public  ObjectBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 188)]
    public class ObjectBlockBase
    {
        internal byte[] invalidName_;
        internal Flags flags;
        internal float boundingRadiusWorldUnits;
        internal OpenTK.Vector3 boundingOffset;
        /// <summary>
        /// marine 1.0, grunt 1.4, elite 0.9, hunter 0.5, etc.
        /// </summary>
        internal float accelerationScale0Inf;
        internal LightmapShadowMode lightmapShadowMode;
        internal SweetenerSize sweetenerSize;
        internal byte[] invalidName_0;
        internal byte[] invalidName_1;
        /// <summary>
        /// sphere to use for dynamic lights and shadows. only used if not 0
        /// </summary>
        internal float dynamicLightSphereRadius;
        /// <summary>
        /// only used if radius not 0
        /// </summary>
        internal OpenTK.Vector3 dynamicLightSphereOffset;
        internal Moonfish.Tags.StringID defaultModelVariant;
        [TagReference("hlmt")]
        internal Moonfish.Tags.TagReference model;
        [TagReference("bloc")]
        internal Moonfish.Tags.TagReference crateObject;
        [TagReference("shad")]
        internal Moonfish.Tags.TagReference modifierShader;
        [TagReference("effe")]
        internal Moonfish.Tags.TagReference creationEffect;
        [TagReference("foot")]
        internal Moonfish.Tags.TagReference materialEffects;
        internal ObjectAiPropertiesBlock[] aiProperties;
        internal ObjectFunctionBlock[] functions;
        /// <summary>
        /// 0 means 1.  1 is standard scale.  Some things may want to apply more damage
        /// </summary>
        internal float applyCollisionDamageScale;
        /// <summary>
        /// 0-oo
        /// </summary>
        internal float minGameAccDefault;
        /// <summary>
        /// 0-oo
        /// </summary>
        internal float maxGameAccDefault;
        /// <summary>
        /// 0-1
        /// </summary>
        internal float minGameScaleDefault;
        /// <summary>
        /// 0-1
        /// </summary>
        internal float maxGameScaleDefault;
        /// <summary>
        /// 0-oo
        /// </summary>
        internal float minAbsAccDefault;
        /// <summary>
        /// 0-oo
        /// </summary>
        internal float maxAbsAccDefault;
        /// <summary>
        /// 0-1
        /// </summary>
        internal float minAbsScaleDefault;
        /// <summary>
        /// 0-1
        /// </summary>
        internal float maxAbsScaleDefault;
        internal short hudTextMessageIndex;
        internal byte[] invalidName_2;
        internal ObjectAttachmentBlock[] attachments;
        internal ObjectWidgetBlock[] widgets;
        internal OldObjectFunctionBlock[] oldFunctions;
        internal ObjectChangeColors[] changeColors;
        internal PredictedResourceBlock[] predictedResources;
        internal  ObjectBlockBase(BinaryReader binaryReader)
        {
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.flags = (Flags)binaryReader.ReadInt16();
            this.boundingRadiusWorldUnits = binaryReader.ReadSingle();
            this.boundingOffset = binaryReader.ReadVector3();
            this.accelerationScale0Inf = binaryReader.ReadSingle();
            this.lightmapShadowMode = (LightmapShadowMode)binaryReader.ReadInt16();
            this.sweetenerSize = (SweetenerSize)binaryReader.ReadByte();
            this.invalidName_0 = binaryReader.ReadBytes(1);
            this.invalidName_1 = binaryReader.ReadBytes(4);
            this.dynamicLightSphereRadius = binaryReader.ReadSingle();
            this.dynamicLightSphereOffset = binaryReader.ReadVector3();
            this.defaultModelVariant = binaryReader.ReadStringID();
            this.model = binaryReader.ReadTagReference();
            this.crateObject = binaryReader.ReadTagReference();
            this.modifierShader = binaryReader.ReadTagReference();
            this.creationEffect = binaryReader.ReadTagReference();
            this.materialEffects = binaryReader.ReadTagReference();
            this.aiProperties = ReadObjectAiPropertiesBlockArray(binaryReader);
            this.functions = ReadObjectFunctionBlockArray(binaryReader);
            this.applyCollisionDamageScale = binaryReader.ReadSingle();
            this.minGameAccDefault = binaryReader.ReadSingle();
            this.maxGameAccDefault = binaryReader.ReadSingle();
            this.minGameScaleDefault = binaryReader.ReadSingle();
            this.maxGameScaleDefault = binaryReader.ReadSingle();
            this.minAbsAccDefault = binaryReader.ReadSingle();
            this.maxAbsAccDefault = binaryReader.ReadSingle();
            this.minAbsScaleDefault = binaryReader.ReadSingle();
            this.maxAbsScaleDefault = binaryReader.ReadSingle();
            this.hudTextMessageIndex = binaryReader.ReadInt16();
            this.invalidName_2 = binaryReader.ReadBytes(2);
            this.attachments = ReadObjectAttachmentBlockArray(binaryReader);
            this.widgets = ReadObjectWidgetBlockArray(binaryReader);
            this.oldFunctions = ReadOldObjectFunctionBlockArray(binaryReader);
            this.changeColors = ReadObjectChangeColorsArray(binaryReader);
            this.predictedResources = ReadPredictedResourceBlockArray(binaryReader);
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
        internal  virtual ObjectAiPropertiesBlock[] ReadObjectAiPropertiesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ObjectAiPropertiesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ObjectAiPropertiesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ObjectAiPropertiesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ObjectFunctionBlock[] ReadObjectFunctionBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ObjectFunctionBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ObjectFunctionBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ObjectFunctionBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ObjectAttachmentBlock[] ReadObjectAttachmentBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ObjectAttachmentBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ObjectAttachmentBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ObjectAttachmentBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ObjectWidgetBlock[] ReadObjectWidgetBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ObjectWidgetBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ObjectWidgetBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ObjectWidgetBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual OldObjectFunctionBlock[] ReadOldObjectFunctionBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(OldObjectFunctionBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new OldObjectFunctionBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new OldObjectFunctionBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ObjectChangeColors[] ReadObjectChangeColorsArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ObjectChangeColors));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ObjectChangeColors[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ObjectChangeColors(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PredictedResourceBlock[] ReadPredictedResourceBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PredictedResourceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PredictedResourceBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PredictedResourceBlock(binaryReader);
                }
            }
            return array;
        }
        [FlagsAttribute]
        internal enum Flags : short
        
        {
            DoesNotCastShadow = 1,
            SearchCardinalDirectionLightmapsOnFailure = 2,
            Unused = 4,
            NotAPathfindingObstacle = 8,
            ExtensionOfParentObjectPassesAllFunctionValuesToParentAndUsesParentsMarkers = 16,
            DoesNotCauseCollisionDamage = 32,
            EarlyMover = 64,
            EarlyMoverLocalizedPhysics = 128,
            UseStaticMassiveLightmapSampleCastATonOfRaysOnceAndStoreTheResultsForLighting = 256,
            ObjectScalesAttachments = 512,
            InheritsPlayersAppearance = 1024,
            DeadBipedsCantLocalize = 2048,
            AttachToClustersByDynamicSphereUseThisForTheMacGunOnSpacestation = 4096,
            EffectsCreatedByThisObjectDoNotSpawnObjectsInMultiplayer = 8192,
        };
        internal enum LightmapShadowMode : short
        
        {
            Default = 0,
            Never = 1,
            Always = 2,
        };
        internal enum SweetenerSize : byte
        
        {
            Small = 0,
            Medium = 1,
            Large = 2,
        };
    };
}
