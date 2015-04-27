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
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class TextValuePairBlockBase : GuerillaBlock
    {
        [TagReference("sily")]
        internal Moonfish.Tags.TagReference valuePairs;
        
        public override int SerializedSize{get { return 8; }}
        
        internal  TextValuePairBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            valuePairs = binaryReader.ReadTagReference();
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
