// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class MassDistributionsBlock : MassDistributionsBlockBase
    {
        public  MassDistributionsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  MassDistributionsBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 64, Alignment = 16)]
    public class MassDistributionsBlockBase : GuerillaBlock
    {
        internal OpenTK.Vector3 centerOfMass;
        internal byte[] invalidName_;
        internal OpenTK.Vector3 inertiaTensorI;
        internal byte[] invalidName_0;
        internal OpenTK.Vector3 inertiaTensorJ;
        internal byte[] invalidName_1;
        internal OpenTK.Vector3 inertiaTensorK;
        internal byte[] invalidName_2;
        
        public override int SerializedSize{get { return 64; }}
        
        
        public override int Alignment{get { return 16; }}
        
        public  MassDistributionsBlockBase(BinaryReader binaryReader): base(binaryReader)
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
        public  MassDistributionsBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
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
                return nextAddress;
            }
        }
    };
}
