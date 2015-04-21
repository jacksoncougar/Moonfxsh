// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class PlanesBlock : PlanesBlockBase
    {
        public PlanesBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 16, Alignment = 16 )]
    public class PlanesBlockBase : IGuerilla
    {
        internal OpenTK.Vector4 plane;

        internal PlanesBlockBase( BinaryReader binaryReader )
        {
            plane = binaryReader.ReadVector4( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( plane );
                return nextAddress;
            }
        }
    };
}