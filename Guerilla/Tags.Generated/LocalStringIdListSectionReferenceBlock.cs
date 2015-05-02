// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class LocalStringIdListSectionReferenceBlock : LocalStringIdListSectionReferenceBlockBase
    {
        public  LocalStringIdListSectionReferenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  LocalStringIdListSectionReferenceBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class LocalStringIdListSectionReferenceBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent sectionName;
        internal LocalStringIdListStringReferenceBlock[] localStringSectionReferences;
        
        public override int SerializedSize{get { return 12; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  LocalStringIdListSectionReferenceBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            sectionName = binaryReader.ReadStringID();
            localStringSectionReferences = Guerilla.ReadBlockArray<LocalStringIdListStringReferenceBlock>(binaryReader);
        }
        public  LocalStringIdListSectionReferenceBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            sectionName = binaryReader.ReadStringID();
            localStringSectionReferences = Guerilla.ReadBlockArray<LocalStringIdListStringReferenceBlock>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(sectionName);
                nextAddress = Guerilla.WriteBlockArray<LocalStringIdListStringReferenceBlock>(binaryWriter, localStringSectionReferences, nextAddress);
                return nextAddress;
            }
        }
    };
}
