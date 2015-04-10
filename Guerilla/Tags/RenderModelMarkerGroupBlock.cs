using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class RenderModelMarkerGroupBlock : RenderModelMarkerGroupBlockBase
    {
        public  RenderModelMarkerGroupBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12)]
    public class RenderModelMarkerGroupBlockBase
    {
        internal Moonfish.Tags.StringID name;
        internal RenderModelMarkerBlock[] markers;
        internal  RenderModelMarkerGroupBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            this.markers = ReadRenderModelMarkerBlockArray(binaryReader);
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
        internal  virtual RenderModelMarkerBlock[] ReadRenderModelMarkerBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(RenderModelMarkerBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new RenderModelMarkerBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new RenderModelMarkerBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
