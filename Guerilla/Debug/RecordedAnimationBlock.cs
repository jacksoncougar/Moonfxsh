// ReSharper disable All
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
        public  RecordedAnimationBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  RecordedAnimationBlockBase(System.IO.BinaryReader binaryReader)
        {
            name = binaryReader.ReadString32();
            version = binaryReader.ReadByte();
            rawAnimationData = binaryReader.ReadByte();
            unitControlDataVersion = binaryReader.ReadByte();
            invalidName_ = binaryReader.ReadBytes(1);
            lengthOfAnimationTicks = binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(2);
            invalidName_1 = binaryReader.ReadBytes(4);
            recordedAnimationEventStream = ReadData(binaryReader);
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write(version);
                binaryWriter.Write(rawAnimationData);
                binaryWriter.Write(unitControlDataVersion);
                binaryWriter.Write(invalidName_, 0, 1);
                binaryWriter.Write(lengthOfAnimationTicks);
                binaryWriter.Write(invalidName_0, 0, 2);
                binaryWriter.Write(invalidName_1, 0, 4);
                WriteData(binaryWriter);
            }
        }
    };
}
