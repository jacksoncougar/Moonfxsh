//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Moonfish.Guerilla.Tags
{
    using Moonfish.Tags;
    using Moonfish.Model;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    
    public partial class WindowPaneReferenceBlock : GuerillaBlock, IWriteQueueable
    {
        /// <summary>
        /// Define the screen's panes here (normal screens have 1 pane, tab-view screens have 2+ panes)
        /// </summary>
        private byte[] fieldpad = new byte[2];
        public AnimationIndexEnum AnimationIndex;
        public ButtonWidgetReferenceBlock[] Buttons = new ButtonWidgetReferenceBlock[0];
        public ListReferenceBlock[] ListBlock = new ListReferenceBlock[0];
        public TableViewListReferenceBlock[] TableView = new TableViewListReferenceBlock[0];
        public TextBlockReferenceBlock[] TextBlocks = new TextBlockReferenceBlock[0];
        public BitmapBlockReferenceBlock[] BitmapBlocks = new BitmapBlockReferenceBlock[0];
        public UiModelSceneReferenceBlock[] ModelSceneBlocks = new UiModelSceneReferenceBlock[0];
        public STextValuePairBlocksBlockUNUSED[] TextvalueBlocks = new STextValuePairBlocksBlockUNUSED[0];
        public HudBlockReferenceBlock[] HudBlocks = new HudBlockReferenceBlock[0];
        public PlayerBlockReferenceBlock[] PlayerBlocks = new PlayerBlockReferenceBlock[0];
        public override int SerializedSize
        {
            get
            {
                return 76;
            }
        }
        public override int Alignment
        {
            get
            {
                return 4;
            }
        }
        public override System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> ReadFields(System.IO.BinaryReader binaryReader)
        {
            System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(base.ReadFields(binaryReader));
            this.fieldpad = binaryReader.ReadBytes(2);
            this.AnimationIndex = ((AnimationIndexEnum)(binaryReader.ReadInt16()));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(60));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(24));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(40));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(44));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(56));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(76));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(40));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(36));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(24));
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.Buttons = base.ReadBlockArrayData<ButtonWidgetReferenceBlock>(binaryReader, pointerQueue.Dequeue());
            this.ListBlock = base.ReadBlockArrayData<ListReferenceBlock>(binaryReader, pointerQueue.Dequeue());
            this.TableView = base.ReadBlockArrayData<TableViewListReferenceBlock>(binaryReader, pointerQueue.Dequeue());
            this.TextBlocks = base.ReadBlockArrayData<TextBlockReferenceBlock>(binaryReader, pointerQueue.Dequeue());
            this.BitmapBlocks = base.ReadBlockArrayData<BitmapBlockReferenceBlock>(binaryReader, pointerQueue.Dequeue());
            this.ModelSceneBlocks = base.ReadBlockArrayData<UiModelSceneReferenceBlock>(binaryReader, pointerQueue.Dequeue());
            this.TextvalueBlocks = base.ReadBlockArrayData<STextValuePairBlocksBlockUNUSED>(binaryReader, pointerQueue.Dequeue());
            this.HudBlocks = base.ReadBlockArrayData<HudBlockReferenceBlock>(binaryReader, pointerQueue.Dequeue());
            this.PlayerBlocks = base.ReadBlockArrayData<PlayerBlockReferenceBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.QueueWrites(queueableBlamBinaryWriter);
            queueableBlamBinaryWriter.QueueWrite(this.Buttons);
            queueableBlamBinaryWriter.QueueWrite(this.ListBlock);
            queueableBlamBinaryWriter.QueueWrite(this.TableView);
            queueableBlamBinaryWriter.QueueWrite(this.TextBlocks);
            queueableBlamBinaryWriter.QueueWrite(this.BitmapBlocks);
            queueableBlamBinaryWriter.QueueWrite(this.ModelSceneBlocks);
            queueableBlamBinaryWriter.QueueWrite(this.TextvalueBlocks);
            queueableBlamBinaryWriter.QueueWrite(this.HudBlocks);
            queueableBlamBinaryWriter.QueueWrite(this.PlayerBlocks);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.Write_(queueableBlamBinaryWriter);
            queueableBlamBinaryWriter.Write(this.fieldpad);
            queueableBlamBinaryWriter.Write(((short)(this.AnimationIndex)));
            queueableBlamBinaryWriter.WritePointer(this.Buttons);
            queueableBlamBinaryWriter.WritePointer(this.ListBlock);
            queueableBlamBinaryWriter.WritePointer(this.TableView);
            queueableBlamBinaryWriter.WritePointer(this.TextBlocks);
            queueableBlamBinaryWriter.WritePointer(this.BitmapBlocks);
            queueableBlamBinaryWriter.WritePointer(this.ModelSceneBlocks);
            queueableBlamBinaryWriter.WritePointer(this.TextvalueBlocks);
            queueableBlamBinaryWriter.WritePointer(this.HudBlocks);
            queueableBlamBinaryWriter.WritePointer(this.PlayerBlocks);
        }
        public enum AnimationIndexEnum : short
        {
            NONE = 0,
            _00 = 1,
            _01 = 2,
            _02 = 3,
            _03 = 4,
            _04 = 5,
            _05 = 6,
            _06 = 7,
            _07 = 8,
            _08 = 9,
            _09 = 10,
            _10 = 11,
            _11 = 12,
            _12 = 13,
            _13 = 14,
            _14 = 15,
            _15 = 16,
            _16 = 17,
            _17 = 18,
            _18 = 19,
            _19 = 20,
            _20 = 21,
            _21 = 22,
            _22 = 23,
            _23 = 24,
            _24 = 25,
            _25 = 26,
            _26 = 27,
            _27 = 28,
            _28 = 29,
            _29 = 30,
            _30 = 31,
            _31 = 32,
            _32 = 33,
            _33 = 34,
            _34 = 35,
            _35 = 36,
            _36 = 37,
            _37 = 38,
            _38 = 39,
            _39 = 40,
            _40 = 41,
            _41 = 42,
            _42 = 43,
            _43 = 44,
            _44 = 45,
            _45 = 46,
            _46 = 47,
            _47 = 48,
            _48 = 49,
            _49 = 50,
            _50 = 51,
            _51 = 52,
            _52 = 53,
            _53 = 54,
            _54 = 55,
            _55 = 56,
            _56 = 57,
            _57 = 58,
            _58 = 59,
            _59 = 60,
            _60 = 61,
            _61 = 62,
            _62 = 63,
            _63 = 64,
        }
    }
}
