// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class PathfindingObjectIndexListBlock : PathfindingObjectIndexListBlockBase
    {
        public  PathfindingObjectIndexListBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class PathfindingObjectIndexListBlockBase  : IGuerilla
    {
        internal short bSPIndex;
        internal short pathfindingObjectIndex;
        internal  PathfindingObjectIndexListBlockBase(BinaryReader binaryReader)
        {
            bSPIndex = binaryReader.ReadInt16();
            pathfindingObjectIndex = binaryReader.ReadInt16();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(bSPIndex);
                binaryWriter.Write(pathfindingObjectIndex);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
