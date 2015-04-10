using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("whip")]
    public  partial class CellularAutomata2dBlock : CellularAutomata2dBlockBase
    {
        public  CellularAutomata2dBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 544)]
    public class CellularAutomata2dBlockBase
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
        internal Moonfish.Tags.StringID marker;
        internal InterpolationFlags interpolationFlags;
        internal Moonfish.Tags.ColorR8G8B8 baseColor;
        internal Moonfish.Tags.ColorR8G8B8 peakColor;
        internal byte[] invalidName_2;
        internal short widthCells0;
        internal short heightCells0;
        internal float cellWidthWorldUnits0;
        internal OpenTK.Vector2 velocityCellsUpdate0;
        internal byte[] invalidName_3;
        internal Moonfish.Tags.StringID marker0;
        internal short textureWidthCells;
        internal byte[] invalidName_4;
        internal byte[] invalidName_5;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference texture;
        internal byte[] invalidName_6;
        internal RulesBlock[] rules;
        internal  CellularAutomata2dBlockBase(BinaryReader binaryReader)
        {
            this.updatesPerSecondHz = binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.deadCellPenalty = binaryReader.ReadSingle();
            this.liveCellBonus = binaryReader.ReadSingle();
            this.invalidName_0 = binaryReader.ReadBytes(80);
            this.widthCells = binaryReader.ReadInt16();
            this.heightCells = binaryReader.ReadInt16();
            this.cellWidthWorldUnits = binaryReader.ReadSingle();
            this.heightWorldUnits = binaryReader.ReadSingle();
            this.velocityCellsUpdate = binaryReader.ReadVector2();
            this.invalidName_1 = binaryReader.ReadBytes(28);
            this.marker = binaryReader.ReadStringID();
            this.interpolationFlags = (InterpolationFlags)binaryReader.ReadInt32();
            this.baseColor = binaryReader.ReadColorR8G8B8();
            this.peakColor = binaryReader.ReadColorR8G8B8();
            this.invalidName_2 = binaryReader.ReadBytes(76);
            this.widthCells0 = binaryReader.ReadInt16();
            this.heightCells0 = binaryReader.ReadInt16();
            this.cellWidthWorldUnits0 = binaryReader.ReadSingle();
            this.velocityCellsUpdate0 = binaryReader.ReadVector2();
            this.invalidName_3 = binaryReader.ReadBytes(48);
            this.marker0 = binaryReader.ReadStringID();
            this.textureWidthCells = binaryReader.ReadInt16();
            this.invalidName_4 = binaryReader.ReadBytes(2);
            this.invalidName_5 = binaryReader.ReadBytes(48);
            this.texture = binaryReader.ReadTagReference();
            this.invalidName_6 = binaryReader.ReadBytes(160);
            this.rules = ReadRulesBlockArray(binaryReader);
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
        internal  virtual RulesBlock[] ReadRulesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(RulesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new RulesBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new RulesBlock(binaryReader);
                }
            }
            return array;
        }
        [FlagsAttribute]
        internal enum InterpolationFlags : int
        
        {
            BlendInHsvBlendsColorsInHsvRatherThanRgbSpace = 1,
            MoreColorsBlendsColorsThroughMoreHuesGoesTheLongWayAroundTheColorWheel = 2,
        };
    };
}
