// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class GlobalZReferenceVectorBlock : GlobalZReferenceVectorBlockBase
    {
        public GlobalZReferenceVectorBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 16, Alignment = 4 )]
    public class GlobalZReferenceVectorBlockBase : IGuerilla
    {
        internal float invalidName_;
        internal float invalidName_0;
        internal float invalidName_1;
        internal float invalidName_2;

        internal GlobalZReferenceVectorBlockBase( BinaryReader binaryReader )
        {
            invalidName_ = binaryReader.ReadSingle( );
            invalidName_0 = binaryReader.ReadSingle( );
            invalidName_1 = binaryReader.ReadSingle( );
            invalidName_2 = binaryReader.ReadSingle( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( invalidName_ );
                binaryWriter.Write( invalidName_0 );
                binaryWriter.Write( invalidName_1 );
                binaryWriter.Write( invalidName_2 );
                return nextAddress;
            }
        }
    };
}