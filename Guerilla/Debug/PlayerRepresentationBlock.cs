// ReSharper disable All
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
        public  PlayerRepresentationBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  PlayerRepresentationBlockBase(System.IO.BinaryReader binaryReader)
        {
            firstPersonHands = binaryReader.ReadTagReference();
            firstPersonBody = binaryReader.ReadTagReference();
            invalidName_ = binaryReader.ReadBytes(40);
            invalidName_0 = binaryReader.ReadBytes(120);
            thirdPersonUnit = binaryReader.ReadTagReference();
            thirdPersonVariant = binaryReader.ReadStringID();
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(firstPersonHands);
                binaryWriter.Write(firstPersonBody);
                binaryWriter.Write(invalidName_, 0, 40);
                binaryWriter.Write(invalidName_0, 0, 120);
                binaryWriter.Write(thirdPersonUnit);
                binaryWriter.Write(thirdPersonVariant);
            }
        }
    };
}
