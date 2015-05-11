// ReSharper disable All

using Moonfish.Model;

using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class AntennaVertexBlock : AntennaVertexBlockBase
    {
        public AntennaVertexBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 128, Alignment = 4)]
    public class AntennaVertexBlockBase : GuerillaBlock
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

        public override int SerializedSize
        {
            get { return 128; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public AntennaVertexBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            springStrengthCoefficient = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadBytes(24);
            angles = binaryReader.ReadVector2();
            lengthWorldUnits = binaryReader.ReadSingle();
            sequenceIndex = binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(2);
            color = binaryReader.ReadVector4();
            lODColor = binaryReader.ReadVector4();
            invalidName_1 = binaryReader.ReadBytes(40);
            invalidName_2 = binaryReader.ReadBytes(12);
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(springStrengthCoefficient);
                binaryWriter.Write(invalidName_, 0, 24);
                binaryWriter.Write(angles);
                binaryWriter.Write(lengthWorldUnits);
                binaryWriter.Write(sequenceIndex);
                binaryWriter.Write(invalidName_0, 0, 2);
                binaryWriter.Write(color);
                binaryWriter.Write(lODColor);
                binaryWriter.Write(invalidName_1, 0, 40);
                binaryWriter.Write(invalidName_2, 0, 12);
                return nextAddress;
            }
        }
    };
}