// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass BsdtClass = (TagClass)"bsdt";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("bsdt")]
    public  partial class BreakableSurfaceBlock : BreakableSurfaceBlockBase
    {
        public  BreakableSurfaceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 32, Alignment = 4)]
    public class BreakableSurfaceBlockBase  : IGuerilla
    {
        internal float maximumVitality;
        [TagReference("effe")]
        internal Moonfish.Tags.TagReference effect;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference sound;
        internal ParticleSystemDefinitionBlockNew[] particleEffects;
        internal float particleDensity;
        internal  BreakableSurfaceBlockBase(BinaryReader binaryReader)
        {
            maximumVitality = binaryReader.ReadSingle();
            effect = binaryReader.ReadTagReference();
            sound = binaryReader.ReadTagReference();
            particleEffects = Guerilla.ReadBlockArray<ParticleSystemDefinitionBlockNew>(binaryReader);
            particleDensity = binaryReader.ReadSingle();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(maximumVitality);
                binaryWriter.Write(effect);
                binaryWriter.Write(sound);
                nextAddress = Guerilla.WriteBlockArray<ParticleSystemDefinitionBlockNew>(binaryWriter, particleEffects, nextAddress);
                binaryWriter.Write(particleDensity);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
