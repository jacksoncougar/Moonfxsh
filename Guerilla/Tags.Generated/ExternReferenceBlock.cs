// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ExternReferenceBlock : ExternReferenceBlockBase
    {
        public ExternReferenceBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 2, Alignment = 4 )]
    public class ExternReferenceBlockBase : IGuerilla
    {
        internal byte parameterIndex;
        internal byte externIndex;

        internal ExternReferenceBlockBase( BinaryReader binaryReader )
        {
            parameterIndex = binaryReader.ReadByte( );
            externIndex = binaryReader.ReadByte( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( parameterIndex );
                binaryWriter.Write( externIndex );
                return nextAddress;
            }
        }
    };
}