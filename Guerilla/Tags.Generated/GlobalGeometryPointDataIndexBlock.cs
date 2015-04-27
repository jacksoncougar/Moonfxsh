// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class GlobalGeometryPointDataIndexBlock : GlobalGeometryPointDataIndexBlockBase
    {
        public GlobalGeometryPointDataIndexBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 2, Alignment = 4 )]
    public class GlobalGeometryPointDataIndexBlockBase : GuerillaBlock
    {
        internal short index;

        public override int SerializedSize
        {
            get { return 2; }
        }

        internal GlobalGeometryPointDataIndexBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            index = binaryReader.ReadInt16( );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( index );
                return nextAddress;
            }
        }
    };
}