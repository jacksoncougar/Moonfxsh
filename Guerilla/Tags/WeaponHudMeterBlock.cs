using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class WeaponHudMeterBlock : WeaponHudMeterBlockBase
    {
        public  WeaponHudMeterBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 165)]
    public class WeaponHudMeterBlockBase
    {
        internal StateAttachedTo stateAttachedTo;
        internal byte[] invalidName_;
        internal CanUseOnMapType canUseOnMapType;
        internal byte[] invalidName_0;
        internal byte[] invalidName_1;
        internal Moonfish.Tags.Point anchorOffset;
        internal float widthScale;
        internal float heightScale;
        internal ScalingFlags scalingFlags;
        internal byte[] invalidName_2;
        internal byte[] invalidName_3;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference meterBitmap;
        internal Moonfish.Tags.RGBColor colorAtMeterMinimum;
        internal Moonfish.Tags.RGBColor colorAtMeterMaximum;
        internal Moonfish.Tags.RGBColor flashColor;
        internal Moonfish.Tags.ColourA1R1G1B1 emptyColor;
        internal Flags flags;
        internal byte minumumMeterValue;
        internal short sequenceIndex;
        internal byte alphaMultiplier;
        internal byte alphaBias;
        /// <summary>
        /// used for non-integral values, i.e. health and shields
        /// </summary>
        internal short valueScale;
        internal float opacity;
        internal float translucency;
        internal Moonfish.Tags.ColourA1R1G1B1 disabledColor;
        internal GNullBlock[] gNullBlock;
        internal byte[] invalidName_4;
        internal byte[] invalidName_5;
        internal  WeaponHudMeterBlockBase(BinaryReader binaryReader)
        {
            this.stateAttachedTo = (StateAttachedTo)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.canUseOnMapType = (CanUseOnMapType)binaryReader.ReadInt16();
            this.invalidName_0 = binaryReader.ReadBytes(2);
            this.invalidName_1 = binaryReader.ReadBytes(28);
            this.anchorOffset = binaryReader.ReadPoint();
            this.widthScale = binaryReader.ReadSingle();
            this.heightScale = binaryReader.ReadSingle();
            this.scalingFlags = (ScalingFlags)binaryReader.ReadInt16();
            this.invalidName_2 = binaryReader.ReadBytes(2);
            this.invalidName_3 = binaryReader.ReadBytes(20);
            this.meterBitmap = binaryReader.ReadTagReference();
            this.colorAtMeterMinimum = binaryReader.ReadRGBColor();
            this.colorAtMeterMaximum = binaryReader.ReadRGBColor();
            this.flashColor = binaryReader.ReadRGBColor();
            this.emptyColor = binaryReader.ReadColourA1R1G1B1();
            this.flags = (Flags)binaryReader.ReadByte();
            this.minumumMeterValue = binaryReader.ReadByte();
            this.sequenceIndex = binaryReader.ReadInt16();
            this.alphaMultiplier = binaryReader.ReadByte();
            this.alphaBias = binaryReader.ReadByte();
            this.valueScale = binaryReader.ReadInt16();
            this.opacity = binaryReader.ReadSingle();
            this.translucency = binaryReader.ReadSingle();
            this.disabledColor = binaryReader.ReadColourA1R1G1B1();
            this.gNullBlock = ReadGNullBlockArray(binaryReader);
            this.invalidName_4 = binaryReader.ReadBytes(4);
            this.invalidName_5 = binaryReader.ReadBytes(40);
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
        internal  virtual GNullBlock[] ReadGNullBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GNullBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GNullBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GNullBlock(binaryReader);
                }
            }
            return array;
        }
        internal enum StateAttachedTo : short
        
        {
            InventoryAmmo = 0,
            LoadedAmmo = 1,
            Heat = 2,
            Age = 3,
            SecondaryWeaponInventoryAmmo = 4,
            SecondaryWeaponLoadedAmmo = 5,
            DistanceToTarget = 6,
            ElevationToTarget = 7,
        };
        internal enum CanUseOnMapType : short
        
        {
            Any = 0,
            Solo = 1,
            Multiplayer = 2,
        };
        [FlagsAttribute]
        internal enum ScalingFlags : short
        
        {
            DontScaleOffset = 1,
            DontScaleSize = 2,
        };
        [FlagsAttribute]
        internal enum Flags : byte
        
        {
            UseMinMaxForStateChanges = 1,
            InterpolateBetweenMinMaxFlashColorsAsStateChanges = 2,
            InterpolateColorAlongHsvSpace = 4,
            MoreColorsForHsvInterpolation = 8,
            InvertInterpolation = 16,
        };
    };
}
