// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class PredictedBitmapsBlock : PredictedBitmapsBlockBase
    {
        public PredictedBitmapsBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 8, Alignment = 4 )]
    public class PredictedBitmapsBlockBase : IGuerilla
    {
        [TagReference( "bitm" )] internal Moonfish.Tags.TagReference bitmap;

        internal PredictedBitmapsBlockBase( BinaryReader binaryReader )
        {
            bitmap = binaryReader.ReadTagReference( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( bitmap );
                return nextAddress;
            }
        }
    };
}