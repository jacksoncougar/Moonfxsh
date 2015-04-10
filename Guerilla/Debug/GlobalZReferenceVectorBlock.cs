// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class GlobalZReferenceVectorBlock : GlobalZReferenceVectorBlockBase
    {
        public  GlobalZReferenceVectorBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class GlobalZReferenceVectorBlockBase
    {
        internal float invalidName_;
        internal float invalidName_0;
        internal float invalidName_1;
        internal float invalidName_2;
        internal  GlobalZReferenceVectorBlockBase(System.IO.BinaryReader binaryReader)
        {
            invalidName_ = binaryReader.ReadSingle();
            invalidName_0 = binaryReader.ReadSingle();
            invalidName_1 = binaryReader.ReadSingle();
            invalidName_2 = binaryReader.ReadSingle();
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
                binaryWriter.Write(invalidName_);
                binaryWriter.Write(invalidName_0);
                binaryWriter.Write(invalidName_1);
                binaryWriter.Write(invalidName_2);
            }
        }
    };
}
