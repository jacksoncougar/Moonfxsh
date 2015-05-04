// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class MultiplayerInformationBlock : MultiplayerInformationBlockBase
    {
        public MultiplayerInformationBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 152, Alignment = 4)]
    public class MultiplayerInformationBlockBase : GuerillaBlock
    {
        [TagReference("item")]
        internal Moonfish.Tags.TagReference flag;
        [TagReference("unit")]
        internal Moonfish.Tags.TagReference unit;
        internal VehiclesBlock[] vehicles;
        [TagReference("shad")]
        internal Moonfish.Tags.TagReference hillShader;
        [TagReference("shad")]
        internal Moonfish.Tags.TagReference flagShader;
        [TagReference("item")]
        internal Moonfish.Tags.TagReference ball;
        internal SoundsBlock[] sounds;
        [TagReference("unic")]
        internal Moonfish.Tags.TagReference inGameText;
        internal byte[] invalidName_;
        internal GameEngineGeneralEventBlock[] generalEvents;
        internal GameEngineSlayerEventBlock[] slayerEvents;
        internal GameEngineCtfEventBlock[] ctfEvents;
        internal GameEngineOddballEventBlock[] oddballEvents;
        internal GNullBlock[] gNullBlock;
        internal GameEngineKingEventBlock[] kingEvents;
        public override int SerializedSize { get { return 152; } }
        public override int Alignment { get { return 4; } }
        public MultiplayerInformationBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            flag = binaryReader.ReadTagReference();
            unit = binaryReader.ReadTagReference();
            blamPointers.Enqueue(ReadBlockArrayPointer<VehiclesBlock>(binaryReader));
            hillShader = binaryReader.ReadTagReference();
            flagShader = binaryReader.ReadTagReference();
            ball = binaryReader.ReadTagReference();
            blamPointers.Enqueue(ReadBlockArrayPointer<SoundsBlock>(binaryReader));
            inGameText = binaryReader.ReadTagReference();
            invalidName_ = binaryReader.ReadBytes(40);
            blamPointers.Enqueue(ReadBlockArrayPointer<GameEngineGeneralEventBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<GameEngineSlayerEventBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<GameEngineCtfEventBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<GameEngineOddballEventBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<GNullBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<GameEngineKingEventBlock>(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            vehicles = ReadBlockArrayData<VehiclesBlock>(binaryReader, blamPointers.Dequeue());
            sounds = ReadBlockArrayData<SoundsBlock>(binaryReader, blamPointers.Dequeue());
            invalidName_[0].ReadPointers(binaryReader, blamPointers);
            invalidName_[1].ReadPointers(binaryReader, blamPointers);
            invalidName_[2].ReadPointers(binaryReader, blamPointers);
            invalidName_[3].ReadPointers(binaryReader, blamPointers);
            invalidName_[4].ReadPointers(binaryReader, blamPointers);
            invalidName_[5].ReadPointers(binaryReader, blamPointers);
            invalidName_[6].ReadPointers(binaryReader, blamPointers);
            invalidName_[7].ReadPointers(binaryReader, blamPointers);
            invalidName_[8].ReadPointers(binaryReader, blamPointers);
            invalidName_[9].ReadPointers(binaryReader, blamPointers);
            invalidName_[10].ReadPointers(binaryReader, blamPointers);
            invalidName_[11].ReadPointers(binaryReader, blamPointers);
            invalidName_[12].ReadPointers(binaryReader, blamPointers);
            invalidName_[13].ReadPointers(binaryReader, blamPointers);
            invalidName_[14].ReadPointers(binaryReader, blamPointers);
            invalidName_[15].ReadPointers(binaryReader, blamPointers);
            invalidName_[16].ReadPointers(binaryReader, blamPointers);
            invalidName_[17].ReadPointers(binaryReader, blamPointers);
            invalidName_[18].ReadPointers(binaryReader, blamPointers);
            invalidName_[19].ReadPointers(binaryReader, blamPointers);
            invalidName_[20].ReadPointers(binaryReader, blamPointers);
            invalidName_[21].ReadPointers(binaryReader, blamPointers);
            invalidName_[22].ReadPointers(binaryReader, blamPointers);
            invalidName_[23].ReadPointers(binaryReader, blamPointers);
            invalidName_[24].ReadPointers(binaryReader, blamPointers);
            invalidName_[25].ReadPointers(binaryReader, blamPointers);
            invalidName_[26].ReadPointers(binaryReader, blamPointers);
            invalidName_[27].ReadPointers(binaryReader, blamPointers);
            invalidName_[28].ReadPointers(binaryReader, blamPointers);
            invalidName_[29].ReadPointers(binaryReader, blamPointers);
            invalidName_[30].ReadPointers(binaryReader, blamPointers);
            invalidName_[31].ReadPointers(binaryReader, blamPointers);
            invalidName_[32].ReadPointers(binaryReader, blamPointers);
            invalidName_[33].ReadPointers(binaryReader, blamPointers);
            invalidName_[34].ReadPointers(binaryReader, blamPointers);
            invalidName_[35].ReadPointers(binaryReader, blamPointers);
            invalidName_[36].ReadPointers(binaryReader, blamPointers);
            invalidName_[37].ReadPointers(binaryReader, blamPointers);
            invalidName_[38].ReadPointers(binaryReader, blamPointers);
            invalidName_[39].ReadPointers(binaryReader, blamPointers);
            generalEvents = ReadBlockArrayData<GameEngineGeneralEventBlock>(binaryReader, blamPointers.Dequeue());
            slayerEvents = ReadBlockArrayData<GameEngineSlayerEventBlock>(binaryReader, blamPointers.Dequeue());
            ctfEvents = ReadBlockArrayData<GameEngineCtfEventBlock>(binaryReader, blamPointers.Dequeue());
            oddballEvents = ReadBlockArrayData<GameEngineOddballEventBlock>(binaryReader, blamPointers.Dequeue());
            gNullBlock = ReadBlockArrayData<GNullBlock>(binaryReader, blamPointers.Dequeue());
            kingEvents = ReadBlockArrayData<GameEngineKingEventBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(flag);
                binaryWriter.Write(unit);
                nextAddress = Guerilla.WriteBlockArray<VehiclesBlock>(binaryWriter, vehicles, nextAddress);
                binaryWriter.Write(hillShader);
                binaryWriter.Write(flagShader);
                binaryWriter.Write(ball);
                nextAddress = Guerilla.WriteBlockArray<SoundsBlock>(binaryWriter, sounds, nextAddress);
                binaryWriter.Write(inGameText);
                binaryWriter.Write(invalidName_, 0, 40);
                nextAddress = Guerilla.WriteBlockArray<GameEngineGeneralEventBlock>(binaryWriter, generalEvents, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GameEngineSlayerEventBlock>(binaryWriter, slayerEvents, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GameEngineCtfEventBlock>(binaryWriter, ctfEvents, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GameEngineOddballEventBlock>(binaryWriter, oddballEvents, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GNullBlock>(binaryWriter, gNullBlock, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GameEngineKingEventBlock>(binaryWriter, kingEvents, nextAddress);
                return nextAddress;
            }
        }
    };
}
