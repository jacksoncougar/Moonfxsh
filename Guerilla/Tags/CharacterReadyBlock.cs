// ReSharper disable All
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
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class CharacterReadyBlockBase  : IGuerilla
    {
        /// <summary>
        /// Character will pause for given time before engaging threat
        /// </summary>
        internal Moonfish.Model.Range readyTimeBounds;
        internal  CharacterReadyBlockBase(BinaryReader binaryReader)
        {
            readyTimeBounds = binaryReader.ReadRange();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(readyTimeBounds);
                return nextAddress;
            }
        }
    };
}
