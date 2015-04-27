// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class GlobalScenarioLoadParametersBlock : GlobalScenarioLoadParametersBlockBase
    {
        public GlobalScenarioLoadParametersBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 48, Alignment = 4 )]
    public class GlobalScenarioLoadParametersBlockBase : GuerillaBlock
    {
        [TagReference( "scnr" )] internal Moonfish.Tags.TagReference scenario;
        internal byte[] parameters;
        internal byte[] invalidName_;

        public override int SerializedSize
        {
            get { return 48; }
        }

        internal GlobalScenarioLoadParametersBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            scenario = binaryReader.ReadTagReference( );
            parameters = Guerilla.ReadData( binaryReader );
            invalidName_ = binaryReader.ReadBytes( 32 );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( scenario );
                nextAddress = Guerilla.WriteData( binaryWriter, parameters, nextAddress );
                binaryWriter.Write( invalidName_, 0, 32 );
                return nextAddress;
            }
        }
    };
}