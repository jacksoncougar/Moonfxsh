// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Hlmt = (TagClass) "hlmt";
    };
} ;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("hlmt")]
    public partial class ModelBlock : ModelBlockBase
    {
        public ModelBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 252, Alignment = 4)]
    public class ModelBlockBase : GuerillaBlock
    {
        [TagReference("mode")] internal Moonfish.Tags.TagReference renderModel;
        [TagReference("coll")] internal Moonfish.Tags.TagReference collisionModel;
        [TagReference("jmad")] internal Moonfish.Tags.TagReference animation;
        [TagReference("phys")] internal Moonfish.Tags.TagReference physics;
        [TagReference("phmo")] internal Moonfish.Tags.TagReference physicsModel;
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
        [TagReference("udlg")] internal Moonfish.Tags.TagReference defaultDialogue;

        [TagReference("shad")] internal Moonfish.Tags.TagReference uNUSED;
        internal Flags flags;

        /// <summary>
        /// The default dialogue tag for this model (overriden by variants)
        /// </summary>
        internal Moonfish.Tags.StringIdent defaultDialogueEffect;

        internal RenderOnlyNodeFlags[] renderOnlyNodeFlags;
        internal RenderOnlySectionFlags[] renderOnlySectionFlags;
        internal RuntimeFlags runtimeFlags;
        internal GlobalScenarioLoadParametersBlock[] scenarioLoadParameters;
        [TagReference("shad")] internal Moonfish.Tags.TagReference hologramShader;
        internal Moonfish.Tags.StringIdent hologramControlFunction;

        public override int SerializedSize
        {
            get { return 252; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ModelBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
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
            shadowFadeDistance = (ShadowFadeDistance) binaryReader.ReadInt16();
            invalidName_1 = binaryReader.ReadBytes(2);
            blamPointers.Enqueue(ReadBlockArrayPointer<ModelVariantBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ModelMaterialBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<GlobalDamageInfoBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ModelTargetBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ModelRegionBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ModelNodeBlock>(binaryReader));
            invalidName_2 = binaryReader.ReadBytes(4);
            blamPointers.Enqueue(ReadBlockArrayPointer<ModelObjectDataBlock>(binaryReader));
            defaultDialogue = binaryReader.ReadTagReference();
            uNUSED = binaryReader.ReadTagReference();
            flags = (Flags) binaryReader.ReadInt32();
            defaultDialogueEffect = binaryReader.ReadStringID();
            renderOnlyNodeFlags = new[]
            {
                new RenderOnlyNodeFlags(), new RenderOnlyNodeFlags(), new RenderOnlyNodeFlags(), new RenderOnlyNodeFlags(),
                new RenderOnlyNodeFlags(), new RenderOnlyNodeFlags(), new RenderOnlyNodeFlags(),
                new RenderOnlyNodeFlags(), new RenderOnlyNodeFlags(), new RenderOnlyNodeFlags(),
                new RenderOnlyNodeFlags(), new RenderOnlyNodeFlags(), new RenderOnlyNodeFlags(),
                new RenderOnlyNodeFlags(), new RenderOnlyNodeFlags(), new RenderOnlyNodeFlags(),
                new RenderOnlyNodeFlags(), new RenderOnlyNodeFlags(), new RenderOnlyNodeFlags(),
                new RenderOnlyNodeFlags(), new RenderOnlyNodeFlags(), new RenderOnlyNodeFlags(),
                new RenderOnlyNodeFlags(), new RenderOnlyNodeFlags(), new RenderOnlyNodeFlags(),
                new RenderOnlyNodeFlags(), new RenderOnlyNodeFlags(), new RenderOnlyNodeFlags(),
                new RenderOnlyNodeFlags(), new RenderOnlyNodeFlags(), new RenderOnlyNodeFlags(),
                new RenderOnlyNodeFlags()
            };
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(renderOnlyNodeFlags[0].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(renderOnlyNodeFlags[1].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(renderOnlyNodeFlags[2].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(renderOnlyNodeFlags[3].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(renderOnlyNodeFlags[4].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(renderOnlyNodeFlags[5].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(renderOnlyNodeFlags[6].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(renderOnlyNodeFlags[7].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(renderOnlyNodeFlags[8].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(renderOnlyNodeFlags[9].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(renderOnlyNodeFlags[10].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(renderOnlyNodeFlags[11].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(renderOnlyNodeFlags[12].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(renderOnlyNodeFlags[13].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(renderOnlyNodeFlags[14].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(renderOnlyNodeFlags[15].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(renderOnlyNodeFlags[16].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(renderOnlyNodeFlags[17].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(renderOnlyNodeFlags[18].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(renderOnlyNodeFlags[19].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(renderOnlyNodeFlags[20].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(renderOnlyNodeFlags[21].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(renderOnlyNodeFlags[22].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(renderOnlyNodeFlags[23].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(renderOnlyNodeFlags[24].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(renderOnlyNodeFlags[25].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(renderOnlyNodeFlags[26].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(renderOnlyNodeFlags[27].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(renderOnlyNodeFlags[28].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(renderOnlyNodeFlags[29].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(renderOnlyNodeFlags[30].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(renderOnlyNodeFlags[31].ReadFields(binaryReader)));
            renderOnlySectionFlags = new[]
            {
                new RenderOnlySectionFlags(), new RenderOnlySectionFlags(), new RenderOnlySectionFlags(),
                new RenderOnlySectionFlags(), new RenderOnlySectionFlags(), new RenderOnlySectionFlags(),
                new RenderOnlySectionFlags(), new RenderOnlySectionFlags(), new RenderOnlySectionFlags(),
                new RenderOnlySectionFlags(), new RenderOnlySectionFlags(), new RenderOnlySectionFlags(),
                new RenderOnlySectionFlags(), new RenderOnlySectionFlags(), new RenderOnlySectionFlags(),
                new RenderOnlySectionFlags(), new RenderOnlySectionFlags(), new RenderOnlySectionFlags(),
                new RenderOnlySectionFlags(), new RenderOnlySectionFlags(), new RenderOnlySectionFlags(),
                new RenderOnlySectionFlags(), new RenderOnlySectionFlags(), new RenderOnlySectionFlags(),
                new RenderOnlySectionFlags(), new RenderOnlySectionFlags(), new RenderOnlySectionFlags(),
                new RenderOnlySectionFlags(), new RenderOnlySectionFlags(), new RenderOnlySectionFlags(),
                new RenderOnlySectionFlags(), new RenderOnlySectionFlags()
            };
            blamPointers =
                new Queue<BlamPointer>(blamPointers.Concat(renderOnlySectionFlags[0].ReadFields(binaryReader)));
            blamPointers =
                new Queue<BlamPointer>(blamPointers.Concat(renderOnlySectionFlags[1].ReadFields(binaryReader)));
            blamPointers =
                new Queue<BlamPointer>(blamPointers.Concat(renderOnlySectionFlags[2].ReadFields(binaryReader)));
            blamPointers =
                new Queue<BlamPointer>(blamPointers.Concat(renderOnlySectionFlags[3].ReadFields(binaryReader)));
            blamPointers =
                new Queue<BlamPointer>(blamPointers.Concat(renderOnlySectionFlags[4].ReadFields(binaryReader)));
            blamPointers =
                new Queue<BlamPointer>(blamPointers.Concat(renderOnlySectionFlags[5].ReadFields(binaryReader)));
            blamPointers =
                new Queue<BlamPointer>(blamPointers.Concat(renderOnlySectionFlags[6].ReadFields(binaryReader)));
            blamPointers =
                new Queue<BlamPointer>(blamPointers.Concat(renderOnlySectionFlags[7].ReadFields(binaryReader)));
            blamPointers =
                new Queue<BlamPointer>(blamPointers.Concat(renderOnlySectionFlags[8].ReadFields(binaryReader)));
            blamPointers =
                new Queue<BlamPointer>(blamPointers.Concat(renderOnlySectionFlags[9].ReadFields(binaryReader)));
            blamPointers =
                new Queue<BlamPointer>(blamPointers.Concat(renderOnlySectionFlags[10].ReadFields(binaryReader)));
            blamPointers =
                new Queue<BlamPointer>(blamPointers.Concat(renderOnlySectionFlags[11].ReadFields(binaryReader)));
            blamPointers =
                new Queue<BlamPointer>(blamPointers.Concat(renderOnlySectionFlags[12].ReadFields(binaryReader)));
            blamPointers =
                new Queue<BlamPointer>(blamPointers.Concat(renderOnlySectionFlags[13].ReadFields(binaryReader)));
            blamPointers =
                new Queue<BlamPointer>(blamPointers.Concat(renderOnlySectionFlags[14].ReadFields(binaryReader)));
            blamPointers =
                new Queue<BlamPointer>(blamPointers.Concat(renderOnlySectionFlags[15].ReadFields(binaryReader)));
            blamPointers =
                new Queue<BlamPointer>(blamPointers.Concat(renderOnlySectionFlags[16].ReadFields(binaryReader)));
            blamPointers =
                new Queue<BlamPointer>(blamPointers.Concat(renderOnlySectionFlags[17].ReadFields(binaryReader)));
            blamPointers =
                new Queue<BlamPointer>(blamPointers.Concat(renderOnlySectionFlags[18].ReadFields(binaryReader)));
            blamPointers =
                new Queue<BlamPointer>(blamPointers.Concat(renderOnlySectionFlags[19].ReadFields(binaryReader)));
            blamPointers =
                new Queue<BlamPointer>(blamPointers.Concat(renderOnlySectionFlags[20].ReadFields(binaryReader)));
            blamPointers =
                new Queue<BlamPointer>(blamPointers.Concat(renderOnlySectionFlags[21].ReadFields(binaryReader)));
            blamPointers =
                new Queue<BlamPointer>(blamPointers.Concat(renderOnlySectionFlags[22].ReadFields(binaryReader)));
            blamPointers =
                new Queue<BlamPointer>(blamPointers.Concat(renderOnlySectionFlags[23].ReadFields(binaryReader)));
            blamPointers =
                new Queue<BlamPointer>(blamPointers.Concat(renderOnlySectionFlags[24].ReadFields(binaryReader)));
            blamPointers =
                new Queue<BlamPointer>(blamPointers.Concat(renderOnlySectionFlags[25].ReadFields(binaryReader)));
            blamPointers =
                new Queue<BlamPointer>(blamPointers.Concat(renderOnlySectionFlags[26].ReadFields(binaryReader)));
            blamPointers =
                new Queue<BlamPointer>(blamPointers.Concat(renderOnlySectionFlags[27].ReadFields(binaryReader)));
            blamPointers =
                new Queue<BlamPointer>(blamPointers.Concat(renderOnlySectionFlags[28].ReadFields(binaryReader)));
            blamPointers =
                new Queue<BlamPointer>(blamPointers.Concat(renderOnlySectionFlags[29].ReadFields(binaryReader)));
            blamPointers =
                new Queue<BlamPointer>(blamPointers.Concat(renderOnlySectionFlags[30].ReadFields(binaryReader)));
            blamPointers =
                new Queue<BlamPointer>(blamPointers.Concat(renderOnlySectionFlags[31].ReadFields(binaryReader)));
            runtimeFlags = (RuntimeFlags) binaryReader.ReadInt32();
            blamPointers.Enqueue(ReadBlockArrayPointer<GlobalScenarioLoadParametersBlock>(binaryReader));
            hologramShader = binaryReader.ReadTagReference();
            hologramControlFunction = binaryReader.ReadStringID();
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            variants = ReadBlockArrayData<ModelVariantBlock>(binaryReader, blamPointers.Dequeue());
            materials = ReadBlockArrayData<ModelMaterialBlock>(binaryReader, blamPointers.Dequeue());
            newDamageInfo = ReadBlockArrayData<GlobalDamageInfoBlock>(binaryReader, blamPointers.Dequeue());
            targets = ReadBlockArrayData<ModelTargetBlock>(binaryReader, blamPointers.Dequeue());
            modelRegionBlock = ReadBlockArrayData<ModelRegionBlock>(binaryReader, blamPointers.Dequeue());
            modelNodeBlock = ReadBlockArrayData<ModelNodeBlock>(binaryReader, blamPointers.Dequeue());
            modelObjectData = ReadBlockArrayData<ModelObjectDataBlock>(binaryReader, blamPointers.Dequeue());
            renderOnlyNodeFlags[0].ReadPointers(binaryReader, blamPointers);
            renderOnlyNodeFlags[1].ReadPointers(binaryReader, blamPointers);
            renderOnlyNodeFlags[2].ReadPointers(binaryReader, blamPointers);
            renderOnlyNodeFlags[3].ReadPointers(binaryReader, blamPointers);
            renderOnlyNodeFlags[4].ReadPointers(binaryReader, blamPointers);
            renderOnlyNodeFlags[5].ReadPointers(binaryReader, blamPointers);
            renderOnlyNodeFlags[6].ReadPointers(binaryReader, blamPointers);
            renderOnlyNodeFlags[7].ReadPointers(binaryReader, blamPointers);
            renderOnlyNodeFlags[8].ReadPointers(binaryReader, blamPointers);
            renderOnlyNodeFlags[9].ReadPointers(binaryReader, blamPointers);
            renderOnlyNodeFlags[10].ReadPointers(binaryReader, blamPointers);
            renderOnlyNodeFlags[11].ReadPointers(binaryReader, blamPointers);
            renderOnlyNodeFlags[12].ReadPointers(binaryReader, blamPointers);
            renderOnlyNodeFlags[13].ReadPointers(binaryReader, blamPointers);
            renderOnlyNodeFlags[14].ReadPointers(binaryReader, blamPointers);
            renderOnlyNodeFlags[15].ReadPointers(binaryReader, blamPointers);
            renderOnlyNodeFlags[16].ReadPointers(binaryReader, blamPointers);
            renderOnlyNodeFlags[17].ReadPointers(binaryReader, blamPointers);
            renderOnlyNodeFlags[18].ReadPointers(binaryReader, blamPointers);
            renderOnlyNodeFlags[19].ReadPointers(binaryReader, blamPointers);
            renderOnlyNodeFlags[20].ReadPointers(binaryReader, blamPointers);
            renderOnlyNodeFlags[21].ReadPointers(binaryReader, blamPointers);
            renderOnlyNodeFlags[22].ReadPointers(binaryReader, blamPointers);
            renderOnlyNodeFlags[23].ReadPointers(binaryReader, blamPointers);
            renderOnlyNodeFlags[24].ReadPointers(binaryReader, blamPointers);
            renderOnlyNodeFlags[25].ReadPointers(binaryReader, blamPointers);
            renderOnlyNodeFlags[26].ReadPointers(binaryReader, blamPointers);
            renderOnlyNodeFlags[27].ReadPointers(binaryReader, blamPointers);
            renderOnlyNodeFlags[28].ReadPointers(binaryReader, blamPointers);
            renderOnlyNodeFlags[29].ReadPointers(binaryReader, blamPointers);
            renderOnlyNodeFlags[30].ReadPointers(binaryReader, blamPointers);
            renderOnlyNodeFlags[31].ReadPointers(binaryReader, blamPointers);
            renderOnlySectionFlags[0].ReadPointers(binaryReader, blamPointers);
            renderOnlySectionFlags[1].ReadPointers(binaryReader, blamPointers);
            renderOnlySectionFlags[2].ReadPointers(binaryReader, blamPointers);
            renderOnlySectionFlags[3].ReadPointers(binaryReader, blamPointers);
            renderOnlySectionFlags[4].ReadPointers(binaryReader, blamPointers);
            renderOnlySectionFlags[5].ReadPointers(binaryReader, blamPointers);
            renderOnlySectionFlags[6].ReadPointers(binaryReader, blamPointers);
            renderOnlySectionFlags[7].ReadPointers(binaryReader, blamPointers);
            renderOnlySectionFlags[8].ReadPointers(binaryReader, blamPointers);
            renderOnlySectionFlags[9].ReadPointers(binaryReader, blamPointers);
            renderOnlySectionFlags[10].ReadPointers(binaryReader, blamPointers);
            renderOnlySectionFlags[11].ReadPointers(binaryReader, blamPointers);
            renderOnlySectionFlags[12].ReadPointers(binaryReader, blamPointers);
            renderOnlySectionFlags[13].ReadPointers(binaryReader, blamPointers);
            renderOnlySectionFlags[14].ReadPointers(binaryReader, blamPointers);
            renderOnlySectionFlags[15].ReadPointers(binaryReader, blamPointers);
            renderOnlySectionFlags[16].ReadPointers(binaryReader, blamPointers);
            renderOnlySectionFlags[17].ReadPointers(binaryReader, blamPointers);
            renderOnlySectionFlags[18].ReadPointers(binaryReader, blamPointers);
            renderOnlySectionFlags[19].ReadPointers(binaryReader, blamPointers);
            renderOnlySectionFlags[20].ReadPointers(binaryReader, blamPointers);
            renderOnlySectionFlags[21].ReadPointers(binaryReader, blamPointers);
            renderOnlySectionFlags[22].ReadPointers(binaryReader, blamPointers);
            renderOnlySectionFlags[23].ReadPointers(binaryReader, blamPointers);
            renderOnlySectionFlags[24].ReadPointers(binaryReader, blamPointers);
            renderOnlySectionFlags[25].ReadPointers(binaryReader, blamPointers);
            renderOnlySectionFlags[26].ReadPointers(binaryReader, blamPointers);
            renderOnlySectionFlags[27].ReadPointers(binaryReader, blamPointers);
            renderOnlySectionFlags[28].ReadPointers(binaryReader, blamPointers);
            renderOnlySectionFlags[29].ReadPointers(binaryReader, blamPointers);
            renderOnlySectionFlags[30].ReadPointers(binaryReader, blamPointers);
            renderOnlySectionFlags[31].ReadPointers(binaryReader, blamPointers);
            scenarioLoadParameters = ReadBlockArrayData<GlobalScenarioLoadParametersBlock>(binaryReader,
                blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
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
                binaryWriter.Write((Int16) shadowFadeDistance);
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
                binaryWriter.Write((Int32) flags);
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
                binaryWriter.Write((Int32) runtimeFlags);
                nextAddress = Guerilla.WriteBlockArray<GlobalScenarioLoadParametersBlock>(binaryWriter,
                    scenarioLoadParameters, nextAddress);
                binaryWriter.Write(hologramShader);
                binaryWriter.Write(hologramControlFunction);
                return nextAddress;
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

        [LayoutAttribute(Size = 1, Alignment = 1)]
        public class RenderOnlyNodeFlags : GuerillaBlock
        {
            internal byte invalidName_;

            public override int SerializedSize
            {
                get { return 1; }
            }

            public override int Alignment
            {
                get { return 1; }
            }

            public RenderOnlyNodeFlags() : base()
            {
            }

            public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
            {
                var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
                invalidName_ = binaryReader.ReadByte();
                return blamPointers;
            }

            public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
            {
                base.ReadPointers(binaryReader, blamPointers);
            }

            public override int Write(BinaryWriter binaryWriter, int nextAddress)
            {
                base.Write(binaryWriter, nextAddress);
                using (binaryWriter.BaseStream.Pin())
                {
                    binaryWriter.Write(invalidName_);
                    return nextAddress;
                }
            }
        };

        [LayoutAttribute(Size = 1, Alignment = 1)]
        public class RenderOnlySectionFlags : GuerillaBlock
        {
            internal byte invalidName_;

            public override int SerializedSize
            {
                get { return 1; }
            }

            public override int Alignment
            {
                get { return 1; }
            }

            public RenderOnlySectionFlags() : base()
            {
            }

            public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
            {
                var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
                invalidName_ = binaryReader.ReadByte();
                return blamPointers;
            }

            public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
            {
                base.ReadPointers(binaryReader, blamPointers);
            }

            public override int Write(BinaryWriter binaryWriter, int nextAddress)
            {
                base.Write(binaryWriter, nextAddress);
                using (binaryWriter.BaseStream.Pin())
                {
                    binaryWriter.Write(invalidName_);
                    return nextAddress;
                }
            }
        };
    };
}