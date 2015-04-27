// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class RagdollConstraintsBlock : RagdollConstraintsBlockBase
    {
        public RagdollConstraintsBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 148, Alignment = 4 )]
    public class RagdollConstraintsBlockBase : GuerillaBlock
    {
        internal ConstraintBodiesStructBlock constraintBodies;
        internal byte[] invalidName_;
        internal float minTwist;
        internal float maxTwist;
        internal float minCone;
        internal float maxCone;
        internal float minPlane;
        internal float maxPlane;
        internal float maxFricitonTorque;

        public override int SerializedSize
        {
            get { return 148; }
        }

        internal RagdollConstraintsBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            constraintBodies = new ConstraintBodiesStructBlock( binaryReader );
            invalidName_ = binaryReader.ReadBytes( 4 );
            minTwist = binaryReader.ReadSingle( );
            maxTwist = binaryReader.ReadSingle( );
            minCone = binaryReader.ReadSingle( );
            maxCone = binaryReader.ReadSingle( );
            minPlane = binaryReader.ReadSingle( );
            maxPlane = binaryReader.ReadSingle( );
            maxFricitonTorque = binaryReader.ReadSingle( );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                constraintBodies.Write( binaryWriter );
                binaryWriter.Write( invalidName_, 0, 4 );
                binaryWriter.Write( minTwist );
                binaryWriter.Write( maxTwist );
                binaryWriter.Write( minCone );
                binaryWriter.Write( maxCone );
                binaryWriter.Write( minPlane );
                binaryWriter.Write( maxPlane );
                binaryWriter.Write( maxFricitonTorque );
                return nextAddress;
            }
        }
    };
}