// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class LocalStringIdListStringReferenceBlock : LocalStringIdListStringReferenceBlockBase
    {
        public  LocalStringIdListStringReferenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  LocalStringIdListStringReferenceBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class LocalStringIdListStringReferenceBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringID stringId;
        
        public override int SerializedSize{get { return 4; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  LocalStringIdListStringReferenceBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            stringId = binaryReader.ReadStringID();
        }
        public  LocalStringIdListStringReferenceBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(stringId);
                return nextAddress;
            }
        }
    };
}
