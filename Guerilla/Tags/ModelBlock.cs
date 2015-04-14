// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass HlmtClass = (TagClass)"hlmt";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("hlmt")]
    public  partial class ModelBlock : ModelBlockBase
    {
        public  ModelBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 252, Alignment = 4)]
    public class ModelBlockBase  : IGuerilla
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
            variants = Guerilla.ReadBlockArray<ModelVariantBlock>(binaryReader);
            materials = Guerilla.ReadBlockArray<ModelMaterialBlock>(binaryReader);
            newDamageInfo = Guerilla.ReadBlockArray<GlobalDamageInfoBlock>(binaryReader);
            targets = Guerilla.ReadBlockArray<ModelTargetBlock>(binaryReader);
            modelRegionBlock = Guerilla.ReadBlockArray<ModelRegionBlock>(binaryReader);
            modelNodeBlock = Guerilla.ReadBlockArray<ModelNodeBlock>(binaryReader);
            invalidName_2 = binaryReader.ReadBytes(4);
            modelObjectData = Guerilla.ReadBlockArray<ModelObjectDataBlock>(binaryReader);
            defaultDialogue = binaryReader.ReadTagReference();
            uNUSED = binaryReader.ReadTagReference();
            flags = (Flags)binaryReader.ReadInt32();
            defaultDialogueEffect = binaryReader.ReadStringID();
            renderOnlyNodeFlags = new []{ new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader), new RenderOnlyNodeFlags(binaryReader),  };
            renderOnlySectionFlags = new []{ new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader), new RenderOnlySectionFlags(binaryReader),  };
            runtimeFlags = (RuntimeFlags)binaryReader.ReadInt32();
            scenarioLoadParameters = Guerilla.ReadBlockArray<GlobalScenarioLoadParametersBlock>(binaryReader);
            hologramShader = binaryReader.ReadTagReference();
            hologramControlFunction = binaryReader.ReadStringID();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
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
                nextAddress = Guerilla.WriteBlockArray<ModelVariantBlock>(binaryWriter, variants, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ModelMaterialBlock>(binaryWriter, materials, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GlobalDamageInfoBlock>(binaryWriter, newDamageInfo, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ModelTargetBlock>(binaryWriter, targets, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ModelRegionBlock>(binaryWriter, modelRegionBlock, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ModelNodeBlock>(binaryWriter, modelNodeBlock, nextAddress);
                binaryWriter.Write(invalidName_2, 0, 4);
                nextAddress = Guerilla.WriteBlockArray<ModelObjectDataBlock>(binaryWriter, modelObjectData, nextAddress);
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
                nextAddress = Guerilla.WriteBlockArray<GlobalScenarioLoadParametersBlock>(binaryWriter, scenarioLoadParameters, nextAddress);
                binaryWriter.Write(hologramShader);
                binaryWriter.Write(hologramControlFunction);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
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
        public class RenderOnlyNodeFlags  : IGuerilla
        {
            internal byte invalidName_;
            internal  RenderOnlyNodeFlags(BinaryReader binaryReader)
            {
                invalidName_ = binaryReader.ReadByte();
            }
            public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
            {
                using(binaryWriter.BaseStream.Pin())
                {
                    binaryWriter.Write(invalidName_);
                    return nextAddress = (int)binaryWriter.BaseStream.Position;
                }
            }
        };
        public class RenderOnlySectionFlags  : IGuerilla
        {
            internal byte invalidName_;
            internal  RenderOnlySectionFlags(BinaryReader binaryReader)
            {
                invalidName_ = binaryReader.ReadByte();
            }
            public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
            {
                using(binaryWriter.BaseStream.Pin())
                {
                    binaryWriter.Write(invalidName_);
                    return nextAddress = (int)binaryWriter.BaseStream.Position;
                }
            }
        };
    };
}
