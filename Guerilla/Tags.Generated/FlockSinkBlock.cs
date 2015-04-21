// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class FlockSinkBlock : FlockSinkBlockBase
    {
        public FlockSinkBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 16, Alignment = 4 )]
    public class FlockSinkBlockBase : IGuerilla
    {
        internal OpenTK.Vector3 position;
        internal float radius;

        internal FlockSinkBlockBase( BinaryReader binaryReader )
        {
            position = binaryReader.ReadVector3( );
            radius = binaryReader.ReadSingle( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( position );
                binaryWriter.Write( radius );
                return nextAddress;
            }
        }
    };
}