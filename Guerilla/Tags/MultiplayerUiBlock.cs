// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class MultiplayerUiBlock : MultiplayerUiBlockBase
    {
        public  MultiplayerUiBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 32, Alignment = 4)]
    public class MultiplayerUiBlockBase  : IGuerilla
    {
        [TagReference("unic")]
        internal Moonfish.Tags.TagReference randomPlayerNames;
        internal MultiplayerColorBlock[] obsoleteProfileColors;
        internal MultiplayerColorBlock[] teamColors;
        [TagReference("unic")]
        internal Moonfish.Tags.TagReference teamNames;
        internal  MultiplayerUiBlockBase(BinaryReader binaryReader)
        {
            randomPlayerNames = binaryReader.ReadTagReference();
            obsoleteProfileColors = Guerilla.ReadBlockArray<MultiplayerColorBlock>(binaryReader);
            teamColors = Guerilla.ReadBlockArray<MultiplayerColorBlock>(binaryReader);
            teamNames = binaryReader.ReadTagReference();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(randomPlayerNames);
                Guerilla.WriteBlockArray<MultiplayerColorBlock>(binaryWriter, obsoleteProfileColors, nextAddress);
                Guerilla.WriteBlockArray<MultiplayerColorBlock>(binaryWriter, teamColors, nextAddress);
                binaryWriter.Write(teamNames);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
