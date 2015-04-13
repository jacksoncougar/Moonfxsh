// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class DamageAnimationBlock : DamageAnimationBlockBase
    {
        public  DamageAnimationBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class DamageAnimationBlockBase  : IGuerilla
    {
        internal Moonfish.Tags.StringID label;
        internal DamageDirectionBlock[] directionsAABBCC;
        internal  DamageAnimationBlockBase(BinaryReader binaryReader)
        {
            label = binaryReader.ReadStringID();
            directionsAABBCC = Guerilla.ReadBlockArray<DamageDirectionBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(label);
                Guerilla.WriteBlockArray<DamageDirectionBlock>(binaryWriter, directionsAABBCC, nextAddress);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
