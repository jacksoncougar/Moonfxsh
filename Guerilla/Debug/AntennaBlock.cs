// ReSharper disable All
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
        public  AntennaBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  AntennaBlockBase(System.IO.BinaryReader binaryReader)
        {
            attachmentMarkerName = binaryReader.ReadStringID();
            bitmaps = binaryReader.ReadTagReference();
            physics = binaryReader.ReadTagReference();
            invalidName_ = binaryReader.ReadBytes(80);
            springStrengthCoefficient = binaryReader.ReadSingle();
            falloffPixels = binaryReader.ReadSingle();
            cutoffPixels = binaryReader.ReadSingle();
            invalidName_0 = binaryReader.ReadBytes(40);
            ReadAntennaVertexBlockArray(binaryReader);
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
        internal  virtual AntennaVertexBlock[] ReadAntennaVertexBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(AntennaVertexBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new AntennaVertexBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new AntennaVertexBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteAntennaVertexBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(attachmentMarkerName);
                binaryWriter.Write(bitmaps);
                binaryWriter.Write(physics);
                binaryWriter.Write(invalidName_, 0, 80);
                binaryWriter.Write(springStrengthCoefficient);
                binaryWriter.Write(falloffPixels);
                binaryWriter.Write(cutoffPixels);
                binaryWriter.Write(invalidName_0, 0, 40);
                WriteAntennaVertexBlockArray(binaryWriter);
            }
        }
    };
}
