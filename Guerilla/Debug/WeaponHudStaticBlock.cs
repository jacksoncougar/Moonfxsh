// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class WeaponHudStaticBlock : WeaponHudStaticBlockBase
    {
        public  WeaponHudStaticBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 168)]
    public class WeaponHudStaticBlockBase
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
        internal Moonfish.Tags.TagReference interfaceBitmap;
        internal Moonfish.Tags.ColourA1R1G1B1 defaultColor;
        internal Moonfish.Tags.ColourA1R1G1B1 flashingColor;
        internal float flashPeriod;
        /// <summary>
        /// time between flashes
        /// </summary>
        internal float flashDelay;
        internal short numberOfFlashes;
        internal FlashFlags flashFlags;
        /// <summary>
        /// time of each flash
        /// </summary>
        internal float flashLength;
        internal Moonfish.Tags.ColourA1R1G1B1 disabledColor;
        internal byte[] invalidName_4;
        internal short sequenceIndex;
        internal byte[] invalidName_5;
        internal GlobalHudMultitextureOverlayDefinition[] multitexOverlay;
        internal byte[] invalidName_6;
        internal byte[] invalidName_7;
        internal  WeaponHudStaticBlockBase(System.IO.BinaryReader binaryReader)
        {
            stateAttachedTo = (StateAttachedTo)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            canUseOnMapType = (CanUseOnMapType)binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(2);
            invalidName_1 = binaryReader.ReadBytes(28);
            anchorOffset = binaryReader.ReadPoint();
            widthScale = binaryReader.ReadSingle();
            heightScale = binaryReader.ReadSingle();
            scalingFlags = (ScalingFlags)binaryReader.ReadInt16();
            invalidName_2 = binaryReader.ReadBytes(2);
            invalidName_3 = binaryReader.ReadBytes(20);
            interfaceBitmap = binaryReader.ReadTagReference();
            defaultColor = binaryReader.ReadColourA1R1G1B1();
            flashingColor = binaryReader.ReadColourA1R1G1B1();
            flashPeriod = binaryReader.ReadSingle();
            flashDelay = binaryReader.ReadSingle();
            numberOfFlashes = binaryReader.ReadInt16();
            flashFlags = (FlashFlags)binaryReader.ReadInt16();
            flashLength = binaryReader.ReadSingle();
            disabledColor = binaryReader.ReadColourA1R1G1B1();
            invalidName_4 = binaryReader.ReadBytes(4);
            sequenceIndex = binaryReader.ReadInt16();
            invalidName_5 = binaryReader.ReadBytes(2);
            ReadGlobalHudMultitextureOverlayDefinitionArray(binaryReader);
            invalidName_6 = binaryReader.ReadBytes(4);
            invalidName_7 = binaryReader.ReadBytes(40);
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
        internal  virtual GlobalHudMultitextureOverlayDefinition[] ReadGlobalHudMultitextureOverlayDefinitionArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalHudMultitextureOverlayDefinition));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalHudMultitextureOverlayDefinition[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalHudMultitextureOverlayDefinition(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGlobalHudMultitextureOverlayDefinitionArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)stateAttachedTo);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write((Int16)canUseOnMapType);
                binaryWriter.Write(invalidName_0, 0, 2);
                binaryWriter.Write(invalidName_1, 0, 28);
                binaryWriter.Write(anchorOffset);
                binaryWriter.Write(widthScale);
                binaryWriter.Write(heightScale);
                binaryWriter.Write((Int16)scalingFlags);
                binaryWriter.Write(invalidName_2, 0, 2);
                binaryWriter.Write(invalidName_3, 0, 20);
                binaryWriter.Write(interfaceBitmap);
                binaryWriter.Write(defaultColor);
                binaryWriter.Write(flashingColor);
                binaryWriter.Write(flashPeriod);
                binaryWriter.Write(flashDelay);
                binaryWriter.Write(numberOfFlashes);
                binaryWriter.Write((Int16)flashFlags);
                binaryWriter.Write(flashLength);
                binaryWriter.Write(disabledColor);
                binaryWriter.Write(invalidName_4, 0, 4);
                binaryWriter.Write(sequenceIndex);
                binaryWriter.Write(invalidName_5, 0, 2);
                WriteGlobalHudMultitextureOverlayDefinitionArray(binaryWriter);
                binaryWriter.Write(invalidName_6, 0, 4);
                binaryWriter.Write(invalidName_7, 0, 40);
            }
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
        internal enum FlashFlags : short
        
        {
            ReverseDefaultFlashingColors = 1,
        };
    };
}
