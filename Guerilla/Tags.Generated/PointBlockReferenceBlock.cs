// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class PointBlockReferenceBlock : PointBlockReferenceBlockBase
    {
        public PointBlockReferenceBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 4, Alignment = 4 )]
    public class PointBlockReferenceBlockBase : IGuerilla
    {
        internal Moonfish.Tags.Point coordinates;

        internal PointBlockReferenceBlockBase( BinaryReader binaryReader )
        {
            coordinates = binaryReader.ReadPoint( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( coordinates );
                return nextAddress;
            }
        }
    };
}