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
    public partial class ShaderPostprocessDefinitionNewBlock : ShaderPostprocessDefinitionNewBlockBase
    {
        public ShaderPostprocessDefinitionNewBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 124, Alignment = 4)]
    public class ShaderPostprocessDefinitionNewBlockBase : GuerillaBlock
    {
        internal int shaderTemplateIndex;
        internal ShaderPostprocessBitmapNewBlock[] bitmaps;
        internal Pixel32Block[] pixelConstants;
        internal RealVector4dBlock[] vertexConstants;
        internal ShaderPostprocessLevelOfDetailNewBlock[] levelsOfDetail;
        internal TagBlockIndexBlock[] layers;
        internal TagBlockIndexBlock[] passes;
        internal ShaderPostprocessImplementationNewBlock[] implementations;
        internal ShaderPostprocessOverlayNewBlock[] overlays;
        internal ShaderPostprocessOverlayReferenceNewBlock[] overlayReferences;
        internal ShaderPostprocessAnimatedParameterNewBlock[] animatedParameters;
        internal ShaderPostprocessAnimatedParameterReferenceNewBlock[] animatedParameterReferences;
        internal ShaderPostprocessBitmapPropertyBlock[] bitmapProperties;
        internal ShaderPostprocessColorPropertyBlock[] colorProperties;
        internal ShaderPostprocessValuePropertyBlock[] valueProperties;
        internal ShaderPostprocessLevelOfDetailBlock[] oldLevelsOfDetail;

        public override int SerializedSize
        {
            get { return 124; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ShaderPostprocessDefinitionNewBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            shaderTemplateIndex = binaryReader.ReadInt32();
            blamPointers.Enqueue(ReadBlockArrayPointer<ShaderPostprocessBitmapNewBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<Pixel32Block>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<RealVector4dBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ShaderPostprocessLevelOfDetailNewBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<TagBlockIndexBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<TagBlockIndexBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ShaderPostprocessImplementationNewBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ShaderPostprocessOverlayNewBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ShaderPostprocessOverlayReferenceNewBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ShaderPostprocessAnimatedParameterNewBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ShaderPostprocessAnimatedParameterReferenceNewBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ShaderPostprocessBitmapPropertyBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ShaderPostprocessColorPropertyBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ShaderPostprocessValuePropertyBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ShaderPostprocessLevelOfDetailBlock>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            bitmaps = ReadBlockArrayData<ShaderPostprocessBitmapNewBlock>(binaryReader, blamPointers.Dequeue());
            pixelConstants = ReadBlockArrayData<Pixel32Block>(binaryReader, blamPointers.Dequeue());
            vertexConstants = ReadBlockArrayData<RealVector4dBlock>(binaryReader, blamPointers.Dequeue());
            levelsOfDetail = ReadBlockArrayData<ShaderPostprocessLevelOfDetailNewBlock>(binaryReader,
                blamPointers.Dequeue());
            layers = ReadBlockArrayData<TagBlockIndexBlock>(binaryReader, blamPointers.Dequeue());
            passes = ReadBlockArrayData<TagBlockIndexBlock>(binaryReader, blamPointers.Dequeue());
            implementations = ReadBlockArrayData<ShaderPostprocessImplementationNewBlock>(binaryReader,
                blamPointers.Dequeue());
            overlays = ReadBlockArrayData<ShaderPostprocessOverlayNewBlock>(binaryReader, blamPointers.Dequeue());
            overlayReferences = ReadBlockArrayData<ShaderPostprocessOverlayReferenceNewBlock>(binaryReader,
                blamPointers.Dequeue());
            animatedParameters = ReadBlockArrayData<ShaderPostprocessAnimatedParameterNewBlock>(binaryReader,
                blamPointers.Dequeue());
            animatedParameterReferences =
                ReadBlockArrayData<ShaderPostprocessAnimatedParameterReferenceNewBlock>(binaryReader,
                    blamPointers.Dequeue());
            bitmapProperties = ReadBlockArrayData<ShaderPostprocessBitmapPropertyBlock>(binaryReader,
                blamPointers.Dequeue());
            colorProperties = ReadBlockArrayData<ShaderPostprocessColorPropertyBlock>(binaryReader,
                blamPointers.Dequeue());
            valueProperties = ReadBlockArrayData<ShaderPostprocessValuePropertyBlock>(binaryReader,
                blamPointers.Dequeue());
            oldLevelsOfDetail = ReadBlockArrayData<ShaderPostprocessLevelOfDetailBlock>(binaryReader,
                blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(shaderTemplateIndex);
                nextAddress = Guerilla.WriteBlockArray<ShaderPostprocessBitmapNewBlock>(binaryWriter, bitmaps,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<Pixel32Block>(binaryWriter, pixelConstants, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<RealVector4dBlock>(binaryWriter, vertexConstants, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ShaderPostprocessLevelOfDetailNewBlock>(binaryWriter,
                    levelsOfDetail, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<TagBlockIndexBlock>(binaryWriter, layers, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<TagBlockIndexBlock>(binaryWriter, passes, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ShaderPostprocessImplementationNewBlock>(binaryWriter,
                    implementations, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ShaderPostprocessOverlayNewBlock>(binaryWriter, overlays,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ShaderPostprocessOverlayReferenceNewBlock>(binaryWriter,
                    overlayReferences, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ShaderPostprocessAnimatedParameterNewBlock>(binaryWriter,
                    animatedParameters, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ShaderPostprocessAnimatedParameterReferenceNewBlock>(
                    binaryWriter, animatedParameterReferences, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ShaderPostprocessBitmapPropertyBlock>(binaryWriter,
                    bitmapProperties, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ShaderPostprocessColorPropertyBlock>(binaryWriter,
                    colorProperties, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ShaderPostprocessValuePropertyBlock>(binaryWriter,
                    valueProperties, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ShaderPostprocessLevelOfDetailBlock>(binaryWriter,
                    oldLevelsOfDetail, nextAddress);
                return nextAddress;
            }
        }
    };
}