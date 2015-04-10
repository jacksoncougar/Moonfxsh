// ReSharper disable All
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
        public  ParticleController(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  ParticleControllerBase(System.IO.BinaryReader binaryReader)
        {
            type = (Type)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            ReadParticleControllerParametersArray(binaryReader);
            invalidName_0 = binaryReader.ReadBytes(8);
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
        internal  virtual ParticleControllerParameters[] ReadParticleControllerParametersArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ParticleControllerParameters));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ParticleControllerParameters[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ParticleControllerParameters(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteParticleControllerParametersArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)type);
                binaryWriter.Write(invalidName_, 0, 2);
                WriteParticleControllerParametersArray(binaryWriter);
                binaryWriter.Write(invalidName_0, 0, 8);
            }
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
