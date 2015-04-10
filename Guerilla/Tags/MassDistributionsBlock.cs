using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class MassDistributionsBlock : MassDistributionsBlockBase
    {
        public  MassDistributionsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 64)]
    public class MassDistributionsBlockBase
    {
        internal OpenTK.Vector3 centerOfMass;
        internal byte[] invalidName_;
        internal OpenTK.Vector3 inertiaTensorI;
        internal byte[] invalidName_0;
        internal OpenTK.Vector3 inertiaTensorJ;
        internal byte[] invalidName_1;
        internal OpenTK.Vector3 inertiaTensorK;
        internal byte[] invalidName_2;
        internal  MassDistributionsBlockBase(BinaryReader binaryReader)
        {
            this.centerOfMass = binaryReader.ReadVector3();
            this.invalidName_ = binaryReader.ReadBytes(4);
            this.inertiaTensorI = binaryReader.ReadVector3();
            this.invalidName_0 = binaryReader.ReadBytes(4);
            this.inertiaTensorJ = binaryReader.ReadVector3();
            this.invalidName_1 = binaryReader.ReadBytes(4);
            this.inertiaTensorK = binaryReader.ReadVector3();
            this.invalidName_2 = binaryReader.ReadBytes(4);
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
