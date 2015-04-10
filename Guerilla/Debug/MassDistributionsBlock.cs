// ReSharper disable All
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
        public  MassDistributionsBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  MassDistributionsBlockBase(System.IO.BinaryReader binaryReader)
        {
            centerOfMass = binaryReader.ReadVector3();
            invalidName_ = binaryReader.ReadBytes(4);
            inertiaTensorI = binaryReader.ReadVector3();
            invalidName_0 = binaryReader.ReadBytes(4);
            inertiaTensorJ = binaryReader.ReadVector3();
            invalidName_1 = binaryReader.ReadBytes(4);
            inertiaTensorK = binaryReader.ReadVector3();
            invalidName_2 = binaryReader.ReadBytes(4);
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
                binaryWriter.Write(centerOfMass);
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(inertiaTensorI);
                binaryWriter.Write(invalidName_0, 0, 4);
                binaryWriter.Write(inertiaTensorJ);
                binaryWriter.Write(invalidName_1, 0, 4);
                binaryWriter.Write(inertiaTensorK);
                binaryWriter.Write(invalidName_2, 0, 4);
            }
        }
    };
}
