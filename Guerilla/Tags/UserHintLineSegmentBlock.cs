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
        public  UserHintLineSegmentBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  UserHintLineSegmentBlockBase(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt32();
            this.point0 = binaryReader.ReadVector3();
            this.referenceFrame = binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.point1 = binaryReader.ReadVector3();
            this.referenceFrame0 = binaryReader.ReadInt16();
            this.invalidName_0 = binaryReader.ReadBytes(2);
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
        [FlagsAttribute]
        internal enum Flags : int
        
        {
            Bidirectional = 1,
            Closed = 2,
        };
    };
}
