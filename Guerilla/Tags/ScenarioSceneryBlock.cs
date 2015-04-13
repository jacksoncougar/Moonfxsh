// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ScenarioSceneryBlock : ScenarioSceneryBlockBase
    {
        public  ScenarioSceneryBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 92, Alignment = 4)]
    public class ScenarioSceneryBlockBase  : IGuerilla
    {
        internal Moonfish.Tags.ShortBlockIndex1 type;
        internal Moonfish.Tags.ShortBlockIndex1 name;
        internal ScenarioObjectDatumStructBlock objectData;
        internal byte[] indexer;
        internal ScenarioObjectPermutationStructBlock permutationData;
        internal ScenarioSceneryDatumStructV4Block sceneryData;
        internal  ScenarioSceneryBlockBase(BinaryReader binaryReader)
        {
            type = binaryReader.ReadShortBlockIndex1();
            name = binaryReader.ReadShortBlockIndex1();
            objectData = new ScenarioObjectDatumStructBlock(binaryReader);
            indexer = binaryReader.ReadBytes(4);
            permutationData = new ScenarioObjectPermutationStructBlock(binaryReader);
            sceneryData = new ScenarioSceneryDatumStructV4Block(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(type);
                binaryWriter.Write(name);
                objectData.Write(binaryWriter);
                binaryWriter.Write(indexer, 0, 4);
                permutationData.Write(binaryWriter);
                sceneryData.Write(binaryWriter);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
