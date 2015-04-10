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
        public  GlobalNewHudGlobalsConstantsStructBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  GlobalNewHudGlobalsConstantsStructBlockBase(System.IO.BinaryReader binaryReader)
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
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
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
            }
        }
    };
}
