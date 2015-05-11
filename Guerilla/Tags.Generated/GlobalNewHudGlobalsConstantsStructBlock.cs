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
    public partial class GlobalNewHudGlobalsConstantsStructBlock : GlobalNewHudGlobalsConstantsStructBlockBase
    {
        public GlobalNewHudGlobalsConstantsStructBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 96, Alignment = 4)]
    public class GlobalNewHudGlobalsConstantsStructBlockBase : GuerillaBlock
    {
        [TagReference("null")] internal Moonfish.Tags.TagReference primaryMessageSound;
        [TagReference("null")] internal Moonfish.Tags.TagReference secondaryMessageSound;
        internal Moonfish.Tags.StringIdent bootGrieferString;
        internal Moonfish.Tags.StringIdent cannotBootGrieferString;
        [TagReference("shad")] internal Moonfish.Tags.TagReference trainingShader;
        [TagReference("bitm")] internal Moonfish.Tags.TagReference humanTrainingTopRight;
        [TagReference("bitm")] internal Moonfish.Tags.TagReference humanTrainingTopCenter;
        [TagReference("bitm")] internal Moonfish.Tags.TagReference humanTrainingTopLeft;
        [TagReference("bitm")] internal Moonfish.Tags.TagReference humanTrainingMiddle;
        [TagReference("bitm")] internal Moonfish.Tags.TagReference eliteTrainingTopRight;
        [TagReference("bitm")] internal Moonfish.Tags.TagReference eliteTrainingTopCenter;
        [TagReference("bitm")] internal Moonfish.Tags.TagReference eliteTrainingTopLeft;
        [TagReference("bitm")] internal Moonfish.Tags.TagReference eliteTrainingMiddle;

        public override int SerializedSize
        {
            get { return 96; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public GlobalNewHudGlobalsConstantsStructBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            primaryMessageSound = binaryReader.ReadTagReference();
            secondaryMessageSound = binaryReader.ReadTagReference();
            bootGrieferString = binaryReader.ReadStringID();
            cannotBootGrieferString = binaryReader.ReadStringID();
            trainingShader = binaryReader.ReadTagReference();
            humanTrainingTopRight = binaryReader.ReadTagReference();
            humanTrainingTopCenter = binaryReader.ReadTagReference();
            humanTrainingTopLeft = binaryReader.ReadTagReference();
            humanTrainingMiddle = binaryReader.ReadTagReference();
            eliteTrainingTopRight = binaryReader.ReadTagReference();
            eliteTrainingTopCenter = binaryReader.ReadTagReference();
            eliteTrainingTopLeft = binaryReader.ReadTagReference();
            eliteTrainingMiddle = binaryReader.ReadTagReference();
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
                binaryWriter.Write(primaryMessageSound);
                binaryWriter.Write(secondaryMessageSound);
                binaryWriter.Write(bootGrieferString);
                binaryWriter.Write(cannotBootGrieferString);
                binaryWriter.Write(trainingShader);
                binaryWriter.Write(humanTrainingTopRight);
                binaryWriter.Write(humanTrainingTopCenter);
                binaryWriter.Write(humanTrainingTopLeft);
                binaryWriter.Write(humanTrainingMiddle);
                binaryWriter.Write(eliteTrainingTopRight);
                binaryWriter.Write(eliteTrainingTopCenter);
                binaryWriter.Write(eliteTrainingTopLeft);
                binaryWriter.Write(eliteTrainingMiddle);
                return nextAddress;
            }
        }
    };
}