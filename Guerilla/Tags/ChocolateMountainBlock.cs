using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("gldf")]
    public  partial class ChocolateMountainBlock : ChocolateMountainBlockBase
    {
        public  ChocolateMountainBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8)]
    public class ChocolateMountainBlockBase
    {
        internal LightingVariablesBlock[] lightingVariables;
        internal  ChocolateMountainBlockBase(BinaryReader binaryReader)
        {
            this.lightingVariables = ReadLightingVariablesBlockArray(binaryReader);
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
        internal  virtual LightingVariablesBlock[] ReadLightingVariablesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(LightingVariablesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new LightingVariablesBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new LightingVariablesBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
