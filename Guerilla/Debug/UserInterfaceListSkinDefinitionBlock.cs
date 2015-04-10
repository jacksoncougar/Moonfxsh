// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("skin")]
    public  partial class UserInterfaceListSkinDefinitionBlock : UserInterfaceListSkinDefinitionBlockBase
    {
        public  UserInterfaceListSkinDefinitionBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 60)]
    public class UserInterfaceListSkinDefinitionBlockBase
    {
        internal ListFlags listFlags;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference arrowsBitmap;
        internal Moonfish.Tags.Point upArrowsOffsetFromBotLeftOf1StItem;
        internal Moonfish.Tags.Point downArrowsOffsetFromBotLeftOf1StItem;
        internal SingleAnimationReferenceBlock[] itemAnimations;
        internal TextBlockReferenceBlock[] textBlocks;
        internal BitmapBlockReferenceBlock[] bitmapBlocks;
        internal HudBlockReferenceBlock[] hudBlocks;
        internal PlayerBlockReferenceBlock[] playerBlocks;
        internal  UserInterfaceListSkinDefinitionBlockBase(System.IO.BinaryReader binaryReader)
        {
            listFlags = (ListFlags)binaryReader.ReadInt32();
            arrowsBitmap = binaryReader.ReadTagReference();
            upArrowsOffsetFromBotLeftOf1StItem = binaryReader.ReadPoint();
            downArrowsOffsetFromBotLeftOf1StItem = binaryReader.ReadPoint();
            ReadSingleAnimationReferenceBlockArray(binaryReader);
            ReadTextBlockReferenceBlockArray(binaryReader);
            ReadBitmapBlockReferenceBlockArray(binaryReader);
            ReadHudBlockReferenceBlockArray(binaryReader);
            ReadPlayerBlockReferenceBlockArray(binaryReader);
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
        internal  virtual SingleAnimationReferenceBlock[] ReadSingleAnimationReferenceBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SingleAnimationReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SingleAnimationReferenceBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SingleAnimationReferenceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual TextBlockReferenceBlock[] ReadTextBlockReferenceBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(TextBlockReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new TextBlockReferenceBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new TextBlockReferenceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual BitmapBlockReferenceBlock[] ReadBitmapBlockReferenceBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(BitmapBlockReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new BitmapBlockReferenceBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new BitmapBlockReferenceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual HudBlockReferenceBlock[] ReadHudBlockReferenceBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(HudBlockReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new HudBlockReferenceBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new HudBlockReferenceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PlayerBlockReferenceBlock[] ReadPlayerBlockReferenceBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PlayerBlockReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PlayerBlockReferenceBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PlayerBlockReferenceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteSingleAnimationReferenceBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteTextBlockReferenceBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteBitmapBlockReferenceBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteHudBlockReferenceBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WritePlayerBlockReferenceBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)listFlags);
                binaryWriter.Write(arrowsBitmap);
                binaryWriter.Write(upArrowsOffsetFromBotLeftOf1StItem);
                binaryWriter.Write(downArrowsOffsetFromBotLeftOf1StItem);
                WriteSingleAnimationReferenceBlockArray(binaryWriter);
                WriteTextBlockReferenceBlockArray(binaryWriter);
                WriteBitmapBlockReferenceBlockArray(binaryWriter);
                WriteHudBlockReferenceBlockArray(binaryWriter);
                WritePlayerBlockReferenceBlockArray(binaryWriter);
            }
        }
        [FlagsAttribute]
        internal enum ListFlags : int
        
        {
            Unused = 1,
        };
    };
}
