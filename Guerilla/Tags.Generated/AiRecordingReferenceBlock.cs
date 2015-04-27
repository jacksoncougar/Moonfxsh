// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class AiRecordingReferenceBlock : AiRecordingReferenceBlockBase
    {
        public  AiRecordingReferenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  AiRecordingReferenceBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 40, Alignment = 4)]
    public class AiRecordingReferenceBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.String32 recordingName;
        internal byte[] invalidName_;
        
        public override int SerializedSize{get { return 40; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  AiRecordingReferenceBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            recordingName = binaryReader.ReadString32();
            invalidName_ = binaryReader.ReadBytes(8);
        }
        public  AiRecordingReferenceBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(recordingName);
                binaryWriter.Write(invalidName_, 0, 8);
                return nextAddress;
            }
        }
    };
}
