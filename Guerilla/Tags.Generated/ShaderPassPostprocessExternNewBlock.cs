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
    public partial class ShaderPassPostprocessExternNewBlock : ShaderPassPostprocessExternNewBlockBase
    {
        public ShaderPassPostprocessExternNewBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class ShaderPassPostprocessExternNewBlockBase : GuerillaBlock
    {
        internal byte[] invalidName_;
        internal byte externIndex;
        public override int SerializedSize { get { return 4; } }
        public override int Alignment { get { return 4; } }
        public ShaderPassPostprocessExternNewBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            invalidName_ = binaryReader.ReadBytes(3);
            externIndex = binaryReader.ReadByte();
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            invalidName_[0].ReadPointers(binaryReader, blamPointers);
            invalidName_[1].ReadPointers(binaryReader, blamPointers);
            invalidName_[2].ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_, 0, 3);
                binaryWriter.Write(externIndex);
                return nextAddress;
            }
        }
    };
}
