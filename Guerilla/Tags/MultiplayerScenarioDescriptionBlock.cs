using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("mply")]
    public  partial class MultiplayerScenarioDescriptionBlock : MultiplayerScenarioDescriptionBlockBase
    {
        public  MultiplayerScenarioDescriptionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8)]
    public class MultiplayerScenarioDescriptionBlockBase
    {
        internal ScenarioDescriptionBlock[] multiplayerScenarios;
        internal  MultiplayerScenarioDescriptionBlockBase(BinaryReader binaryReader)
        {
            this.multiplayerScenarios = ReadScenarioDescriptionBlockArray(binaryReader);
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
        internal  virtual ScenarioDescriptionBlock[] ReadScenarioDescriptionBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioDescriptionBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioDescriptionBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioDescriptionBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
