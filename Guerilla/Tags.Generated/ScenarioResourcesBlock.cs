// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioResourcesBlock : ScenarioResourcesBlockBase
    {
        public ScenarioResourcesBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class ScenarioResourcesBlockBase : GuerillaBlock
    {
        internal ScenarioResourceReferenceBlock[] references;
        internal ScenarioHsSourceReferenceBlock[] scriptSource;
        internal ScenarioAiResourceReferenceBlock[] aIResources;

        public override int SerializedSize
        {
            get { return 24; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ScenarioResourcesBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioResourceReferenceBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioHsSourceReferenceBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioAiResourceReferenceBlock>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            references = ReadBlockArrayData<ScenarioResourceReferenceBlock>(binaryReader, blamPointers.Dequeue());
            scriptSource = ReadBlockArrayData<ScenarioHsSourceReferenceBlock>(binaryReader, blamPointers.Dequeue());
            aIResources = ReadBlockArrayData<ScenarioAiResourceReferenceBlock>(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<ScenarioResourceReferenceBlock>(binaryWriter, references,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioHsSourceReferenceBlock>(binaryWriter, scriptSource,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioAiResourceReferenceBlock>(binaryWriter, aIResources,
                    nextAddress);
                return nextAddress;
            }
        }
    };
}