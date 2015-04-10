using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ScenarioResourcesBlock : ScenarioResourcesBlockBase
    {
        public  ScenarioResourcesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 24)]
    public class ScenarioResourcesBlockBase
    {
        internal ScenarioResourceReferenceBlock[] references;
        internal ScenarioHsSourceReferenceBlock[] scriptSource;
        internal ScenarioAiResourceReferenceBlock[] aIResources;
        internal  ScenarioResourcesBlockBase(BinaryReader binaryReader)
        {
            this.references = ReadScenarioResourceReferenceBlockArray(binaryReader);
            this.scriptSource = ReadScenarioHsSourceReferenceBlockArray(binaryReader);
            this.aIResources = ReadScenarioAiResourceReferenceBlockArray(binaryReader);
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
        internal  virtual ScenarioResourceReferenceBlock[] ReadScenarioResourceReferenceBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioResourceReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioResourceReferenceBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioResourceReferenceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioHsSourceReferenceBlock[] ReadScenarioHsSourceReferenceBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioHsSourceReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioHsSourceReferenceBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioHsSourceReferenceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioAiResourceReferenceBlock[] ReadScenarioAiResourceReferenceBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioAiResourceReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioAiResourceReferenceBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioAiResourceReferenceBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
