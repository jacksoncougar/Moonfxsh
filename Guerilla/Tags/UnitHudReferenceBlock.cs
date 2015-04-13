// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class UnitHudReferenceBlock : UnitHudReferenceBlockBase
    {
        public  UnitHudReferenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class UnitHudReferenceBlockBase  : IGuerilla
    {
        [TagReference("nhdt")]
        internal Moonfish.Tags.TagReference newUnitHudInterface;
        internal  UnitHudReferenceBlockBase(BinaryReader binaryReader)
        {
            newUnitHudInterface = binaryReader.ReadTagReference();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(newUnitHudInterface);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
