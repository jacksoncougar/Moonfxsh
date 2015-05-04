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
    public partial class GrenadesBlock : GrenadesBlockBase
    {
        public GrenadesBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 44, Alignment = 4)]
    public class GrenadesBlockBase : GuerillaBlock
    {
        internal short maximumCount;
        internal byte[] invalidName_;
        [TagReference("effe")]
        internal Moonfish.Tags.TagReference throwingEffect;
        internal byte[] invalidName_0;
        [TagReference("eqip")]
        internal Moonfish.Tags.TagReference equipment;
        [TagReference("proj")]
        internal Moonfish.Tags.TagReference projectile;
        public override int SerializedSize { get { return 44; } }
        public override int Alignment { get { return 4; } }
        public GrenadesBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            maximumCount = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            throwingEffect = binaryReader.ReadTagReference();
            invalidName_0 = binaryReader.ReadBytes(16);
            equipment = binaryReader.ReadTagReference();
            projectile = binaryReader.ReadTagReference();
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
            invalidName_0[4].ReadPointers(binaryReader, blamPointers);
            invalidName_0[5].ReadPointers(binaryReader, blamPointers);
            invalidName_0[6].ReadPointers(binaryReader, blamPointers);
            invalidName_0[7].ReadPointers(binaryReader, blamPointers);
            invalidName_0[8].ReadPointers(binaryReader, blamPointers);
            invalidName_0[9].ReadPointers(binaryReader, blamPointers);
            invalidName_0[10].ReadPointers(binaryReader, blamPointers);
            invalidName_0[11].ReadPointers(binaryReader, blamPointers);
            invalidName_0[12].ReadPointers(binaryReader, blamPointers);
            invalidName_0[13].ReadPointers(binaryReader, blamPointers);
            invalidName_0[14].ReadPointers(binaryReader, blamPointers);
            invalidName_0[15].ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(maximumCount);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(throwingEffect);
                binaryWriter.Write(invalidName_0, 0, 16);
                binaryWriter.Write(equipment);
                binaryWriter.Write(projectile);
                return nextAddress;
            }
        }
    };
}
