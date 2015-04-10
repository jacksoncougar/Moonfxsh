// ReSharper disable All
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
        public  ScenarioInterpolatorBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  ScenarioInterpolatorBlockBase(System.IO.BinaryReader binaryReader)
        {
            name = binaryReader.ReadStringID();
            acceleratorNameInterpolator = binaryReader.ReadStringID();
            multiplierNameInterpolator = binaryReader.ReadStringID();
            function = new ScalarFunctionStructBlock(binaryReader);
            invalidName_ = binaryReader.ReadBytes(2);
            invalidName_0 = binaryReader.ReadBytes(2);
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
                binaryWriter.Write(name);
                binaryWriter.Write(acceleratorNameInterpolator);
                binaryWriter.Write(multiplierNameInterpolator);
                function.Write(binaryWriter);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(invalidName_0, 0, 2);
            }
        }
    };
}
