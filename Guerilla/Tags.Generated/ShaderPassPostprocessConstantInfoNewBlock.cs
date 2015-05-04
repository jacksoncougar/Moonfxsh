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
    public partial class ShaderPassPostprocessConstantInfoNewBlock : ShaderPassPostprocessConstantInfoNewBlockBase
    {
        public ShaderPassPostprocessConstantInfoNewBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 7, Alignment = 4)]
    public class ShaderPassPostprocessConstantInfoNewBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent parameterName;
        internal byte[] invalidName_;
        public override int SerializedSize { get { return 7; } }
        public override int Alignment { get { return 4; } }
        public ShaderPassPostprocessConstantInfoNewBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            parameterName = binaryReader.ReadStringID();
            invalidName_ = binaryReader.ReadBytes(3);
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(parameterName);
                binaryWriter.Write(invalidName_, 0, 3);
                return nextAddress;
            }
        }
    };
}
