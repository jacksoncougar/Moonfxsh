using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("jmad")]
    public  partial class ModelAnimationGraphBlock : ModelAnimationGraphBlockBase
    {
        public  ModelAnimationGraphBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 172)]
    public class ModelAnimationGraphBlockBase
    {
        internal AnimationGraphResourcesStructBlock resources;
        internal AnimationGraphContentsStructBlock content;
        internal ModelAnimationRuntimeDataStructBlock runTimeData;
        internal byte[] lastImportResults;
        internal AdditionalNodeDataBlock[] additionalNodeData;
        internal  ModelAnimationGraphBlockBase(BinaryReader binaryReader)
        {
            this.resources = new AnimationGraphResourcesStructBlock(binaryReader);
            this.content = new AnimationGraphContentsStructBlock(binaryReader);
            this.runTimeData = new ModelAnimationRuntimeDataStructBlock(binaryReader);
            this.lastImportResults = ReadData(binaryReader);
            this.additionalNodeData = ReadAdditionalNodeDataBlockArray(binaryReader);
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
        internal  virtual AdditionalNodeDataBlock[] ReadAdditionalNodeDataBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(AdditionalNodeDataBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new AdditionalNodeDataBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new AdditionalNodeDataBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
