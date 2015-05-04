// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class UserHintFlightBlock : UserHintFlightBlockBase
    {
        public  UserHintFlightBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  UserHintFlightBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class UserHintFlightBlockBase : GuerillaBlock
    {
        internal UserHintFlightPointBlock[] points;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  UserHintFlightBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            points = Guerilla.ReadBlockArray<UserHintFlightPointBlock>(binaryReader);
        }
        public  UserHintFlightBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            points = Guerilla.ReadBlockArray<UserHintFlightPointBlock>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<UserHintFlightPointBlock>(binaryWriter, points, nextAddress);
                return nextAddress;
            }
        }
    };
}
