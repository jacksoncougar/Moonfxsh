// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class UserHintPointBlock : UserHintPointBlockBase
    {
        public  UserHintPointBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class UserHintPointBlockBase
    {
        internal OpenTK.Vector3 point;
        internal short referenceFrame;
        internal byte[] invalidName_;
        internal  UserHintPointBlockBase(System.IO.BinaryReader binaryReader)
        {
            point = binaryReader.ReadVector3();
            referenceFrame = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
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
                binaryWriter.Write(point);
                binaryWriter.Write(referenceFrame);
                binaryWriter.Write(invalidName_, 0, 2);
            }
        }
    };
}
