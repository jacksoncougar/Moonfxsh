// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Weat = (TagClass)"weat";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("weat")]
    public partial class WeatherSystemBlock : WeatherSystemBlockBase
    {
        public  WeatherSystemBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  WeatherSystemBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 176, Alignment = 4)]
    public class WeatherSystemBlockBase : GuerillaBlock
    {
        internal GlobalParticleSystemLiteBlock[] particleSystem;
        internal GlobalWeatherBackgroundPlateBlock[] backgroundPlates;
        internal GlobalWindModelStructBlock windModel;
        internal float fadeRadius;
        
        public override int SerializedSize{get { return 176; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  WeatherSystemBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            particleSystem = Guerilla.ReadBlockArray<GlobalParticleSystemLiteBlock>(binaryReader);
            backgroundPlates = Guerilla.ReadBlockArray<GlobalWeatherBackgroundPlateBlock>(binaryReader);
            windModel = new GlobalWindModelStructBlock(binaryReader);
            fadeRadius = binaryReader.ReadSingle();
        }
        public  WeatherSystemBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            particleSystem = Guerilla.ReadBlockArray<GlobalParticleSystemLiteBlock>(binaryReader);
            backgroundPlates = Guerilla.ReadBlockArray<GlobalWeatherBackgroundPlateBlock>(binaryReader);
            windModel = new GlobalWindModelStructBlock(binaryReader);
            fadeRadius = binaryReader.ReadSingle();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<GlobalParticleSystemLiteBlock>(binaryWriter, particleSystem, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GlobalWeatherBackgroundPlateBlock>(binaryWriter, backgroundPlates, nextAddress);
                windModel.Write(binaryWriter);
                binaryWriter.Write(fadeRadius);
                return nextAddress;
            }
        }
    };
}
