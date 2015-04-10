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
    [LayoutAttribute(Size = 96)]
    public class GlobalNewHudGlobalsConstantsStructBlockBase
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
            this.primaryMessageSound = binaryReader.ReadTagReference();
            this.secondaryMessageSound = binaryReader.ReadTagReference();
            this.bootGrieferString = binaryReader.ReadStringID();
            this.cannotBootGrieferString = binaryReader.ReadStringID();
            this.trainingShader = binaryReader.ReadTagReference();
            this.humanTrainingTopRight = binaryReader.ReadTagReference();
            this.humanTrainingTopCenter = binaryReader.ReadTagReference();
            this.humanTrainingTopLeft = binaryReader.ReadTagReference();
            this.humanTrainingMiddle = binaryReader.ReadTagReference();
            this.eliteTrainingTopRight = binaryReader.ReadTagReference();
            this.eliteTrainingTopCenter = binaryReader.ReadTagReference();
            this.eliteTrainingTopLeft = binaryReader.ReadTagReference();
            this.eliteTrainingMiddle = binaryReader.ReadTagReference();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
        }
    };
}
