// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("weat")]
    public  partial class WeatherSystemBlock : WeatherSystemBlockBase
    {
        public  WeatherSystemBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 176)]
    public class WeatherSystemBlockBase
    {
        internal GlobalParticleSystemLiteBlock[] particleSystem;
        internal GlobalWeatherBackgroundPlateBlock[] backgroundPlates;
        internal GlobalWindModelStructBlock windModel;
        internal float fadeRadius;
        internal  WeatherSystemBlockBase(System.IO.BinaryReader binaryReader)
        {
            ReadGlobalParticleSystemLiteBlockArray(binaryReader);
            ReadGlobalWeatherBackgroundPlateBlockArray(binaryReader);
            windModel = new GlobalWindModelStructBlock(binaryReader);
            fadeRadius = binaryReader.ReadSingle();
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
        internal  virtual GlobalParticleSystemLiteBlock[] ReadGlobalParticleSystemLiteBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalParticleSystemLiteBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalParticleSystemLiteBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalParticleSystemLiteBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GlobalWeatherBackgroundPlateBlock[] ReadGlobalWeatherBackgroundPlateBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalWeatherBackgroundPlateBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalWeatherBackgroundPlateBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalWeatherBackgroundPlateBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGlobalParticleSystemLiteBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGlobalWeatherBackgroundPlateBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                WriteGlobalParticleSystemLiteBlockArray(binaryWriter);
                WriteGlobalWeatherBackgroundPlateBlockArray(binaryWriter);
                windModel.Write(binaryWriter);
                binaryWriter.Write(fadeRadius);
            }
        }
    };
}
