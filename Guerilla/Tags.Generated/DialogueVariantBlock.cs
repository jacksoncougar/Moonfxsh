// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class DialogueVariantBlock : DialogueVariantBlockBase
    {
        public DialogueVariantBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 12, Alignment = 4 )]
    public class DialogueVariantBlockBase : IGuerilla
    {
        /// <summary>
        /// variantNumber to use this dialogue with (must match the suffix in the permutations on the unit's model)
        /// </summary>
        internal short variantNumber;

        internal byte[] invalidName_;
        [TagReference( "udlg" )] internal Moonfish.Tags.TagReference dialogue;

        internal DialogueVariantBlockBase( BinaryReader binaryReader )
        {
            variantNumber = binaryReader.ReadInt16( );
            invalidName_ = binaryReader.ReadBytes( 2 );
            dialogue = binaryReader.ReadTagReference( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( variantNumber );
                binaryWriter.Write( invalidName_, 0, 2 );
                binaryWriter.Write( dialogue );
                return nextAddress;
            }
        }
    };
}