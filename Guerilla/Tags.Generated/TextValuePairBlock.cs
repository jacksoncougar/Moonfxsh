// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class TextValuePairBlock : TextValuePairBlockBase
    {
        public  TextValuePairBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  TextValuePairBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class TextValuePairBlockBase : GuerillaBlock
    {
        [TagReference("sily")]
        internal Moonfish.Tags.TagReference valuePairs;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  TextValuePairBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            valuePairs = binaryReader.ReadTagReference();
        }
        public  TextValuePairBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(valuePairs);
                return nextAddress;
            }
        }
    };
}
