// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class UserHintWellBlock : UserHintWellBlockBase
    {
        public  UserHintWellBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  UserHintWellBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class UserHintWellBlockBase : GuerillaBlock
    {
        internal Flags flags;
        internal UserHintWellPointBlock[] points;
        
        public override int SerializedSize{get { return 12; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  UserHintWellBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt32();
            points = Guerilla.ReadBlockArray<UserHintWellPointBlock>(binaryReader);
        }
        public  UserHintWellBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt32();
            points = Guerilla.ReadBlockArray<UserHintWellPointBlock>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)flags);
                nextAddress = Guerilla.WriteBlockArray<UserHintWellPointBlock>(binaryWriter, points, nextAddress);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        {
            Bidirectional = 1,
        };
    };
}
