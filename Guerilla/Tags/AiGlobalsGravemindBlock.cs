using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class AiGlobalsGravemindBlock : AiGlobalsGravemindBlockBase
    {
        public  AiGlobalsGravemindBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12)]
    public class AiGlobalsGravemindBlockBase
    {
        internal float minRetreatTimeSecs;
        internal float idealRetreatTimeSecs;
        internal float maxRetreatTimeSecs;
        internal  AiGlobalsGravemindBlockBase(BinaryReader binaryReader)
        {
            this.minRetreatTimeSecs = binaryReader.ReadSingle();
            this.idealRetreatTimeSecs = binaryReader.ReadSingle();
            this.maxRetreatTimeSecs = binaryReader.ReadSingle();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
        }
    };
}
