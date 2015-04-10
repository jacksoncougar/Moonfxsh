// ReSharper disable All
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
        public  ObjectBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  ObjectBlockBase(System.IO.BinaryReader binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(2);
            flags = (Flags)binaryReader.ReadInt16();
            boundingRadiusWorldUnits = binaryReader.ReadSingle();
            boundingOffset = binaryReader.ReadVector3();
            accelerationScale0Inf = binaryReader.ReadSingle();
            lightmapShadowMode = (LightmapShadowMode)binaryReader.ReadInt16();
            sweetenerSize = (SweetenerSize)binaryReader.ReadByte();
            invalidName_0 = binaryReader.ReadBytes(1);
            invalidName_1 = binaryReader.ReadBytes(4);
            dynamicLightSphereRadius = binaryReader.ReadSingle();
            dynamicLightSphereOffset = binaryReader.ReadVector3();
            defaultModelVariant = binaryReader.ReadStringID();
            model = binaryReader.ReadTagReference();
            crateObject = binaryReader.ReadTagReference();
            modifierShader = binaryReader.ReadTagReference();
            creationEffect = binaryReader.ReadTagReference();
            materialEffects = binaryReader.ReadTagReference();
            ReadObjectAiPropertiesBlockArray(binaryReader);
            ReadObjectFunctionBlockArray(binaryReader);
            applyCollisionDamageScale = binaryReader.ReadSingle();
            minGameAccDefault = binaryReader.ReadSingle();
            maxGameAccDefault = binaryReader.ReadSingle();
            minGameScaleDefault = binaryReader.ReadSingle();
            maxGameScaleDefault = binaryReader.ReadSingle();
            minAbsAccDefault = binaryReader.ReadSingle();
            maxAbsAccDefault = binaryReader.ReadSingle();
            minAbsScaleDefault = binaryReader.ReadSingle();
            maxAbsScaleDefault = binaryReader.ReadSingle();
            hudTextMessageIndex = binaryReader.ReadInt16();
            invalidName_2 = binaryReader.ReadBytes(2);
            ReadObjectAttachmentBlockArray(binaryReader);
            ReadObjectWidgetBlockArray(binaryReader);
            ReadOldObjectFunctionBlockArray(binaryReader);
            ReadObjectChangeColorsArray(binaryReader);
            ReadPredictedResourceBlockArray(binaryReader);
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
        internal  virtual ObjectAiPropertiesBlock[] ReadObjectAiPropertiesBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual ObjectFunctionBlock[] ReadObjectFunctionBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual ObjectAttachmentBlock[] ReadObjectAttachmentBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual ObjectWidgetBlock[] ReadObjectWidgetBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual OldObjectFunctionBlock[] ReadOldObjectFunctionBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual ObjectChangeColors[] ReadObjectChangeColorsArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual PredictedResourceBlock[] ReadPredictedResourceBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteObjectAiPropertiesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteObjectFunctionBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteObjectAttachmentBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteObjectWidgetBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteOldObjectFunctionBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteObjectChangeColorsArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WritePredictedResourceBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(boundingRadiusWorldUnits);
                binaryWriter.Write(boundingOffset);
                binaryWriter.Write(accelerationScale0Inf);
                binaryWriter.Write((Int16)lightmapShadowMode);
                binaryWriter.Write((Byte)sweetenerSize);
                binaryWriter.Write(invalidName_0, 0, 1);
                binaryWriter.Write(invalidName_1, 0, 4);
                binaryWriter.Write(dynamicLightSphereRadius);
                binaryWriter.Write(dynamicLightSphereOffset);
                binaryWriter.Write(defaultModelVariant);
                binaryWriter.Write(model);
                binaryWriter.Write(crateObject);
                binaryWriter.Write(modifierShader);
                binaryWriter.Write(creationEffect);
                binaryWriter.Write(materialEffects);
                WriteObjectAiPropertiesBlockArray(binaryWriter);
                WriteObjectFunctionBlockArray(binaryWriter);
                binaryWriter.Write(applyCollisionDamageScale);
                binaryWriter.Write(minGameAccDefault);
                binaryWriter.Write(maxGameAccDefault);
                binaryWriter.Write(minGameScaleDefault);
                binaryWriter.Write(maxGameScaleDefault);
                binaryWriter.Write(minAbsAccDefault);
                binaryWriter.Write(maxAbsAccDefault);
                binaryWriter.Write(minAbsScaleDefault);
                binaryWriter.Write(maxAbsScaleDefault);
                binaryWriter.Write(hudTextMessageIndex);
                binaryWriter.Write(invalidName_2, 0, 2);
                WriteObjectAttachmentBlockArray(binaryWriter);
                WriteObjectWidgetBlockArray(binaryWriter);
                WriteOldObjectFunctionBlockArray(binaryWriter);
                WriteObjectChangeColorsArray(binaryWriter);
                WritePredictedResourceBlockArray(binaryWriter);
            }
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
