// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class ShaderPassPostprocessImplementationBlock : ShaderPassPostprocessImplementationBlockBase
    {
        public ShaderPassPostprocessImplementationBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 438, Alignment = 4)]
    public class ShaderPassPostprocessImplementationBlockBase : GuerillaBlock
    {
        internal ShaderGpuStateStructBlock gPUState;
        internal ShaderGpuStateReferenceStructBlock gPUConstantState;
        internal ShaderGpuStateReferenceStructBlock gPUVolatileState;
        internal ShaderGpuStateReferenceStructBlock gPUDefaultState;
        [TagReference("vrtx")]
        internal Moonfish.Tags.TagReference vertexShader;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal byte[] invalidName_1;
        internal byte[] invalidName_2;
        internal ExternReferenceBlock[] valueExterns;
        internal ExternReferenceBlock[] colorExterns;
        internal ExternReferenceBlock[] switchExterns;
        internal short bitmapParameterCount;
        internal byte[] invalidName_3;
        internal byte[] invalidName_4;
        internal PixelShaderFragmentBlock[] pixelShaderFragments;
        internal PixelShaderPermutationBlock[] pixelShaderPermutations;
        internal PixelShaderCombinerBlock[] pixelShaderCombiners;
        internal PixelShaderConstantBlock[] pixelShaderConstants;
        internal byte[] invalidName_5;
        internal byte[] invalidName_6;
        public override int SerializedSize { get { return 438; } }
        public override int Alignment { get { return 4; } }
        public ShaderPassPostprocessImplementationBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            gPUState = new ShaderGpuStateStructBlock();
            blamPointers.Concat(gPUState.ReadFields(binaryReader));
            gPUConstantState = new ShaderGpuStateReferenceStructBlock();
            blamPointers.Concat(gPUConstantState.ReadFields(binaryReader));
            gPUVolatileState = new ShaderGpuStateReferenceStructBlock();
            blamPointers.Concat(gPUVolatileState.ReadFields(binaryReader));
            gPUDefaultState = new ShaderGpuStateReferenceStructBlock();
            blamPointers.Concat(gPUDefaultState.ReadFields(binaryReader));
            vertexShader = binaryReader.ReadTagReference();
            invalidName_ = binaryReader.ReadBytes(8);
            invalidName_0 = binaryReader.ReadBytes(8);
            invalidName_1 = binaryReader.ReadBytes(4);
            invalidName_2 = binaryReader.ReadBytes(4);
            blamPointers.Enqueue(ReadBlockArrayPointer<ExternReferenceBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ExternReferenceBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ExternReferenceBlock>(binaryReader));
            bitmapParameterCount = binaryReader.ReadInt16();
            invalidName_3 = binaryReader.ReadBytes(2);
            invalidName_4 = binaryReader.ReadBytes(240);
            blamPointers.Enqueue(ReadBlockArrayPointer<PixelShaderFragmentBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<PixelShaderPermutationBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<PixelShaderCombinerBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<PixelShaderConstantBlock>(binaryReader));
            invalidName_5 = binaryReader.ReadBytes(4);
            invalidName_6 = binaryReader.ReadBytes(4);
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            gPUState.ReadPointers(binaryReader, blamPointers);
            gPUConstantState.ReadPointers(binaryReader, blamPointers);
            gPUVolatileState.ReadPointers(binaryReader, blamPointers);
            gPUDefaultState.ReadPointers(binaryReader, blamPointers);
            valueExterns = ReadBlockArrayData<ExternReferenceBlock>(binaryReader, blamPointers.Dequeue());
            colorExterns = ReadBlockArrayData<ExternReferenceBlock>(binaryReader, blamPointers.Dequeue());
            switchExterns = ReadBlockArrayData<ExternReferenceBlock>(binaryReader, blamPointers.Dequeue());
            pixelShaderFragments = ReadBlockArrayData<PixelShaderFragmentBlock>(binaryReader, blamPointers.Dequeue());
            pixelShaderPermutations = ReadBlockArrayData<PixelShaderPermutationBlock>(binaryReader, blamPointers.Dequeue());
            pixelShaderCombiners = ReadBlockArrayData<PixelShaderCombinerBlock>(binaryReader, blamPointers.Dequeue());
            pixelShaderConstants = ReadBlockArrayData<PixelShaderConstantBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                gPUState.Write(binaryWriter);
                gPUConstantState.Write(binaryWriter);
                gPUVolatileState.Write(binaryWriter);
                gPUDefaultState.Write(binaryWriter);
                binaryWriter.Write(vertexShader);
                binaryWriter.Write(invalidName_, 0, 8);
                binaryWriter.Write(invalidName_0, 0, 8);
                binaryWriter.Write(invalidName_1, 0, 4);
                binaryWriter.Write(invalidName_2, 0, 4);
                nextAddress = Guerilla.WriteBlockArray<ExternReferenceBlock>(binaryWriter, valueExterns, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ExternReferenceBlock>(binaryWriter, colorExterns, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ExternReferenceBlock>(binaryWriter, switchExterns, nextAddress);
                binaryWriter.Write(bitmapParameterCount);
                binaryWriter.Write(invalidName_3, 0, 2);
                binaryWriter.Write(invalidName_4, 0, 240);
                nextAddress = Guerilla.WriteBlockArray<PixelShaderFragmentBlock>(binaryWriter, pixelShaderFragments, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<PixelShaderPermutationBlock>(binaryWriter, pixelShaderPermutations, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<PixelShaderCombinerBlock>(binaryWriter, pixelShaderCombiners, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<PixelShaderConstantBlock>(binaryWriter, pixelShaderConstants, nextAddress);
                binaryWriter.Write(invalidName_5, 0, 4);
                binaryWriter.Write(invalidName_6, 0, 4);
                return nextAddress;
            }
        }
    };
}
