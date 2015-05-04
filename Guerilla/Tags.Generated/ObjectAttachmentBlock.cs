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
    public partial class ObjectAttachmentBlock : ObjectAttachmentBlockBase
    {
        public ObjectAttachmentBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class ObjectAttachmentBlockBase : GuerillaBlock
    {
        [TagReference("null")] internal Moonfish.Tags.TagReference type;
        internal Moonfish.Tags.StringIdent marker;
        internal ChangeColor changeColor;
        internal byte[] invalidName_;
        internal Moonfish.Tags.StringIdent primaryScale;
        internal Moonfish.Tags.StringIdent secondaryScale;

        public override int SerializedSize
        {
            get { return 24; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ObjectAttachmentBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            type = binaryReader.ReadTagReference();
            marker = binaryReader.ReadStringID();
            changeColor = (ChangeColor) binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            primaryScale = binaryReader.ReadStringID();
            secondaryScale = binaryReader.ReadStringID();
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
                binaryWriter.Write(type);
                binaryWriter.Write(marker);
                binaryWriter.Write((Int16) changeColor);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(primaryScale);
                binaryWriter.Write(secondaryScale);
                return nextAddress;
            }
        }

        internal enum ChangeColor : short
        {
            None = 0,
            Primary = 1,
            Secondary = 2,
            Tertiary = 3,
            Quaternary = 4,
        };
    };
}