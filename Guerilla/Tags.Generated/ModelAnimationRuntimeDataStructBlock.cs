// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ModelAnimationRuntimeDataStructBlock : ModelAnimationRuntimeDataStructBlockBase
    {
        public  ModelAnimationRuntimeDataStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ModelAnimationRuntimeDataStructBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 80, Alignment = 4)]
    public class ModelAnimationRuntimeDataStructBlockBase : GuerillaBlock
    {
        internal InheritedAnimationBlock[] inheritenceListBBAAAA;
        internal WeaponClassLookupBlock[] weaponListBBAAAA;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        
        public override int SerializedSize{get { return 80; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ModelAnimationRuntimeDataStructBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            inheritenceListBBAAAA = Guerilla.ReadBlockArray<InheritedAnimationBlock>(binaryReader);
            weaponListBBAAAA = Guerilla.ReadBlockArray<WeaponClassLookupBlock>(binaryReader);
            invalidName_ = binaryReader.ReadBytes(32);
            invalidName_0 = binaryReader.ReadBytes(32);
        }
        public  ModelAnimationRuntimeDataStructBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            inheritenceListBBAAAA = Guerilla.ReadBlockArray<InheritedAnimationBlock>(binaryReader);
            weaponListBBAAAA = Guerilla.ReadBlockArray<WeaponClassLookupBlock>(binaryReader);
            invalidName_ = binaryReader.ReadBytes(32);
            invalidName_0 = binaryReader.ReadBytes(32);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<InheritedAnimationBlock>(binaryWriter, inheritenceListBBAAAA, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<WeaponClassLookupBlock>(binaryWriter, weaponListBBAAAA, nextAddress);
                binaryWriter.Write(invalidName_, 0, 32);
                binaryWriter.Write(invalidName_0, 0, 32);
                return nextAddress;
            }
        }
    };
}
