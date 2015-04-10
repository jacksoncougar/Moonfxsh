using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ScenarioChildScenarioBlock : ScenarioChildScenarioBlockBase
    {
        public  ScenarioChildScenarioBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 24)]
    public class ScenarioChildScenarioBlockBase
    {
        [TagReference("scnr")]
        internal Moonfish.Tags.TagReference childScenario;
        internal byte[] invalidName_;
        internal  ScenarioChildScenarioBlockBase(BinaryReader binaryReader)
        {
            this.childScenario = binaryReader.ReadTagReference();
            this.invalidName_ = binaryReader.ReadBytes(16);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
    };
}
