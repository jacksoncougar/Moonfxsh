// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class MultiplayerUniversalBlock : MultiplayerUniversalBlockBase
    {
        public  MultiplayerUniversalBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 32, Alignment = 4)]
    public class MultiplayerUniversalBlockBase  : IGuerilla
    {
        [TagReference("unic")]
        internal Moonfish.Tags.TagReference randomPlayerNames;
        [TagReference("unic")]
        internal Moonfish.Tags.TagReference teamNames;
        internal MultiplayerColorBlock[] teamColors;
        [TagReference("unic")]
        internal Moonfish.Tags.TagReference multiplayerText;
        internal  MultiplayerUniversalBlockBase(BinaryReader binaryReader)
        {
            randomPlayerNames = binaryReader.ReadTagReference();
            teamNames = binaryReader.ReadTagReference();
            teamColors = Guerilla.ReadBlockArray<MultiplayerColorBlock>(binaryReader);
            multiplayerText = binaryReader.ReadTagReference();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(randomPlayerNames);
                binaryWriter.Write(teamNames);
                nextAddress = Guerilla.WriteBlockArray<MultiplayerColorBlock>(binaryWriter, teamColors, nextAddress);
                binaryWriter.Write(multiplayerText);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
