using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [LayoutAttribute(Size = 16)]
    public  partial class ModelVariantObjectBlock : ModelVariantObjectBlockBase
    {
        public  ModelVariantObjectBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class ModelVariantObjectBlockBase
    {
        internal Moonfish.Tags.StringID parentMarker;
        internal Moonfish.Tags.StringID childMarker;
        [TagReference("obje")]
        internal Moonfish.Tags.TagReference childObject;
        internal  ModelVariantObjectBlockBase(BinaryReader binaryReader)
        {
            this.parentMarker = binaryReader.ReadStringID();
            this.childMarker = binaryReader.ReadStringID();
            this.childObject = binaryReader.ReadTagReference();
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
