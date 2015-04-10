// ReSharper disable All
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
        public  MultiplayerInformationBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  MultiplayerInformationBlockBase(System.IO.BinaryReader binaryReader)
        {
            flag = binaryReader.ReadTagReference();
            unit = binaryReader.ReadTagReference();
            ReadVehiclesBlockArray(binaryReader);
            hillShader = binaryReader.ReadTagReference();
            flagShader = binaryReader.ReadTagReference();
            ball = binaryReader.ReadTagReference();
            ReadSoundsBlockArray(binaryReader);
            inGameText = binaryReader.ReadTagReference();
            invalidName_ = binaryReader.ReadBytes(40);
            ReadGameEngineGeneralEventBlockArray(binaryReader);
            ReadGameEngineSlayerEventBlockArray(binaryReader);
            ReadGameEngineCtfEventBlockArray(binaryReader);
            ReadGameEngineOddballEventBlockArray(binaryReader);
            ReadGNullBlockArray(binaryReader);
            ReadGameEngineKingEventBlockArray(binaryReader);
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
        internal  virtual VehiclesBlock[] ReadVehiclesBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(VehiclesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new VehiclesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new VehiclesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual SoundsBlock[] ReadSoundsBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SoundsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SoundsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SoundsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GameEngineGeneralEventBlock[] ReadGameEngineGeneralEventBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GameEngineGeneralEventBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GameEngineGeneralEventBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GameEngineGeneralEventBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GameEngineSlayerEventBlock[] ReadGameEngineSlayerEventBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GameEngineSlayerEventBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GameEngineSlayerEventBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GameEngineSlayerEventBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GameEngineCtfEventBlock[] ReadGameEngineCtfEventBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GameEngineCtfEventBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GameEngineCtfEventBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GameEngineCtfEventBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GameEngineOddballEventBlock[] ReadGameEngineOddballEventBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GameEngineOddballEventBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GameEngineOddballEventBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GameEngineOddballEventBlock(binaryReader);
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
        internal  virtual GameEngineKingEventBlock[] ReadGameEngineKingEventBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GameEngineKingEventBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GameEngineKingEventBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GameEngineKingEventBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteVehiclesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteSoundsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGameEngineGeneralEventBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGameEngineSlayerEventBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGameEngineCtfEventBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGameEngineOddballEventBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGNullBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGameEngineKingEventBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(flag);
                binaryWriter.Write(unit);
                WriteVehiclesBlockArray(binaryWriter);
                binaryWriter.Write(hillShader);
                binaryWriter.Write(flagShader);
                binaryWriter.Write(ball);
                WriteSoundsBlockArray(binaryWriter);
                binaryWriter.Write(inGameText);
                binaryWriter.Write(invalidName_, 0, 40);
                WriteGameEngineGeneralEventBlockArray(binaryWriter);
                WriteGameEngineSlayerEventBlockArray(binaryWriter);
                WriteGameEngineCtfEventBlockArray(binaryWriter);
                WriteGameEngineOddballEventBlockArray(binaryWriter);
                WriteGNullBlockArray(binaryWriter);
                WriteGameEngineKingEventBlockArray(binaryWriter);
            }
        }
    };
}
