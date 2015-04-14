// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class UserHintFlightBlock : UserHintFlightBlockBase
    {
        public  UserHintFlightBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class UserHintFlightBlockBase  : IGuerilla
    {
        internal UserHintFlightPointBlock[] points;
        internal  UserHintFlightBlockBase(BinaryReader binaryReader)
        {
            points = Guerilla.ReadBlockArray<UserHintFlightPointBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                Guerilla.WriteBlockArray<UserHintFlightPointBlock>(binaryWriter, points, nextAddress);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
