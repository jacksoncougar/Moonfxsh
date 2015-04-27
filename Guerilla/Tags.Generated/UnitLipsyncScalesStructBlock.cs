// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class UnitLipsyncScalesStructBlock : UnitLipsyncScalesStructBlockBase
    {
        public UnitLipsyncScalesStructBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 8, Alignment = 4 )]
    public class UnitLipsyncScalesStructBlockBase : IGuerilla
    {
        internal float attackWeight;
        internal float decayWeight;

        internal UnitLipsyncScalesStructBlockBase( BinaryReader binaryReader )
        {
            attackWeight = binaryReader.ReadSingle( );
            decayWeight = binaryReader.ReadSingle( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( attackWeight );
                binaryWriter.Write( decayWeight );
                return nextAddress;
            }
        }
    };
}