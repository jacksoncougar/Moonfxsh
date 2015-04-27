// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class GrenadeBlock : GrenadeBlockBase
    {
        public  GrenadeBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  GrenadeBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class GrenadeBlockBase : GuerillaBlock
    {
        [TagReference("eqip")]
        internal Moonfish.Tags.TagReference weapon;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  GrenadeBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            weapon = binaryReader.ReadTagReference();
        }
        public  GrenadeBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            weapon = binaryReader.ReadTagReference();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(weapon);
                return nextAddress;
            }
        }
    };
}
