using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("metr")]
    public  partial class MeterBlock : MeterBlockBase
    {
        public  MeterBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 144)]
    public class MeterBlockBase
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
        internal  MeterBlockBase(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt32();
            this.stencilBitmaps = binaryReader.ReadTagReference();
            this.sourceBitmap = binaryReader.ReadTagReference();
            this.stencilSequenceIndex = binaryReader.ReadInt16();
            this.sourceSequenceIndex = binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(16);
            this.invalidName_0 = binaryReader.ReadBytes(4);
            this.interpolateColors = (InterpolateColors)binaryReader.ReadInt16();
            this.anchorColors = (AnchorColors)binaryReader.ReadInt16();
            this.invalidName_1 = binaryReader.ReadBytes(8);
            this.emptyColor = binaryReader.ReadVector4();
            this.fullColor = binaryReader.ReadVector4();
            this.invalidName_2 = binaryReader.ReadBytes(20);
            this.unmaskDistanceMeterUnits = binaryReader.ReadSingle();
            this.maskDistanceMeterUnits = binaryReader.ReadSingle();
            this.invalidName_3 = binaryReader.ReadBytes(20);
            this.encodedStencil = ReadData(binaryReader);
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
