// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class CharacterReadyBlock : CharacterReadyBlockBase
    {
        public  CharacterReadyBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  CharacterReadyBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class CharacterReadyBlockBase : GuerillaBlock
    {
        /// <summary>
        /// Character will pause for given time before engaging threat
        /// </summary>
        internal Moonfish.Model.Range readyTimeBounds;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  CharacterReadyBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            readyTimeBounds = binaryReader.ReadRange();
        }
        public  CharacterReadyBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(readyTimeBounds);
                return nextAddress;
            }
        }
    };
}
