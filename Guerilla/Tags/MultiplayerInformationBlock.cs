using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class MultiplayerInformationBlock : MultiplayerInformationBlockBase
    {
        public  MultiplayerInformationBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 152)]
    public class MultiplayerInformationBlockBase
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
        internal  MultiplayerInformationBlockBase(BinaryReader binaryReader)
        {
            this.flag = binaryReader.ReadTagReference();
            this.unit = binaryReader.ReadTagReference();
            this.vehicles = ReadVehiclesBlockArray(binaryReader);
            this.hillShader = binaryReader.ReadTagReference();
            this.flagShader = binaryReader.ReadTagReference();
            this.ball = binaryReader.ReadTagReference();
            this.sounds = ReadSoundsBlockArray(binaryReader);
            this.inGameText = binaryReader.ReadTagReference();
            this.invalidName_ = binaryReader.ReadBytes(40);
            this.generalEvents = ReadGameEngineGeneralEventBlockArray(binaryReader);
            this.slayerEvents = ReadGameEngineSlayerEventBlockArray(binaryReader);
            this.ctfEvents = ReadGameEngineCtfEventBlockArray(binaryReader);
            this.oddballEvents = ReadGameEngineOddballEventBlockArray(binaryReader);
            this.gNullBlock = ReadGNullBlockArray(binaryReader);
            this.kingEvents = ReadGameEngineKingEventBlockArray(binaryReader);
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
        internal  virtual VehiclesBlock[] ReadVehiclesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(VehiclesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new VehiclesBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new VehiclesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual SoundsBlock[] ReadSoundsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SoundsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SoundsBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SoundsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GameEngineGeneralEventBlock[] ReadGameEngineGeneralEventBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GameEngineGeneralEventBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GameEngineGeneralEventBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GameEngineGeneralEventBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GameEngineSlayerEventBlock[] ReadGameEngineSlayerEventBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GameEngineSlayerEventBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GameEngineSlayerEventBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GameEngineSlayerEventBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GameEngineCtfEventBlock[] ReadGameEngineCtfEventBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GameEngineCtfEventBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GameEngineCtfEventBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GameEngineCtfEventBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GameEngineOddballEventBlock[] ReadGameEngineOddballEventBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GameEngineOddballEventBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GameEngineOddballEventBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GameEngineOddballEventBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GNullBlock[] ReadGNullBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GNullBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GNullBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GNullBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GameEngineKingEventBlock[] ReadGameEngineKingEventBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GameEngineKingEventBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GameEngineKingEventBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GameEngineKingEventBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
