// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

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
        public WeatherSystemBlock() : base()
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
        public override int SerializedSize { get { return 176; } }
        public override int Alignment { get { return 4; } }
        public WeatherSystemBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<GlobalParticleSystemLiteBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<GlobalWeatherBackgroundPlateBlock>(binaryReader));
            windModel = new GlobalWindModelStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(windModel.ReadFields(binaryReader)));
            fadeRadius = binaryReader.ReadSingle();
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            particleSystem = ReadBlockArrayData<GlobalParticleSystemLiteBlock>(binaryReader, blamPointers.Dequeue());
            backgroundPlates = ReadBlockArrayData<GlobalWeatherBackgroundPlateBlock>(binaryReader, blamPointers.Dequeue());
            windModel.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
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
