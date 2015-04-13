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
        public static readonly TagClass HscClass = (TagClass)"hsc*";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("hsc*")]
    public  partial class HsSourceFilesBlock : HsSourceFilesBlockBase
    {
        public  HsSourceFilesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 40, Alignment = 4)]
    public class HsSourceFilesBlockBase  : IGuerilla
    {
        internal Moonfish.Tags.String32 name;
        internal byte[] source;
        internal  HsSourceFilesBlockBase(BinaryReader binaryReader)
        {
            name = binaryReader.ReadString32();
            source = Guerilla.ReadData(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                Guerilla.WriteData(binaryWriter);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
