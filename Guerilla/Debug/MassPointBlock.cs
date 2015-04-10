// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class MassPointBlock : MassPointBlockBase
    {
        public  MassPointBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 128)]
    public class MassPointBlockBase
    {
        internal Moonfish.Tags.String32 name;
        internal Moonfish.Tags.ShortBlockIndex1 poweredMassPoint;
        internal short modelNode;
        internal Flags flags;
        internal float relativeMass;
        internal float mass;
        internal float relativeDensity;
        internal float density;
        internal OpenTK.Vector3 position;
        internal OpenTK.Vector3 forward;
        internal OpenTK.Vector3 up;
        internal FrictionType frictionType;
        internal byte[] invalidName_;
        internal float frictionParallelScale;
        internal float frictionPerpendicularScale;
        internal float radius;
        internal byte[] invalidName_0;
        internal  MassPointBlockBase(System.IO.BinaryReader binaryReader)
        {
            name = binaryReader.ReadString32();
            poweredMassPoint = binaryReader.ReadShortBlockIndex1();
            modelNode = binaryReader.ReadInt16();
            flags = (Flags)binaryReader.ReadInt32();
            relativeMass = binaryReader.ReadSingle();
            mass = binaryReader.ReadSingle();
            relativeDensity = binaryReader.ReadSingle();
            density = binaryReader.ReadSingle();
            position = binaryReader.ReadVector3();
            forward = binaryReader.ReadVector3();
            up = binaryReader.ReadVector3();
            frictionType = (FrictionType)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            frictionParallelScale = binaryReader.ReadSingle();
            frictionPerpendicularScale = binaryReader.ReadSingle();
            radius = binaryReader.ReadSingle();
            invalidName_0 = binaryReader.ReadBytes(20);
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
                binaryWriter.Write(name);
                binaryWriter.Write(poweredMassPoint);
                binaryWriter.Write(modelNode);
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write(relativeMass);
                binaryWriter.Write(mass);
                binaryWriter.Write(relativeDensity);
                binaryWriter.Write(density);
                binaryWriter.Write(position);
                binaryWriter.Write(forward);
                binaryWriter.Write(up);
                binaryWriter.Write((Int16)frictionType);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(frictionParallelScale);
                binaryWriter.Write(frictionPerpendicularScale);
                binaryWriter.Write(radius);
                binaryWriter.Write(invalidName_0, 0, 20);
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        
        {
            Metallic = 1,
        };
        internal enum FrictionType : short
        
        {
            Point = 0,
            Forward = 1,
            Left = 2,
            Up = 3,
        };
    };
}
