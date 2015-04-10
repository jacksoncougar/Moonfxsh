using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("ssce")]
    public  partial class SoundSceneryBlock : SoundSceneryBlockBase
    {
        public  SoundSceneryBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class SoundSceneryBlockBase : ObjectBlock
    {
        internal byte[] invalidName_;
        internal  SoundSceneryBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            this.invalidName_ = binaryReader.ReadBytes(16);
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
