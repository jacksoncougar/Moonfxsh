// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class SkillToRankMappingBlock : SkillToRankMappingBlockBase
    {
        public  SkillToRankMappingBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  SkillToRankMappingBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class SkillToRankMappingBlockBase : GuerillaBlock
    {
        internal int skillBounds;
        
        public override int SerializedSize{get { return 4; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  SkillToRankMappingBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            skillBounds = binaryReader.ReadInt32();
        }
        public  SkillToRankMappingBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(skillBounds);
                return nextAddress;
            }
        }
    };
}
