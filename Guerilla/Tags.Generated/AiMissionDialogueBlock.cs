// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Mdlg = ( TagClass ) "mdlg";
    };
} ;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute( "mdlg" )]
    public partial class AiMissionDialogueBlock : AiMissionDialogueBlockBase
    {
        public AiMissionDialogueBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 8, Alignment = 4 )]
    public class AiMissionDialogueBlockBase : IGuerilla
    {
        internal MissionDialogueLinesBlock[] lines;

        internal AiMissionDialogueBlockBase( BinaryReader binaryReader )
        {
            lines = Guerilla.ReadBlockArray<MissionDialogueLinesBlock>( binaryReader );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                nextAddress = Guerilla.WriteBlockArray<MissionDialogueLinesBlock>( binaryWriter, lines, nextAddress );
                return nextAddress;
            }
        }
    };
}