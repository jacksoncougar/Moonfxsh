using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("phys")]
    public  partial class PhysicsBlock : PhysicsBlockBase
    {
        public  PhysicsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 116)]
    public class PhysicsBlockBase
    {
        /// <summary>
        /// positive uses old inferior physics, negative uses new improved physics
        /// </summary>
        internal float radius;
        internal float momentScale;
        internal float mass;
        internal OpenTK.Vector3 centerOfMass;
        internal float density;
        internal float gravityScale;
        internal float groundFriction;
        internal float groundDepth;
        internal float groundDampFraction;
        internal float groundNormalK1;
        internal float groundNormalK0;
        internal byte[] invalidName_;
        internal float waterFriction;
        internal float waterDepth;
        internal float waterDensity;
        internal byte[] invalidName_0;
        internal float airFriction;
        internal byte[] invalidName_1;
        internal float xxMoment;
        internal float yyMoment;
        internal float zzMoment;
        internal InertialMatrixBlock[] inertialMatrixAndInverse;
        internal PoweredMassPointBlock[] poweredMassPoints;
        internal MassPointBlock[] massPoints;
        internal  PhysicsBlockBase(BinaryReader binaryReader)
        {
            this.radius = binaryReader.ReadSingle();
            this.momentScale = binaryReader.ReadSingle();
            this.mass = binaryReader.ReadSingle();
            this.centerOfMass = binaryReader.ReadVector3();
            this.density = binaryReader.ReadSingle();
            this.gravityScale = binaryReader.ReadSingle();
            this.groundFriction = binaryReader.ReadSingle();
            this.groundDepth = binaryReader.ReadSingle();
            this.groundDampFraction = binaryReader.ReadSingle();
            this.groundNormalK1 = binaryReader.ReadSingle();
            this.groundNormalK0 = binaryReader.ReadSingle();
            this.invalidName_ = binaryReader.ReadBytes(4);
            this.waterFriction = binaryReader.ReadSingle();
            this.waterDepth = binaryReader.ReadSingle();
            this.waterDensity = binaryReader.ReadSingle();
            this.invalidName_0 = binaryReader.ReadBytes(4);
            this.airFriction = binaryReader.ReadSingle();
            this.invalidName_1 = binaryReader.ReadBytes(4);
            this.xxMoment = binaryReader.ReadSingle();
            this.yyMoment = binaryReader.ReadSingle();
            this.zzMoment = binaryReader.ReadSingle();
            this.inertialMatrixAndInverse = ReadInertialMatrixBlockArray(binaryReader);
            this.poweredMassPoints = ReadPoweredMassPointBlockArray(binaryReader);
            this.massPoints = ReadMassPointBlockArray(binaryReader);
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
        internal  virtual InertialMatrixBlock[] ReadInertialMatrixBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(InertialMatrixBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new InertialMatrixBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new InertialMatrixBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PoweredMassPointBlock[] ReadPoweredMassPointBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PoweredMassPointBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PoweredMassPointBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PoweredMassPointBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual MassPointBlock[] ReadMassPointBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(MassPointBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new MassPointBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new MassPointBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
