// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("deca")]
    public  partial class DecalBlock : DecalBlockBase
    {
        public  DecalBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 172)]
    public class DecalBlockBase
    {
        internal Flags flags;
        /// <summary>
        /// controls how the decal wraps onto surface geometry
        /// </summary>
        internal TypeControlsHowTheDecalWrapsOntoSurfaceGeometry type;
        internal Layer layer;
        internal short maxOverlappingCount;
        [TagReference("deca")]
        internal Moonfish.Tags.TagReference nextDecalInChain;
        /// <summary>
        /// 0 defaults to 0.125
        /// </summary>
        internal Moonfish.Model.Range radiusWorldUnits;
        internal float radiusOverlapRejectionMuliplier;
        internal Moonfish.Tags.ColorR8G8B8 colorLowerBounds;
        internal Moonfish.Tags.ColorR8G8B8 colorUpperBounds;
        internal Moonfish.Model.Range lifetimeSeconds;
        internal Moonfish.Model.Range decayTimeSeconds;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal byte[] invalidName_1;
        internal byte[] invalidName_2;
        internal byte[] invalidName_3;
        internal byte[] invalidName_4;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference bitmap;
        internal byte[] invalidName_5;
        internal float maximumSpriteExtentPixels;
        internal byte[] invalidName_6;
        internal  DecalBlockBase(System.IO.BinaryReader binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt16();
            type = (TypeControlsHowTheDecalWrapsOntoSurfaceGeometry)binaryReader.ReadInt16();
            layer = (Layer)binaryReader.ReadInt16();
            maxOverlappingCount = binaryReader.ReadInt16();
            nextDecalInChain = binaryReader.ReadTagReference();
            radiusWorldUnits = binaryReader.ReadRange();
            radiusOverlapRejectionMuliplier = binaryReader.ReadSingle();
            colorLowerBounds = binaryReader.ReadColorR8G8B8();
            colorUpperBounds = binaryReader.ReadColorR8G8B8();
            lifetimeSeconds = binaryReader.ReadRange();
            decayTimeSeconds = binaryReader.ReadRange();
            invalidName_ = binaryReader.ReadBytes(40);
            invalidName_0 = binaryReader.ReadBytes(2);
            invalidName_1 = binaryReader.ReadBytes(2);
            invalidName_2 = binaryReader.ReadBytes(2);
            invalidName_3 = binaryReader.ReadBytes(2);
            invalidName_4 = binaryReader.ReadBytes(20);
            bitmap = binaryReader.ReadTagReference();
            invalidName_5 = binaryReader.ReadBytes(20);
            maximumSpriteExtentPixels = binaryReader.ReadSingle();
            invalidName_6 = binaryReader.ReadBytes(4);
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
                binaryWriter.Write((Int16)type);
                binaryWriter.Write((Int16)layer);
                binaryWriter.Write(maxOverlappingCount);
                binaryWriter.Write(nextDecalInChain);
                binaryWriter.Write(radiusWorldUnits);
                binaryWriter.Write(radiusOverlapRejectionMuliplier);
                binaryWriter.Write(colorLowerBounds);
                binaryWriter.Write(colorUpperBounds);
                binaryWriter.Write(lifetimeSeconds);
                binaryWriter.Write(decayTimeSeconds);
                binaryWriter.Write(invalidName_, 0, 40);
                binaryWriter.Write(invalidName_0, 0, 2);
                binaryWriter.Write(invalidName_1, 0, 2);
                binaryWriter.Write(invalidName_2, 0, 2);
                binaryWriter.Write(invalidName_3, 0, 2);
                binaryWriter.Write(invalidName_4, 0, 20);
                binaryWriter.Write(bitmap);
                binaryWriter.Write(invalidName_5, 0, 20);
                binaryWriter.Write(maximumSpriteExtentPixels);
                binaryWriter.Write(invalidName_6, 0, 4);
            }
        }
        [FlagsAttribute]
        internal enum Flags : short
        
        {
            GeometryInheritedByNextDecalInChain = 1,
            InterpolateColorInHsv = 2,
            MoreColors = 4,
            NoRandomRotation = 8,
            UNUSED = 16,
            SAPIENSnapToAxis = 32,
            SAPIENIncrementalCounter = 64,
            UNUSED0 = 128,
            PreserveAspect = 256,
            UNUSED1 = 512,
        };
        internal enum TypeControlsHowTheDecalWrapsOntoSurfaceGeometry : short
        
        {
            Scratch = 0,
            Splatter = 1,
            Burn = 2,
            PaintedSign = 3,
        };
        internal enum Layer : short
        
        {
            LitAlphaBlendPrelight = 0,
            LitAlphaBlend = 1,
            DoubleMultiply = 2,
            Multiply = 3,
            Max = 4,
            Add = 5,
            Error = 6,
        };
    };
}
