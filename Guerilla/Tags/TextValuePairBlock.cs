// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class TextValuePairBlock : TextValuePairBlockBase
    {
        public  TextValuePairBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class TextValuePairBlockBase  : IGuerilla
    {
        [TagReference("sily")]
        internal Moonfish.Tags.TagReference valuePairs;
        internal  TextValuePairBlockBase(BinaryReader binaryReader)
        {
            valuePairs = binaryReader.ReadTagReference();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(valuePairs);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
