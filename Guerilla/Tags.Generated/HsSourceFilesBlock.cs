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
        public static readonly TagClass Hsc = (TagClass)"hsc*";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("hsc*")]
    public partial class HsSourceFilesBlock : HsSourceFilesBlockBase
    {
        public  HsSourceFilesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  HsSourceFilesBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 40, Alignment = 4)]
    public class HsSourceFilesBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.String32 name;
        internal byte[] source;
        
        public override int SerializedSize{get { return 40; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  HsSourceFilesBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            name = binaryReader.ReadString32();
            source = Guerilla.ReadData(binaryReader);
        }
        public  HsSourceFilesBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                nextAddress = Guerilla.WriteData(binaryWriter, source, nextAddress);
                return nextAddress;
            }
        }
    };
}
