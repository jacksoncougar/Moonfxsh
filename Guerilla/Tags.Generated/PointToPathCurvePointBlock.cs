// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class PointToPathCurvePointBlock : PointToPathCurvePointBlockBase
    {
        public PointToPathCurvePointBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 16, Alignment = 4 )]
    public class PointToPathCurvePointBlockBase : GuerillaBlock
    {
        internal OpenTK.Vector3 position;
        internal float tValue;

        public override int SerializedSize
        {
            get { return 16; }
        }

        internal PointToPathCurvePointBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            position = binaryReader.ReadVector3( );
            tValue = binaryReader.ReadSingle( );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( position );
                binaryWriter.Write( tValue );
                return nextAddress;
            }
        }
    };
}