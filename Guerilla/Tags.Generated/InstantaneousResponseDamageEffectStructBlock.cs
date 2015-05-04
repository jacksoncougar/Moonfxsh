// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class InstantaneousResponseDamageEffectStructBlock : InstantaneousResponseDamageEffectStructBlockBase
    {
        public  InstantaneousResponseDamageEffectStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  InstantaneousResponseDamageEffectStructBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class InstantaneousResponseDamageEffectStructBlockBase : GuerillaBlock
    {
        [TagReference("jpt!")]
        internal Moonfish.Tags.TagReference transitionDamageEffect;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  InstantaneousResponseDamageEffectStructBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            transitionDamageEffect = binaryReader.ReadTagReference();
        }
        public  InstantaneousResponseDamageEffectStructBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            transitionDamageEffect = binaryReader.ReadTagReference();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(transitionDamageEffect);
                return nextAddress;
            }
        }
    };
}
