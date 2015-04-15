// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class DamageDirectionBlock : DamageDirectionBlockBase
    {
        public  DamageDirectionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class DamageDirectionBlockBase  : IGuerilla
    {
        internal DamageRegionBlock[] regionsAABBCC;
        internal  DamageDirectionBlockBase(BinaryReader binaryReader)
        {
            regionsAABBCC = Guerilla.ReadBlockArray<DamageRegionBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<DamageRegionBlock>(binaryWriter, regionsAABBCC, nextAddress);
                return nextAddress;
            }
        }
    };
}
