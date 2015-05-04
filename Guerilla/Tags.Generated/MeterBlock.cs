// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Metr = (TagClass)"metr";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("metr")]
    public partial class MeterBlock : MeterBlockBase
    {
        public MeterBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 144, Alignment = 4)]
    public class MeterBlockBase : GuerillaBlock
    {
        internal Flags flags;
        /// <summary>
        /// two bitmaps specifying the mask and the meter levels
        /// </summary>
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference stencilBitmaps;
        /// <summary>
        /// optional bitmap to draw into the unmasked regions of the meter (modulated by the colors below)
        /// </summary>
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference sourceBitmap;
        internal short stencilSequenceIndex;
        internal short sourceSequenceIndex;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal InterpolateColors interpolateColors;
        internal AnchorColors anchorColors;
        internal byte[] invalidName_1;
        internal OpenTK.Vector4 emptyColor;
        internal OpenTK.Vector4 fullColor;
        internal byte[] invalidName_2;
        /// <summary>
        /// fade from fully masked to fully unmasked this distance beyond full (and below empty)
        /// </summary>
        internal float unmaskDistanceMeterUnits;
        /// <summary>
        /// fade from fully unmasked to fully masked this distance below full (and beyond empty)
        /// </summary>
        internal float maskDistanceMeterUnits;
        internal byte[] invalidName_3;
        internal byte[] encodedStencil;
        public override int SerializedSize { get { return 144; } }
        public override int Alignment { get { return 4; } }
        public MeterBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            flags = (Flags)binaryReader.ReadInt32();
            stencilBitmaps = binaryReader.ReadTagReference();
            sourceBitmap = binaryReader.ReadTagReference();
            stencilSequenceIndex = binaryReader.ReadInt16();
            sourceSequenceIndex = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(16);
            invalidName_0 = binaryReader.ReadBytes(4);
            interpolateColors = (InterpolateColors)binaryReader.ReadInt16();
            anchorColors = (AnchorColors)binaryReader.ReadInt16();
            invalidName_1 = binaryReader.ReadBytes(8);
            emptyColor = binaryReader.ReadVector4();
            fullColor = binaryReader.ReadVector4();
            invalidName_2 = binaryReader.ReadBytes(20);
            unmaskDistanceMeterUnits = binaryReader.ReadSingle();
            maskDistanceMeterUnits = binaryReader.ReadSingle();
            invalidName_3 = binaryReader.ReadBytes(20);
            blamPointers.Enqueue(ReadBlockArrayPointer(binaryReader, 1));
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
            invalidName_0[0].ReadPointers(binaryReader, blamPointers);
            invalidName_0[1].ReadPointers(binaryReader, blamPointers);
            invalidName_0[2].ReadPointers(binaryReader, blamPointers);
            invalidName_0[3].ReadPointers(binaryReader, blamPointers);
            invalidName_1[0].ReadPointers(binaryReader, blamPointers);
            invalidName_1[1].ReadPointers(binaryReader, blamPointers);
            invalidName_1[2].ReadPointers(binaryReader, blamPointers);
            invalidName_1[3].ReadPointers(binaryReader, blamPointers);
            invalidName_1[4].ReadPointers(binaryReader, blamPointers);
            invalidName_1[5].ReadPointers(binaryReader, blamPointers);
            invalidName_1[6].ReadPointers(binaryReader, blamPointers);
            invalidName_1[7].ReadPointers(binaryReader, blamPointers);
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
            invalidName_2[12].ReadPointers(binaryReader, blamPointers);
            invalidName_2[13].ReadPointers(binaryReader, blamPointers);
            invalidName_2[14].ReadPointers(binaryReader, blamPointers);
            invalidName_2[15].ReadPointers(binaryReader, blamPointers);
            invalidName_2[16].ReadPointers(binaryReader, blamPointers);
            invalidName_2[17].ReadPointers(binaryReader, blamPointers);
            invalidName_2[18].ReadPointers(binaryReader, blamPointers);
            invalidName_2[19].ReadPointers(binaryReader, blamPointers);
            invalidName_3[0].ReadPointers(binaryReader, blamPointers);
            invalidName_3[1].ReadPointers(binaryReader, blamPointers);
            invalidName_3[2].ReadPointers(binaryReader, blamPointers);
            invalidName_3[3].ReadPointers(binaryReader, blamPointers);
            invalidName_3[4].ReadPointers(binaryReader, blamPointers);
            invalidName_3[5].ReadPointers(binaryReader, blamPointers);
            invalidName_3[6].ReadPointers(binaryReader, blamPointers);
            invalidName_3[7].ReadPointers(binaryReader, blamPointers);
            invalidName_3[8].ReadPointers(binaryReader, blamPointers);
            invalidName_3[9].ReadPointers(binaryReader, blamPointers);
            invalidName_3[10].ReadPointers(binaryReader, blamPointers);
            invalidName_3[11].ReadPointers(binaryReader, blamPointers);
            invalidName_3[12].ReadPointers(binaryReader, blamPointers);
            invalidName_3[13].ReadPointers(binaryReader, blamPointers);
            invalidName_3[14].ReadPointers(binaryReader, blamPointers);
            invalidName_3[15].ReadPointers(binaryReader, blamPointers);
            invalidName_3[16].ReadPointers(binaryReader, blamPointers);
            invalidName_3[17].ReadPointers(binaryReader, blamPointers);
            invalidName_3[18].ReadPointers(binaryReader, blamPointers);
            invalidName_3[19].ReadPointers(binaryReader, blamPointers);
            encodedStencil = ReadDataByteArray(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write(stencilBitmaps);
                binaryWriter.Write(sourceBitmap);
                binaryWriter.Write(stencilSequenceIndex);
                binaryWriter.Write(sourceSequenceIndex);
                binaryWriter.Write(invalidName_, 0, 16);
                binaryWriter.Write(invalidName_0, 0, 4);
                binaryWriter.Write((Int16)interpolateColors);
                binaryWriter.Write((Int16)anchorColors);
                binaryWriter.Write(invalidName_1, 0, 8);
                binaryWriter.Write(emptyColor);
                binaryWriter.Write(fullColor);
                binaryWriter.Write(invalidName_2, 0, 20);
                binaryWriter.Write(unmaskDistanceMeterUnits);
                binaryWriter.Write(maskDistanceMeterUnits);
                binaryWriter.Write(invalidName_3, 0, 20);
                nextAddress = Guerilla.WriteData(binaryWriter, encodedStencil, nextAddress);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        {
        };
        internal enum InterpolateColors : short
        {
            Linearly = 0,
            FasterNearEmpty = 1,
            FasterNearFull = 2,
            ThroughRandomNoise = 3,
        };
        internal enum AnchorColors : short
        {
            AtBothEnds = 0,
            AtEmpty = 1,
            AtFull = 2,
        };
    };
}
