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
    public partial class ShaderGpuStateStructBlock : ShaderGpuStateStructBlockBase
    {
        public ShaderGpuStateStructBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 56, Alignment = 4)]
    public class ShaderGpuStateStructBlockBase : GuerillaBlock
    {
        internal RenderStateBlock[] renderStates;
        internal TextureStageStateBlock[] textureStageStates;
        internal RenderStateParameterBlock[] renderStateParameters;
        internal TextureStageStateParameterBlock[] textureStageParameters;
        internal TextureBlock[] textures;
        internal VertexShaderConstantBlock[] vnConstants;
        internal VertexShaderConstantBlock[] cnConstants;

        public override int SerializedSize
        {
            get { return 56; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ShaderGpuStateStructBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<RenderStateBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<TextureStageStateBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<RenderStateParameterBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<TextureStageStateParameterBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<TextureBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<VertexShaderConstantBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<VertexShaderConstantBlock>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            renderStates = ReadBlockArrayData<RenderStateBlock>(binaryReader, blamPointers.Dequeue());
            textureStageStates = ReadBlockArrayData<TextureStageStateBlock>(binaryReader, blamPointers.Dequeue());
            renderStateParameters = ReadBlockArrayData<RenderStateParameterBlock>(binaryReader, blamPointers.Dequeue());
            textureStageParameters = ReadBlockArrayData<TextureStageStateParameterBlock>(binaryReader,
                blamPointers.Dequeue());
            textures = ReadBlockArrayData<TextureBlock>(binaryReader, blamPointers.Dequeue());
            vnConstants = ReadBlockArrayData<VertexShaderConstantBlock>(binaryReader, blamPointers.Dequeue());
            cnConstants = ReadBlockArrayData<VertexShaderConstantBlock>(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<RenderStateBlock>(binaryWriter, renderStates, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<TextureStageStateBlock>(binaryWriter, textureStageStates,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<RenderStateParameterBlock>(binaryWriter, renderStateParameters,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<TextureStageStateParameterBlock>(binaryWriter,
                    textureStageParameters, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<TextureBlock>(binaryWriter, textures, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<VertexShaderConstantBlock>(binaryWriter, vnConstants, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<VertexShaderConstantBlock>(binaryWriter, cnConstants, nextAddress);
                return nextAddress;
            }
        }
    };
}