// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class DamageGroupBlock : DamageGroupBlockBase
    {
        public  DamageGroupBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  DamageGroupBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class DamageGroupBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent name;
        internal ArmorModifierBlock[] armorModifiers;
        
        public override int SerializedSize{get { return 12; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  DamageGroupBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            name = binaryReader.ReadStringID();
            armorModifiers = Guerilla.ReadBlockArray<ArmorModifierBlock>(binaryReader);
        }
        public  DamageGroupBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            name = binaryReader.ReadStringID();
            armorModifiers = Guerilla.ReadBlockArray<ArmorModifierBlock>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                nextAddress = Guerilla.WriteBlockArray<ArmorModifierBlock>(binaryWriter, armorModifiers, nextAddress);
                return nextAddress;
            }
        }
    };
}
