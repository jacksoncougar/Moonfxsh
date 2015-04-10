using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("devo")]
    public  partial class CellularAutomataBlock : CellularAutomataBlockBase
    {
        public  CellularAutomataBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 548)]
    public class CellularAutomataBlockBase
    {
        internal short updatesPerSecondHz;
        internal short xWidthCells;
        internal short yDepthCells;
        internal short zHeightCells;
        internal float xWidthWorldUnits;
        internal float yDepthWorldUnits;
        internal float zHeightWorldUnits;
        internal byte[] invalidName_;
        internal Moonfish.Tags.StringID marker;
        internal float cellBirthChance01;
        internal byte[] invalidName_0;
        internal int cellGeneMutates1InTimes;
        internal int virusGeneMutations1InTimes;
        internal byte[] invalidName_1;
        /// <summary>
        /// the lifespan of a cell once infected
        /// </summary>
        internal int infectedCellLifespanUpdates;
        /// <summary>
        /// no cell can be infected before it has been alive this number of updates
        /// </summary>
        internal short minimumInfectionAgeUpdates;
        internal byte[] invalidName_2;
        internal float cellInfectionChance01;
        /// <summary>
        /// 0.0 is most difficult for the virus, 1.0 means any virus can infect any cell
        /// </summary>
        internal float infectionThreshold01;
        internal byte[] invalidName_3;
        internal float newCellFilledChance01;
        internal float newCellInfectedChance01;
        internal byte[] invalidName_4;
        internal float detailTextureChangeChance01;
        internal byte[] invalidName_5;
        /// <summary>
        /// the number of cells repeating across the detail texture in both dimensions
        /// </summary>
        internal short detailTextureWidthCells;
        internal byte[] invalidName_6;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference detailTexture;
        internal byte[] invalidName_7;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference maskBitmap;
        internal byte[] invalidName_8;
        internal  CellularAutomataBlockBase(BinaryReader binaryReader)
        {
            this.updatesPerSecondHz = binaryReader.ReadInt16();
            this.xWidthCells = binaryReader.ReadInt16();
            this.yDepthCells = binaryReader.ReadInt16();
            this.zHeightCells = binaryReader.ReadInt16();
            this.xWidthWorldUnits = binaryReader.ReadSingle();
            this.yDepthWorldUnits = binaryReader.ReadSingle();
            this.zHeightWorldUnits = binaryReader.ReadSingle();
            this.invalidName_ = binaryReader.ReadBytes(32);
            this.marker = binaryReader.ReadStringID();
            this.cellBirthChance01 = binaryReader.ReadSingle();
            this.invalidName_0 = binaryReader.ReadBytes(32);
            this.cellGeneMutates1InTimes = binaryReader.ReadInt32();
            this.virusGeneMutations1InTimes = binaryReader.ReadInt32();
            this.invalidName_1 = binaryReader.ReadBytes(32);
            this.infectedCellLifespanUpdates = binaryReader.ReadInt32();
            this.minimumInfectionAgeUpdates = binaryReader.ReadInt16();
            this.invalidName_2 = binaryReader.ReadBytes(2);
            this.cellInfectionChance01 = binaryReader.ReadSingle();
            this.infectionThreshold01 = binaryReader.ReadSingle();
            this.invalidName_3 = binaryReader.ReadBytes(32);
            this.newCellFilledChance01 = binaryReader.ReadSingle();
            this.newCellInfectedChance01 = binaryReader.ReadSingle();
            this.invalidName_4 = binaryReader.ReadBytes(32);
            this.detailTextureChangeChance01 = binaryReader.ReadSingle();
            this.invalidName_5 = binaryReader.ReadBytes(32);
            this.detailTextureWidthCells = binaryReader.ReadInt16();
            this.invalidName_6 = binaryReader.ReadBytes(2);
            this.detailTexture = binaryReader.ReadTagReference();
            this.invalidName_7 = binaryReader.ReadBytes(32);
            this.maskBitmap = binaryReader.ReadTagReference();
            this.invalidName_8 = binaryReader.ReadBytes(240);
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
    };
}
