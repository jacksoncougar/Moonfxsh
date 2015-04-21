// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class AiScriptReferenceBlock : AiScriptReferenceBlockBase
    {
        public AiScriptReferenceBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 40, Alignment = 4 )]
    public class AiScriptReferenceBlockBase : IGuerilla
    {
        internal Moonfish.Tags.String32 scriptName;
        internal byte[] invalidName_;

        internal AiScriptReferenceBlockBase( BinaryReader binaryReader )
        {
            scriptName = binaryReader.ReadString32( );
            invalidName_ = binaryReader.ReadBytes( 8 );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( scriptName );
                binaryWriter.Write( invalidName_, 0, 8 );
                return nextAddress;
            }
        }
    };
}