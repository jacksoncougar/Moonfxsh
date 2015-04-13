// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class MultiplayerColorBlock : MultiplayerColorBlockBase
    {
        public  MultiplayerColorBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class MultiplayerColorBlockBase  : IGuerilla
    {
        internal Moonfish.Tags.ColorR8G8B8 color;
        internal  MultiplayerColorBlockBase(BinaryReader binaryReader)
        {
            color = binaryReader.ReadColorR8G8B8();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(color);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
