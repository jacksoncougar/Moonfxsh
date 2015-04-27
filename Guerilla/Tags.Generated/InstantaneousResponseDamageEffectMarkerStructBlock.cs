// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class InstantaneousResponseDamageEffectMarkerStructBlock :
        InstantaneousResponseDamageEffectMarkerStructBlockBase
    {
        public InstantaneousResponseDamageEffectMarkerStructBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 4, Alignment = 4 )]
    public class InstantaneousResponseDamageEffectMarkerStructBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringID damageEffectMarkerName;

        public override int SerializedSize
        {
            get { return 4; }
        }

        internal InstantaneousResponseDamageEffectMarkerStructBlockBase( BinaryReader binaryReader )
            : base( binaryReader )
        {
            damageEffectMarkerName = binaryReader.ReadStringID( );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( damageEffectMarkerName );
                return nextAddress;
            }
        }
    };
}