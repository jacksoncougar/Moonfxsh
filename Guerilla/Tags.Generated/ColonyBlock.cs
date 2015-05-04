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
        public static readonly TagClass Coln = (TagClass)"coln";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("coln")]
    public partial class ColonyBlock : ColonyBlockBase
    {
        public ColonyBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 60, Alignment = 4)]
    public class ColonyBlockBase : GuerillaBlock
    {
        internal Flags flags;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal Moonfish.Model.Range radius;
        internal byte[] invalidName_1;
        internal OpenTK.Vector4 debugColor;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference baseMap;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference detailMap;
        public override int SerializedSize { get { return 60; } }
        public override int Alignment { get { return 4; } }
        public ColonyBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            flags = (Flags)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            invalidName_0 = binaryReader.ReadBytes(4);
            radius = binaryReader.ReadRange();
            invalidName_1 = binaryReader.ReadBytes(12);
            debugColor = binaryReader.ReadVector4();
            baseMap = binaryReader.ReadTagReference();
            detailMap = binaryReader.ReadTagReference();
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            invalidName_[0].ReadPointers(binaryReader, blamPointers);
            invalidName_[1].ReadPointers(binaryReader, blamPointers);
            invalidName_0[0].ReadPointers(binaryReader, blamPointers);
            invalidName_0[1].ReadPointers(binaryReader, blamPointers);
            invalidName_0[2].ReadPointers(binaryReader, blamPointers);
            invalidName_0[3].ReadPointers(binaryReader, blamPointers);
            invalidName_1[0].ReadPointers(binaryReader, blamPointers);
            invalidName_1[1].ReadPointers(binaryReader, blamPointers);
            invalidName_1[2].ReadPointers(binaryReader, blamPointers);
            invalidName_1[3].ReadPointers(binaryReader, blamPointers);
            invalidName_1[4].ReadPointers(binaryReader, blamPointers);
            invalidName_1[5].ReadPointers(binaryReader, blamPointers);
            invalidName_1[6].ReadPointers(binaryReader, blamPointers);
            invalidName_1[7].ReadPointers(binaryReader, blamPointers);
            invalidName_1[8].ReadPointers(binaryReader, blamPointers);
            invalidName_1[9].ReadPointers(binaryReader, blamPointers);
            invalidName_1[10].ReadPointers(binaryReader, blamPointers);
            invalidName_1[11].ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(invalidName_0, 0, 4);
                binaryWriter.Write(radius);
                binaryWriter.Write(invalidName_1, 0, 12);
                binaryWriter.Write(debugColor);
                binaryWriter.Write(baseMap);
                binaryWriter.Write(detailMap);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : short
        {
            Unused = 1,
        };
    };
}
