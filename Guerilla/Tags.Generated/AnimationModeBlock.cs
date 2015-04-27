// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class AnimationModeBlock : AnimationModeBlockBase
    {
        public  AnimationModeBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  AnimationModeBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class AnimationModeBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringID label;
        internal WeaponClassBlock[] weaponClassAABBCC;
        internal AnimationIkBlock[] modeIkAABBCC;
        
        public override int SerializedSize{get { return 20; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  AnimationModeBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            label = binaryReader.ReadStringID();
            weaponClassAABBCC = Guerilla.ReadBlockArray<WeaponClassBlock>(binaryReader);
            modeIkAABBCC = Guerilla.ReadBlockArray<AnimationIkBlock>(binaryReader);
        }
        public  AnimationModeBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(label);
                nextAddress = Guerilla.WriteBlockArray<WeaponClassBlock>(binaryWriter, weaponClassAABBCC, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<AnimationIkBlock>(binaryWriter, modeIkAABBCC, nextAddress);
                return nextAddress;
            }
        }
    };
}
