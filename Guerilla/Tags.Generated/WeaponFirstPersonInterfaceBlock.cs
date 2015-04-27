// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class WeaponFirstPersonInterfaceBlock : WeaponFirstPersonInterfaceBlockBase
    {
        public  WeaponFirstPersonInterfaceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  WeaponFirstPersonInterfaceBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class WeaponFirstPersonInterfaceBlockBase : GuerillaBlock
    {
        [TagReference("mode")]
        internal Moonfish.Tags.TagReference firstPersonModel;
        [TagReference("jmad")]
        internal Moonfish.Tags.TagReference firstPersonAnimations;
        
        public override int SerializedSize{get { return 16; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  WeaponFirstPersonInterfaceBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            firstPersonModel = binaryReader.ReadTagReference();
            firstPersonAnimations = binaryReader.ReadTagReference();
        }
        public  WeaponFirstPersonInterfaceBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(firstPersonModel);
                binaryWriter.Write(firstPersonAnimations);
                return nextAddress;
            }
        }
    };
}
