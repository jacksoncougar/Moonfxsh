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
        public static readonly TagClass Lens = (TagClass) "lens";
    };
} ;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("lens")]
    public partial class LensFlareBlock : LensFlareBlockBase
    {
        public LensFlareBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 100, Alignment = 4)]
    public class LensFlareBlockBase : GuerillaBlock
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

        [TagReference("bitm")] internal Moonfish.Tags.TagReference bitmap;
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

        public override int SerializedSize
        {
            get { return 100; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public LensFlareBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            falloffAngleDegrees = binaryReader.ReadSingle();
            cutoffAngleDegrees = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadBytes(4);
            invalidName_0 = binaryReader.ReadBytes(4);
            occlusionRadiusWorldUnits = binaryReader.ReadSingle();
            occlusionOffsetDirection = (OcclusionOffsetDirection) binaryReader.ReadInt16();
            occlusionInnerRadiusScale = (OcclusionInnerRadiusScale) binaryReader.ReadInt16();
            nearFadeDistanceWorldUnits = binaryReader.ReadSingle();
            farFadeDistanceWorldUnits = binaryReader.ReadSingle();
            bitmap = binaryReader.ReadTagReference();
            flags = (Flags) binaryReader.ReadInt16();
            invalidName_1 = binaryReader.ReadBytes(2);
            rotationFunction = (RotationFunction) binaryReader.ReadInt16();
            invalidName_2 = binaryReader.ReadBytes(2);
            rotationFunctionScaleDegrees = binaryReader.ReadSingle();
            coronaScale = binaryReader.ReadVector2();
            falloffFunction = (FalloffFunction) binaryReader.ReadInt16();
            invalidName_3 = binaryReader.ReadBytes(2);
            blamPointers.Enqueue(ReadBlockArrayPointer<LensFlareReflectionBlock>(binaryReader));
            flags0 = (Flags) binaryReader.ReadInt16();
            invalidName_4 = binaryReader.ReadBytes(2);
            blamPointers.Enqueue(ReadBlockArrayPointer<LensFlareScalarAnimationBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<LensFlareColorAnimationBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<LensFlareScalarAnimationBlock>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            reflections = ReadBlockArrayData<LensFlareReflectionBlock>(binaryReader, blamPointers.Dequeue());
            brightness = ReadBlockArrayData<LensFlareScalarAnimationBlock>(binaryReader, blamPointers.Dequeue());
            color = ReadBlockArrayData<LensFlareColorAnimationBlock>(binaryReader, blamPointers.Dequeue());
            rotation = ReadBlockArrayData<LensFlareScalarAnimationBlock>(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(falloffAngleDegrees);
                binaryWriter.Write(cutoffAngleDegrees);
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(invalidName_0, 0, 4);
                binaryWriter.Write(occlusionRadiusWorldUnits);
                binaryWriter.Write((Int16) occlusionOffsetDirection);
                binaryWriter.Write((Int16) occlusionInnerRadiusScale);
                binaryWriter.Write(nearFadeDistanceWorldUnits);
                binaryWriter.Write(farFadeDistanceWorldUnits);
                binaryWriter.Write(bitmap);
                binaryWriter.Write((Int16) flags);
                binaryWriter.Write(invalidName_1, 0, 2);
                binaryWriter.Write((Int16) rotationFunction);
                binaryWriter.Write(invalidName_2, 0, 2);
                binaryWriter.Write(rotationFunctionScaleDegrees);
                binaryWriter.Write(coronaScale);
                binaryWriter.Write((Int16) falloffFunction);
                binaryWriter.Write(invalidName_3, 0, 2);
                nextAddress = Guerilla.WriteBlockArray<LensFlareReflectionBlock>(binaryWriter, reflections, nextAddress);
                binaryWriter.Write((Int16) flags0);
                binaryWriter.Write(invalidName_4, 0, 2);
                nextAddress = Guerilla.WriteBlockArray<LensFlareScalarAnimationBlock>(binaryWriter, brightness,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<LensFlareColorAnimationBlock>(binaryWriter, color, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<LensFlareScalarAnimationBlock>(binaryWriter, rotation,
                    nextAddress);
                return nextAddress;
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