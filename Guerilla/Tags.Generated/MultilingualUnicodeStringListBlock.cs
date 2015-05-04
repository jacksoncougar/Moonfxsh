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
        public static readonly TagClass Unic = (TagClass)"unic";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("unic")]
    public partial class MultilingualUnicodeStringListBlock : MultilingualUnicodeStringListBlockBase
    {
        public MultilingualUnicodeStringListBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 52, Alignment = 4)]
    public class MultilingualUnicodeStringListBlockBase : GuerillaBlock
    {
        internal MultilingualUnicodeStringReferenceBlock[] stringReferences;
        internal byte[] stringDataUtf8;
        internal byte[] invalidName_;
        public override int SerializedSize { get { return 52; } }
        public override int Alignment { get { return 4; } }
        public MultilingualUnicodeStringListBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<MultilingualUnicodeStringReferenceBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer(binaryReader, 1));
            invalidName_ = binaryReader.ReadBytes(36);
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            stringReferences = ReadBlockArrayData<MultilingualUnicodeStringReferenceBlock>(binaryReader, blamPointers.Dequeue());
            stringDataUtf8 = ReadDataByteArray(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<MultilingualUnicodeStringReferenceBlock>(binaryWriter, stringReferences, nextAddress);
                nextAddress = Guerilla.WriteData(binaryWriter, stringDataUtf8, nextAddress);
                binaryWriter.Write(invalidName_, 0, 36);
                return nextAddress;
            }
        }
    };
}
