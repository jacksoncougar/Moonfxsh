// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioChildScenarioBlock : ScenarioChildScenarioBlockBase
    {
        public ScenarioChildScenarioBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 24, Alignment = 4 )]
    public class ScenarioChildScenarioBlockBase : GuerillaBlock
    {
        [TagReference( "scnr" )] internal Moonfish.Tags.TagReference childScenario;
        internal byte[] invalidName_;

        public override int SerializedSize
        {
            get { return 24; }
        }

        internal ScenarioChildScenarioBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            childScenario = binaryReader.ReadTagReference( );
            invalidName_ = binaryReader.ReadBytes( 16 );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( childScenario );
                binaryWriter.Write( invalidName_, 0, 16 );
                return nextAddress;
            }
        }
    };
}