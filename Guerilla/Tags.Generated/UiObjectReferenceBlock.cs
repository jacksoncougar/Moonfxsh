// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class UiObjectReferenceBlock : UiObjectReferenceBlockBase
    {
        public UiObjectReferenceBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 32, Alignment = 4 )]
    public class UiObjectReferenceBlockBase : IGuerilla
    {
        internal Moonfish.Tags.String32 name;

        internal UiObjectReferenceBlockBase( BinaryReader binaryReader )
        {
            name = binaryReader.ReadString32( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( name );
                return nextAddress;
            }
        }
    };
}