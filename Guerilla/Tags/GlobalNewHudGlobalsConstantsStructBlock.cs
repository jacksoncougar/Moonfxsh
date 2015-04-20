// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class GlobalNewHudGlobalsConstantsStructBlock : GlobalNewHudGlobalsConstantsStructBlockBase
    {
        public  GlobalNewHudGlobalsConstantsStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 96, Alignment = 4)]
    public class GlobalNewHudGlobalsConstantsStructBlockBase  : IGuerilla
    {
        [TagReference("null")]
        internal Moonfish.Tags.TagReference primaryMessageSound;
        [TagReference("null")]
        internal Moonfish.Tags.TagReference secondaryMessageSound;
        internal Moonfish.Tags.StringID bootGrieferString;
        internal Moonfish.Tags.StringID cannotBootGrieferString;
        [TagReference("shad")]
        internal Moonfish.Tags.TagReference trainingShader;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference humanTrainingTopRight;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference humanTrainingTopCenter;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference humanTrainingTopLeft;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference humanTrainingMiddle;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference eliteTrainingTopRight;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference eliteTrainingTopCenter;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference eliteTrainingTopLeft;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference eliteTrainingMiddle;
        internal  GlobalNewHudGlobalsConstantsStructBlockBase(BinaryReader binaryReader)
        {
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
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
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
