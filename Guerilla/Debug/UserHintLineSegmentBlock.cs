// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class UserHintLineSegmentBlock : UserHintLineSegmentBlockBase
    {
        public  UserHintLineSegmentBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 36)]
    public class UserHintLineSegmentBlockBase
    {
        internal Flags flags;
        internal OpenTK.Vector3 point0;
        internal short referenceFrame;
        internal byte[] invalidName_;
        internal OpenTK.Vector3 point1;
        internal short referenceFrame0;
        internal byte[] invalidName_0;
        internal  UserHintLineSegmentBlockBase(System.IO.BinaryReader binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt32();
            point0 = binaryReader.ReadVector3();
            referenceFrame = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            point1 = binaryReader.ReadVector3();
            referenceFrame0 = binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(2);
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
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write(point0);
                binaryWriter.Write(referenceFrame);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(point1);
                binaryWriter.Write(referenceFrame0);
                binaryWriter.Write(invalidName_0, 0, 2);
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
