// ReSharper disable All
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
        public  GlobalScenarioLoadParametersBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  GlobalScenarioLoadParametersBlockBase(System.IO.BinaryReader binaryReader)
        {
            scenario = binaryReader.ReadTagReference();
            parameters = ReadData(binaryReader);
            invalidName_ = binaryReader.ReadBytes(32);
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(scenario);
                WriteData(binaryWriter);
                binaryWriter.Write(invalidName_, 0, 32);
            }
        }
    };
}
