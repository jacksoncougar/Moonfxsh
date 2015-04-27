// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class DamageDirectionBlock : DamageDirectionBlockBase
    {
        public  DamageDirectionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  DamageDirectionBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class DamageDirectionBlockBase : GuerillaBlock
    {
        internal DamageRegionBlock[] regionsAABBCC;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  DamageDirectionBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            regionsAABBCC = Guerilla.ReadBlockArray<DamageRegionBlock>(binaryReader);
        }
        public  DamageDirectionBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<DamageRegionBlock>(binaryWriter, regionsAABBCC, nextAddress);
                return nextAddress;
            }
        }
    };
}
