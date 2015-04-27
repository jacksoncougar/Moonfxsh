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
    public class UnitLipsyncScalesStructBlockBase : GuerillaBlock
    {
        internal float attackWeight;
        internal float decayWeight;

        public override int SerializedSize
        {
            get { return 8; }
        }

        internal UnitLipsyncScalesStructBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            attackWeight = binaryReader.ReadSingle( );
            decayWeight = binaryReader.ReadSingle( );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
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