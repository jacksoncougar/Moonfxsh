using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class WeaponFirstPersonInterfaceBlock : WeaponFirstPersonInterfaceBlockBase
    {
        public  WeaponFirstPersonInterfaceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class WeaponFirstPersonInterfaceBlockBase
    {
        [TagReference("mode")]
        internal Moonfish.Tags.TagReference firstPersonModel;
        [TagReference("jmad")]
        internal Moonfish.Tags.TagReference firstPersonAnimations;
        internal  WeaponFirstPersonInterfaceBlockBase(BinaryReader binaryReader)
        {
            this.firstPersonModel = binaryReader.ReadTagReference();
            this.firstPersonAnimations = binaryReader.ReadTagReference();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
    };
}
