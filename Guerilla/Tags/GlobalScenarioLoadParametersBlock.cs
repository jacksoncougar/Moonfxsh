using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class GlobalScenarioLoadParametersBlock : GlobalScenarioLoadParametersBlockBase
    {
        public  GlobalScenarioLoadParametersBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 48)]
    public class GlobalScenarioLoadParametersBlockBase
    {
        [TagReference("scnr")]
        internal Moonfish.Tags.TagReference scenario;
        internal byte[] parameters;
        internal byte[] invalidName_;
        internal  GlobalScenarioLoadParametersBlockBase(BinaryReader binaryReader)
        {
            this.scenario = binaryReader.ReadTagReference();
            this.parameters = ReadData(binaryReader);
            this.invalidName_ = binaryReader.ReadBytes(32);
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
