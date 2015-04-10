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
        public  ParticlePhysicsBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  ParticlePhysicsBlockBase(BinaryReader binaryReader)
        {
            this.template = binaryReader.ReadTagReference();
            this.flags = (Flags)binaryReader.ReadInt32();
            this.movements = ReadParticleControllerArray(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
        }
        internal  virtual ParticleController[] ReadParticleControllerArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ParticleController));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ParticleController[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ParticleController(binaryReader);
                }
            }
            return array;
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
