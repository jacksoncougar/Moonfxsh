// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("lens")]
    public  partial class LensFlareBlock : LensFlareBlockBase
    {
        public  LensFlareBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 100)]
    public class LensFlareBlockBase
    {
        internal float falloffAngleDegrees;
        internal float cutoffAngleDegrees;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        /// <summary>
        /// radius of the square used to test occlusion
        /// </summary>
        internal float occlusionRadiusWorldUnits;
        internal OcclusionOffsetDirection occlusionOffsetDirection;
        internal OcclusionInnerRadiusScale occlusionInnerRadiusScale;
        /// <summary>
        /// distance at which the lens flare brightness is maximum
        /// </summary>
        internal float nearFadeDistanceWorldUnits;
        /// <summary>
        /// distance at which the lens flare brightness is minimum; set to zero to disable distance fading
        /// </summary>
        internal float farFadeDistanceWorldUnits;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference bitmap;
        internal Flags flags;
        internal byte[] invalidName_1;
        internal RotationFunction rotationFunction;
        internal byte[] invalidName_2;
        internal float rotationFunctionScaleDegrees;
        /// <summary>
        /// amount to stretch the corona
        /// </summary>
        internal OpenTK.Vector2 coronaScale;
        internal FalloffFunction falloffFunction;
        internal byte[] invalidName_3;
        internal LensFlareReflectionBlock[] reflections;
        internal Flags flags0;
        internal byte[] invalidName_4;
        internal LensFlareScalarAnimationBlock[] brightness;
        internal LensFlareColorAnimationBlock[] color;
        internal LensFlareScalarAnimationBlock[] rotation;
        internal  LensFlareBlockBase(System.IO.BinaryReader binaryReader)
        {
            falloffAngleDegrees = binaryReader.ReadSingle();
            cutoffAngleDegrees = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadBytes(4);
            invalidName_0 = binaryReader.ReadBytes(4);
            occlusionRadiusWorldUnits = binaryReader.ReadSingle();
            occlusionOffsetDirection = (OcclusionOffsetDirection)binaryReader.ReadInt16();
            occlusionInnerRadiusScale = (OcclusionInnerRadiusScale)binaryReader.ReadInt16();
            nearFadeDistanceWorldUnits = binaryReader.ReadSingle();
            farFadeDistanceWorldUnits = binaryReader.ReadSingle();
            bitmap = binaryReader.ReadTagReference();
            flags = (Flags)binaryReader.ReadInt16();
            invalidName_1 = binaryReader.ReadBytes(2);
            rotationFunction = (RotationFunction)binaryReader.ReadInt16();
            invalidName_2 = binaryReader.ReadBytes(2);
            rotationFunctionScaleDegrees = binaryReader.ReadSingle();
            coronaScale = binaryReader.ReadVector2();
            falloffFunction = (FalloffFunction)binaryReader.ReadInt16();
            invalidName_3 = binaryReader.ReadBytes(2);
            ReadLensFlareReflectionBlockArray(binaryReader);
            flags0 = (Flags)binaryReader.ReadInt16();
            invalidName_4 = binaryReader.ReadBytes(2);
            ReadLensFlareScalarAnimationBlockArray(binaryReader);
            ReadLensFlareColorAnimationBlockArray(binaryReader);
            ReadLensFlareScalarAnimationBlockArray(binaryReader);
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
        internal  virtual LensFlareReflectionBlock[] ReadLensFlareReflectionBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(LensFlareReflectionBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new LensFlareReflectionBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new LensFlareReflectionBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual LensFlareScalarAnimationBlock[] ReadLensFlareScalarAnimationBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(LensFlareScalarAnimationBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new LensFlareScalarAnimationBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new LensFlareScalarAnimationBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual LensFlareColorAnimationBlock[] ReadLensFlareColorAnimationBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(LensFlareColorAnimationBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new LensFlareColorAnimationBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new LensFlareColorAnimationBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteLensFlareReflectionBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteLensFlareScalarAnimationBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteLensFlareColorAnimationBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(falloffAngleDegrees);
                binaryWriter.Write(cutoffAngleDegrees);
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(invalidName_0, 0, 4);
                binaryWriter.Write(occlusionRadiusWorldUnits);
                binaryWriter.Write((Int16)occlusionOffsetDirection);
                binaryWriter.Write((Int16)occlusionInnerRadiusScale);
                binaryWriter.Write(nearFadeDistanceWorldUnits);
                binaryWriter.Write(farFadeDistanceWorldUnits);
                binaryWriter.Write(bitmap);
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(invalidName_1, 0, 2);
                binaryWriter.Write((Int16)rotationFunction);
                binaryWriter.Write(invalidName_2, 0, 2);
                binaryWriter.Write(rotationFunctionScaleDegrees);
                binaryWriter.Write(coronaScale);
                binaryWriter.Write((Int16)falloffFunction);
                binaryWriter.Write(invalidName_3, 0, 2);
                WriteLensFlareReflectionBlockArray(binaryWriter);
                binaryWriter.Write((Int16)flags0);
                binaryWriter.Write(invalidName_4, 0, 2);
                WriteLensFlareScalarAnimationBlockArray(binaryWriter);
                WriteLensFlareColorAnimationBlockArray(binaryWriter);
                WriteLensFlareScalarAnimationBlockArray(binaryWriter);
            }
        }
        internal enum OcclusionOffsetDirection : short
        
        {
            TowardViewer = 0,
            MarkerForward = 1,
            None = 2,
        };
        internal enum OcclusionInnerRadiusScale : short
        
        {
            None = 0,
            InvalidName12 = 1,
            InvalidName14 = 2,
            InvalidName18 = 3,
            InvalidName116 = 4,
            InvalidName132 = 5,
            InvalidName164 = 6,
        };
        [FlagsAttribute]
        internal enum Flags : short
        
        {
            Sun = 1,
            NoOcclusionTest = 2,
            OnlyRenderInFirstPerson = 4,
            OnlyRenderInThirdPerson = 8,
            FadeInMoreQuickly = 16,
            FadeOutMoreQuickly = 32,
            ScaleByMarker = 64,
        };
        internal enum RotationFunction : short
        
        {
            None = 0,
            RotationA = 1,
            RotationB = 2,
            RotationTranslation = 3,
            Translation = 4,
        };
        internal enum FalloffFunction : short
        
        {
            Linear = 0,
            Late = 1,
            VeryLate = 2,
            Early = 3,
            VeryEarly = 4,
            Cosine = 5,
            Zero = 6,
            One = 7,
        };
        [FlagsAttribute]
        internal enum Flags0 : short
        
        {
            Synchronized = 1,
        };
    };
}
