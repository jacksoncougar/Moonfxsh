using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ScenarioBipedPaletteBlock : ScenarioBipedPaletteBlockBase
    {
        public  ScenarioBipedPaletteBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 40)]
    public class ScenarioBipedPaletteBlockBase
    {
        [TagReference("bipd")]
        internal Moonfish.Tags.TagReference name;
        internal byte[] invalidName_;
        internal  ScenarioBipedPaletteBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadTagReference();
            this.invalidName_ = binaryReader.ReadBytes(32);
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
