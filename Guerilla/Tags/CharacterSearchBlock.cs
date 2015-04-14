using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class CharacterSearchBlock : CharacterSearchBlockBase
    {
        public  CharacterSearchBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20)]
    public class CharacterSearchBlockBase
    {
        internal SearchFlags searchFlags;
        internal Moonfish.Model.Range searchTime;
        /// <summary>
        /// Distance of uncover point from target. Hard lower limit, soft upper limit.
        /// </summary>
        internal Moonfish.Model.Range uncoverDistanceBounds;
        internal  CharacterSearchBlockBase(BinaryReader binaryReader)
        {
            this.searchFlags = (SearchFlags)binaryReader.ReadInt32();
            this.searchTime = binaryReader.ReadRange();
            this.uncoverDistanceBounds = binaryReader.ReadRange();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
        }
        [FlagsAttribute]
        internal enum SearchFlags : int
        
        {
            CrouchOnInvestigate = 1,
            WalkOnPursuit = 2,
        };
    };
}
