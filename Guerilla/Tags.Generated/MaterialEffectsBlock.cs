// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Foot = (TagClass)"foot";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("foot")]
    public partial class MaterialEffectsBlock : MaterialEffectsBlockBase
    {
        public  MaterialEffectsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  MaterialEffectsBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class MaterialEffectsBlockBase : GuerillaBlock
    {
        internal MaterialEffectBlockV2[] effects;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  MaterialEffectsBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            effects = Guerilla.ReadBlockArray<MaterialEffectBlockV2>(binaryReader);
        }
        public  MaterialEffectsBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            effects = Guerilla.ReadBlockArray<MaterialEffectBlockV2>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<MaterialEffectBlockV2>(binaryWriter, effects, nextAddress);
                return nextAddress;
            }
        }
    };
}
