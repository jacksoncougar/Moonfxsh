// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class GlobalMapLeafBlock : GlobalMapLeafBlockBase
    {
        public  GlobalMapLeafBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class GlobalMapLeafBlockBase  : IGuerilla
    {
        internal MapLeafFaceBlock[] faces;
        internal MapLeafConnectionIndexBlock[] connectionIndices;
        internal  GlobalMapLeafBlockBase(BinaryReader binaryReader)
        {
            faces = Guerilla.ReadBlockArray<MapLeafFaceBlock>(binaryReader);
            connectionIndices = Guerilla.ReadBlockArray<MapLeafConnectionIndexBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                Guerilla.WriteBlockArray<MapLeafFaceBlock>(binaryWriter, faces, nextAddress);
                Guerilla.WriteBlockArray<MapLeafConnectionIndexBlock>(binaryWriter, connectionIndices, nextAddress);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
