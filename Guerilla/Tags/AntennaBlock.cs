using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("ant!")]
    public  partial class AntennaBlock : AntennaBlockBase
    {
        public  AntennaBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 160)]
    public class AntennaBlockBase
    {
        /// <summary>
        /// the marker name where the antenna should be attached
        /// </summary>
        internal Moonfish.Tags.StringID attachmentMarkerName;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference bitmaps;
        [TagReference("pphy")]
        internal Moonfish.Tags.TagReference physics;
        internal byte[] invalidName_;
        /// <summary>
        /// strength of the spring (larger values make the spring stronger)
        /// </summary>
        internal float springStrengthCoefficient;
        internal float falloffPixels;
        internal float cutoffPixels;
        internal byte[] invalidName_0;
        internal AntennaVertexBlock[] vertices;
        internal  AntennaBlockBase(BinaryReader binaryReader)
        {
            this.attachmentMarkerName = binaryReader.ReadStringID();
            this.bitmaps = binaryReader.ReadTagReference();
            this.physics = binaryReader.ReadTagReference();
            this.invalidName_ = binaryReader.ReadBytes(80);
            this.springStrengthCoefficient = binaryReader.ReadSingle();
            this.falloffPixels = binaryReader.ReadSingle();
            this.cutoffPixels = binaryReader.ReadSingle();
            this.invalidName_0 = binaryReader.ReadBytes(40);
            this.vertices = ReadAntennaVertexBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
        }
        internal  virtual AntennaVertexBlock[] ReadAntennaVertexBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(AntennaVertexBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new AntennaVertexBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new AntennaVertexBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
