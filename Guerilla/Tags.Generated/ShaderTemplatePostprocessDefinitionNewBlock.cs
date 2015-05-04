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
    public partial class ShaderTemplatePostprocessDefinitionNewBlock : ShaderTemplatePostprocessDefinitionNewBlockBase
    {
        public ShaderTemplatePostprocessDefinitionNewBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 40, Alignment = 4)]
    public class ShaderTemplatePostprocessDefinitionNewBlockBase : GuerillaBlock
    {
        internal ShaderTemplatePostprocessLevelOfDetailNewBlock[] levelsOfDetail;
        internal TagBlockIndexBlock[] layers;
        internal ShaderTemplatePostprocessPassNewBlock[] passes;
        internal ShaderTemplatePostprocessImplementationNewBlock[] implementations;
        internal ShaderTemplatePostprocessRemappingNewBlock[] remappings;

        public override int SerializedSize
        {
            get { return 40; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ShaderTemplatePostprocessDefinitionNewBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ShaderTemplatePostprocessLevelOfDetailNewBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<TagBlockIndexBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ShaderTemplatePostprocessPassNewBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ShaderTemplatePostprocessImplementationNewBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ShaderTemplatePostprocessRemappingNewBlock>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            levelsOfDetail = ReadBlockArrayData<ShaderTemplatePostprocessLevelOfDetailNewBlock>(binaryReader,
                blamPointers.Dequeue());
            layers = ReadBlockArrayData<TagBlockIndexBlock>(binaryReader, blamPointers.Dequeue());
            passes = ReadBlockArrayData<ShaderTemplatePostprocessPassNewBlock>(binaryReader, blamPointers.Dequeue());
            implementations = ReadBlockArrayData<ShaderTemplatePostprocessImplementationNewBlock>(binaryReader,
                blamPointers.Dequeue());
            remappings = ReadBlockArrayData<ShaderTemplatePostprocessRemappingNewBlock>(binaryReader,
                blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<ShaderTemplatePostprocessLevelOfDetailNewBlock>(binaryWriter,
                    levelsOfDetail, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<TagBlockIndexBlock>(binaryWriter, layers, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ShaderTemplatePostprocessPassNewBlock>(binaryWriter, passes,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ShaderTemplatePostprocessImplementationNewBlock>(binaryWriter,
                    implementations, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ShaderTemplatePostprocessRemappingNewBlock>(binaryWriter,
                    remappings, nextAddress);
                return nextAddress;
            }
        }
    };
}