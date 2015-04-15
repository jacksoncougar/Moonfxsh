// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class UnitPosturesBlock : UnitPosturesBlockBase
    {
        public  UnitPosturesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class UnitPosturesBlockBase  : IGuerilla
    {
        internal Moonfish.Tags.StringID name;
        internal OpenTK.Vector3 pillOffset;
        internal  UnitPosturesBlockBase(BinaryReader binaryReader)
        {
            name = binaryReader.ReadStringID();
            pillOffset = binaryReader.ReadVector3();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write(pillOffset);
                return nextAddress;
            }
        }
    };
}
