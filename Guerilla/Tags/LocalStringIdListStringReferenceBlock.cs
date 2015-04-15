// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class LocalStringIdListStringReferenceBlock : LocalStringIdListStringReferenceBlockBase
    {
        public  LocalStringIdListStringReferenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class LocalStringIdListStringReferenceBlockBase  : IGuerilla
    {
        internal Moonfish.Tags.StringID stringId;
        internal  LocalStringIdListStringReferenceBlockBase(BinaryReader binaryReader)
        {
            stringId = binaryReader.ReadStringID();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(stringId);
                return nextAddress;
            }
        }
    };
}
