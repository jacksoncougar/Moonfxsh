using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class AiRecordingReferenceBlock : AiRecordingReferenceBlockBase
    {
        public  AiRecordingReferenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 40)]
    public class AiRecordingReferenceBlockBase
    {
        internal Moonfish.Tags.String32 recordingName;
        internal byte[] invalidName_;
        internal  AiRecordingReferenceBlockBase(BinaryReader binaryReader)
        {
            this.recordingName = binaryReader.ReadString32();
            this.invalidName_ = binaryReader.ReadBytes(8);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
    };
}
