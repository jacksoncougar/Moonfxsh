// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SoundGestaltExtraInfoBlock : SoundGestaltExtraInfoBlockBase
    {
        public  SoundGestaltExtraInfoBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 44, Alignment = 4)]
    public class SoundGestaltExtraInfoBlockBase  : IGuerilla
    {
        internal SoundEncodedDialogueSectionBlock[] encodedPermutationSection;
        internal GlobalGeometryBlockInfoStructBlock geometryBlockInfo;
        internal  SoundGestaltExtraInfoBlockBase(BinaryReader binaryReader)
        {
            encodedPermutationSection = Guerilla.ReadBlockArray<SoundEncodedDialogueSectionBlock>(binaryReader);
            geometryBlockInfo = new GlobalGeometryBlockInfoStructBlock(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
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
