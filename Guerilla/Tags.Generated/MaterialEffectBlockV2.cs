// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class MaterialEffectBlockV2 : MaterialEffectBlockV2Base
    {
        public  MaterialEffectBlockV2(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  MaterialEffectBlockV2(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class MaterialEffectBlockV2Base : GuerillaBlock
    {
        internal OldMaterialEffectMaterialBlock[] oldMaterialsDONOTUSE;
        internal MaterialEffectMaterialBlock[] sounds;
        internal MaterialEffectMaterialBlock[] effects;
        
        public override int SerializedSize{get { return 24; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  MaterialEffectBlockV2Base(BinaryReader binaryReader): base(binaryReader)
        {
            oldMaterialsDONOTUSE = Guerilla.ReadBlockArray<OldMaterialEffectMaterialBlock>(binaryReader);
            sounds = Guerilla.ReadBlockArray<MaterialEffectMaterialBlock>(binaryReader);
            effects = Guerilla.ReadBlockArray<MaterialEffectMaterialBlock>(binaryReader);
        }
        public  MaterialEffectBlockV2Base(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            oldMaterialsDONOTUSE = Guerilla.ReadBlockArray<OldMaterialEffectMaterialBlock>(binaryReader);
            sounds = Guerilla.ReadBlockArray<MaterialEffectMaterialBlock>(binaryReader);
            effects = Guerilla.ReadBlockArray<MaterialEffectMaterialBlock>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<OldMaterialEffectMaterialBlock>(binaryWriter, oldMaterialsDONOTUSE, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<MaterialEffectMaterialBlock>(binaryWriter, sounds, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<MaterialEffectMaterialBlock>(binaryWriter, effects, nextAddress);
                return nextAddress;
            }
        }
    };
}
