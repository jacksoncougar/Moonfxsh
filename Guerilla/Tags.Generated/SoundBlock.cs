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
        public static readonly TagClass Snd = ( TagClass ) "snd!";
    };
} ;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute( "snd!" )]
    public partial class SoundBlock : SoundBlockBase
    {
        public SoundBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 20, Alignment = 4 )]
    public class SoundBlockBase : IGuerilla
    {
        internal byte[] soundFields;

        internal SoundBlockBase( BinaryReader binaryReader )
        {
            soundFields = binaryReader.ReadBytes( 20 );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( soundFields, 0, 20 );
                return nextAddress;
            }
        }
    };
}