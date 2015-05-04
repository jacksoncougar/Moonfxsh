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
    public partial class ShaderPassPostprocessDefinitionNewBlock : ShaderPassPostprocessDefinitionNewBlockBase
    {
        public ShaderPassPostprocessDefinitionNewBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 88, Alignment = 4)]
    public class ShaderPassPostprocessDefinitionNewBlockBase : GuerillaBlock
    {
        internal ShaderPassPostprocessImplementationNewBlock[] implementations;
        internal ShaderPassPostprocessTextureNewBlock[] textures;
        internal RenderStateBlock[] renderStates;
        internal ShaderPassPostprocessTextureStateBlock[] textureStates;
        internal PixelShaderFragmentBlock[] psFragments;
        internal PixelShaderPermutationNewBlock[] psPermutations;
        internal PixelShaderCombinerBlock[] psCombiners;
        internal ShaderPassPostprocessExternNewBlock[] externs;
        internal ShaderPassPostprocessConstantNewBlock[] constants;
        internal ShaderPassPostprocessConstantInfoNewBlock[] constantInfo;
        internal ShaderPassPostprocessImplementationBlock[] oldImplementations;

        public override int SerializedSize
        {
            get { return 88; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ShaderPassPostprocessDefinitionNewBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ShaderPassPostprocessImplementationNewBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ShaderPassPostprocessTextureNewBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<RenderStateBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ShaderPassPostprocessTextureStateBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<PixelShaderFragmentBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<PixelShaderPermutationNewBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<PixelShaderCombinerBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ShaderPassPostprocessExternNewBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ShaderPassPostprocessConstantNewBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ShaderPassPostprocessConstantInfoNewBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ShaderPassPostprocessImplementationBlock>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            implementations = ReadBlockArrayData<ShaderPassPostprocessImplementationNewBlock>(binaryReader,
                blamPointers.Dequeue());
            textures = ReadBlockArrayData<ShaderPassPostprocessTextureNewBlock>(binaryReader, blamPointers.Dequeue());
            renderStates = ReadBlockArrayData<RenderStateBlock>(binaryReader, blamPointers.Dequeue());
            textureStates = ReadBlockArrayData<ShaderPassPostprocessTextureStateBlock>(binaryReader,
                blamPointers.Dequeue());
            psFragments = ReadBlockArrayData<PixelShaderFragmentBlock>(binaryReader, blamPointers.Dequeue());
            psPermutations = ReadBlockArrayData<PixelShaderPermutationNewBlock>(binaryReader, blamPointers.Dequeue());
            psCombiners = ReadBlockArrayData<PixelShaderCombinerBlock>(binaryReader, blamPointers.Dequeue());
            externs = ReadBlockArrayData<ShaderPassPostprocessExternNewBlock>(binaryReader, blamPointers.Dequeue());
            constants = ReadBlockArrayData<ShaderPassPostprocessConstantNewBlock>(binaryReader, blamPointers.Dequeue());
            constantInfo = ReadBlockArrayData<ShaderPassPostprocessConstantInfoNewBlock>(binaryReader,
                blamPointers.Dequeue());
            oldImplementations = ReadBlockArrayData<ShaderPassPostprocessImplementationBlock>(binaryReader,
                blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<ShaderPassPostprocessImplementationNewBlock>(binaryWriter,
                    implementations, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ShaderPassPostprocessTextureNewBlock>(binaryWriter, textures,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<RenderStateBlock>(binaryWriter, renderStates, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ShaderPassPostprocessTextureStateBlock>(binaryWriter,
                    textureStates, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<PixelShaderFragmentBlock>(binaryWriter, psFragments, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<PixelShaderPermutationNewBlock>(binaryWriter, psPermutations,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<PixelShaderCombinerBlock>(binaryWriter, psCombiners, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ShaderPassPostprocessExternNewBlock>(binaryWriter, externs,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ShaderPassPostprocessConstantNewBlock>(binaryWriter, constants,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ShaderPassPostprocessConstantInfoNewBlock>(binaryWriter,
                    constantInfo, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ShaderPassPostprocessImplementationBlock>(binaryWriter,
                    oldImplementations, nextAddress);
                return nextAddress;
            }
        }
    };
}