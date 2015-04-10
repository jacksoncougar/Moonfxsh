using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ParticleController : ParticleControllerBase
    {
        public  ParticleController(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20)]
    public class ParticleControllerBase
    {
        internal Type type;
        internal byte[] invalidName_;
        internal ParticleControllerParameters[] parameters;
        internal byte[] invalidName_0;
        internal  ParticleControllerBase(BinaryReader binaryReader)
        {
            this.type = (Type)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.parameters = ReadParticleControllerParametersArray(binaryReader);
            this.invalidName_0 = binaryReader.ReadBytes(8);
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
        internal  virtual ParticleControllerParameters[] ReadParticleControllerParametersArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ParticleControllerParameters));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ParticleControllerParameters[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ParticleControllerParameters(binaryReader);
                }
            }
            return array;
        }
        internal enum Type : short
        
        {
            Physics = 0,
            Collider = 1,
            Swarm = 2,
            Wind = 3,
        };
    };
}
