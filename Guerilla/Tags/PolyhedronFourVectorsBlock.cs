using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class PolyhedronFourVectorsBlock : PolyhedronFourVectorsBlockBase
    {
        public  PolyhedronFourVectorsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 48)]
    public class PolyhedronFourVectorsBlockBase
    {
        internal OpenTK.Vector3 fourVectorsX;
        internal byte[] invalidName_;
        internal OpenTK.Vector3 fourVectorsY;
        internal byte[] invalidName_0;
        internal OpenTK.Vector3 fourVectorsZ;
        internal byte[] invalidName_1;
        internal  PolyhedronFourVectorsBlockBase(BinaryReader binaryReader)
        {
            this.fourVectorsX = binaryReader.ReadVector3();
            this.invalidName_ = binaryReader.ReadBytes(4);
            this.fourVectorsY = binaryReader.ReadVector3();
            this.invalidName_0 = binaryReader.ReadBytes(4);
            this.fourVectorsZ = binaryReader.ReadVector3();
            this.invalidName_1 = binaryReader.ReadBytes(4);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
        }
    };
}
