// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SectorVertexBlock : SectorVertexBlockBase
    {
        public  SectorVertexBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class SectorVertexBlockBase  : IGuerilla
    {
        internal OpenTK.Vector3 point;
        internal  SectorVertexBlockBase(BinaryReader binaryReader)
        {
            point = binaryReader.ReadVector3();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(point);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
