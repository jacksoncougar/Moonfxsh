// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class EnvironmentObjectBspRefs : EnvironmentObjectBspRefsBase
    {
        public EnvironmentObjectBspRefs( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 16, Alignment = 4 )]
    public class EnvironmentObjectBspRefsBase : IGuerilla
    {
        internal int bspReference;
        internal int firstSector;
        internal int lastSector;
        internal short nodeIndex;
        internal byte[] invalidName_;

        internal EnvironmentObjectBspRefsBase( BinaryReader binaryReader )
        {
            bspReference = binaryReader.ReadInt32( );
            firstSector = binaryReader.ReadInt32( );
            lastSector = binaryReader.ReadInt32( );
            nodeIndex = binaryReader.ReadInt16( );
            invalidName_ = binaryReader.ReadBytes( 2 );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( bspReference );
                binaryWriter.Write( firstSector );
                binaryWriter.Write( lastSector );
                binaryWriter.Write( nodeIndex );
                binaryWriter.Write( invalidName_, 0, 2 );
                return nextAddress;
            }
        }
    };
}