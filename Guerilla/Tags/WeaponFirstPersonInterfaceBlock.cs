// ReSharper disable All
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
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class WeaponFirstPersonInterfaceBlockBase  : IGuerilla
    {
        [TagReference("mode")]
        internal Moonfish.Tags.TagReference firstPersonModel;
        [TagReference("jmad")]
        internal Moonfish.Tags.TagReference firstPersonAnimations;
        internal  WeaponFirstPersonInterfaceBlockBase(BinaryReader binaryReader)
        {
            firstPersonModel = binaryReader.ReadTagReference();
            firstPersonAnimations = binaryReader.ReadTagReference();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
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
