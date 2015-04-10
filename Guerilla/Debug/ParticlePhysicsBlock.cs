// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("pmov")]
    public  partial class ParticlePhysicsBlock : ParticlePhysicsBlockBase
    {
        public  ParticlePhysicsBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20)]
    public class ParticlePhysicsBlockBase
    {
        [TagReference("pmov")]
        internal Moonfish.Tags.TagReference template;
        internal Flags flags;
        internal ParticleController[] movements;
        internal  ParticlePhysicsBlockBase(System.IO.BinaryReader binaryReader)
        {
            template = binaryReader.ReadTagReference();
            flags = (Flags)binaryReader.ReadInt32();
            ReadParticleControllerArray(binaryReader);
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
        internal  virtual ParticleController[] ReadParticleControllerArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ParticleController));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ParticleController[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ParticleController(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteParticleControllerArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(template);
                binaryWriter.Write((Int32)flags);
                WriteParticleControllerArray(binaryWriter);
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        
        {
            Physics = 1,
            CollideWithStructure = 2,
            CollideWithMedia = 4,
            CollideWithScenery = 8,
            CollideWithVehicles = 16,
            CollideWithBipeds = 32,
            Swarm = 64,
            Wind = 128,
        };
    };
}
