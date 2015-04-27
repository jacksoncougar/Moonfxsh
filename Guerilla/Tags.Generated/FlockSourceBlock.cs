// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class FlockSourceBlock : FlockSourceBlockBase
    {
        public FlockSourceBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 28, Alignment = 4 )]
    public class FlockSourceBlockBase : GuerillaBlock
    {
        internal OpenTK.Vector3 position;
        internal OpenTK.Vector2 startingYawPitchDegrees;
        internal float radius;

        /// <summary>
        /// probability of producing at this source
        /// </summary>
        internal float weight;

        public override int SerializedSize
        {
            get { return 28; }
        }

        internal FlockSourceBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            position = binaryReader.ReadVector3( );
            startingYawPitchDegrees = binaryReader.ReadVector2( );
            radius = binaryReader.ReadSingle( );
            weight = binaryReader.ReadSingle( );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( position );
                binaryWriter.Write( startingYawPitchDegrees );
                binaryWriter.Write( radius );
                binaryWriter.Write( weight );
                return nextAddress;
            }
        }
    };
}