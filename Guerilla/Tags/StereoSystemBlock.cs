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
        public static readonly TagClass BoomClass = (TagClass)"BooM";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("BooM")]
    public  partial class StereoSystemBlock : StereoSystemBlockBase
    {
        public  StereoSystemBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class StereoSystemBlockBase  : IGuerilla
    {
        internal int unused;
        internal  StereoSystemBlockBase(BinaryReader binaryReader)
        {
            unused = binaryReader.ReadInt32();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(unused);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
