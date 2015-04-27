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
        public static readonly TagClass Snd = (TagClass)"snd!";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("snd!")]
    public partial class SoundBlock : SoundBlockBase
    {
        public  SoundBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  SoundBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class SoundBlockBase : GuerillaBlock
    {
        internal byte[] soundFields;
        
        public override int SerializedSize{get { return 20; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  SoundBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            soundFields = binaryReader.ReadBytes(20);
        }
        public  SoundBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            soundFields = binaryReader.ReadBytes(20);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(soundFields, 0, 20);
                return nextAddress;
            }
        }
    };
}
