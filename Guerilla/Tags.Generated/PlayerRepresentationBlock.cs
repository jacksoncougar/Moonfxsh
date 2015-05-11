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
    public partial class PlayerRepresentationBlock : PlayerRepresentationBlockBase
    {
        public PlayerRepresentationBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 188, Alignment = 4)]
    public class PlayerRepresentationBlockBase : GuerillaBlock
    {
        [TagReference("mode")] internal Moonfish.Tags.TagReference firstPersonHands;
        [TagReference("mode")] internal Moonfish.Tags.TagReference firstPersonBody;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        [TagReference("unit")] internal Moonfish.Tags.TagReference thirdPersonUnit;
        internal Moonfish.Tags.StringIdent thirdPersonVariant;

        public override int SerializedSize
        {
            get { return 188; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public PlayerRepresentationBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            firstPersonHands = binaryReader.ReadTagReference();
            firstPersonBody = binaryReader.ReadTagReference();
            invalidName_ = binaryReader.ReadBytes(40);
            invalidName_0 = binaryReader.ReadBytes(120);
            thirdPersonUnit = binaryReader.ReadTagReference();
            thirdPersonVariant = binaryReader.ReadStringID();
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(firstPersonHands);
                binaryWriter.Write(firstPersonBody);
                binaryWriter.Write(invalidName_, 0, 40);
                binaryWriter.Write(invalidName_0, 0, 120);
                binaryWriter.Write(thirdPersonUnit);
                binaryWriter.Write(thirdPersonVariant);
                return nextAddress;
            }
        }
    };
}