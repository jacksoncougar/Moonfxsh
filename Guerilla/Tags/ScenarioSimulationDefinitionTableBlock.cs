// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ScenarioSimulationDefinitionTableBlock : ScenarioSimulationDefinitionTableBlockBase
    {
        public  ScenarioSimulationDefinitionTableBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class ScenarioSimulationDefinitionTableBlockBase  : IGuerilla
    {
        internal byte[] invalidName_;
        internal  ScenarioSimulationDefinitionTableBlockBase(BinaryReader binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(4);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_, 0, 4);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
