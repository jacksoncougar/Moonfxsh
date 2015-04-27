// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class MultiplayerInformationBlock : MultiplayerInformationBlockBase
    {
        public  MultiplayerInformationBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  MultiplayerInformationBlock(): base()
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
        
        public override int SerializedSize{get { return 152; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  MultiplayerInformationBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            flag = binaryReader.ReadTagReference();
            unit = binaryReader.ReadTagReference();
            vehicles = Guerilla.ReadBlockArray<VehiclesBlock>(binaryReader);
            hillShader = binaryReader.ReadTagReference();
            flagShader = binaryReader.ReadTagReference();
            ball = binaryReader.ReadTagReference();
            sounds = Guerilla.ReadBlockArray<SoundsBlock>(binaryReader);
            inGameText = binaryReader.ReadTagReference();
            invalidName_ = binaryReader.ReadBytes(40);
            generalEvents = Guerilla.ReadBlockArray<GameEngineGeneralEventBlock>(binaryReader);
            slayerEvents = Guerilla.ReadBlockArray<GameEngineSlayerEventBlock>(binaryReader);
            ctfEvents = Guerilla.ReadBlockArray<GameEngineCtfEventBlock>(binaryReader);
            oddballEvents = Guerilla.ReadBlockArray<GameEngineOddballEventBlock>(binaryReader);
            gNullBlock = Guerilla.ReadBlockArray<GNullBlock>(binaryReader);
            kingEvents = Guerilla.ReadBlockArray<GameEngineKingEventBlock>(binaryReader);
        }
        public  MultiplayerInformationBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
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
