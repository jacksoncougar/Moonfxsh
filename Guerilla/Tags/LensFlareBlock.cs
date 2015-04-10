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
        public  LensFlareBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  LensFlareBlockBase(BinaryReader binaryReader)
        {
            this.falloffAngleDegrees = binaryReader.ReadSingle();
            this.cutoffAngleDegrees = binaryReader.ReadSingle();
            this.invalidName_ = binaryReader.ReadBytes(4);
            this.invalidName_0 = binaryReader.ReadBytes(4);
            this.occlusionRadiusWorldUnits = binaryReader.ReadSingle();
            this.occlusionOffsetDirection = (OcclusionOffsetDirection)binaryReader.ReadInt16();
            this.occlusionInnerRadiusScale = (OcclusionInnerRadiusScale)binaryReader.ReadInt16();
            this.nearFadeDistanceWorldUnits = binaryReader.ReadSingle();
            this.farFadeDistanceWorldUnits = binaryReader.ReadSingle();
            this.bitmap = binaryReader.ReadTagReference();
            this.flags = (Flags)binaryReader.ReadInt16();
            this.invalidName_1 = binaryReader.ReadBytes(2);
            this.rotationFunction = (RotationFunction)binaryReader.ReadInt16();
            this.invalidName_2 = binaryReader.ReadBytes(2);
            this.rotationFunctionScaleDegrees = binaryReader.ReadSingle();
            this.coronaScale = binaryReader.ReadVector2();
            this.falloffFunction = (FalloffFunction)binaryReader.ReadInt16();
            this.invalidName_3 = binaryReader.ReadBytes(2);
            this.reflections = ReadLensFlareReflectionBlockArray(binaryReader);
            this.flags0 = (Flags)binaryReader.ReadInt16();
            this.invalidName_4 = binaryReader.ReadBytes(2);
            this.brightness = ReadLensFlareScalarAnimationBlockArray(binaryReader);
            this.color = ReadLensFlareColorAnimationBlockArray(binaryReader);
            this.rotation = ReadLensFlareScalarAnimationBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
        }
        internal  virtual LensFlareReflectionBlock[] ReadLensFlareReflectionBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(LensFlareReflectionBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new LensFlareReflectionBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new LensFlareReflectionBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual LensFlareScalarAnimationBlock[] ReadLensFlareScalarAnimationBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(LensFlareScalarAnimationBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new LensFlareScalarAnimationBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new LensFlareScalarAnimationBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual LensFlareColorAnimationBlock[] ReadLensFlareColorAnimationBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(LensFlareColorAnimationBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new LensFlareColorAnimationBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new LensFlareColorAnimationBlock(binaryReader);
                }
            }
            return array;
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
