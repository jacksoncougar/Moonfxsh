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
        public static readonly TagClass Lifi = (TagClass)"lifi";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("lifi")]
    public partial class DeviceLightFixtureBlock : DeviceLightFixtureBlockBase
    {
        public  DeviceLightFixtureBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  DeviceLightFixtureBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 0, Alignment = 4)]
    public class DeviceLightFixtureBlockBase : GuerillaBlock
    {
        
        public override int SerializedSize{get { return 0; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  DeviceLightFixtureBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  DeviceLightFixtureBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                return nextAddress;
            }
        }
    };
}
