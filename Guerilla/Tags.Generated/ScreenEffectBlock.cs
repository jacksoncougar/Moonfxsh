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
        public static readonly TagClass Egor = (TagClass)"egor";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("egor")]
    public partial class ScreenEffectBlock : ScreenEffectBlockBase
    {
        public ScreenEffectBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 144, Alignment = 4)]
    public class ScreenEffectBlockBase : GuerillaBlock
    {
        internal byte[] invalidName_;
        [TagReference("shad")]
        internal Moonfish.Tags.TagReference shader;
        internal byte[] invalidName_0;
        internal RasterizerScreenEffectPassReferenceBlock[] passReferences;
        public override int SerializedSize { get { return 144; } }
        public override int Alignment { get { return 4; } }
        public ScreenEffectBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            invalidName_ = binaryReader.ReadBytes(64);
            shader = binaryReader.ReadTagReference();
            invalidName_0 = binaryReader.ReadBytes(64);
            blamPointers.Enqueue(ReadBlockArrayPointer<RasterizerScreenEffectPassReferenceBlock>(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            passReferences = ReadBlockArrayData<RasterizerScreenEffectPassReferenceBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_, 0, 64);
                binaryWriter.Write(shader);
                binaryWriter.Write(invalidName_0, 0, 64);
                nextAddress = Guerilla.WriteBlockArray<RasterizerScreenEffectPassReferenceBlock>(binaryWriter, passReferences, nextAddress);
                return nextAddress;
            }
        }
    };
}
