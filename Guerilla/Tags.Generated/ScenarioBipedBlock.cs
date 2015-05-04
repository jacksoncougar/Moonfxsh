// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioBipedBlock : ScenarioBipedBlockBase
    {
        public ScenarioBipedBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 84, Alignment = 4)]
    public class ScenarioBipedBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.ShortBlockIndex1 type;
        internal Moonfish.Tags.ShortBlockIndex1 name;
        internal ScenarioObjectDatumStructBlock objectData;
        internal byte[] indexer;
        internal ScenarioObjectPermutationStructBlock permutationData;
        internal ScenarioUnitStructBlock unitData;
        public override int SerializedSize { get { return 84; } }
        public override int Alignment { get { return 4; } }
        public ScenarioBipedBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            type = binaryReader.ReadShortBlockIndex1();
            name = binaryReader.ReadShortBlockIndex1();
            objectData = new ScenarioObjectDatumStructBlock();
            blamPointers.Concat(objectData.ReadFields(binaryReader));
            indexer = binaryReader.ReadBytes(4);
            permutationData = new ScenarioObjectPermutationStructBlock();
            blamPointers.Concat(permutationData.ReadFields(binaryReader));
            unitData = new ScenarioUnitStructBlock();
            blamPointers.Concat(unitData.ReadFields(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            objectData.ReadPointers(binaryReader, blamPointers);
            indexer[0].ReadPointers(binaryReader, blamPointers);
            indexer[1].ReadPointers(binaryReader, blamPointers);
            indexer[2].ReadPointers(binaryReader, blamPointers);
            indexer[3].ReadPointers(binaryReader, blamPointers);
            permutationData.ReadPointers(binaryReader, blamPointers);
            unitData.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(type);
                binaryWriter.Write(name);
                objectData.Write(binaryWriter);
                binaryWriter.Write(indexer, 0, 4);
                permutationData.Write(binaryWriter);
                unitData.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
