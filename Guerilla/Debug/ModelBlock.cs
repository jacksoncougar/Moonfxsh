// ReSharper disable All
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
        public  ModelBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  ModelBlockBase(System.IO.BinaryReader binaryReader)
        {
            renderModel = binaryReader.ReadTagReference();
            collisionModel = binaryReader.ReadTagReference();
            animation = binaryReader.ReadTagReference();
            physics = binaryReader.ReadTagReference();
            physicsModel = binaryReader.ReadTagReference();
            disappearDistanceWorldUnits = binaryReader.ReadSingle();
            beginFadeDistanceWorldUnits = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadBytes(4);
            reduceToL1WorldUnitsSuperLow = binaryReader.ReadSingle();
            reduceToL2WorldUnitsLow = binaryReader.ReadSingle();
            reduceToL3WorldUnitsMedium = binaryReader.ReadSingle();
            reduceToL4WorldUnitsHigh = binaryReader.ReadSingle();
            reduceToL5WorldUnitsSuperHigh = binaryReader.ReadSingle();
            invalidName_0 = binaryReader.ReadBytes(4);
            shadowFadeDistance = (ShadowFadeDistance)binaryReader.ReadInt16();
            invalidName_1 = binaryReader.ReadBytes(2);
            ReadModelVariantBlockArray(binaryReader);
            ReadModelMaterialBlockArray(binaryReader);
            ReadGlobalDamageInfoBlockArray(binaryReader);
            ReadModelTargetBlockArray(binaryReader);
            ReadModelRegionBlockArray(binaryReader);
            ReadModelNodeBlockArray(binaryReader);
            invalidName_2 = binaryReader.ReadBytes(4);
            ReadModelObjectDataBlockArray(binaryReader);
            defaultDialogue = binaryReader.ReadTagReference();
            uNUSED = binaryReader.ReadTagReference();
            flags = (Flags)binaryReader.ReadInt32();
            defaultDialogueEffect = binaryReader.ReadStringID();
            renderOnlyNodeFlags = new []{ new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader),  };
            renderOnlySectionFlags = new []{ new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader),  };
            runtimeFlags = (RuntimeFlags)binaryReader.ReadInt32();
            ReadGlobalScenarioLoadParametersBlockArray(binaryReader);
            hologramShader = binaryReader.ReadTagReference();
            hologramControlFunction = binaryReader.ReadStringID();
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
        internal  virtual ModelVariantBlock[] ReadModelVariantBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ModelVariantBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ModelVariantBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ModelVariantBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ModelMaterialBlock[] ReadModelMaterialBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ModelMaterialBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ModelMaterialBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ModelMaterialBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GlobalDamageInfoBlock[] ReadGlobalDamageInfoBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalDamageInfoBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalDamageInfoBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalDamageInfoBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ModelTargetBlock[] ReadModelTargetBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ModelTargetBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ModelTargetBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ModelTargetBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ModelRegionBlock[] ReadModelRegionBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ModelRegionBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ModelRegionBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ModelRegionBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ModelNodeBlock[] ReadModelNodeBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ModelNodeBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ModelNodeBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ModelNodeBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ModelObjectDataBlock[] ReadModelObjectDataBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ModelObjectDataBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ModelObjectDataBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ModelObjectDataBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GlobalScenarioLoadParametersBlock[] ReadGlobalScenarioLoadParametersBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalScenarioLoadParametersBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalScenarioLoadParametersBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalScenarioLoadParametersBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteModelVariantBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteModelMaterialBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGlobalDamageInfoBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteModelTargetBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteModelRegionBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteModelNodeBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteModelObjectDataBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGlobalScenarioLoadParametersBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(renderModel);
                binaryWriter.Write(collisionModel);
                binaryWriter.Write(animation);
                binaryWriter.Write(physics);
                binaryWriter.Write(physicsModel);
                binaryWriter.Write(disappearDistanceWorldUnits);
                binaryWriter.Write(beginFadeDistanceWorldUnits);
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(reduceToL1WorldUnitsSuperLow);
                binaryWriter.Write(reduceToL2WorldUnitsLow);
                binaryWriter.Write(reduceToL3WorldUnitsMedium);
                binaryWriter.Write(reduceToL4WorldUnitsHigh);
                binaryWriter.Write(reduceToL5WorldUnitsSuperHigh);
                binaryWriter.Write(invalidName_0, 0, 4);
                binaryWriter.Write((Int16)shadowFadeDistance);
                binaryWriter.Write(invalidName_1, 0, 2);
                WriteModelVariantBlockArray(binaryWriter);
                WriteModelMaterialBlockArray(binaryWriter);
                WriteGlobalDamageInfoBlockArray(binaryWriter);
                WriteModelTargetBlockArray(binaryWriter);
                WriteModelRegionBlockArray(binaryWriter);
                WriteModelNodeBlockArray(binaryWriter);
                binaryWriter.Write(invalidName_2, 0, 4);
                WriteModelObjectDataBlockArray(binaryWriter);
                binaryWriter.Write(defaultDialogue);
                binaryWriter.Write(uNUSED);
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write(defaultDialogueEffect);
                renderOnlyNodeFlags[0].Write(binaryWriter);
                renderOnlyNodeFlags[1].Write(binaryWriter);
                renderOnlyNodeFlags[2].Write(binaryWriter);
                renderOnlyNodeFlags[3].Write(binaryWriter);
                renderOnlyNodeFlags[4].Write(binaryWriter);
                renderOnlyNodeFlags[5].Write(binaryWriter);
                renderOnlyNodeFlags[6].Write(binaryWriter);
                renderOnlyNodeFlags[7].Write(binaryWriter);
                renderOnlyNodeFlags[8].Write(binaryWriter);
                renderOnlyNodeFlags[9].Write(binaryWriter);
                renderOnlyNodeFlags[10].Write(binaryWriter);
                renderOnlyNodeFlags[11].Write(binaryWriter);
                renderOnlyNodeFlags[12].Write(binaryWriter);
                renderOnlyNodeFlags[13].Write(binaryWriter);
                renderOnlyNodeFlags[14].Write(binaryWriter);
                renderOnlyNodeFlags[15].Write(binaryWriter);
                renderOnlyNodeFlags[16].Write(binaryWriter);
                renderOnlyNodeFlags[17].Write(binaryWriter);
                renderOnlyNodeFlags[18].Write(binaryWriter);
                renderOnlyNodeFlags[19].Write(binaryWriter);
                renderOnlyNodeFlags[20].Write(binaryWriter);
                renderOnlyNodeFlags[21].Write(binaryWriter);
                renderOnlyNodeFlags[22].Write(binaryWriter);
                renderOnlyNodeFlags[23].Write(binaryWriter);
                renderOnlyNodeFlags[24].Write(binaryWriter);
                renderOnlyNodeFlags[25].Write(binaryWriter);
                renderOnlyNodeFlags[26].Write(binaryWriter);
                renderOnlyNodeFlags[27].Write(binaryWriter);
                renderOnlyNodeFlags[28].Write(binaryWriter);
                renderOnlyNodeFlags[29].Write(binaryWriter);
                renderOnlyNodeFlags[30].Write(binaryWriter);
                renderOnlyNodeFlags[31].Write(binaryWriter);
                renderOnlySectionFlags[0].Write(binaryWriter);
                renderOnlySectionFlags[1].Write(binaryWriter);
                renderOnlySectionFlags[2].Write(binaryWriter);
                renderOnlySectionFlags[3].Write(binaryWriter);
                renderOnlySectionFlags[4].Write(binaryWriter);
                renderOnlySectionFlags[5].Write(binaryWriter);
                renderOnlySectionFlags[6].Write(binaryWriter);
                renderOnlySectionFlags[7].Write(binaryWriter);
                renderOnlySectionFlags[8].Write(binaryWriter);
                renderOnlySectionFlags[9].Write(binaryWriter);
                renderOnlySectionFlags[10].Write(binaryWriter);
                renderOnlySectionFlags[11].Write(binaryWriter);
                renderOnlySectionFlags[12].Write(binaryWriter);
                renderOnlySectionFlags[13].Write(binaryWriter);
                renderOnlySectionFlags[14].Write(binaryWriter);
                renderOnlySectionFlags[15].Write(binaryWriter);
                renderOnlySectionFlags[16].Write(binaryWriter);
                renderOnlySectionFlags[17].Write(binaryWriter);
                renderOnlySectionFlags[18].Write(binaryWriter);
                renderOnlySectionFlags[19].Write(binaryWriter);
                renderOnlySectionFlags[20].Write(binaryWriter);
                renderOnlySectionFlags[21].Write(binaryWriter);
                renderOnlySectionFlags[22].Write(binaryWriter);
                renderOnlySectionFlags[23].Write(binaryWriter);
                renderOnlySectionFlags[24].Write(binaryWriter);
                renderOnlySectionFlags[25].Write(binaryWriter);
                renderOnlySectionFlags[26].Write(binaryWriter);
                renderOnlySectionFlags[27].Write(binaryWriter);
                renderOnlySectionFlags[28].Write(binaryWriter);
                renderOnlySectionFlags[29].Write(binaryWriter);
                renderOnlySectionFlags[30].Write(binaryWriter);
                renderOnlySectionFlags[31].Write(binaryWriter);
                binaryWriter.Write((Int32)runtimeFlags);
                WriteGlobalScenarioLoadParametersBlockArray(binaryWriter);
                binaryWriter.Write(hologramShader);
                binaryWriter.Write(hologramControlFunction);
            }
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
            internal  RenderOnlyNodeFlags(System.IO.BinaryReader binaryReader)
            {
                invalidName_ = binaryReader.ReadByte();
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
            internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
            {
                
            }
            public void Write(System.IO.BinaryWriter binaryWriter)
            {
                using(binaryWriter.BaseStream.Pin())
                {
                    binaryWriter.Write(invalidName_);
                }
            }
        };
        public class RenderOnlySectionFlags
        {
            internal byte invalidName_;
            internal  RenderOnlySectionFlags(System.IO.BinaryReader binaryReader)
            {
                invalidName_ = binaryReader.ReadByte();
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
            internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
            {
                
            }
            public void Write(System.IO.BinaryWriter binaryWriter)
            {
                using(binaryWriter.BaseStream.Pin())
                {
                    binaryWriter.Write(invalidName_);
                }
            }
        };
    };
}
