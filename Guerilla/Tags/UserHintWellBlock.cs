// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class UserHintWellBlock : UserHintWellBlockBase
    {
        public  UserHintWellBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class UserHintWellBlockBase  : IGuerilla
    {
        internal Flags flags;
        internal UserHintWellPointBlock[] points;
        internal  UserHintWellBlockBase(BinaryReader binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt32();
            points = Guerilla.ReadBlockArray<UserHintWellPointBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)flags);
                nextAddress = Guerilla.WriteBlockArray<UserHintWellPointBlock>(binaryWriter, points, nextAddress);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        {
            Bidirectional = 1,
        };
    };
}
