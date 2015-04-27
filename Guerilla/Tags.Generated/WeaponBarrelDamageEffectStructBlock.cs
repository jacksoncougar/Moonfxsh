// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class WeaponBarrelDamageEffectStructBlock : WeaponBarrelDamageEffectStructBlockBase
    {
        public  WeaponBarrelDamageEffectStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  WeaponBarrelDamageEffectStructBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class WeaponBarrelDamageEffectStructBlockBase : GuerillaBlock
    {
        [TagReference("jpt!")]
        internal Moonfish.Tags.TagReference damageEffect;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  WeaponBarrelDamageEffectStructBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            damageEffect = binaryReader.ReadTagReference();
        }
        public  WeaponBarrelDamageEffectStructBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            damageEffect = binaryReader.ReadTagReference();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(damageEffect);
                return nextAddress;
            }
        }
    };
}
