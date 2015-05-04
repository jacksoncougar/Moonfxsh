// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class WeaponClassBlock : WeaponClassBlockBase
    {
        public  WeaponClassBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  WeaponClassBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class WeaponClassBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent label;
        internal WeaponTypeBlock[] weaponTypeAABBCC;
        internal AnimationIkBlock[] weaponIkAABBCC;
        
        public override int SerializedSize{get { return 20; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  WeaponClassBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            label = binaryReader.ReadStringID();
            weaponTypeAABBCC = Guerilla.ReadBlockArray<WeaponTypeBlock>(binaryReader);
            weaponIkAABBCC = Guerilla.ReadBlockArray<AnimationIkBlock>(binaryReader);
        }
        public  WeaponClassBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            label = binaryReader.ReadStringID();
            weaponTypeAABBCC = Guerilla.ReadBlockArray<WeaponTypeBlock>(binaryReader);
            weaponIkAABBCC = Guerilla.ReadBlockArray<AnimationIkBlock>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(label);
                nextAddress = Guerilla.WriteBlockArray<WeaponTypeBlock>(binaryWriter, weaponTypeAABBCC, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<AnimationIkBlock>(binaryWriter, weaponIkAABBCC, nextAddress);
                return nextAddress;
            }
        }
    };
}
