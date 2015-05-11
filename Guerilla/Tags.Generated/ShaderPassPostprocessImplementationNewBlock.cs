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
    public partial class ShaderPassPostprocessImplementationNewBlock : ShaderPassPostprocessImplementationNewBlockBase
    {
        public ShaderPassPostprocessImplementationNewBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 306, Alignment = 4)]
    public class ShaderPassPostprocessImplementationNewBlockBase : GuerillaBlock
    {
        internal TagBlockIndexStructBlock textures;
        internal TagBlockIndexStructBlock renderStates;
        internal TagBlockIndexStructBlock textureStates;
        internal byte[] invalidName_;
        internal TagBlockIndexStructBlock psFragments;
        internal TagBlockIndexStructBlock psPermutations;
        internal TagBlockIndexStructBlock psCombiners;
        [TagReference("vrtx")] internal Moonfish.Tags.TagReference vertexShader;
        internal byte[] invalidName_0;
        internal byte[] invalidName_1;
        internal byte[] invalidName_2;
        internal byte[] invalidName_3;
        internal TagBlockIndexStructBlock defaultRenderStates;
        internal TagBlockIndexStructBlock renderStateExterns;
        internal TagBlockIndexStructBlock textureStateExterns;
        internal TagBlockIndexStructBlock pixelConstantExterns;
        internal TagBlockIndexStructBlock vertexConstantExterns;
        internal TagBlockIndexStructBlock psConstants;
        internal TagBlockIndexStructBlock vsConstants;
        internal TagBlockIndexStructBlock pixelConstantInfo;
        internal TagBlockIndexStructBlock vertexConstantInfo;
        internal TagBlockIndexStructBlock renderStateInfo;
        internal TagBlockIndexStructBlock textureStateInfo;

        public override int SerializedSize
        {
            get { return 306; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ShaderPassPostprocessImplementationNewBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            textures = new TagBlockIndexStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(textures.ReadFields(binaryReader)));
            renderStates = new TagBlockIndexStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(renderStates.ReadFields(binaryReader)));
            textureStates = new TagBlockIndexStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(textureStates.ReadFields(binaryReader)));
            invalidName_ = binaryReader.ReadBytes(240);
            psFragments = new TagBlockIndexStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(psFragments.ReadFields(binaryReader)));
            psPermutations = new TagBlockIndexStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(psPermutations.ReadFields(binaryReader)));
            psCombiners = new TagBlockIndexStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(psCombiners.ReadFields(binaryReader)));
            vertexShader = binaryReader.ReadTagReference();
            invalidName_0 = binaryReader.ReadBytes(8);
            invalidName_1 = binaryReader.ReadBytes(8);
            invalidName_2 = binaryReader.ReadBytes(4);
            invalidName_3 = binaryReader.ReadBytes(4);
            defaultRenderStates = new TagBlockIndexStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(defaultRenderStates.ReadFields(binaryReader)));
            renderStateExterns = new TagBlockIndexStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(renderStateExterns.ReadFields(binaryReader)));
            textureStateExterns = new TagBlockIndexStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(textureStateExterns.ReadFields(binaryReader)));
            pixelConstantExterns = new TagBlockIndexStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(pixelConstantExterns.ReadFields(binaryReader)));
            vertexConstantExterns = new TagBlockIndexStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(vertexConstantExterns.ReadFields(binaryReader)));
            psConstants = new TagBlockIndexStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(psConstants.ReadFields(binaryReader)));
            vsConstants = new TagBlockIndexStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(vsConstants.ReadFields(binaryReader)));
            pixelConstantInfo = new TagBlockIndexStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(pixelConstantInfo.ReadFields(binaryReader)));
            vertexConstantInfo = new TagBlockIndexStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(vertexConstantInfo.ReadFields(binaryReader)));
            renderStateInfo = new TagBlockIndexStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(renderStateInfo.ReadFields(binaryReader)));
            textureStateInfo = new TagBlockIndexStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(textureStateInfo.ReadFields(binaryReader)));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            textures.ReadPointers(binaryReader, blamPointers);
            renderStates.ReadPointers(binaryReader, blamPointers);
            textureStates.ReadPointers(binaryReader, blamPointers);
            psFragments.ReadPointers(binaryReader, blamPointers);
            psPermutations.ReadPointers(binaryReader, blamPointers);
            psCombiners.ReadPointers(binaryReader, blamPointers);
            defaultRenderStates.ReadPointers(binaryReader, blamPointers);
            renderStateExterns.ReadPointers(binaryReader, blamPointers);
            textureStateExterns.ReadPointers(binaryReader, blamPointers);
            pixelConstantExterns.ReadPointers(binaryReader, blamPointers);
            vertexConstantExterns.ReadPointers(binaryReader, blamPointers);
            psConstants.ReadPointers(binaryReader, blamPointers);
            vsConstants.ReadPointers(binaryReader, blamPointers);
            pixelConstantInfo.ReadPointers(binaryReader, blamPointers);
            vertexConstantInfo.ReadPointers(binaryReader, blamPointers);
            renderStateInfo.ReadPointers(binaryReader, blamPointers);
            textureStateInfo.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                textures.Write(binaryWriter);
                renderStates.Write(binaryWriter);
                textureStates.Write(binaryWriter);
                binaryWriter.Write(invalidName_, 0, 240);
                psFragments.Write(binaryWriter);
                psPermutations.Write(binaryWriter);
                psCombiners.Write(binaryWriter);
                binaryWriter.Write(vertexShader);
                binaryWriter.Write(invalidName_0, 0, 8);
                binaryWriter.Write(invalidName_1, 0, 8);
                binaryWriter.Write(invalidName_2, 0, 4);
                binaryWriter.Write(invalidName_3, 0, 4);
                defaultRenderStates.Write(binaryWriter);
                renderStateExterns.Write(binaryWriter);
                textureStateExterns.Write(binaryWriter);
                pixelConstantExterns.Write(binaryWriter);
                vertexConstantExterns.Write(binaryWriter);
                psConstants.Write(binaryWriter);
                vsConstants.Write(binaryWriter);
                pixelConstantInfo.Write(binaryWriter);
                vertexConstantInfo.Write(binaryWriter);
                renderStateInfo.Write(binaryWriter);
                textureStateInfo.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}