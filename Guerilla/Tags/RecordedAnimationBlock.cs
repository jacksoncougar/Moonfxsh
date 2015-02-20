using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class RecordedAnimationBlock : RecordedAnimationBlockBase
    {
        public  RecordedAnimationBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 52)]
    public class RecordedAnimationBlockBase
    {
        internal Moonfish.Tags.String32 name;
        internal byte version;
        internal byte rawAnimationData;
        internal byte unitControlDataVersion;
        internal byte[] invalidName_;
        internal short lengthOfAnimationTicks;
        internal byte[] invalidName_0;
        internal byte[] invalidName_1;
        internal byte[] recordedAnimationEventStream;
        internal  RecordedAnimationBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadString32();
            this.version = binaryReader.ReadByte();
            this.rawAnimationData = binaryReader.ReadByte();
            this.unitControlDataVersion = binaryReader.ReadByte();
            this.invalidName_ = binaryReader.ReadBytes(1);
            this.lengthOfAnimationTicks = binaryReader.ReadInt16();
            this.invalidName_0 = binaryReader.ReadBytes(2);
            this.invalidName_1 = binaryReader.ReadBytes(4);
            this.recordedAnimationEventStream = ReadData(binaryReader);
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
