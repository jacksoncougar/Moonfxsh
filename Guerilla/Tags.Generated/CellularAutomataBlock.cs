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
        public static readonly TagClass Devo = (TagClass)"devo";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("devo")]
    public partial class CellularAutomataBlock : CellularAutomataBlockBase
    {
        public CellularAutomataBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 548, Alignment = 4)]
    public class CellularAutomataBlockBase : GuerillaBlock
    {
        internal short updatesPerSecondHz;
        internal short xWidthCells;
        internal short yDepthCells;
        internal short zHeightCells;
        internal float xWidthWorldUnits;
        internal float yDepthWorldUnits;
        internal float zHeightWorldUnits;
        internal byte[] invalidName_;
        internal Moonfish.Tags.StringIdent marker;
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
        public override int SerializedSize { get { return 548; } }
        public override int Alignment { get { return 4; } }
        public CellularAutomataBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            updatesPerSecondHz = binaryReader.ReadInt16();
            xWidthCells = binaryReader.ReadInt16();
            yDepthCells = binaryReader.ReadInt16();
            zHeightCells = binaryReader.ReadInt16();
            xWidthWorldUnits = binaryReader.ReadSingle();
            yDepthWorldUnits = binaryReader.ReadSingle();
            zHeightWorldUnits = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadBytes(32);
            marker = binaryReader.ReadStringID();
            cellBirthChance01 = binaryReader.ReadSingle();
            invalidName_0 = binaryReader.ReadBytes(32);
            cellGeneMutates1InTimes = binaryReader.ReadInt32();
            virusGeneMutations1InTimes = binaryReader.ReadInt32();
            invalidName_1 = binaryReader.ReadBytes(32);
            infectedCellLifespanUpdates = binaryReader.ReadInt32();
            minimumInfectionAgeUpdates = binaryReader.ReadInt16();
            invalidName_2 = binaryReader.ReadBytes(2);
            cellInfectionChance01 = binaryReader.ReadSingle();
            infectionThreshold01 = binaryReader.ReadSingle();
            invalidName_3 = binaryReader.ReadBytes(32);
            newCellFilledChance01 = binaryReader.ReadSingle();
            newCellInfectedChance01 = binaryReader.ReadSingle();
            invalidName_4 = binaryReader.ReadBytes(32);
            detailTextureChangeChance01 = binaryReader.ReadSingle();
            invalidName_5 = binaryReader.ReadBytes(32);
            detailTextureWidthCells = binaryReader.ReadInt16();
            invalidName_6 = binaryReader.ReadBytes(2);
            detailTexture = binaryReader.ReadTagReference();
            invalidName_7 = binaryReader.ReadBytes(32);
            maskBitmap = binaryReader.ReadTagReference();
            invalidName_8 = binaryReader.ReadBytes(240);
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(updatesPerSecondHz);
                binaryWriter.Write(xWidthCells);
                binaryWriter.Write(yDepthCells);
                binaryWriter.Write(zHeightCells);
                binaryWriter.Write(xWidthWorldUnits);
                binaryWriter.Write(yDepthWorldUnits);
                binaryWriter.Write(zHeightWorldUnits);
                binaryWriter.Write(invalidName_, 0, 32);
                binaryWriter.Write(marker);
                binaryWriter.Write(cellBirthChance01);
                binaryWriter.Write(invalidName_0, 0, 32);
                binaryWriter.Write(cellGeneMutates1InTimes);
                binaryWriter.Write(virusGeneMutations1InTimes);
                binaryWriter.Write(invalidName_1, 0, 32);
                binaryWriter.Write(infectedCellLifespanUpdates);
                binaryWriter.Write(minimumInfectionAgeUpdates);
                binaryWriter.Write(invalidName_2, 0, 2);
                binaryWriter.Write(cellInfectionChance01);
                binaryWriter.Write(infectionThreshold01);
                binaryWriter.Write(invalidName_3, 0, 32);
                binaryWriter.Write(newCellFilledChance01);
                binaryWriter.Write(newCellInfectedChance01);
                binaryWriter.Write(invalidName_4, 0, 32);
                binaryWriter.Write(detailTextureChangeChance01);
                binaryWriter.Write(invalidName_5, 0, 32);
                binaryWriter.Write(detailTextureWidthCells);
                binaryWriter.Write(invalidName_6, 0, 2);
                binaryWriter.Write(detailTexture);
                binaryWriter.Write(invalidName_7, 0, 32);
                binaryWriter.Write(maskBitmap);
                binaryWriter.Write(invalidName_8, 0, 240);
                return nextAddress;
            }
        }
    };
}
