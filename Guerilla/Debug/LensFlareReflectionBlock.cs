// ReSharper disable All
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
        public  LensFlareReflectionBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  LensFlareReflectionBlockBase(System.IO.BinaryReader binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            bitmapIndex = binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(2);
            positionAlongFlareAxis = binaryReader.ReadSingle();
            rotationOffsetDegrees = binaryReader.ReadSingle();
            radiusWorldUnits = binaryReader.ReadRange();
            brightness01 = binaryReader.ReadVector2();
            modulationFactor01 = binaryReader.ReadSingle();
            color = binaryReader.ReadColorR8G8B8();
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(bitmapIndex);
                binaryWriter.Write(invalidName_0, 0, 2);
                binaryWriter.Write(positionAlongFlareAxis);
                binaryWriter.Write(rotationOffsetDegrees);
                binaryWriter.Write(radiusWorldUnits);
                binaryWriter.Write(brightness01);
                binaryWriter.Write(modulationFactor01);
                binaryWriter.Write(color);
            }
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
