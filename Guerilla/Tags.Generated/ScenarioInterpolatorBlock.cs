// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioInterpolatorBlock : ScenarioInterpolatorBlockBase
    {
        public ScenarioInterpolatorBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 24, Alignment = 4 )]
    public class ScenarioInterpolatorBlockBase : IGuerilla
    {
        internal Moonfish.Tags.StringID name;
        internal Moonfish.Tags.StringID acceleratorNameInterpolator;
        internal Moonfish.Tags.StringID multiplierNameInterpolator;
        internal ScalarFunctionStructBlock function;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;

        internal ScenarioInterpolatorBlockBase( BinaryReader binaryReader )
        {
            name = binaryReader.ReadStringID( );
            acceleratorNameInterpolator = binaryReader.ReadStringID( );
            multiplierNameInterpolator = binaryReader.ReadStringID( );
            function = new ScalarFunctionStructBlock( binaryReader );
            invalidName_ = binaryReader.ReadBytes( 2 );
            invalidName_0 = binaryReader.ReadBytes( 2 );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( name );
                binaryWriter.Write( acceleratorNameInterpolator );
                binaryWriter.Write( multiplierNameInterpolator );
                function.Write( binaryWriter );
                binaryWriter.Write( invalidName_, 0, 2 );
                binaryWriter.Write( invalidName_0, 0, 2 );
                return nextAddress;
            }
        }
    };
}