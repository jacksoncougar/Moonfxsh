using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class UserHintWellPointBlock : UserHintWellPointBlockBase
    {
        public  UserHintWellPointBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 32)]
    public class UserHintWellPointBlockBase
    {
        internal Type type;
        internal byte[] invalidName_;
        internal OpenTK.Vector3 point;
        internal short referenceFrame;
        internal byte[] invalidName_0;
        internal int sectorIndex;
        internal OpenTK.Vector2 normal;
        internal  UserHintWellPointBlockBase(BinaryReader binaryReader)
        {
            this.type = (Type)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.point = binaryReader.ReadVector3();
            this.referenceFrame = binaryReader.ReadInt16();
            this.invalidName_0 = binaryReader.ReadBytes(2);
            this.sectorIndex = binaryReader.ReadInt32();
            this.normal = binaryReader.ReadVector2();
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
        internal enum Type : short
        
        {
            Jump = 0,
            Climb = 1,
            Hoist = 2,
        };
    };
}
