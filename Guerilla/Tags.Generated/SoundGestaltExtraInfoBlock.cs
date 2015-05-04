// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class SoundGestaltExtraInfoBlock : SoundGestaltExtraInfoBlockBase
    {
        public  SoundGestaltExtraInfoBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  SoundGestaltExtraInfoBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 44, Alignment = 4)]
    public class SoundGestaltExtraInfoBlockBase : GuerillaBlock
    {
        internal SoundEncodedDialogueSectionBlock[] encodedPermutationSection;
        internal GlobalGeometryBlockInfoStructBlock geometryBlockInfo;
        
        public override int SerializedSize{get { return 44; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  SoundGestaltExtraInfoBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            encodedPermutationSection = Guerilla.ReadBlockArray<SoundEncodedDialogueSectionBlock>(binaryReader);
            geometryBlockInfo = new GlobalGeometryBlockInfoStructBlock(binaryReader);
        }
        public  SoundGestaltExtraInfoBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            encodedPermutationSection = Guerilla.ReadBlockArray<SoundEncodedDialogueSectionBlock>(binaryReader);
            geometryBlockInfo = new GlobalGeometryBlockInfoStructBlock(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<SoundEncodedDialogueSectionBlock>(binaryWriter, encodedPermutationSection, nextAddress);
                geometryBlockInfo.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
