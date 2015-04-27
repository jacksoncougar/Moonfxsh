// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class StiffSpringConstraintsBlock : StiffSpringConstraintsBlockBase
    {
        public StiffSpringConstraintsBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 124, Alignment = 4 )]
    public class StiffSpringConstraintsBlockBase : GuerillaBlock
    {
        internal ConstraintBodiesStructBlock constraintBodies;
        internal byte[] invalidName_;
        internal float springLength;

        public override int SerializedSize
        {
            get { return 124; }
        }

        internal StiffSpringConstraintsBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            constraintBodies = new ConstraintBodiesStructBlock( binaryReader );
            invalidName_ = binaryReader.ReadBytes( 4 );
            springLength = binaryReader.ReadSingle( );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                constraintBodies.Write( binaryWriter );
                binaryWriter.Write( invalidName_, 0, 4 );
                binaryWriter.Write( springLength );
                return nextAddress;
            }
        }
    };
}