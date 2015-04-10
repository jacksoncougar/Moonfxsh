// ReSharper disable All
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
        public  WeaponHudInterfaceBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  WeaponHudInterfaceBlockBase(System.IO.BinaryReader binaryReader)
        {
            childHud = binaryReader.ReadTagReference();
            flags = (Flags)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            inventoryAmmoCutoff = binaryReader.ReadInt16();
            loadedAmmoCutoff = binaryReader.ReadInt16();
            heatCutoff = binaryReader.ReadInt16();
            ageCutoff = binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(32);
            anchor = (Anchor)binaryReader.ReadInt16();
            invalidName_1 = binaryReader.ReadBytes(2);
            invalidName_2 = binaryReader.ReadBytes(32);
            ReadWeaponHudStaticBlockArray(binaryReader);
            ReadWeaponHudMeterBlockArray(binaryReader);
            ReadWeaponHudNumberBlockArray(binaryReader);
            ReadWeaponHudCrosshairBlockArray(binaryReader);
            ReadWeaponHudOverlaysBlockArray(binaryReader);
            invalidName_3 = binaryReader.ReadBytes(4);
            ReadGNullBlockArray(binaryReader);
            ReadGlobalHudScreenEffectDefinitionArray(binaryReader);
            invalidName_4 = binaryReader.ReadBytes(132);
            sequenceIndex = binaryReader.ReadInt16();
            widthOffset = binaryReader.ReadInt16();
            offsetFromReferenceCorner = binaryReader.ReadPoint();
            overrideIconColor = binaryReader.ReadColourA1R1G1B1();
            frameRate030 = binaryReader.ReadByte();
            flags0 = (Flags)binaryReader.ReadInt16();
            textIndex = binaryReader.ReadInt16();
            invalidName_5 = binaryReader.ReadBytes(48);
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
        internal  virtual WeaponHudStaticBlock[] ReadWeaponHudStaticBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(WeaponHudStaticBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new WeaponHudStaticBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new WeaponHudStaticBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual WeaponHudMeterBlock[] ReadWeaponHudMeterBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(WeaponHudMeterBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new WeaponHudMeterBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new WeaponHudMeterBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual WeaponHudNumberBlock[] ReadWeaponHudNumberBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(WeaponHudNumberBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new WeaponHudNumberBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new WeaponHudNumberBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual WeaponHudCrosshairBlock[] ReadWeaponHudCrosshairBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(WeaponHudCrosshairBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new WeaponHudCrosshairBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new WeaponHudCrosshairBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual WeaponHudOverlaysBlock[] ReadWeaponHudOverlaysBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(WeaponHudOverlaysBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new WeaponHudOverlaysBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new WeaponHudOverlaysBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GNullBlock[] ReadGNullBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GNullBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GNullBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GNullBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GlobalHudScreenEffectDefinition[] ReadGlobalHudScreenEffectDefinitionArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalHudScreenEffectDefinition));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalHudScreenEffectDefinition[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalHudScreenEffectDefinition(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteWeaponHudStaticBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteWeaponHudMeterBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteWeaponHudNumberBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteWeaponHudCrosshairBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteWeaponHudOverlaysBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGNullBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGlobalHudScreenEffectDefinitionArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(childHud);
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(inventoryAmmoCutoff);
                binaryWriter.Write(loadedAmmoCutoff);
                binaryWriter.Write(heatCutoff);
                binaryWriter.Write(ageCutoff);
                binaryWriter.Write(invalidName_0, 0, 32);
                binaryWriter.Write((Int16)anchor);
                binaryWriter.Write(invalidName_1, 0, 2);
                binaryWriter.Write(invalidName_2, 0, 32);
                WriteWeaponHudStaticBlockArray(binaryWriter);
                WriteWeaponHudMeterBlockArray(binaryWriter);
                WriteWeaponHudNumberBlockArray(binaryWriter);
                WriteWeaponHudCrosshairBlockArray(binaryWriter);
                WriteWeaponHudOverlaysBlockArray(binaryWriter);
                binaryWriter.Write(invalidName_3, 0, 4);
                WriteGNullBlockArray(binaryWriter);
                WriteGlobalHudScreenEffectDefinitionArray(binaryWriter);
                binaryWriter.Write(invalidName_4, 0, 132);
                binaryWriter.Write(sequenceIndex);
                binaryWriter.Write(widthOffset);
                binaryWriter.Write(offsetFromReferenceCorner);
                binaryWriter.Write(overrideIconColor);
                binaryWriter.Write(frameRate030);
                binaryWriter.Write((Int16)flags0);
                binaryWriter.Write(textIndex);
                binaryWriter.Write(invalidName_5, 0, 48);
            }
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
