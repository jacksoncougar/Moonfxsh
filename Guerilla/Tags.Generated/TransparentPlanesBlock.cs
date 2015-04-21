// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class TransparentPlanesBlock : TransparentPlanesBlockBase
    {
        public TransparentPlanesBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 20, Alignment = 4 )]
    public class TransparentPlanesBlockBase : IGuerilla
    {
        internal short sectionIndex;
        internal short partIndex;
        internal OpenTK.Vector4 plane;

        internal TransparentPlanesBlockBase( BinaryReader binaryReader )
        {
            sectionIndex = binaryReader.ReadInt16( );
            partIndex = binaryReader.ReadInt16( );
            plane = binaryReader.ReadVector4( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( sectionIndex );
                binaryWriter.Write( partIndex );
                binaryWriter.Write( plane );
                return nextAddress;
            }
        }
    };
}