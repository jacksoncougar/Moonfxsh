// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class InstantaneousResponseDamageEffectStructBlock : InstantaneousResponseDamageEffectStructBlockBase
    {
        public  InstantaneousResponseDamageEffectStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class InstantaneousResponseDamageEffectStructBlockBase  : IGuerilla
    {
        [TagReference("jpt!")]
        internal Moonfish.Tags.TagReference transitionDamageEffect;
        internal  InstantaneousResponseDamageEffectStructBlockBase(BinaryReader binaryReader)
        {
            transitionDamageEffect = binaryReader.ReadTagReference();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(transitionDamageEffect);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
