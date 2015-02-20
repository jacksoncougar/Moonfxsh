using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ScenarioInterpolatorBlock : ScenarioInterpolatorBlockBase
    {
        public  ScenarioInterpolatorBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 24)]
    public class ScenarioInterpolatorBlockBase
    {
        internal Moonfish.Tags.StringID name;
        internal Moonfish.Tags.StringID acceleratorNameInterpolator;
        internal Moonfish.Tags.StringID multiplierNameInterpolator;
        internal ScalarFunctionStructBlock function;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal  ScenarioInterpolatorBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            this.acceleratorNameInterpolator = binaryReader.ReadStringID();
            this.multiplierNameInterpolator = binaryReader.ReadStringID();
            this.function = new ScalarFunctionStructBlock(binaryReader);
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.invalidName_0 = binaryReader.ReadBytes(2);
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
