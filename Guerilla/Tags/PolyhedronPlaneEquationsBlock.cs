// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class PolyhedronPlaneEquationsBlock : PolyhedronPlaneEquationsBlockBase
    {
        public PolyhedronPlaneEquationsBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 16, Alignment = 16 )]
    public class PolyhedronPlaneEquationsBlockBase : IGuerilla
    {
        internal byte[] invalidName_;

        internal PolyhedronPlaneEquationsBlockBase( BinaryReader binaryReader )
        {
            invalidName_ = binaryReader.ReadBytes( 16 );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( invalidName_, 0, 16 );
                return nextAddress;
            }
        }
    };
}