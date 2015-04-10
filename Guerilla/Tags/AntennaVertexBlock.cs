using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class AntennaVertexBlock : AntennaVertexBlockBase
    {
        public  AntennaVertexBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 128)]
    public class AntennaVertexBlockBase
    {
        /// <summary>
        /// strength of the spring (larger values make the spring stronger)
        /// </summary>
        internal float springStrengthCoefficient;
        internal byte[] invalidName_;
        /// <summary>
        /// direction toward next vertex
        /// </summary>
        internal OpenTK.Vector2 angles;
        /// <summary>
        /// distance between this vertex and the next
        /// </summary>
        internal float lengthWorldUnits;
        /// <summary>
        /// bitmap group sequenceIndex for this vertex's texture
        /// </summary>
        internal short sequenceIndex;
        internal byte[] invalidName_0;
        /// <summary>
        /// color at this vertex
        /// </summary>
        internal OpenTK.Vector4 color;
        /// <summary>
        /// color at this vertex for the low-LOD line primitives
        /// </summary>
        internal OpenTK.Vector4 lODColor;
        internal byte[] invalidName_1;
        internal byte[] invalidName_2;
        internal  AntennaVertexBlockBase(BinaryReader binaryReader)
        {
            this.springStrengthCoefficient = binaryReader.ReadSingle();
            this.invalidName_ = binaryReader.ReadBytes(24);
            this.angles = binaryReader.ReadVector2();
            this.lengthWorldUnits = binaryReader.ReadSingle();
            this.sequenceIndex = binaryReader.ReadInt16();
            this.invalidName_0 = binaryReader.ReadBytes(2);
            this.color = binaryReader.ReadVector4();
            this.lODColor = binaryReader.ReadVector4();
            this.invalidName_1 = binaryReader.ReadBytes(40);
            this.invalidName_2 = binaryReader.ReadBytes(12);
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
