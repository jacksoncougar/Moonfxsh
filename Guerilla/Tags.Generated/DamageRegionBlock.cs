// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class DamageRegionBlock : DamageRegionBlockBase
    {
        public  DamageRegionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  DamageRegionBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class DamageRegionBlockBase : GuerillaBlock
    {
        internal AnimationIndexStructBlock animation;
        
        public override int SerializedSize{get { return 4; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  DamageRegionBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            animation = new AnimationIndexStructBlock(binaryReader);
        }
        public  DamageRegionBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            animation = new AnimationIndexStructBlock(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                animation.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
