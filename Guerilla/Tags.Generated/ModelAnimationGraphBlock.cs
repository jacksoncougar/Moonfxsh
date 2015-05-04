// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Jmad = (TagClass) "jmad";
    };
} ;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("jmad")]
    public partial class ModelAnimationGraphBlock : ModelAnimationGraphBlockBase
    {
        public ModelAnimationGraphBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 188, Alignment = 4)]
    public class ModelAnimationGraphBlockBase : GuerillaBlock
    {
        internal AnimationGraphResourcesStructBlock resources;
        internal AnimationGraphContentsStructBlock content;
        internal ModelAnimationRuntimeDataStructBlock runTimeData;
        internal byte[] lastImportResults;
        internal AdditionalNodeDataBlock[] additionalNodeData;
        internal MoonfishXboxAnimationRawBlock[] xboxUnknownAnimationBlock;
        internal MoonfishXboxAnimationUnknownBlock[] xboxUnknownAnimationBlock0;

        public override int SerializedSize
        {
            get { return 188; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ModelAnimationGraphBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            resources = new AnimationGraphResourcesStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(resources.ReadFields(binaryReader)));
            content = new AnimationGraphContentsStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(content.ReadFields(binaryReader)));
            runTimeData = new ModelAnimationRuntimeDataStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(runTimeData.ReadFields(binaryReader)));
            blamPointers.Enqueue(ReadBlockArrayPointer(binaryReader, 1));
            blamPointers.Enqueue(ReadBlockArrayPointer<AdditionalNodeDataBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<MoonfishXboxAnimationRawBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<MoonfishXboxAnimationUnknownBlock>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            resources.ReadPointers(binaryReader, blamPointers);
            content.ReadPointers(binaryReader, blamPointers);
            runTimeData.ReadPointers(binaryReader, blamPointers);
            lastImportResults = ReadDataByteArray(binaryReader, blamPointers.Dequeue());
            additionalNodeData = ReadBlockArrayData<AdditionalNodeDataBlock>(binaryReader, blamPointers.Dequeue());
            xboxUnknownAnimationBlock = ReadBlockArrayData<MoonfishXboxAnimationRawBlock>(binaryReader,
                blamPointers.Dequeue());
            xboxUnknownAnimationBlock0 = ReadBlockArrayData<MoonfishXboxAnimationUnknownBlock>(binaryReader,
                blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                resources.Write(binaryWriter);
                content.Write(binaryWriter);
                runTimeData.Write(binaryWriter);
                nextAddress = Guerilla.WriteData(binaryWriter, lastImportResults, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<AdditionalNodeDataBlock>(binaryWriter, additionalNodeData,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<MoonfishXboxAnimationRawBlock>(binaryWriter,
                    xboxUnknownAnimationBlock, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<MoonfishXboxAnimationUnknownBlock>(binaryWriter,
                    xboxUnknownAnimationBlock0, nextAddress);
                return nextAddress;
            }
        }
    };
}