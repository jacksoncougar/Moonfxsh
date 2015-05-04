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
    public partial class MultiplayerUiBlock : MultiplayerUiBlockBase
    {
        public MultiplayerUiBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 32, Alignment = 4)]
    public class MultiplayerUiBlockBase : GuerillaBlock
    {
        [TagReference("unic")] internal Moonfish.Tags.TagReference randomPlayerNames;
        internal MultiplayerColorBlock[] obsoleteProfileColors;
        internal MultiplayerColorBlock[] teamColors;
        [TagReference("unic")] internal Moonfish.Tags.TagReference teamNames;

        public override int SerializedSize
        {
            get { return 32; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public MultiplayerUiBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            randomPlayerNames = binaryReader.ReadTagReference();
            blamPointers.Enqueue(ReadBlockArrayPointer<MultiplayerColorBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<MultiplayerColorBlock>(binaryReader));
            teamNames = binaryReader.ReadTagReference();
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            obsoleteProfileColors = ReadBlockArrayData<MultiplayerColorBlock>(binaryReader, blamPointers.Dequeue());
            teamColors = ReadBlockArrayData<MultiplayerColorBlock>(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(randomPlayerNames);
                nextAddress = Guerilla.WriteBlockArray<MultiplayerColorBlock>(binaryWriter, obsoleteProfileColors,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<MultiplayerColorBlock>(binaryWriter, teamColors, nextAddress);
                binaryWriter.Write(teamNames);
                return nextAddress;
            }
        }
    };
}