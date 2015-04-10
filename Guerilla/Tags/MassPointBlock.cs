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
        public  MassPointBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  MassPointBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadString32();
            this.poweredMassPoint = binaryReader.ReadShortBlockIndex1();
            this.modelNode = binaryReader.ReadInt16();
            this.flags = (Flags)binaryReader.ReadInt32();
            this.relativeMass = binaryReader.ReadSingle();
            this.mass = binaryReader.ReadSingle();
            this.relativeDensity = binaryReader.ReadSingle();
            this.density = binaryReader.ReadSingle();
            this.position = binaryReader.ReadVector3();
            this.forward = binaryReader.ReadVector3();
            this.up = binaryReader.ReadVector3();
            this.frictionType = (FrictionType)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.frictionParallelScale = binaryReader.ReadSingle();
            this.frictionPerpendicularScale = binaryReader.ReadSingle();
            this.radius = binaryReader.ReadSingle();
            this.invalidName_0 = binaryReader.ReadBytes(20);
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
