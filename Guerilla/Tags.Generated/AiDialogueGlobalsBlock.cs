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
        public static readonly TagClass Adlg = ( TagClass ) "adlg";
    };
} ;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute( "adlg" )]
    public partial class AiDialogueGlobalsBlock : AiDialogueGlobalsBlockBase
    {
        public AiDialogueGlobalsBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 44, Alignment = 4 )]
    public class AiDialogueGlobalsBlockBase : IGuerilla
    {
        internal VocalizationDefinitionsBlock0[] vocalizations;
        internal VocalizationPatternsBlock[] patterns;
        internal byte[] invalidName_;
        internal DialogueDataBlock[] dialogueData;
        internal InvoluntaryDataBlock[] involuntaryData;

        internal AiDialogueGlobalsBlockBase( BinaryReader binaryReader )
        {
            vocalizations = Guerilla.ReadBlockArray<VocalizationDefinitionsBlock0>( binaryReader );
            patterns = Guerilla.ReadBlockArray<VocalizationPatternsBlock>( binaryReader );
            invalidName_ = binaryReader.ReadBytes( 12 );
            dialogueData = Guerilla.ReadBlockArray<DialogueDataBlock>( binaryReader );
            involuntaryData = Guerilla.ReadBlockArray<InvoluntaryDataBlock>( binaryReader );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                nextAddress = Guerilla.WriteBlockArray<VocalizationDefinitionsBlock0>( binaryWriter, vocalizations,
                    nextAddress );
                nextAddress = Guerilla.WriteBlockArray<VocalizationPatternsBlock>( binaryWriter, patterns, nextAddress );
                binaryWriter.Write( invalidName_, 0, 12 );
                nextAddress = Guerilla.WriteBlockArray<DialogueDataBlock>( binaryWriter, dialogueData, nextAddress );
                nextAddress = Guerilla.WriteBlockArray<InvoluntaryDataBlock>( binaryWriter, involuntaryData, nextAddress );
                return nextAddress;
            }
        }
    };
}