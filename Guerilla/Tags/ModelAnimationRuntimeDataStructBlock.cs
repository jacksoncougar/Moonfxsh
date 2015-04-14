// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ModelAnimationRuntimeDataStructBlock : ModelAnimationRuntimeDataStructBlockBase
    {
        public  ModelAnimationRuntimeDataStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 80, Alignment = 4)]
    public class ModelAnimationRuntimeDataStructBlockBase  : IGuerilla
    {
        internal InheritedAnimationBlock[] inheritenceListBBAAAA;
        internal WeaponClassLookupBlock[] weaponListBBAAAA;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal  ModelAnimationRuntimeDataStructBlockBase(BinaryReader binaryReader)
        {
            inheritenceListBBAAAA = Guerilla.ReadBlockArray<InheritedAnimationBlock>(binaryReader);
            weaponListBBAAAA = Guerilla.ReadBlockArray<WeaponClassLookupBlock>(binaryReader);
            invalidName_ = binaryReader.ReadBytes(32);
            invalidName_0 = binaryReader.ReadBytes(32);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<InheritedAnimationBlock>(binaryWriter, inheritenceListBBAAAA, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<WeaponClassLookupBlock>(binaryWriter, weaponListBBAAAA, nextAddress);
                binaryWriter.Write(invalidName_, 0, 32);
                binaryWriter.Write(invalidName_0, 0, 32);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
