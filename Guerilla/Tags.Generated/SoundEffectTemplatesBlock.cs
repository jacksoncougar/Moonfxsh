// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class SoundEffectTemplatesBlock : SoundEffectTemplatesBlockBase
    {
        public  SoundEffectTemplatesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  SoundEffectTemplatesBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 28, Alignment = 4)]
    public class SoundEffectTemplatesBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringID dspEffect;
        internal byte[] explanation;
        internal Flags flags;
        internal short invalidName_;
        internal short invalidName_0;
        internal SoundEffectTemplateParameterBlock[] parameters;
        
        public override int SerializedSize{get { return 28; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  SoundEffectTemplatesBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            dspEffect = binaryReader.ReadStringID();
            explanation = Guerilla.ReadData(binaryReader);
            flags = (Flags)binaryReader.ReadInt32();
            invalidName_ = binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadInt16();
            parameters = Guerilla.ReadBlockArray<SoundEffectTemplateParameterBlock>(binaryReader);
        }
        public  SoundEffectTemplatesBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            dspEffect = binaryReader.ReadStringID();
            explanation = Guerilla.ReadData(binaryReader);
            flags = (Flags)binaryReader.ReadInt32();
            invalidName_ = binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadInt16();
            parameters = Guerilla.ReadBlockArray<SoundEffectTemplateParameterBlock>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(dspEffect);
                nextAddress = Guerilla.WriteData(binaryWriter, explanation, nextAddress);
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write(invalidName_);
                binaryWriter.Write(invalidName_0);
                nextAddress = Guerilla.WriteBlockArray<SoundEffectTemplateParameterBlock>(binaryWriter, parameters, nextAddress);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        {
            UseHighLevelParameters = 1,
            CustomParameters = 2,
        };
    };
}
