// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class InertialMatrixBlock : InertialMatrixBlockBase
    {
        public InertialMatrixBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 36, Alignment = 4 )]
    public class InertialMatrixBlockBase : GuerillaBlock
    {
        internal OpenTK.Vector3 yyZzXyZx;
        internal OpenTK.Vector3 xyZzXxYz;
        internal OpenTK.Vector3 zxYzXxYy;

        public override int SerializedSize
        {
            get { return 36; }
        }

        internal InertialMatrixBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            yyZzXyZx = binaryReader.ReadVector3( );
            xyZzXxYz = binaryReader.ReadVector3( );
            zxYzXxYy = binaryReader.ReadVector3( );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( yyZzXyZx );
                binaryWriter.Write( xyZzXxYz );
                binaryWriter.Write( zxYzXxYy );
                return nextAddress;
            }
        }
    };
}