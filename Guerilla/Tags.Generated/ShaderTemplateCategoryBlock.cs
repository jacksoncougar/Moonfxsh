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
    public partial class ShaderTemplateCategoryBlock : ShaderTemplateCategoryBlockBase
    {
        public ShaderTemplateCategoryBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class ShaderTemplateCategoryBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent name;
        internal ShaderTemplateParameterBlock[] parameters;

        public override int SerializedSize
        {
            get { return 12; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ShaderTemplateCategoryBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            name = binaryReader.ReadStringID();
            blamPointers.Enqueue(ReadBlockArrayPointer<ShaderTemplateParameterBlock>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            parameters = ReadBlockArrayData<ShaderTemplateParameterBlock>(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                nextAddress = Guerilla.WriteBlockArray<ShaderTemplateParameterBlock>(binaryWriter, parameters,
                    nextAddress);
                return nextAddress;
            }
        }
    };
}