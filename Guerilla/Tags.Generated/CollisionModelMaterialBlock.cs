// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class CollisionModelMaterialBlock : CollisionModelMaterialBlockBase
    {
        public CollisionModelMaterialBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 4, Alignment = 4 )]
    public class CollisionModelMaterialBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringID name;

        public override int SerializedSize
        {
            get { return 4; }
        }

        internal CollisionModelMaterialBlockBase( BinaryReader binaryReader ) : base( binaryReader )
        {
            name = binaryReader.ReadStringID( );
        }

        public override int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( name );
                return nextAddress;
            }
        }
    };
}