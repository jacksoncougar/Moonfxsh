// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioClusterAtmosphericFogPropertiesBlock : ScenarioClusterAtmosphericFogPropertiesBlockBase
    {
        public ScenarioClusterAtmosphericFogPropertiesBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 4, Alignment = 4 )]
    public class ScenarioClusterAtmosphericFogPropertiesBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.ShortBlockIndex1 type;
        internal byte[] invalidName_;

        public override int SerializedSize
        {
            get { return 4; }
        }

        internal ScenarioClusterAtmosphericFogPropertiesBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            type = binaryReader.ReadShortBlockIndex1( );
            invalidName_ = binaryReader.ReadBytes( 2 );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( type );
                binaryWriter.Write( invalidName_, 0, 2 );
                return nextAddress;
            }
        }
    };
}