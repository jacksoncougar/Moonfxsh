// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class UserHintPolygonBlock : UserHintPolygonBlockBase
    {
        public  UserHintPolygonBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class UserHintPolygonBlockBase  : IGuerilla
    {
        internal Flags flags;
        internal UserHintPointBlock[] points;
        internal  UserHintPolygonBlockBase(BinaryReader binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt32();
            points = Guerilla.ReadBlockArray<UserHintPointBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)flags);
                Guerilla.WriteBlockArray<UserHintPointBlock>(binaryWriter, points, nextAddress);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        {
            Bidirectional = 1,
            Closed = 2,
        };
    };
}
