// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class TextValuePairReferenceBlock : TextValuePairReferenceBlockBase
    {
        public  TextValuePairReferenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  TextValuePairReferenceBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class TextValuePairReferenceBlockBase : GuerillaBlock
    {
        internal Flags flags;
        internal int value;
        internal Moonfish.Tags.StringID labelStringId;
        
        public override int SerializedSize{get { return 12; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  TextValuePairReferenceBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt32();
            value = binaryReader.ReadInt32();
            labelStringId = binaryReader.ReadStringID();
        }
        public  TextValuePairReferenceBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt32();
            value = binaryReader.ReadInt32();
            labelStringId = binaryReader.ReadStringID();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write(value);
                binaryWriter.Write(labelStringId);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        {
            DefaultSetting = 1,
        };
    };
}
