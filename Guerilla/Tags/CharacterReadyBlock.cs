using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class CharacterReadyBlock : CharacterReadyBlockBase
    {
        public  CharacterReadyBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8)]
    public class CharacterReadyBlockBase
    {
        /// <summary>
        /// Character will pause for given time before engaging threat
        /// </summary>
        internal Moonfish.Model.Range readyTimeBounds;
        internal  CharacterReadyBlockBase(BinaryReader binaryReader)
        {
            this.readyTimeBounds = binaryReader.ReadRange();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
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
    };
}
