using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class WindowPaneReferenceBlock : WindowPaneReferenceBlockBase
    {
        public  WindowPaneReferenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 76)]
    public class WindowPaneReferenceBlockBase
    {
        internal byte[] invalidName_;
        internal AnimationIndex animationIndex;
        internal ButtonWidgetReferenceBlock[] buttons;
        internal ListReferenceBlock[] listBlock;
        internal TableViewListReferenceBlock[] tableView;
        internal TextBlockReferenceBlock[] textBlocks;
        internal BitmapBlockReferenceBlock[] bitmapBlocks;
        internal UiModelSceneReferenceBlock[] modelSceneBlocks;
        internal STextValuePairBlocksBlockUNUSED[] textValueBlocks;
        internal HudBlockReferenceBlock[] hudBlocks;
        internal PlayerBlockReferenceBlock[] playerBlocks;
        internal  WindowPaneReferenceBlockBase(BinaryReader binaryReader)
        {
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.animationIndex = (AnimationIndex)binaryReader.ReadInt16();
            this.buttons = ReadButtonWidgetReferenceBlockArray(binaryReader);
            this.listBlock = ReadListReferenceBlockArray(binaryReader);
            this.tableView = ReadTableViewListReferenceBlockArray(binaryReader);
            this.textBlocks = ReadTextBlockReferenceBlockArray(binaryReader);
            this.bitmapBlocks = ReadBitmapBlockReferenceBlockArray(binaryReader);
            this.modelSceneBlocks = ReadUiModelSceneReferenceBlockArray(binaryReader);
            this.textValueBlocks = ReadSTextValuePairBlocksBlockUNUSEDArray(binaryReader);
            this.hudBlocks = ReadHudBlockReferenceBlockArray(binaryReader);
            this.playerBlocks = ReadPlayerBlockReferenceBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
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
        internal  virtual ButtonWidgetReferenceBlock[] ReadButtonWidgetReferenceBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ButtonWidgetReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ButtonWidgetReferenceBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ButtonWidgetReferenceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ListReferenceBlock[] ReadListReferenceBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ListReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ListReferenceBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ListReferenceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual TableViewListReferenceBlock[] ReadTableViewListReferenceBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(TableViewListReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new TableViewListReferenceBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new TableViewListReferenceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual TextBlockReferenceBlock[] ReadTextBlockReferenceBlockArray(BinaryReader binaryReader)
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
        internal  virtual BitmapBlockReferenceBlock[] ReadBitmapBlockReferenceBlockArray(BinaryReader binaryReader)
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
        internal  virtual UiModelSceneReferenceBlock[] ReadUiModelSceneReferenceBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(UiModelSceneReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new UiModelSceneReferenceBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new UiModelSceneReferenceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual STextValuePairBlocksBlockUNUSED[] ReadSTextValuePairBlocksBlockUNUSEDArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(STextValuePairBlocksBlockUNUSED));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new STextValuePairBlocksBlockUNUSED[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new STextValuePairBlocksBlockUNUSED(binaryReader);
                }
            }
            return array;
        }
        internal  virtual HudBlockReferenceBlock[] ReadHudBlockReferenceBlockArray(BinaryReader binaryReader)
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
        internal  virtual PlayerBlockReferenceBlock[] ReadPlayerBlockReferenceBlockArray(BinaryReader binaryReader)
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
        internal enum AnimationIndex : short
        
        {
            NONE = 0,
            InvalidName00 = 1,
            InvalidName01 = 2,
            InvalidName02 = 3,
            InvalidName03 = 4,
            InvalidName04 = 5,
            InvalidName05 = 6,
            InvalidName06 = 7,
            InvalidName07 = 8,
            InvalidName08 = 9,
            InvalidName09 = 10,
            InvalidName10 = 11,
            InvalidName11 = 12,
            InvalidName12 = 13,
            InvalidName13 = 14,
            InvalidName14 = 15,
            InvalidName15 = 16,
            InvalidName16 = 17,
            InvalidName17 = 18,
            InvalidName18 = 19,
            InvalidName19 = 20,
            InvalidName20 = 21,
            InvalidName21 = 22,
            InvalidName22 = 23,
            InvalidName23 = 24,
            InvalidName24 = 25,
            InvalidName25 = 26,
            InvalidName26 = 27,
            InvalidName27 = 28,
            InvalidName28 = 29,
            InvalidName29 = 30,
            InvalidName30 = 31,
            InvalidName31 = 32,
            InvalidName32 = 33,
            InvalidName33 = 34,
            InvalidName34 = 35,
            InvalidName35 = 36,
            InvalidName36 = 37,
            InvalidName37 = 38,
            InvalidName38 = 39,
            InvalidName39 = 40,
            InvalidName40 = 41,
            InvalidName41 = 42,
            InvalidName42 = 43,
            InvalidName43 = 44,
            InvalidName44 = 45,
            InvalidName45 = 46,
            InvalidName46 = 47,
            InvalidName47 = 48,
            InvalidName48 = 49,
            InvalidName49 = 50,
            InvalidName50 = 51,
            InvalidName51 = 52,
            InvalidName52 = 53,
            InvalidName53 = 54,
            InvalidName54 = 55,
            InvalidName55 = 56,
            InvalidName56 = 57,
            InvalidName57 = 58,
            InvalidName58 = 59,
            InvalidName59 = 60,
            InvalidName60 = 61,
            InvalidName61 = 62,
            InvalidName62 = 63,
            InvalidName63 = 64,
        };
    };
}
