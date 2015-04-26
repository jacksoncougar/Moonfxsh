// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class UserHintClimbBlock : UserHintClimbBlockBase
    {
        public  UserHintClimbBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class UserHintClimbBlockBase  : IGuerilla
    {
        internal Flags flags;
        internal Moonfish.Tags.ShortBlockIndex1 geometryIndex;
        internal  UserHintClimbBlockBase(BinaryReader binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt16();
            geometryIndex = binaryReader.ReadShortBlockIndex1();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(geometryIndex);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : short
        {
            Bidirectional = 1,
            Closed = 2,
        };
    };
}
