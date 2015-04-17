// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class HavokCleanupResourcesBlock : HavokCleanupResourcesBlockBase
    {
        public HavokCleanupResourcesBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 8, Alignment = 4 )]
    public class HavokCleanupResourcesBlockBase : IGuerilla
    {
        [TagReference( "effe" )] internal Moonfish.Tags.TagReference objectCleanupEffect;

        internal HavokCleanupResourcesBlockBase( BinaryReader binaryReader )
        {
            objectCleanupEffect = binaryReader.ReadTagReference( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( objectCleanupEffect );
                return nextAddress;
            }
        }
    };
}