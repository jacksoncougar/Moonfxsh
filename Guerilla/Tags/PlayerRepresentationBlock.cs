using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class PlayerRepresentationBlock : PlayerRepresentationBlockBase
    {
        public  PlayerRepresentationBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 188)]
    public class PlayerRepresentationBlockBase
    {
        [TagReference("mode")]
        internal Moonfish.Tags.TagReference firstPersonHands;
        [TagReference("mode")]
        internal Moonfish.Tags.TagReference firstPersonBody;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        [TagReference("unit")]
        internal Moonfish.Tags.TagReference thirdPersonUnit;
        internal Moonfish.Tags.StringID thirdPersonVariant;
        internal  PlayerRepresentationBlockBase(BinaryReader binaryReader)
        {
            this.firstPersonHands = binaryReader.ReadTagReference();
            this.firstPersonBody = binaryReader.ReadTagReference();
            this.invalidName_ = binaryReader.ReadBytes(40);
            this.invalidName_0 = binaryReader.ReadBytes(120);
            this.thirdPersonUnit = binaryReader.ReadTagReference();
            this.thirdPersonVariant = binaryReader.ReadStringID();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
    };
}
