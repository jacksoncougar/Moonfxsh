// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ModelVariantBlock : ModelVariantBlockBase
    {
        public  ModelVariantBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ModelVariantBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 56, Alignment = 4)]
    public class ModelVariantBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringID name;
        internal byte[] invalidName_;
        internal ModelVariantRegionBlock[] regions;
        internal ModelVariantObjectBlock[] objects;
        internal byte[] invalidName_0;
        internal Moonfish.Tags.StringID dialogueSoundEffect;
        [TagReference("udlg")]
        internal Moonfish.Tags.TagReference dialogue;
        
        public override int SerializedSize{get { return 56; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ModelVariantBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            name = binaryReader.ReadStringID();
            invalidName_ = binaryReader.ReadBytes(16);
            regions = Guerilla.ReadBlockArray<ModelVariantRegionBlock>(binaryReader);
            objects = Guerilla.ReadBlockArray<ModelVariantObjectBlock>(binaryReader);
            invalidName_0 = binaryReader.ReadBytes(8);
            dialogueSoundEffect = binaryReader.ReadStringID();
            dialogue = binaryReader.ReadTagReference();
        }
        public  ModelVariantBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            name = binaryReader.ReadStringID();
            invalidName_ = binaryReader.ReadBytes(16);
            regions = Guerilla.ReadBlockArray<ModelVariantRegionBlock>(binaryReader);
            objects = Guerilla.ReadBlockArray<ModelVariantObjectBlock>(binaryReader);
            invalidName_0 = binaryReader.ReadBytes(8);
            dialogueSoundEffect = binaryReader.ReadStringID();
            dialogue = binaryReader.ReadTagReference();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write(invalidName_, 0, 16);
                nextAddress = Guerilla.WriteBlockArray<ModelVariantRegionBlock>(binaryWriter, regions, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ModelVariantObjectBlock>(binaryWriter, objects, nextAddress);
                binaryWriter.Write(invalidName_0, 0, 8);
                binaryWriter.Write(dialogueSoundEffect);
                binaryWriter.Write(dialogue);
                return nextAddress;
            }
        }
    };
}
