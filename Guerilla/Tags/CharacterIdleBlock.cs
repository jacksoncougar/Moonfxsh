// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class CharacterIdleBlock : CharacterIdleBlockBase
    {
        public CharacterIdleBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 12, Alignment = 4 )]
    public class CharacterIdleBlockBase : IGuerilla
    {
        internal byte[] invalidName_;

        /// <summary>
        /// time range for delays between idle poses
        /// </summary>
        internal Moonfish.Model.Range idlePoseDelayTimeSeconds;

        internal CharacterIdleBlockBase( BinaryReader binaryReader )
        {
            invalidName_ = binaryReader.ReadBytes( 4 );
            idlePoseDelayTimeSeconds = binaryReader.ReadRange( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( invalidName_, 0, 4 );
                binaryWriter.Write( idlePoseDelayTimeSeconds );
                return nextAddress;
            }
        }
    };
}