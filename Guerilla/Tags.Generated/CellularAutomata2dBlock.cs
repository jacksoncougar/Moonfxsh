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
        public static readonly TagClass Whip = (TagClass)"whip";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("whip")]
    public partial class CellularAutomata2dBlock : CellularAutomata2dBlockBase
    {
        public CellularAutomata2dBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 544, Alignment = 4)]
    public class CellularAutomata2dBlockBase : GuerillaBlock
    {
        internal short updatesPerSecondHz;
        internal byte[] invalidName_;
        internal float deadCellPenalty;
        internal float liveCellBonus;
        internal byte[] invalidName_0;
        internal short widthCells;
        internal short heightCells;
        internal float cellWidthWorldUnits;
        internal float heightWorldUnits;
        internal OpenTK.Vector2 velocityCellsUpdate;
        internal byte[] invalidName_1;
        internal Moonfish.Tags.StringIdent marker;
        internal InterpolationFlags interpolationFlags;
        internal Moonfish.Tags.ColourR8G8B8 baseColor;
        internal Moonfish.Tags.ColourR8G8B8 peakColor;
        internal byte[] invalidName_2;
        internal short widthCells0;
        internal short heightCells0;
        internal float cellWidthWorldUnits0;
        internal OpenTK.Vector2 velocityCellsUpdate0;
        internal byte[] invalidName_3;
        internal Moonfish.Tags.StringIdent marker0;
        internal short textureWidthCells;
        internal byte[] invalidName_4;
        internal byte[] invalidName_5;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference texture;
        internal byte[] invalidName_6;
        internal RulesBlock[] rules;
        public override int SerializedSize { get { return 544; } }
        public override int Alignment { get { return 4; } }
        public CellularAutomata2dBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            updatesPerSecondHz = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            deadCellPenalty = binaryReader.ReadSingle();
            liveCellBonus = binaryReader.ReadSingle();
            invalidName_0 = binaryReader.ReadBytes(80);
            widthCells = binaryReader.ReadInt16();
            heightCells = binaryReader.ReadInt16();
            cellWidthWorldUnits = binaryReader.ReadSingle();
            heightWorldUnits = binaryReader.ReadSingle();
            velocityCellsUpdate = binaryReader.ReadVector2();
            invalidName_1 = binaryReader.ReadBytes(28);
            marker = binaryReader.ReadStringID();
            interpolationFlags = (InterpolationFlags)binaryReader.ReadInt32();
            baseColor = binaryReader.ReadColorR8G8B8();
            peakColor = binaryReader.ReadColorR8G8B8();
            invalidName_2 = binaryReader.ReadBytes(76);
            widthCells0 = binaryReader.ReadInt16();
            heightCells0 = binaryReader.ReadInt16();
            cellWidthWorldUnits0 = binaryReader.ReadSingle();
            velocityCellsUpdate0 = binaryReader.ReadVector2();
            invalidName_3 = binaryReader.ReadBytes(48);
            marker0 = binaryReader.ReadStringID();
            textureWidthCells = binaryReader.ReadInt16();
            invalidName_4 = binaryReader.ReadBytes(2);
            invalidName_5 = binaryReader.ReadBytes(48);
            texture = binaryReader.ReadTagReference();
            invalidName_6 = binaryReader.ReadBytes(160);
            blamPointers.Enqueue(ReadBlockArrayPointer<RulesBlock>(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            rules = ReadBlockArrayData<RulesBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(updatesPerSecondHz);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(deadCellPenalty);
                binaryWriter.Write(liveCellBonus);
                binaryWriter.Write(invalidName_0, 0, 80);
                binaryWriter.Write(widthCells);
                binaryWriter.Write(heightCells);
                binaryWriter.Write(cellWidthWorldUnits);
                binaryWriter.Write(heightWorldUnits);
                binaryWriter.Write(velocityCellsUpdate);
                binaryWriter.Write(invalidName_1, 0, 28);
                binaryWriter.Write(marker);
                binaryWriter.Write((Int32)interpolationFlags);
                binaryWriter.Write(baseColor);
                binaryWriter.Write(peakColor);
                binaryWriter.Write(invalidName_2, 0, 76);
                binaryWriter.Write(widthCells0);
                binaryWriter.Write(heightCells0);
                binaryWriter.Write(cellWidthWorldUnits0);
                binaryWriter.Write(velocityCellsUpdate0);
                binaryWriter.Write(invalidName_3, 0, 48);
                binaryWriter.Write(marker0);
                binaryWriter.Write(textureWidthCells);
                binaryWriter.Write(invalidName_4, 0, 2);
                binaryWriter.Write(invalidName_5, 0, 48);
                binaryWriter.Write(texture);
                binaryWriter.Write(invalidName_6, 0, 160);
                nextAddress = Guerilla.WriteBlockArray<RulesBlock>(binaryWriter, rules, nextAddress);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum InterpolationFlags : int
        {
            BlendInHsvBlendsColorsInHsvRatherThanRgbSpace = 1,
            MoreColorsBlendsColorsThroughMoreHuesGoesTheLongWayAroundTheColorWheel = 2,
        };
    };
}
