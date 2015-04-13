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
    [LayoutAttribute(Size = 12)]
    public class LocalStringIdListSectionReferenceBlockBase
    {
        internal Moonfish.Tags.StringID sectionName;
        internal LocalStringIdListStringReferenceBlock[] localStringSectionReferences;
        internal  LocalStringIdListSectionReferenceBlockBase(BinaryReader binaryReader)
        {
            this.sectionName = binaryReader.ReadStringID();
            this.localStringSectionReferences = ReadLocalStringIdListStringReferenceBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
        }
        internal  virtual LocalStringIdListStringReferenceBlock[] ReadLocalStringIdListStringReferenceBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(LocalStringIdListStringReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new LocalStringIdListStringReferenceBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new LocalStringIdListStringReferenceBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
