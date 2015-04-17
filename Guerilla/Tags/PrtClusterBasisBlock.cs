// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class PrtClusterBasisBlock : PrtClusterBasisBlockBase
    {
        public PrtClusterBasisBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 4, Alignment = 4 )]
    public class PrtClusterBasisBlockBase : IGuerilla
    {
        internal float basisData;

        internal PrtClusterBasisBlockBase( BinaryReader binaryReader )
        {
            basisData = binaryReader.ReadSingle( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( basisData );
                return nextAddress;
            }
        }
    };
}