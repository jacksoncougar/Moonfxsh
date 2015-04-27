// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class StructureBspEnvironmentObjectPaletteBlock : StructureBspEnvironmentObjectPaletteBlockBase
    {
        public  StructureBspEnvironmentObjectPaletteBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class StructureBspEnvironmentObjectPaletteBlockBase : GuerillaBlock
    {
        [TagReference("scen")]
        internal Moonfish.Tags.TagReference definition;
        [TagReference("mode")]
        internal Moonfish.Tags.TagReference model;
        internal byte[] invalidName_;
        
        public override int SerializedSize{get { return 20; }}
        
        internal  StructureBspEnvironmentObjectPaletteBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            definition = binaryReader.ReadTagReference();
            model = binaryReader.ReadTagReference();
            invalidName_ = binaryReader.ReadBytes(4);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(definition);
                binaryWriter.Write(model);
                binaryWriter.Write(invalidName_, 0, 4);
                return nextAddress;
            }
        }
    };
}
