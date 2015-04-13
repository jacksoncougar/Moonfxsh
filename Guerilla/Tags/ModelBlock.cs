using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("hlmt")]
    public  partial class ModelBlock : ModelBlockBase
    {
        public  ModelBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 252)]
    public class ModelBlockBase
    {
        [TagReference("mode")]
        internal Moonfish.Tags.TagReference renderModel;
        [TagReference("coll")]
        internal Moonfish.Tags.TagReference collisionModel;
        [TagReference("jmad")]
        internal Moonfish.Tags.TagReference animation;
        [TagReference("phys")]
        internal Moonfish.Tags.TagReference physics;
        [TagReference("phmo")]
        internal Moonfish.Tags.TagReference physicsModel;
        internal float disappearDistanceWorldUnits;
        internal float beginFadeDistanceWorldUnits;
        internal byte[] invalidName_;
        internal float reduceToL1WorldUnitsSuperLow;
        internal float reduceToL2WorldUnitsLow;
        internal float reduceToL3WorldUnitsMedium;
        internal float reduceToL4WorldUnitsHigh;
        internal float reduceToL5WorldUnitsSuperHigh;
        internal byte[] invalidName_0;
        internal ShadowFadeDistance shadowFadeDistance;
        internal byte[] invalidName_1;
        internal ModelVariantBlock[] variants;
        internal ModelMaterialBlock[] materials;
        internal GlobalDamageInfoBlock[] newDamageInfo;
        internal ModelTargetBlock[] targets;
        internal ModelRegionBlock[] modelRegionBlock;
        internal ModelNodeBlock[] modelNodeBlock;
        internal byte[] invalidName_2;
        internal ModelObjectDataBlock[] modelObjectData;
        /// <summary>
        /// The defaultDialogue tag for this model (overriden by variants)
        /// </summary>
        [TagReference("udlg")]
        internal Moonfish.Tags.TagReference defaultDialogue;
        [TagReference("shad")]
        internal Moonfish.Tags.TagReference uNUSED;
        internal Flags flags;
        /// <summary>
        /// The default dialogue tag for this model (overriden by variants)
        /// </summary>
        internal Moonfish.Tags.StringID defaultDialogueEffect;
        internal RenderOnlyNodeFlags[] renderOnlyNodeFlags;
        internal RenderOnlySectionFlags[] renderOnlySectionFlags;
        internal RuntimeFlags runtimeFlags;
        internal GlobalScenarioLoadParametersBlock[] scenarioLoadParameters;
        [TagReference("shad")]
        internal Moonfish.Tags.TagReference hologramShader;
        internal Moonfish.Tags.StringID hologramControlFunction;
        internal  ModelBlockBase(BinaryReader binaryReader)
        {
            this.renderModel = binaryReader.ReadTagReference();
            this.collisionModel = binaryReader.ReadTagReference();
            this.animation = binaryReader.ReadTagReference();
            this.physics = binaryReader.ReadTagReference();
            this.physicsModel = binaryReader.ReadTagReference();
            this.disappearDistanceWorldUnits = binaryReader.ReadSingle();
            this.beginFadeDistanceWorldUnits = binaryReader.ReadSingle();
            this.invalidName_ = binaryReader.ReadBytes(4);
            this.reduceToL1WorldUnitsSuperLow = binaryReader.ReadSingle();
            this.reduceToL2WorldUnitsLow = binaryReader.ReadSingle();
            this.reduceToL3WorldUnitsMedium = binaryReader.ReadSingle();
            this.reduceToL4WorldUnitsHigh = binaryReader.ReadSingle();
            this.reduceToL5WorldUnitsSuperHigh = binaryReader.ReadSingle();
            this.invalidName_0 = binaryReader.ReadBytes(4);
            this.shadowFadeDistance = (ShadowFadeDistance)binaryReader.ReadInt16();
            this.invalidName_1 = binaryReader.ReadBytes(2);
            this.variants = ReadModelVariantBlockArray(binaryReader);
            this.materials = ReadModelMaterialBlockArray(binaryReader);
            this.newDamageInfo = ReadGlobalDamageInfoBlockArray(binaryReader);
            this.targets = ReadModelTargetBlockArray(binaryReader);
            this.modelRegionBlock = ReadModelRegionBlockArray(binaryReader);
            this.modelNodeBlock = ReadModelNodeBlockArray(binaryReader);
            this.invalidName_2 = binaryReader.ReadBytes(4);
            this.modelObjectData = ReadModelObjectDataBlockArray(binaryReader);
            this.defaultDialogue = binaryReader.ReadTagReference();
            this.uNUSED = binaryReader.ReadTagReference();
            this.flags = (Flags)binaryReader.ReadInt32();
            this.defaultDialogueEffect = binaryReader.ReadStringID();
            this.renderOnlyNodeFlags = new []{ new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader),  };
            this.renderOnlySectionFlags = new []{ new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader),  };
            this.runtimeFlags = (RuntimeFlags)binaryReader.ReadInt32();
            this.scenarioLoadParameters = ReadGlobalScenarioLoadParametersBlockArray(binaryReader);
            this.hologramShader = binaryReader.ReadTagReference();
            this.hologramControlFunction = binaryReader.ReadStringID();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
        }
        internal  virtual ModelVariantBlock[] ReadModelVariantBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ModelVariantBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ModelVariantBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ModelVariantBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ModelMaterialBlock[] ReadModelMaterialBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ModelMaterialBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ModelMaterialBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ModelMaterialBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GlobalDamageInfoBlock[] ReadGlobalDamageInfoBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalDamageInfoBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalDamageInfoBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalDamageInfoBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ModelTargetBlock[] ReadModelTargetBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ModelTargetBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ModelTargetBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ModelTargetBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ModelRegionBlock[] ReadModelRegionBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ModelRegionBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ModelRegionBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ModelRegionBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ModelNodeBlock[] ReadModelNodeBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ModelNodeBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ModelNodeBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ModelNodeBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ModelObjectDataBlock[] ReadModelObjectDataBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ModelObjectDataBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ModelObjectDataBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ModelObjectDataBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GlobalScenarioLoadParametersBlock[] ReadGlobalScenarioLoadParametersBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalScenarioLoadParametersBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalScenarioLoadParametersBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalScenarioLoadParametersBlock(binaryReader);
                }
            }
            return array;
        }
        internal enum ShadowFadeDistance : short
        
        {
            FadeAtSuperHighDetailLevel = 0,
            FadeAtHighDetailLevel = 1,
            FadeAtMediumDetailLevel = 2,
            FadeAtLowDetailLevel = 3,
            FadeAtSuperLowDetailLevel = 4,
            FadeNever = 5,
        };
        [FlagsAttribute]
        internal enum Flags : int
        
        {
            ActiveCamoAlwaysOn = 1,
            ActiveCamoAlwaysMerge = 2,
            ActiveCamoNeverMerge = 4,
        };
        [FlagsAttribute]
        internal enum RuntimeFlags : int
        
        {
            ContainsRunTimeNodes = 1,
        };
        public class RenderOnlyNodeFlags
        {
            internal byte invalidName_;
            internal  RenderOnlyNodeFlags(BinaryReader binaryReader)
            {
                this.invalidName_ = binaryReader.ReadByte();
            }
            internal  virtual byte[] ReadData(BinaryReader binaryReader)
            {
                var blamPointer = binaryReader.ReadBlamPointer(1);
                var data = new byte[blamPointer.elementCount];
                if(blamPointer.elementCount > 0)
                {
                    using (binaryReader.BaseStream.Pin())
                    {
                        binaryReader.BaseStream.Position = blamPointer[0];
                        data = binaryReader.ReadBytes(blamPointer.elementCount);
                    }
                }
                return data;
            }
        };
        public class RenderOnlySectionFlags
        {
            internal byte invalidName_;
            internal  RenderOnlySectionFlags(BinaryReader binaryReader)
            {
                this.invalidName_ = binaryReader.ReadByte();
            }
            internal  virtual byte[] ReadData(BinaryReader binaryReader)
            {
                var blamPointer = binaryReader.ReadBlamPointer(1);
                var data = new byte[blamPointer.elementCount];
                if(blamPointer.elementCount > 0)
                {
                    using (binaryReader.BaseStream.Pin())
                    {
                        binaryReader.BaseStream.Position = blamPointer[0];
                        data = binaryReader.ReadBytes(blamPointer.elementCount);
                    }
                }
                return data;
            }
        };
    };
}
