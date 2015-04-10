// ReSharper disable All
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
        public  PhysicsBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  PhysicsBlockBase(System.IO.BinaryReader binaryReader)
        {
            radius = binaryReader.ReadSingle();
            momentScale = binaryReader.ReadSingle();
            mass = binaryReader.ReadSingle();
            centerOfMass = binaryReader.ReadVector3();
            density = binaryReader.ReadSingle();
            gravityScale = binaryReader.ReadSingle();
            groundFriction = binaryReader.ReadSingle();
            groundDepth = binaryReader.ReadSingle();
            groundDampFraction = binaryReader.ReadSingle();
            groundNormalK1 = binaryReader.ReadSingle();
            groundNormalK0 = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadBytes(4);
            waterFriction = binaryReader.ReadSingle();
            waterDepth = binaryReader.ReadSingle();
            waterDensity = binaryReader.ReadSingle();
            invalidName_0 = binaryReader.ReadBytes(4);
            airFriction = binaryReader.ReadSingle();
            invalidName_1 = binaryReader.ReadBytes(4);
            xxMoment = binaryReader.ReadSingle();
            yyMoment = binaryReader.ReadSingle();
            zzMoment = binaryReader.ReadSingle();
            ReadInertialMatrixBlockArray(binaryReader);
            ReadPoweredMassPointBlockArray(binaryReader);
            ReadMassPointBlockArray(binaryReader);
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
        internal  virtual InertialMatrixBlock[] ReadInertialMatrixBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(InertialMatrixBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new InertialMatrixBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new InertialMatrixBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PoweredMassPointBlock[] ReadPoweredMassPointBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PoweredMassPointBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PoweredMassPointBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PoweredMassPointBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual MassPointBlock[] ReadMassPointBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(MassPointBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new MassPointBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new MassPointBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteInertialMatrixBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WritePoweredMassPointBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteMassPointBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(radius);
                binaryWriter.Write(momentScale);
                binaryWriter.Write(mass);
                binaryWriter.Write(centerOfMass);
                binaryWriter.Write(density);
                binaryWriter.Write(gravityScale);
                binaryWriter.Write(groundFriction);
                binaryWriter.Write(groundDepth);
                binaryWriter.Write(groundDampFraction);
                binaryWriter.Write(groundNormalK1);
                binaryWriter.Write(groundNormalK0);
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(waterFriction);
                binaryWriter.Write(waterDepth);
                binaryWriter.Write(waterDensity);
                binaryWriter.Write(invalidName_0, 0, 4);
                binaryWriter.Write(airFriction);
                binaryWriter.Write(invalidName_1, 0, 4);
                binaryWriter.Write(xxMoment);
                binaryWriter.Write(yyMoment);
                binaryWriter.Write(zzMoment);
                WriteInertialMatrixBlockArray(binaryWriter);
                WritePoweredMassPointBlockArray(binaryWriter);
                WriteMassPointBlockArray(binaryWriter);
            }
        }
    };
}
