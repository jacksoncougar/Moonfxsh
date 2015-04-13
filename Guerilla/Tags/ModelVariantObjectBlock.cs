// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ModelVariantObjectBlock : ModelVariantObjectBlockBase
    {
        public  ModelVariantObjectBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class ModelVariantObjectBlockBase  : IGuerilla
    {
        internal Moonfish.Tags.StringID parentMarker;
        internal Moonfish.Tags.StringID childMarker;
        [TagReference("obje")]
        internal Moonfish.Tags.TagReference childObject;
        internal  ModelVariantObjectBlockBase(BinaryReader binaryReader)
        {
            parentMarker = binaryReader.ReadStringID();
            childMarker = binaryReader.ReadStringID();
            childObject = binaryReader.ReadTagReference();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(parentMarker);
                binaryWriter.Write(childMarker);
                binaryWriter.Write(childObject);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
