// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ModelVariantObjectBlock : ModelVariantObjectBlockBase
    {
        public  ModelVariantObjectBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ModelVariantObjectBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class ModelVariantObjectBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringID parentMarker;
        internal Moonfish.Tags.StringID childMarker;
        [TagReference("obje")]
        internal Moonfish.Tags.TagReference childObject;
        
        public override int SerializedSize{get { return 16; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ModelVariantObjectBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            parentMarker = binaryReader.ReadStringID();
            childMarker = binaryReader.ReadStringID();
            childObject = binaryReader.ReadTagReference();
        }
        public  ModelVariantObjectBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(parentMarker);
                binaryWriter.Write(childMarker);
                binaryWriter.Write(childObject);
                return nextAddress;
            }
        }
    };
}
