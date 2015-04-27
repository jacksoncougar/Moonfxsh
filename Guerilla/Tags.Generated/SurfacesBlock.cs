// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class SurfacesBlock : SurfacesBlockBase
    {
        public SurfacesBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 8, Alignment = 8 )]
    public class SurfacesBlockBase : IGuerilla
    {
        internal short plane;
        internal short firstEdge;
        internal Flags flags;
        internal byte breakableSurface;
        internal short material;

        internal SurfacesBlockBase( BinaryReader binaryReader )
        {
            plane = binaryReader.ReadInt16( );
            firstEdge = binaryReader.ReadInt16( );
            flags = ( Flags ) binaryReader.ReadByte( );
            breakableSurface = binaryReader.ReadByte( );
            material = binaryReader.ReadInt16( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( plane );
                binaryWriter.Write( firstEdge );
                binaryWriter.Write( ( Byte ) flags );
                binaryWriter.Write( breakableSurface );
                binaryWriter.Write( material );
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum Flags : byte
        {
            TwoSided = 1,
            Invisible = 2,
            Climbable = 4,
            Breakable = 8,
            Invalid = 16,
            Conveyor = 32,
        };
    };
}