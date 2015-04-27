// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class DamageOuterConeAngleStructBlock : DamageOuterConeAngleStructBlockBase
    {
        public  DamageOuterConeAngleStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class DamageOuterConeAngleStructBlockBase : GuerillaBlock
    {
        internal float dmgOuterConeAngle;
        
        public override int SerializedSize{get { return 4; }}
        
        internal  DamageOuterConeAngleStructBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            dmgOuterConeAngle = binaryReader.ReadSingle();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(dmgOuterConeAngle);
                return nextAddress;
            }
        }
    };
}
