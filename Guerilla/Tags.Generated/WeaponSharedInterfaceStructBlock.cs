// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class WeaponSharedInterfaceStructBlock : WeaponSharedInterfaceStructBlockBase
    {
        public  WeaponSharedInterfaceStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  WeaponSharedInterfaceStructBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class WeaponSharedInterfaceStructBlockBase : GuerillaBlock
    {
        internal byte[] invalidName_;
        
        public override int SerializedSize{get { return 16; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  WeaponSharedInterfaceStructBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(16);
        }
        public  WeaponSharedInterfaceStructBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_, 0, 16);
                return nextAddress;
            }
        }
    };
}
