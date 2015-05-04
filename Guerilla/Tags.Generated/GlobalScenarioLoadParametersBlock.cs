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
    public partial class GlobalScenarioLoadParametersBlock : GlobalScenarioLoadParametersBlockBase
    {
        public GlobalScenarioLoadParametersBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 48, Alignment = 4)]
    public class GlobalScenarioLoadParametersBlockBase : GuerillaBlock
    {
        [TagReference("scnr")] internal Moonfish.Tags.TagReference scenario;
        internal byte[] parameters;
        internal byte[] invalidName_;

        public override int SerializedSize
        {
            get { return 48; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public GlobalScenarioLoadParametersBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            scenario = binaryReader.ReadTagReference();
            blamPointers.Enqueue(ReadBlockArrayPointer(binaryReader, 1));
            invalidName_ = binaryReader.ReadBytes(32);
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            parameters = ReadDataByteArray(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(scenario);
                nextAddress = Guerilla.WriteData(binaryWriter, parameters, nextAddress);
                binaryWriter.Write(invalidName_, 0, 32);
                return nextAddress;
            }
        }
    };
}