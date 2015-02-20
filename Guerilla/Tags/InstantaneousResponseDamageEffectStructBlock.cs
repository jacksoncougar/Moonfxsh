using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [LayoutAttribute(Size = 8)]
    public  partial class InstantaneousResponseDamageEffectStructBlock : InstantaneousResponseDamageEffectStructBlockBase
    {
        public  InstantaneousResponseDamageEffectStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8)]
    public class InstantaneousResponseDamageEffectStructBlockBase
    {
        [TagReference("jpt!")]
        internal Moonfish.Tags.TagReference transitionDamageEffect;
        internal  InstantaneousResponseDamageEffectStructBlockBase(BinaryReader binaryReader)
        {
            this.transitionDamageEffect = binaryReader.ReadTagReference();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
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
    };
}
