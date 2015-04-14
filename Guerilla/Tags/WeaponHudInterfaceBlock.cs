using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("wphi")]
    public  partial class WeaponHudInterfaceBlock : WeaponHudInterfaceBlockBase
    {
        public  WeaponHudInterfaceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 344)]
    public class WeaponHudInterfaceBlockBase
    {
        [TagReference("wphi")]
        internal Moonfish.Tags.TagReference childHud;
        internal Flags flags;
        internal byte[] invalidName_;
        internal short inventoryAmmoCutoff;
        internal short loadedAmmoCutoff;
        internal short heatCutoff;
        internal short ageCutoff;
        internal byte[] invalidName_0;
        internal Anchor anchor;
        internal byte[] invalidName_1;
        internal byte[] invalidName_2;
        internal WeaponHudStaticBlock[] staticElements;
        internal WeaponHudMeterBlock[] meterElements;
        internal WeaponHudNumberBlock[] numberElements;
        internal WeaponHudCrosshairBlock[] crosshairs;
        internal WeaponHudOverlaysBlock[] overlayElements;
        internal byte[] invalidName_3;
        internal GNullBlock[] gNullBlock;
        internal GlobalHudScreenEffectDefinition[] screenEffect;
        internal byte[] invalidName_4;
        /// <summary>
        /// sequenceIndex into the global hud icon bitmap
        /// </summary>
        internal short sequenceIndex;
        /// <summary>
        /// extra spacing beyond bitmap width for text alignment
        /// </summary>
        internal short widthOffset;
        internal Moonfish.Tags.Point offsetFromReferenceCorner;
        internal Moonfish.Tags.ColourA1R1G1B1 overrideIconColor;
        internal byte frameRate030;
        internal Flags flags0;
        internal short textIndex;
        internal byte[] invalidName_5;
        internal  WeaponHudInterfaceBlockBase(BinaryReader binaryReader)
        {
            this.childHud = binaryReader.ReadTagReference();
            this.flags = (Flags)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.inventoryAmmoCutoff = binaryReader.ReadInt16();
            this.loadedAmmoCutoff = binaryReader.ReadInt16();
            this.heatCutoff = binaryReader.ReadInt16();
            this.ageCutoff = binaryReader.ReadInt16();
            this.invalidName_0 = binaryReader.ReadBytes(32);
            this.anchor = (Anchor)binaryReader.ReadInt16();
            this.invalidName_1 = binaryReader.ReadBytes(2);
            this.invalidName_2 = binaryReader.ReadBytes(32);
            this.staticElements = ReadWeaponHudStaticBlockArray(binaryReader);
            this.meterElements = ReadWeaponHudMeterBlockArray(binaryReader);
            this.numberElements = ReadWeaponHudNumberBlockArray(binaryReader);
            this.crosshairs = ReadWeaponHudCrosshairBlockArray(binaryReader);
            this.overlayElements = ReadWeaponHudOverlaysBlockArray(binaryReader);
            this.invalidName_3 = binaryReader.ReadBytes(4);
            this.gNullBlock = ReadGNullBlockArray(binaryReader);
            this.screenEffect = ReadGlobalHudScreenEffectDefinitionArray(binaryReader);
            this.invalidName_4 = binaryReader.ReadBytes(132);
            this.sequenceIndex = binaryReader.ReadInt16();
            this.widthOffset = binaryReader.ReadInt16();
            this.offsetFromReferenceCorner = binaryReader.ReadPoint();
            this.overrideIconColor = binaryReader.ReadColourA1R1G1B1();
            this.frameRate030 = binaryReader.ReadByte();
            this.flags0 = (Flags)binaryReader.ReadInt16();
            this.textIndex = binaryReader.ReadInt16();
            this.invalidName_5 = binaryReader.ReadBytes(48);
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
        internal  virtual WeaponHudStaticBlock[] ReadWeaponHudStaticBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(WeaponHudStaticBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new WeaponHudStaticBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new WeaponHudStaticBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual WeaponHudMeterBlock[] ReadWeaponHudMeterBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(WeaponHudMeterBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new WeaponHudMeterBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new WeaponHudMeterBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual WeaponHudNumberBlock[] ReadWeaponHudNumberBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(WeaponHudNumberBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new WeaponHudNumberBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new WeaponHudNumberBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual WeaponHudCrosshairBlock[] ReadWeaponHudCrosshairBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(WeaponHudCrosshairBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new WeaponHudCrosshairBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new WeaponHudCrosshairBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual WeaponHudOverlaysBlock[] ReadWeaponHudOverlaysBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(WeaponHudOverlaysBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new WeaponHudOverlaysBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new WeaponHudOverlaysBlock(binaryReader);
                }
            }
            return array;
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
        internal  virtual GlobalHudScreenEffectDefinition[] ReadGlobalHudScreenEffectDefinitionArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalHudScreenEffectDefinition));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalHudScreenEffectDefinition[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalHudScreenEffectDefinition(binaryReader);
                }
            }
            return array;
        }
        [FlagsAttribute]
        internal enum Flags : short
        
        {
            UseParentHudFlashingParameters = 1,
        };
        internal enum Anchor : short
        
        {
            TopLeft = 0,
            TopRight = 1,
            BottomLeft = 2,
            BottomRight = 3,
            Center = 4,
            Crosshair = 5,
        };
        [FlagsAttribute]
        internal enum Flags0 : byte
        
        {
            UseTextFromStringListInstead = 1,
            OverrideDefaultColor = 2,
            WidthOffsetIsAbsoluteIconWidth = 4,
        };
    };
}
