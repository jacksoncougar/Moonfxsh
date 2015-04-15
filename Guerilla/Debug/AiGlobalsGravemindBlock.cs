// ReSharper disable All
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
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class AiGlobalsGravemindBlockBase  : IGuerilla
    {
        internal float minRetreatTimeSecs;
        internal float idealRetreatTimeSecs;
        internal float maxRetreatTimeSecs;
        internal  AiGlobalsGravemindBlockBase(BinaryReader binaryReader)
        {
            minRetreatTimeSecs = binaryReader.ReadSingle();
            idealRetreatTimeSecs = binaryReader.ReadSingle();
            maxRetreatTimeSecs = binaryReader.ReadSingle();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(minRetreatTimeSecs);
                binaryWriter.Write(idealRetreatTimeSecs);
                binaryWriter.Write(maxRetreatTimeSecs);
                return nextAddress;
            }
        }
    };
}
