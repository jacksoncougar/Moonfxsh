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
        public  DecalBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  DecalBlockBase(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt16();
            this.type = (TypeControlsHowTheDecalWrapsOntoSurfaceGeometry)binaryReader.ReadInt16();
            this.layer = (Layer)binaryReader.ReadInt16();
            this.maxOverlappingCount = binaryReader.ReadInt16();
            this.nextDecalInChain = binaryReader.ReadTagReference();
            this.radiusWorldUnits = binaryReader.ReadRange();
            this.radiusOverlapRejectionMuliplier = binaryReader.ReadSingle();
            this.colorLowerBounds = binaryReader.ReadColorR8G8B8();
            this.colorUpperBounds = binaryReader.ReadColorR8G8B8();
            this.lifetimeSeconds = binaryReader.ReadRange();
            this.decayTimeSeconds = binaryReader.ReadRange();
            this.invalidName_ = binaryReader.ReadBytes(40);
            this.invalidName_0 = binaryReader.ReadBytes(2);
            this.invalidName_1 = binaryReader.ReadBytes(2);
            this.invalidName_2 = binaryReader.ReadBytes(2);
            this.invalidName_3 = binaryReader.ReadBytes(2);
            this.invalidName_4 = binaryReader.ReadBytes(20);
            this.bitmap = binaryReader.ReadTagReference();
            this.invalidName_5 = binaryReader.ReadBytes(20);
            this.maximumSpriteExtentPixels = binaryReader.ReadSingle();
            this.invalidName_6 = binaryReader.ReadBytes(4);
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
