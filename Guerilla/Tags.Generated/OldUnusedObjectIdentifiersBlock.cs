// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class OldUnusedObjectIdentifiersBlock : OldUnusedObjectIdentifiersBlockBase
    {
        public OldUnusedObjectIdentifiersBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 8, Alignment = 4 )]
    public class OldUnusedObjectIdentifiersBlockBase : IGuerilla
    {
        internal ScenarioObjectIdStructBlock objectID;

        internal OldUnusedObjectIdentifiersBlockBase( BinaryReader binaryReader )
        {
            objectID = new ScenarioObjectIdStructBlock( binaryReader );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                objectID.Write( binaryWriter );
                return nextAddress;
            }
        }
    };
}