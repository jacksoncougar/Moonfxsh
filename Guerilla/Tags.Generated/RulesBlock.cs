// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class RulesBlock : RulesBlockBase
    {
        public RulesBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 84, Alignment = 4 )]
    public class RulesBlockBase : IGuerilla
    {
        internal Moonfish.Tags.String32 name;
        internal Moonfish.Tags.ColorR8G8B8 tintColor;
        internal byte[] invalidName_;
        internal StatesBlock[] states;

        internal RulesBlockBase( BinaryReader binaryReader )
        {
            name = binaryReader.ReadString32( );
            tintColor = binaryReader.ReadColorR8G8B8( );
            invalidName_ = binaryReader.ReadBytes( 32 );
            states = Guerilla.ReadBlockArray<StatesBlock>( binaryReader );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( name );
                binaryWriter.Write( tintColor );
                binaryWriter.Write( invalidName_, 0, 32 );
                nextAddress = Guerilla.WriteBlockArray<StatesBlock>( binaryWriter, states, nextAddress );
                return nextAddress;
            }
        }
    };
}