// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class StructureBspWeatherPolyhedronPlaneBlock : StructureBspWeatherPolyhedronPlaneBlockBase
    {
        public StructureBspWeatherPolyhedronPlaneBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 16, Alignment = 4 )]
    public class StructureBspWeatherPolyhedronPlaneBlockBase : IGuerilla
    {
        internal OpenTK.Vector4 plane;

        internal StructureBspWeatherPolyhedronPlaneBlockBase( BinaryReader binaryReader )
        {
            plane = binaryReader.ReadVector4( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( plane );
                return nextAddress;
            }
        }
    };
}