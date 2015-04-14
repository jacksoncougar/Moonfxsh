// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class LocalStringIdListSectionReferenceBlock : LocalStringIdListSectionReferenceBlockBase
    {
        public  LocalStringIdListSectionReferenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class LocalStringIdListSectionReferenceBlockBase  : IGuerilla
    {
        internal Moonfish.Tags.StringID sectionName;
        internal LocalStringIdListStringReferenceBlock[] localStringSectionReferences;
        internal  LocalStringIdListSectionReferenceBlockBase(BinaryReader binaryReader)
        {
            sectionName = binaryReader.ReadStringID();
            localStringSectionReferences = Guerilla.ReadBlockArray<LocalStringIdListStringReferenceBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(sectionName);
                Guerilla.WriteBlockArray<LocalStringIdListStringReferenceBlock>(binaryWriter, localStringSectionReferences, nextAddress);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
