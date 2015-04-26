// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class RefBlock : RefBlockBase
    {
        public  RefBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class RefBlockBase  : IGuerilla
    {
        internal int nodeRefOrSectorRef;
        internal  RefBlockBase(BinaryReader binaryReader)
        {
            nodeRefOrSectorRef = binaryReader.ReadInt32();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(nodeRefOrSectorRef);
                return nextAddress;
            }
        }
    };
}
