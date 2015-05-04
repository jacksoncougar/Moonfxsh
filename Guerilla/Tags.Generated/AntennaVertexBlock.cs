// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
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
        public override int SerializedSize { get { return 128; } }
        public override int Alignment { get { return 4; } }
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
            invalidName_[0].ReadPointers(binaryReader, blamPointers);
            invalidName_[1].ReadPointers(binaryReader, blamPointers);
            invalidName_[2].ReadPointers(binaryReader, blamPointers);
            invalidName_[3].ReadPointers(binaryReader, blamPointers);
            invalidName_[4].ReadPointers(binaryReader, blamPointers);
            invalidName_[5].ReadPointers(binaryReader, blamPointers);
            invalidName_[6].ReadPointers(binaryReader, blamPointers);
            invalidName_[7].ReadPointers(binaryReader, blamPointers);
            invalidName_[8].ReadPointers(binaryReader, blamPointers);
            invalidName_[9].ReadPointers(binaryReader, blamPointers);
            invalidName_[10].ReadPointers(binaryReader, blamPointers);
            invalidName_[11].ReadPointers(binaryReader, blamPointers);
            invalidName_[12].ReadPointers(binaryReader, blamPointers);
            invalidName_[13].ReadPointers(binaryReader, blamPointers);
            invalidName_[14].ReadPointers(binaryReader, blamPointers);
            invalidName_[15].ReadPointers(binaryReader, blamPointers);
            invalidName_[16].ReadPointers(binaryReader, blamPointers);
            invalidName_[17].ReadPointers(binaryReader, blamPointers);
            invalidName_[18].ReadPointers(binaryReader, blamPointers);
            invalidName_[19].ReadPointers(binaryReader, blamPointers);
            invalidName_[20].ReadPointers(binaryReader, blamPointers);
            invalidName_[21].ReadPointers(binaryReader, blamPointers);
            invalidName_[22].ReadPointers(binaryReader, blamPointers);
            invalidName_[23].ReadPointers(binaryReader, blamPointers);
            invalidName_0[0].ReadPointers(binaryReader, blamPointers);
            invalidName_0[1].ReadPointers(binaryReader, blamPointers);
            invalidName_1[0].ReadPointers(binaryReader, blamPointers);
            invalidName_1[1].ReadPointers(binaryReader, blamPointers);
            invalidName_1[2].ReadPointers(binaryReader, blamPointers);
            invalidName_1[3].ReadPointers(binaryReader, blamPointers);
            invalidName_1[4].ReadPointers(binaryReader, blamPointers);
            invalidName_1[5].ReadPointers(binaryReader, blamPointers);
            invalidName_1[6].ReadPointers(binaryReader, blamPointers);
            invalidName_1[7].ReadPointers(binaryReader, blamPointers);
            invalidName_1[8].ReadPointers(binaryReader, blamPointers);
            invalidName_1[9].ReadPointers(binaryReader, blamPointers);
            invalidName_1[10].ReadPointers(binaryReader, blamPointers);
            invalidName_1[11].ReadPointers(binaryReader, blamPointers);
            invalidName_1[12].ReadPointers(binaryReader, blamPointers);
            invalidName_1[13].ReadPointers(binaryReader, blamPointers);
            invalidName_1[14].ReadPointers(binaryReader, blamPointers);
            invalidName_1[15].ReadPointers(binaryReader, blamPointers);
            invalidName_1[16].ReadPointers(binaryReader, blamPointers);
            invalidName_1[17].ReadPointers(binaryReader, blamPointers);
            invalidName_1[18].ReadPointers(binaryReader, blamPointers);
            invalidName_1[19].ReadPointers(binaryReader, blamPointers);
            invalidName_1[20].ReadPointers(binaryReader, blamPointers);
            invalidName_1[21].ReadPointers(binaryReader, blamPointers);
            invalidName_1[22].ReadPointers(binaryReader, blamPointers);
            invalidName_1[23].ReadPointers(binaryReader, blamPointers);
            invalidName_1[24].ReadPointers(binaryReader, blamPointers);
            invalidName_1[25].ReadPointers(binaryReader, blamPointers);
            invalidName_1[26].ReadPointers(binaryReader, blamPointers);
            invalidName_1[27].ReadPointers(binaryReader, blamPointers);
            invalidName_1[28].ReadPointers(binaryReader, blamPointers);
            invalidName_1[29].ReadPointers(binaryReader, blamPointers);
            invalidName_1[30].ReadPointers(binaryReader, blamPointers);
            invalidName_1[31].ReadPointers(binaryReader, blamPointers);
            invalidName_1[32].ReadPointers(binaryReader, blamPointers);
            invalidName_1[33].ReadPointers(binaryReader, blamPointers);
            invalidName_1[34].ReadPointers(binaryReader, blamPointers);
            invalidName_1[35].ReadPointers(binaryReader, blamPointers);
            invalidName_1[36].ReadPointers(binaryReader, blamPointers);
            invalidName_1[37].ReadPointers(binaryReader, blamPointers);
            invalidName_1[38].ReadPointers(binaryReader, blamPointers);
            invalidName_1[39].ReadPointers(binaryReader, blamPointers);
            invalidName_2[0].ReadPointers(binaryReader, blamPointers);
            invalidName_2[1].ReadPointers(binaryReader, blamPointers);
            invalidName_2[2].ReadPointers(binaryReader, blamPointers);
            invalidName_2[3].ReadPointers(binaryReader, blamPointers);
            invalidName_2[4].ReadPointers(binaryReader, blamPointers);
            invalidName_2[5].ReadPointers(binaryReader, blamPointers);
            invalidName_2[6].ReadPointers(binaryReader, blamPointers);
            invalidName_2[7].ReadPointers(binaryReader, blamPointers);
            invalidName_2[8].ReadPointers(binaryReader, blamPointers);
            invalidName_2[9].ReadPointers(binaryReader, blamPointers);
            invalidName_2[10].ReadPointers(binaryReader, blamPointers);
            invalidName_2[11].ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
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
