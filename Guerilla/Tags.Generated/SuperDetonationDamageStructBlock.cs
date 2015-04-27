// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class SuperDetonationDamageStructBlock : SuperDetonationDamageStructBlockBase
    {
        public  SuperDetonationDamageStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  SuperDetonationDamageStructBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class SuperDetonationDamageStructBlockBase : GuerillaBlock
    {
        [TagReference("jpt!")]
        internal Moonfish.Tags.TagReference superDetonationDamage;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  SuperDetonationDamageStructBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            superDetonationDamage = binaryReader.ReadTagReference();
        }
        public  SuperDetonationDamageStructBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(superDetonationDamage);
                return nextAddress;
            }
        }
    };
}
