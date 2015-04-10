// ReSharper disable All
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
        public  CharacterSearchBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  CharacterSearchBlockBase(System.IO.BinaryReader binaryReader)
        {
            searchFlags = (SearchFlags)binaryReader.ReadInt32();
            searchTime = binaryReader.ReadRange();
            uncoverDistanceBounds = binaryReader.ReadRange();
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)searchFlags);
                binaryWriter.Write(searchTime);
                binaryWriter.Write(uncoverDistanceBounds);
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
