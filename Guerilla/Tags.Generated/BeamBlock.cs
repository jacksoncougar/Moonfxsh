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
    public partial class BeamBlock : BeamBlockBase
    {
        public BeamBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 60, Alignment = 4)]
    public class BeamBlockBase : GuerillaBlock
    {
        [TagReference("shad")] internal Moonfish.Tags.TagReference shader;
        internal Moonfish.Tags.ShortBlockIndex1 location;
        internal byte[] invalidName_;
        internal ColorFunctionStructBlock color;
        internal ScalarFunctionStructBlock alpha;
        internal ScalarFunctionStructBlock width;
        internal ScalarFunctionStructBlock length;
        internal ScalarFunctionStructBlock yaw;
        internal ScalarFunctionStructBlock pitch;

        public override int SerializedSize
        {
            get { return 60; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public BeamBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            shader = binaryReader.ReadTagReference();
            location = binaryReader.ReadShortBlockIndex1();
            invalidName_ = binaryReader.ReadBytes(2);
            color = new ColorFunctionStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(color.ReadFields(binaryReader)));
            alpha = new ScalarFunctionStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(alpha.ReadFields(binaryReader)));
            width = new ScalarFunctionStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(width.ReadFields(binaryReader)));
            length = new ScalarFunctionStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(length.ReadFields(binaryReader)));
            yaw = new ScalarFunctionStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(yaw.ReadFields(binaryReader)));
            pitch = new ScalarFunctionStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(pitch.ReadFields(binaryReader)));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            color.ReadPointers(binaryReader, blamPointers);
            alpha.ReadPointers(binaryReader, blamPointers);
            width.ReadPointers(binaryReader, blamPointers);
            length.ReadPointers(binaryReader, blamPointers);
            yaw.ReadPointers(binaryReader, blamPointers);
            pitch.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(shader);
                binaryWriter.Write(location);
                binaryWriter.Write(invalidName_, 0, 2);
                color.Write(binaryWriter);
                alpha.Write(binaryWriter);
                width.Write(binaryWriter);
                length.Write(binaryWriter);
                yaw.Write(binaryWriter);
                pitch.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}