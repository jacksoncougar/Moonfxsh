// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass JmadClass = (TagClass)"jmad";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("jmad")]
    public  partial class ModelAnimationGraphBlock : ModelAnimationGraphBlockBase
    {
        public  ModelAnimationGraphBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 172, Alignment = 4)]
    public class ModelAnimationGraphBlockBase  : IGuerilla
    {
        internal AnimationGraphResourcesStructBlock resources;
        internal AnimationGraphContentsStructBlock content;
        internal ModelAnimationRuntimeDataStructBlock runTimeData;
        internal byte[] lastImportResults;
        internal AdditionalNodeDataBlock[] additionalNodeData;
        internal  ModelAnimationGraphBlockBase(BinaryReader binaryReader)
        {
            resources = new AnimationGraphResourcesStructBlock(binaryReader);
            content = new AnimationGraphContentsStructBlock(binaryReader);
            runTimeData = new ModelAnimationRuntimeDataStructBlock(binaryReader);
            lastImportResults = Guerilla.ReadData(binaryReader);
            additionalNodeData = Guerilla.ReadBlockArray<AdditionalNodeDataBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                resources.Write(binaryWriter);
                content.Write(binaryWriter);
                runTimeData.Write(binaryWriter);
                nextAddress = Guerilla.WriteData(binaryWriter, lastImportResults, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<AdditionalNodeDataBlock>(binaryWriter, additionalNodeData, nextAddress);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
