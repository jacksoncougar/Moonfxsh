// ReSharper disable All

using Moonfish.Model;

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
        public static readonly TagClass Clu = (TagClass) "clu*";
    };
} ;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("clu*")]
    public partial class ScenarioClusterDataResourceBlock : ScenarioClusterDataResourceBlockBase
    {
        public ScenarioClusterDataResourceBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 40, Alignment = 4)]
    public class ScenarioClusterDataResourceBlockBase : GuerillaBlock
    {
        internal ScenarioClusterDataBlock[] clusterData;
        internal StructureBspBackgroundSoundPaletteBlock[] backgroundSoundPalette;
        internal StructureBspSoundEnvironmentPaletteBlock[] soundEnvironmentPalette;
        internal StructureBspWeatherPaletteBlock[] weatherPalette;
        internal ScenarioAtmosphericFogPalette[] atmosphericFogPalette;

        public override int SerializedSize
        {
            get { return 40; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ScenarioClusterDataResourceBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioClusterDataBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureBspBackgroundSoundPaletteBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureBspSoundEnvironmentPaletteBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureBspWeatherPaletteBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioAtmosphericFogPalette>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            clusterData = ReadBlockArrayData<ScenarioClusterDataBlock>(binaryReader, blamPointers.Dequeue());
            backgroundSoundPalette = ReadBlockArrayData<StructureBspBackgroundSoundPaletteBlock>(binaryReader,
                blamPointers.Dequeue());
            soundEnvironmentPalette = ReadBlockArrayData<StructureBspSoundEnvironmentPaletteBlock>(binaryReader,
                blamPointers.Dequeue());
            weatherPalette = ReadBlockArrayData<StructureBspWeatherPaletteBlock>(binaryReader, blamPointers.Dequeue());
            atmosphericFogPalette = ReadBlockArrayData<ScenarioAtmosphericFogPalette>(binaryReader,
                blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<ScenarioClusterDataBlock>(binaryWriter, clusterData, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<StructureBspBackgroundSoundPaletteBlock>(binaryWriter,
                    backgroundSoundPalette, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<StructureBspSoundEnvironmentPaletteBlock>(binaryWriter,
                    soundEnvironmentPalette, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<StructureBspWeatherPaletteBlock>(binaryWriter, weatherPalette,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioAtmosphericFogPalette>(binaryWriter,
                    atmosphericFogPalette, nextAddress);
                return nextAddress;
            }
        }
    };
}