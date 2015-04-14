// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class CollisionModelMaterialBlock : CollisionModelMaterialBlockBase
    {
        public  CollisionModelMaterialBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class CollisionModelMaterialBlockBase  : IGuerilla
    {
        internal Moonfish.Tags.StringID name;
        internal  CollisionModelMaterialBlockBase(BinaryReader binaryReader)
        {
            name = binaryReader.ReadStringID();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
