// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class StructureBspPathfindingEdgesBlock : StructureBspPathfindingEdgesBlockBase
    {
        public  StructureBspPathfindingEdgesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 1, Alignment = 4)]
    public class StructureBspPathfindingEdgesBlockBase  : IGuerilla
    {
        internal byte midpoint;
        internal  StructureBspPathfindingEdgesBlockBase(BinaryReader binaryReader)
        {
            midpoint = binaryReader.ReadByte();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(midpoint);
                return nextAddress;
            }
        }
    };
}
