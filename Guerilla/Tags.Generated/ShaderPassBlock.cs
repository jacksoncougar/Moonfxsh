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
        public static readonly TagClass Spas = (TagClass)"spas";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("spas")]
    public partial class ShaderPassBlock : ShaderPassBlockBase
    {
        public ShaderPassBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 36, Alignment = 4)]
    public class ShaderPassBlockBase : GuerillaBlock
    {
        internal byte[] documentation;
        internal ShaderPassParameterBlock[] parameters;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal ShaderPassImplementationBlock[] implementations;
        internal ShaderPassPostprocessDefinitionNewBlock[] postprocessDefinition;
        public override int SerializedSize { get { return 36; } }
        public override int Alignment { get { return 4; } }
        public ShaderPassBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer(binaryReader, 1));
            blamPointers.Enqueue(ReadBlockArrayPointer<ShaderPassParameterBlock>(binaryReader));
            invalidName_ = binaryReader.ReadBytes(2);
            invalidName_0 = binaryReader.ReadBytes(2);
            blamPointers.Enqueue(ReadBlockArrayPointer<ShaderPassImplementationBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ShaderPassPostprocessDefinitionNewBlock>(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            documentation = ReadDataByteArray(binaryReader, blamPointers.Dequeue());
            parameters = ReadBlockArrayData<ShaderPassParameterBlock>(binaryReader, blamPointers.Dequeue());
            implementations = ReadBlockArrayData<ShaderPassImplementationBlock>(binaryReader, blamPointers.Dequeue());
            postprocessDefinition = ReadBlockArrayData<ShaderPassPostprocessDefinitionNewBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteData(binaryWriter, documentation, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ShaderPassParameterBlock>(binaryWriter, parameters, nextAddress);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(invalidName_0, 0, 2);
                nextAddress = Guerilla.WriteBlockArray<ShaderPassImplementationBlock>(binaryWriter, implementations, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ShaderPassPostprocessDefinitionNewBlock>(binaryWriter, postprocessDefinition, nextAddress);
                return nextAddress;
            }
        }
    };
}
