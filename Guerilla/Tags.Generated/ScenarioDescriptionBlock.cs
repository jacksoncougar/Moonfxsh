// ReSharper disable All

using Moonfish.Model;

using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioDescriptionBlock : ScenarioDescriptionBlockBase
    {
        public ScenarioDescriptionBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 52, Alignment = 4)]
    public class ScenarioDescriptionBlockBase : GuerillaBlock
    {
        [TagReference("bitm")] internal Moonfish.Tags.TagReference descriptiveBitmap;
        [TagReference("unic")] internal Moonfish.Tags.TagReference displayedMapName;

        /// <summary>
        /// this is the path to the directory containing the scenario tag file of the same name
        /// </summary>
        internal Moonfish.Tags.String32 scenarioTagDirectoryPath;

        internal byte[] invalidName_;

        public override int SerializedSize
        {
            get { return 52; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ScenarioDescriptionBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            descriptiveBitmap = binaryReader.ReadTagReference();
            displayedMapName = binaryReader.ReadTagReference();
            scenarioTagDirectoryPath = binaryReader.ReadString32();
            invalidName_ = binaryReader.ReadBytes(4);
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(descriptiveBitmap);
                binaryWriter.Write(displayedMapName);
                binaryWriter.Write(scenarioTagDirectoryPath);
                binaryWriter.Write(invalidName_, 0, 4);
                return nextAddress;
            }
        }
    };
}