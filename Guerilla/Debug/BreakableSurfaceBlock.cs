// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("bsdt")]
    public  partial class BreakableSurfaceBlock : BreakableSurfaceBlockBase
    {
        public  BreakableSurfaceBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 32)]
    public class BreakableSurfaceBlockBase
    {
        internal float maximumVitality;
        [TagReference("effe")]
        internal Moonfish.Tags.TagReference effect;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference sound;
        internal ParticleSystemDefinitionBlockNew[] particleEffects;
        internal float particleDensity;
        internal  BreakableSurfaceBlockBase(System.IO.BinaryReader binaryReader)
        {
            maximumVitality = binaryReader.ReadSingle();
            effect = binaryReader.ReadTagReference();
            sound = binaryReader.ReadTagReference();
            ReadParticleSystemDefinitionBlockNewArray(binaryReader);
            particleDensity = binaryReader.ReadSingle();
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
        internal  virtual ParticleSystemDefinitionBlockNew[] ReadParticleSystemDefinitionBlockNewArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ParticleSystemDefinitionBlockNew));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ParticleSystemDefinitionBlockNew[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ParticleSystemDefinitionBlockNew(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteParticleSystemDefinitionBlockNewArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(maximumVitality);
                binaryWriter.Write(effect);
                binaryWriter.Write(sound);
                WriteParticleSystemDefinitionBlockNewArray(binaryWriter);
                binaryWriter.Write(particleDensity);
            }
        }
    };
}
