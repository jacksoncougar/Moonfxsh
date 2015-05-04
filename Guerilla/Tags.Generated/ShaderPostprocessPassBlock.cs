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
    public partial class ShaderPostprocessPassBlock : ShaderPostprocessPassBlockBase
    {
        public ShaderPostprocessPassBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 10, Alignment = 4)]
    public class ShaderPostprocessPassBlockBase : GuerillaBlock
    {
        [TagReference("spas")]
        internal Moonfish.Tags.TagReference shaderPass;
        internal TagBlockIndexStructBlock implementations;
        public override int SerializedSize { get { return 10; } }
        public override int Alignment { get { return 4; } }
        public ShaderPostprocessPassBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            shaderPass = binaryReader.ReadTagReference();
            implementations = new TagBlockIndexStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(implementations.ReadFields(binaryReader)));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            implementations.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(shaderPass);
                implementations.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
