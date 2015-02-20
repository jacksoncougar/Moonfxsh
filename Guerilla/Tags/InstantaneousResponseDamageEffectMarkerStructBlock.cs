using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [LayoutAttribute(Size = 4)]
    public  partial class InstantaneousResponseDamageEffectMarkerStructBlock : InstantaneousResponseDamageEffectMarkerStructBlockBase
    {
        public  InstantaneousResponseDamageEffectMarkerStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 4)]
    public class InstantaneousResponseDamageEffectMarkerStructBlockBase
    {
        internal Moonfish.Tags.StringID damageEffectMarkerName;
        internal  InstantaneousResponseDamageEffectMarkerStructBlockBase(BinaryReader binaryReader)
        {
            this.damageEffectMarkerName = binaryReader.ReadStringID();
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
