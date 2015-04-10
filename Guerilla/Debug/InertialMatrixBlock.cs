// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class InertialMatrixBlock : InertialMatrixBlockBase
    {
        public  InertialMatrixBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 36)]
    public class InertialMatrixBlockBase
    {
        internal OpenTK.Vector3 yyZzXyZx;
        internal OpenTK.Vector3 xyZzXxYz;
        internal OpenTK.Vector3 zxYzXxYy;
        internal  InertialMatrixBlockBase(System.IO.BinaryReader binaryReader)
        {
            yyZzXyZx = binaryReader.ReadVector3();
            xyZzXxYz = binaryReader.ReadVector3();
            zxYzXxYy = binaryReader.ReadVector3();
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
                binaryWriter.Write(yyZzXyZx);
                binaryWriter.Write(xyZzXxYz);
                binaryWriter.Write(zxYzXxYy);
            }
        }
    };
}
