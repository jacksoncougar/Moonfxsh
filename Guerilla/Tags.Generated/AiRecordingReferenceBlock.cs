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
    public partial class AiRecordingReferenceBlock : AiRecordingReferenceBlockBase
    {
        public AiRecordingReferenceBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 40, Alignment = 4)]
    public class AiRecordingReferenceBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.String32 recordingName;
        internal byte[] invalidName_;
        public override int SerializedSize { get { return 40; } }
        public override int Alignment { get { return 4; } }
        public AiRecordingReferenceBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            recordingName = binaryReader.ReadString32();
            invalidName_ = binaryReader.ReadBytes(8);
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            invalidName_[0].ReadPointers(binaryReader, blamPointers);
            invalidName_[1].ReadPointers(binaryReader, blamPointers);
            invalidName_[2].ReadPointers(binaryReader, blamPointers);
            invalidName_[3].ReadPointers(binaryReader, blamPointers);
            invalidName_[4].ReadPointers(binaryReader, blamPointers);
            invalidName_[5].ReadPointers(binaryReader, blamPointers);
            invalidName_[6].ReadPointers(binaryReader, blamPointers);
            invalidName_[7].ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(recordingName);
                binaryWriter.Write(invalidName_, 0, 8);
                return nextAddress;
            }
        }
    };
}
