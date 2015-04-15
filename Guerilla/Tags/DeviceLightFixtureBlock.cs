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
    public  partial class DeviceLightFixtureBlock : DeviceLightFixtureBlockBase
    {
        public  DeviceLightFixtureBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 0, Alignment = 4)]
    public class DeviceLightFixtureBlockBase : DeviceBlock
    {
        internal  DeviceLightFixtureBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                return nextAddress;
            }
        }
    };
}
