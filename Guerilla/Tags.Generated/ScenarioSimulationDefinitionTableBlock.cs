// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioSimulationDefinitionTableBlock : ScenarioSimulationDefinitionTableBlockBase
    {
        public  ScenarioSimulationDefinitionTableBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ScenarioSimulationDefinitionTableBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class ScenarioSimulationDefinitionTableBlockBase : GuerillaBlock
    {
        internal byte[] invalidName_;
        
        public override int SerializedSize{get { return 4; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ScenarioSimulationDefinitionTableBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(4);
        }
        public  ScenarioSimulationDefinitionTableBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_, 0, 4);
                return nextAddress;
            }
        }
    };
}
