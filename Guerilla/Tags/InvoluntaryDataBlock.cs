// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class InvoluntaryDataBlock : InvoluntaryDataBlockBase
    {
        public InvoluntaryDataBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 4, Alignment = 4 )]
    public class InvoluntaryDataBlockBase : IGuerilla
    {
        internal short involuntaryVocalizationIndex;
        internal byte[] invalidName_;

        internal InvoluntaryDataBlockBase( BinaryReader binaryReader )
        {
            involuntaryVocalizationIndex = binaryReader.ReadInt16( );
            invalidName_ = binaryReader.ReadBytes( 2 );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( involuntaryVocalizationIndex );
                binaryWriter.Write( invalidName_, 0, 2 );
                return nextAddress;
            }
        }
    };
}