// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class AngularVelocityLowerBoundStructBlock : AngularVelocityLowerBoundStructBlockBase
    {
        public AngularVelocityLowerBoundStructBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 4, Alignment = 4 )]
    public class AngularVelocityLowerBoundStructBlockBase : GuerillaBlock
    {
        internal float guidedAngularVelocityLowerDegreesPerSecond;

        public override int SerializedSize
        {
            get { return 4; }
        }

        internal AngularVelocityLowerBoundStructBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            guidedAngularVelocityLowerDegreesPerSecond = binaryReader.ReadSingle( );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( guidedAngularVelocityLowerDegreesPerSecond );
                return nextAddress;
            }
        }
    };
}