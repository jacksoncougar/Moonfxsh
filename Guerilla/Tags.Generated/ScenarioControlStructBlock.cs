// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioControlStructBlock : ScenarioControlStructBlockBase
    {
        public ScenarioControlStructBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 8, Alignment = 4 )]
    public class ScenarioControlStructBlockBase : GuerillaBlock
    {
        internal Flags flags;
        internal short dONTTOUCHTHIS;
        internal byte[] invalidName_;

        public override int SerializedSize
        {
            get { return 8; }
        }

        internal ScenarioControlStructBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            flags = ( Flags ) binaryReader.ReadInt32( );
            dONTTOUCHTHIS = binaryReader.ReadInt16( );
            invalidName_ = binaryReader.ReadBytes( 2 );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( ( Int32 ) flags );
                binaryWriter.Write( dONTTOUCHTHIS );
                binaryWriter.Write( invalidName_, 0, 2 );
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum Flags : int
        {
            UsableFromBothSides = 1,
        };
    };
}