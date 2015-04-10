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
        public  WeatherSystemBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  WeatherSystemBlockBase(BinaryReader binaryReader)
        {
            this.particleSystem = ReadGlobalParticleSystemLiteBlockArray(binaryReader);
            this.backgroundPlates = ReadGlobalWeatherBackgroundPlateBlockArray(binaryReader);
            this.windModel = new GlobalWindModelStructBlock(binaryReader);
            this.fadeRadius = binaryReader.ReadSingle();
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
        internal  virtual GlobalParticleSystemLiteBlock[] ReadGlobalParticleSystemLiteBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalParticleSystemLiteBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalParticleSystemLiteBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalParticleSystemLiteBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GlobalWeatherBackgroundPlateBlock[] ReadGlobalWeatherBackgroundPlateBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalWeatherBackgroundPlateBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalWeatherBackgroundPlateBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalWeatherBackgroundPlateBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
