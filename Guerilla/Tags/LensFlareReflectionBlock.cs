using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class LensFlareReflectionBlock : LensFlareReflectionBlockBase
    {
        public  LensFlareReflectionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 48)]
    public class LensFlareReflectionBlockBase
    {
        internal Flags flags;
        internal byte[] invalidName_;
        internal short bitmapIndex;
        internal byte[] invalidName_0;
        /// <summary>
        /// 0 is on top of light, 1 is opposite light, 0.5 is the center of the screen, etc.
        /// </summary>
        internal float positionAlongFlareAxis;
        internal float rotationOffsetDegrees;
        /// <summary>
        /// interpolated by external input
        /// </summary>
        internal Moonfish.Model.Range radiusWorldUnits;
        /// <summary>
        /// interpolated by external input
        /// </summary>
        internal OpenTK.Vector2 brightness01;
        internal float modulationFactor01;
        internal Moonfish.Tags.ColorR8G8B8 color;
        internal  LensFlareReflectionBlockBase(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.bitmapIndex = binaryReader.ReadInt16();
            this.invalidName_0 = binaryReader.ReadBytes(2);
            this.positionAlongFlareAxis = binaryReader.ReadSingle();
            this.rotationOffsetDegrees = binaryReader.ReadSingle();
            this.radiusWorldUnits = binaryReader.ReadRange();
            this.brightness01 = binaryReader.ReadVector2();
            this.modulationFactor01 = binaryReader.ReadSingle();
            this.color = binaryReader.ReadColorR8G8B8();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
        }
        [FlagsAttribute]
        internal enum Flags : short
        
        {
            AlignRotationWithScreenCenter = 1,
            RadiusNOTScaledByDistance = 2,
            RadiusScaledByOcclusionFactor = 4,
            OccludedBySolidObjects = 8,
            IgnoreLightColor = 16,
            NotAffectedByInnerOcclusion = 32,
        };
    };
}
