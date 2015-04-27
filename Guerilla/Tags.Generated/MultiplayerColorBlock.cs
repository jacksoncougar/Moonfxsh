// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class MultiplayerColorBlock : MultiplayerColorBlockBase
    {
        public  MultiplayerColorBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  MultiplayerColorBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class MultiplayerColorBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.ColorR8G8B8 color;
        
        public override int SerializedSize{get { return 12; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  MultiplayerColorBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            color = binaryReader.ReadColorR8G8B8();
        }
        public  MultiplayerColorBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(color);
                return nextAddress;
            }
        }
    };
}
