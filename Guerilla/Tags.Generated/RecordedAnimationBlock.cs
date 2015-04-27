// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class RecordedAnimationBlock : RecordedAnimationBlockBase
    {
        public  RecordedAnimationBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  RecordedAnimationBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 52, Alignment = 4)]
    public class RecordedAnimationBlockBase : GuerillaBlock
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
        
        public override int SerializedSize{get { return 52; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  RecordedAnimationBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            name = binaryReader.ReadString32();
            version = binaryReader.ReadByte();
            rawAnimationData = binaryReader.ReadByte();
            unitControlDataVersion = binaryReader.ReadByte();
            invalidName_ = binaryReader.ReadBytes(1);
            lengthOfAnimationTicks = binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(2);
            invalidName_1 = binaryReader.ReadBytes(4);
            recordedAnimationEventStream = Guerilla.ReadData(binaryReader);
        }
        public  RecordedAnimationBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            name = binaryReader.ReadString32();
            version = binaryReader.ReadByte();
            rawAnimationData = binaryReader.ReadByte();
            unitControlDataVersion = binaryReader.ReadByte();
            invalidName_ = binaryReader.ReadBytes(1);
            lengthOfAnimationTicks = binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(2);
            invalidName_1 = binaryReader.ReadBytes(4);
            recordedAnimationEventStream = Guerilla.ReadData(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
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
                nextAddress = Guerilla.WriteData(binaryWriter, recordedAnimationEventStream, nextAddress);
                return nextAddress;
            }
        }
    };
}
