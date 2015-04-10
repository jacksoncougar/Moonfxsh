using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class StructureBspEnvironmentObjectPaletteBlock : StructureBspEnvironmentObjectPaletteBlockBase
    {
        public  StructureBspEnvironmentObjectPaletteBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20)]
    public class StructureBspEnvironmentObjectPaletteBlockBase
    {
        [TagReference("scen")]
        internal Moonfish.Tags.TagReference definition;
        [TagReference("mode")]
        internal Moonfish.Tags.TagReference model;
        internal byte[] invalidName_;
        internal  StructureBspEnvironmentObjectPaletteBlockBase(BinaryReader binaryReader)
        {
            this.definition = binaryReader.ReadTagReference();
            this.model = binaryReader.ReadTagReference();
            this.invalidName_ = binaryReader.ReadBytes(4);
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
