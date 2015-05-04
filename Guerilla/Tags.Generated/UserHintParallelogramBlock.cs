// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class UserHintParallelogramBlock : UserHintParallelogramBlockBase
    {
        public  UserHintParallelogramBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  UserHintParallelogramBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 68, Alignment = 4)]
    public class UserHintParallelogramBlockBase : GuerillaBlock
    {
        internal Flags flags;
        internal OpenTK.Vector3 point0;
        internal short referenceFrame;
        internal byte[] invalidName_;
        internal OpenTK.Vector3 point1;
        internal short referenceFrame0;
        internal byte[] invalidName_0;
        internal OpenTK.Vector3 point2;
        internal short referenceFrame1;
        internal byte[] invalidName_1;
        internal OpenTK.Vector3 point3;
        internal short referenceFrame2;
        internal byte[] invalidName_2;
        
        public override int SerializedSize{get { return 68; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  UserHintParallelogramBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt32();
            point0 = binaryReader.ReadVector3();
            referenceFrame = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            point1 = binaryReader.ReadVector3();
            referenceFrame0 = binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(2);
            point2 = binaryReader.ReadVector3();
            referenceFrame1 = binaryReader.ReadInt16();
            invalidName_1 = binaryReader.ReadBytes(2);
            point3 = binaryReader.ReadVector3();
            referenceFrame2 = binaryReader.ReadInt16();
            invalidName_2 = binaryReader.ReadBytes(2);
        }
        public  UserHintParallelogramBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt32();
            point0 = binaryReader.ReadVector3();
            referenceFrame = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            point1 = binaryReader.ReadVector3();
            referenceFrame0 = binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(2);
            point2 = binaryReader.ReadVector3();
            referenceFrame1 = binaryReader.ReadInt16();
            invalidName_1 = binaryReader.ReadBytes(2);
            point3 = binaryReader.ReadVector3();
            referenceFrame2 = binaryReader.ReadInt16();
            invalidName_2 = binaryReader.ReadBytes(2);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write(point0);
                binaryWriter.Write(referenceFrame);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(point1);
                binaryWriter.Write(referenceFrame0);
                binaryWriter.Write(invalidName_0, 0, 2);
                binaryWriter.Write(point2);
                binaryWriter.Write(referenceFrame1);
                binaryWriter.Write(invalidName_1, 0, 2);
                binaryWriter.Write(point3);
                binaryWriter.Write(referenceFrame2);
                binaryWriter.Write(invalidName_2, 0, 2);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        {
            Bidirectional = 1,
            Closed = 2,
        };
    };
}
