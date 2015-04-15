// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class WeaponBarrelDamageEffectStructBlock : WeaponBarrelDamageEffectStructBlockBase
    {
        public  WeaponBarrelDamageEffectStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class WeaponBarrelDamageEffectStructBlockBase  : IGuerilla
    {
        [TagReference("jpt!")]
        internal Moonfish.Tags.TagReference damageEffect;
        internal  WeaponBarrelDamageEffectStructBlockBase(BinaryReader binaryReader)
        {
            damageEffect = binaryReader.ReadTagReference();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(damageEffect);
                return nextAddress;
            }
        }
    };
}
