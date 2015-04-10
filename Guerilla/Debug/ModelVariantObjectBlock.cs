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
        public  ModelVariantObjectBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  ModelVariantObjectBlockBase(System.IO.BinaryReader binaryReader)
        {
            parentMarker = binaryReader.ReadStringID();
            childMarker = binaryReader.ReadStringID();
            childObject = binaryReader.ReadTagReference();
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
                binaryWriter.Write(parentMarker);
                binaryWriter.Write(childMarker);
                binaryWriter.Write(childObject);
            }
        }
    };
}
