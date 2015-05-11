// ReSharper disable All

using Moonfish.Model;

using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class ShaderPostprocessLevelOfDetailBlock : ShaderPostprocessLevelOfDetailBlockBase
    {
        public ShaderPostprocessLevelOfDetailBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 152, Alignment = 4)]
    public class ShaderPostprocessLevelOfDetailBlockBase : GuerillaBlock
    {
        internal float projectedHeightPercentage;
        internal int availableLayers;
        internal ShaderPostprocessLayerBlock[] layers;
        internal ShaderPostprocessPassBlock[] passes;
        internal ShaderPostprocessImplementationBlock[] implementations;
        internal ShaderPostprocessBitmapBlock[] bitmaps;
        internal ShaderPostprocessBitmapTransformBlock[] bitmapTransforms;
        internal ShaderPostprocessValueBlock[] values;
        internal ShaderPostprocessColorBlock[] colors;
        internal ShaderPostprocessBitmapTransformOverlayBlock[] bitmapTransformOverlays;
        internal ShaderPostprocessValueOverlayBlock[] valueOverlays;
        internal ShaderPostprocessColorOverlayBlock[] colorOverlays;
        internal ShaderPostprocessVertexShaderConstantBlock[] vertexShaderConstants;
        internal ShaderGpuStateStructBlock gPUState;

        public override int SerializedSize
        {
            get { return 152; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ShaderPostprocessLevelOfDetailBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            projectedHeightPercentage = binaryReader.ReadSingle();
            availableLayers = binaryReader.ReadInt32();
            blamPointers.Enqueue(ReadBlockArrayPointer<ShaderPostprocessLayerBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ShaderPostprocessPassBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ShaderPostprocessImplementationBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ShaderPostprocessBitmapBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ShaderPostprocessBitmapTransformBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ShaderPostprocessValueBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ShaderPostprocessColorBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ShaderPostprocessBitmapTransformOverlayBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ShaderPostprocessValueOverlayBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ShaderPostprocessColorOverlayBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ShaderPostprocessVertexShaderConstantBlock>(binaryReader));
            gPUState = new ShaderGpuStateStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(gPUState.ReadFields(binaryReader)));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            layers = ReadBlockArrayData<ShaderPostprocessLayerBlock>(binaryReader, blamPointers.Dequeue());
            passes = ReadBlockArrayData<ShaderPostprocessPassBlock>(binaryReader, blamPointers.Dequeue());
            implementations = ReadBlockArrayData<ShaderPostprocessImplementationBlock>(binaryReader,
                blamPointers.Dequeue());
            bitmaps = ReadBlockArrayData<ShaderPostprocessBitmapBlock>(binaryReader, blamPointers.Dequeue());
            bitmapTransforms = ReadBlockArrayData<ShaderPostprocessBitmapTransformBlock>(binaryReader,
                blamPointers.Dequeue());
            values = ReadBlockArrayData<ShaderPostprocessValueBlock>(binaryReader, blamPointers.Dequeue());
            colors = ReadBlockArrayData<ShaderPostprocessColorBlock>(binaryReader, blamPointers.Dequeue());
            bitmapTransformOverlays = ReadBlockArrayData<ShaderPostprocessBitmapTransformOverlayBlock>(binaryReader,
                blamPointers.Dequeue());
            valueOverlays = ReadBlockArrayData<ShaderPostprocessValueOverlayBlock>(binaryReader, blamPointers.Dequeue());
            colorOverlays = ReadBlockArrayData<ShaderPostprocessColorOverlayBlock>(binaryReader, blamPointers.Dequeue());
            vertexShaderConstants = ReadBlockArrayData<ShaderPostprocessVertexShaderConstantBlock>(binaryReader,
                blamPointers.Dequeue());
            gPUState.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(projectedHeightPercentage);
                binaryWriter.Write(availableLayers);
                nextAddress = Guerilla.WriteBlockArray<ShaderPostprocessLayerBlock>(binaryWriter, layers, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ShaderPostprocessPassBlock>(binaryWriter, passes, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ShaderPostprocessImplementationBlock>(binaryWriter,
                    implementations, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ShaderPostprocessBitmapBlock>(binaryWriter, bitmaps, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ShaderPostprocessBitmapTransformBlock>(binaryWriter,
                    bitmapTransforms, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ShaderPostprocessValueBlock>(binaryWriter, values, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ShaderPostprocessColorBlock>(binaryWriter, colors, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ShaderPostprocessBitmapTransformOverlayBlock>(binaryWriter,
                    bitmapTransformOverlays, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ShaderPostprocessValueOverlayBlock>(binaryWriter, valueOverlays,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ShaderPostprocessColorOverlayBlock>(binaryWriter, colorOverlays,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ShaderPostprocessVertexShaderConstantBlock>(binaryWriter,
                    vertexShaderConstants, nextAddress);
                gPUState.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}