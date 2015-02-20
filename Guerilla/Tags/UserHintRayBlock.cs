using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class UserHintRayBlock : UserHintRayBlockBase
    {
        public  UserHintRayBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 28)]
    public class UserHintRayBlockBase
    {
        internal OpenTK.Vector3 point;
        internal short referenceFrame;
        internal byte[] invalidName_;
        internal OpenTK.Vector3 vector;
        internal  UserHintRayBlockBase(BinaryReader binaryReader)
        {
            this.point = binaryReader.ReadVector3();
            this.referenceFrame = binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.vector = binaryReader.ReadVector3();
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
