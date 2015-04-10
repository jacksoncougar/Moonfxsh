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
        public  InertialMatrixBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 36)]
    public class InertialMatrixBlockBase
    {
        internal OpenTK.Vector3 yyZzXyZx;
        internal OpenTK.Vector3 xyZzXxYz;
        internal OpenTK.Vector3 zxYzXxYy;
        internal  InertialMatrixBlockBase(BinaryReader binaryReader)
        {
            this.yyZzXyZx = binaryReader.ReadVector3();
            this.xyZzXxYz = binaryReader.ReadVector3();
            this.zxYzXxYy = binaryReader.ReadVector3();
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
