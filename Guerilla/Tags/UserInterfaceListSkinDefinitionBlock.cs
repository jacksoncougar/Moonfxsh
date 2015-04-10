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
        public  UserInterfaceListSkinDefinitionBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  UserInterfaceListSkinDefinitionBlockBase(BinaryReader binaryReader)
        {
            this.listFlags = (ListFlags)binaryReader.ReadInt32();
            this.arrowsBitmap = binaryReader.ReadTagReference();
            this.upArrowsOffsetFromBotLeftOf1StItem = binaryReader.ReadPoint();
            this.downArrowsOffsetFromBotLeftOf1StItem = binaryReader.ReadPoint();
            this.itemAnimations = ReadSingleAnimationReferenceBlockArray(binaryReader);
            this.textBlocks = ReadTextBlockReferenceBlockArray(binaryReader);
            this.bitmapBlocks = ReadBitmapBlockReferenceBlockArray(binaryReader);
            this.hudBlocks = ReadHudBlockReferenceBlockArray(binaryReader);
            this.playerBlocks = ReadPlayerBlockReferenceBlockArray(binaryReader);
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
        internal  virtual SingleAnimationReferenceBlock[] ReadSingleAnimationReferenceBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SingleAnimationReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SingleAnimationReferenceBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SingleAnimationReferenceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual TextBlockReferenceBlock[] ReadTextBlockReferenceBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(TextBlockReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new TextBlockReferenceBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new TextBlockReferenceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual BitmapBlockReferenceBlock[] ReadBitmapBlockReferenceBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(BitmapBlockReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new BitmapBlockReferenceBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new BitmapBlockReferenceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual HudBlockReferenceBlock[] ReadHudBlockReferenceBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(HudBlockReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new HudBlockReferenceBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new HudBlockReferenceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PlayerBlockReferenceBlock[] ReadPlayerBlockReferenceBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PlayerBlockReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PlayerBlockReferenceBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PlayerBlockReferenceBlock(binaryReader);
                }
            }
            return array;
        }
        [FlagsAttribute]
        internal enum ListFlags : int
        
        {
            Unused = 1,
        };
    };
}
