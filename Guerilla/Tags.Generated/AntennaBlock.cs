// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Ant = (TagClass)"ant!";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("ant!")]
    public partial class AntennaBlock : AntennaBlockBase
    {
        public  AntennaBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  AntennaBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 160, Alignment = 4)]
    public class AntennaBlockBase : GuerillaBlock
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
        
        public override int SerializedSize{get { return 160; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  AntennaBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            attachmentMarkerName = binaryReader.ReadStringID();
            bitmaps = binaryReader.ReadTagReference();
            physics = binaryReader.ReadTagReference();
            invalidName_ = binaryReader.ReadBytes(80);
            springStrengthCoefficient = binaryReader.ReadSingle();
            falloffPixels = binaryReader.ReadSingle();
            cutoffPixels = binaryReader.ReadSingle();
            invalidName_0 = binaryReader.ReadBytes(40);
            vertices = Guerilla.ReadBlockArray<AntennaVertexBlock>(binaryReader);
        }
        public  AntennaBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
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
                nextAddress = Guerilla.WriteBlockArray<AntennaVertexBlock>(binaryWriter, vertices, nextAddress);
                return nextAddress;
            }
        }
    };
}
