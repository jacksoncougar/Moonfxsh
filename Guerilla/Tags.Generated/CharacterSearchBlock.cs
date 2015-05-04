// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class CharacterSearchBlock : CharacterSearchBlockBase
    {
        public  CharacterSearchBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  CharacterSearchBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class CharacterSearchBlockBase : GuerillaBlock
    {
        internal SearchFlags searchFlags;
        internal Moonfish.Model.Range searchTime;
        /// <summary>
        /// Distance of uncover point from target. Hard lower limit, soft upper limit.
        /// </summary>
        internal Moonfish.Model.Range uncoverDistanceBounds;
        
        public override int SerializedSize{get { return 20; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  CharacterSearchBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            searchFlags = (SearchFlags)binaryReader.ReadInt32();
            searchTime = binaryReader.ReadRange();
            uncoverDistanceBounds = binaryReader.ReadRange();
        }
        public  CharacterSearchBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            searchFlags = (SearchFlags)binaryReader.ReadInt32();
            searchTime = binaryReader.ReadRange();
            uncoverDistanceBounds = binaryReader.ReadRange();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)searchFlags);
                binaryWriter.Write(searchTime);
                binaryWriter.Write(uncoverDistanceBounds);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum SearchFlags : int
        {
            CrouchOnInvestigate = 1,
            WalkOnPursuit = 2,
        };
    };
}
