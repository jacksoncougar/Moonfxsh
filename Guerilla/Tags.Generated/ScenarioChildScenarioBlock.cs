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
    public class ScenarioChildScenarioBlockBase : IGuerilla
    {
        [TagReference( "scnr" )] internal Moonfish.Tags.TagReference childScenario;
        internal byte[] invalidName_;

        internal ScenarioChildScenarioBlockBase( BinaryReader binaryReader )
        {
            childScenario = binaryReader.ReadTagReference( );
            invalidName_ = binaryReader.ReadBytes( 16 );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
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