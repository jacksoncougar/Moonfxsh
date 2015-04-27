// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class HudDashlightsBlock : HudDashlightsBlockBase
    {
        public  HudDashlightsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  HudDashlightsBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 28, Alignment = 4)]
    public class HudDashlightsBlockBase : GuerillaBlock
    {
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference bitmap;
        [TagReference("shad")]
        internal Moonfish.Tags.TagReference shader;
        internal short sequenceIndex;
        internal Flags flags;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference sound;
        
        public override int SerializedSize{get { return 28; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  HudDashlightsBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            bitmap = binaryReader.ReadTagReference();
            shader = binaryReader.ReadTagReference();
            sequenceIndex = binaryReader.ReadInt16();
            flags = (Flags)binaryReader.ReadInt16();
            sound = binaryReader.ReadTagReference();
        }
        public  HudDashlightsBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            bitmap = binaryReader.ReadTagReference();
            shader = binaryReader.ReadTagReference();
            sequenceIndex = binaryReader.ReadInt16();
            flags = (Flags)binaryReader.ReadInt16();
            sound = binaryReader.ReadTagReference();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(bitmap);
                binaryWriter.Write(shader);
                binaryWriter.Write(sequenceIndex);
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(sound);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : short
        {
            DontScaleWhenPulsing = 1,
        };
    };
}
